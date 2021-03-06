#region Usings

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Genie.Core.Base.Configuration.Abstract;
using Genie.Core.Base.Exceptions;
using Genie.Core.Base.Reading.Abstract;
using Genie.Core.Base.Reading.Concrete.Models;
using Genie.Core.Extensions;
using Genie.Core.Models.Abstract;
using Genie.Core.Models.Concrete;
using Genie.Core.Tools;
using Attribute = Genie.Core.Models.Concrete.Attribute;
using Enum = Genie.Core.Models.Concrete.Enum;

#endregion

namespace Genie.Core.Base.Reading.Concrete
{
    /// <summary>
    ///     Base class for Sql schema reader implementations
    ///     Written while listening to Kasun Kalhara and Indrachapa :)
    /// </summary>
    internal abstract class SqlSchemaReader
    {
        protected string QueryToGetExtendedProperties = "";
        protected string QueryToGetParameters = "";
        protected string QueryToReadColumns = "";

        public IDatabaseSchema Read(IConfiguration configuration)
        {
            Setup(configuration);
            DatabaseSchema schema;
            try
            {
                schema = ReadDatabase(configuration.ConnectionString);
                schema.BaseNamespace = configuration.BaseNamespace;
            }
            catch (Exception e)
            {
                throw new GenieException("Unable to fetch database schema", e);
            }

            ProcessRelationships(schema.Relations);

            if (configuration.Enums != null && configuration.Enums.Count > 0)
            {
                foreach (var e in configuration.Enums)
                    if (schema.Relations.All(r => r.Name != e.Table))
                        throw new GenieException($"{e.Table} is not a table. (Enums)");

                schema.Enums = ReadEnums(configuration.ConnectionString, configuration.Enums, configuration);
            }
            else
            {
                schema.Enums = new List<IEnum>();
            }

            return schema;
        }

        private DatabaseSchema ReadDatabase(string connectionString)
        {
            var databaseSchemaColumns = new List<DatabaseSchemaColumn>();
            var databaseParameters = new List<DatabaseParameter>();
            var databaseExtendedProperties = new List<ExtendedPropertyInfo>();

            using (var connection = GetConnection(connectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();

                var commandToGetColumns = GetCommand(QueryToReadColumns, connection, transaction);

                using (var reader = commandToGetColumns.ExecuteReader())
                {
                    while (reader.Read()) databaseSchemaColumns.Add(ReadColumn(reader));

                    var filtered = new List<DatabaseSchemaColumn>();
                    foreach (var databaseSchemaColumn in databaseSchemaColumns.Where(
                        databaseSchemaColumn => !filtered.Any(
                            f =>
                                f.TableName == databaseSchemaColumn.TableName && f.Name == databaseSchemaColumn.Name)))
                        filtered.Add(databaseSchemaColumn);

                    foreach (var databaseSchemaColumn in filtered)
                    {
                        var column = databaseSchemaColumn;
                        var nonFiltered =
                            databaseSchemaColumns.Where(
                                d =>
                                    d.TableName == column.TableName && d.Name == column.Name);

                        foreach (var schemaColumn in nonFiltered)
                        {
                            if (schemaColumn.IsForeignKey)
                            {
                                databaseSchemaColumn.IsForeignKey = true;
                                databaseSchemaColumn.ReferencedColumnName = schemaColumn.ReferencedColumnName;
                                databaseSchemaColumn.ReferencedTableName = schemaColumn.ReferencedTableName;
                            }

                            if (schemaColumn.IsPrimaryKey) databaseSchemaColumn.IsPrimaryKey = true;
                        }
                    }

                    databaseSchemaColumns = filtered;
                }

                var commandToGetParameters = GetCommand(
                    QueryToGetParameters, connection, transaction);

                using (var reader = commandToGetParameters.ExecuteReader())
                {
                    while (reader.Read()) databaseParameters.Add(ReadParameter(reader));
                }

                if (!string.IsNullOrWhiteSpace(QueryToGetExtendedProperties))
                {
                    var commandToGetExtendedProperties =
                        GetCommand(QueryToGetExtendedProperties, connection, transaction);
                    using (var reader = commandToGetExtendedProperties.ExecuteReader())
                    {
                        while (reader.Read()) databaseExtendedProperties.Add(ReadExtendedProperty(reader));
                    }
                }

                transaction.Commit();
                connection.Close();
            }

            return Process(databaseSchemaColumns, databaseParameters, databaseExtendedProperties);
        }


        private static void ProcessRelationships(IReadOnlyCollection<IRelation> relations)
        {
            try
            {
                /*
                 * for each r in relationship
                 *      if r has a foreign key to any other table
                 *          get the table from list
                 *              add a list to that table
                 * 
                 */

                foreach (var relation in relations)
                foreach (var foreignKeyAttribute in relation.ForeignKeyAttributes)
                {
                    var referencingRelation =
                        relations.FirstOrDefault(r => r.Name == foreignKeyAttribute.ReferencingRelationName);
                    referencingRelation?.ReferenceLists.Add(new ReferenceList
                    {
                        ReferencedPropertyName = foreignKeyAttribute.ReferencingNonForeignKeyAttribute.Name,
                        ReferencedPropertyOnThisRelation = foreignKeyAttribute.ReferencingTableColumnName,
                        ReferencedRelationName = relation.Name
                    });
                }
            }
            catch (Exception e)
            {
                throw new GenieException("Unable to process relationships of the tables", e);
            }
        }


        private DatabaseSchema Process(IReadOnlyCollection<DatabaseSchemaColumn> columns,
            IReadOnlyCollection<DatabaseParameter> parameters,
            IReadOnlyCollection<ExtendedPropertyInfo> extendedProperties)
        {
            if (columns == null || columns.Count < 1) return null;

            var tables = new List<IRelation>();
            var views = new List<IView>();
            var storedProcedures = new List<IStoredProcedure>();

            foreach (var databaseSchemaColumn in columns)
            {
                string dataType;
                bool lit;
                if (databaseSchemaColumn.Type == "BASE TABLE")
                {
                    var table = tables.FirstOrDefault(t => t.Name == databaseSchemaColumn.TableName);
                    if (table == null)
                    {
                        table = new Relation
                        {
                            Name = databaseSchemaColumn.TableName,
                            FieldName =
                                "_" + (databaseSchemaColumn.TableName.First() + "").ToLower() +
                                databaseSchemaColumn.TableName.Substring(1),
                            Attributes = new List<IAttribute>(),
                            ForeignKeyAttributes = new List<IForeignKeyAttribute>(),
                            ReferenceLists = new List<IReferenceList>(),
                            Comment = databaseSchemaColumn.TableComment
                        };

                        tables.Add(table);
                    }

                    dataType = CommonTools.GetCSharpDataType(databaseSchemaColumn.DataType,
                        databaseSchemaColumn.Nullable);
                    lit = dataType == "string" || dataType.StartsWith("DateTime");

                    var attribute = new Attribute
                    {
                        IsLiteralType = lit,
                        IsKey = databaseSchemaColumn.IsPrimaryKey,
                        Name = databaseSchemaColumn.Name,
                        DataType = dataType,
                        FieldName = "_" + (databaseSchemaColumn.Name.First() + "").ToLower() +
                                    databaseSchemaColumn.Name.Substring(1),
                        Comment = databaseSchemaColumn.Comment,
                        IsIdentity = databaseSchemaColumn.IsIdentity
                    };

                    if (databaseSchemaColumn.IsForeignKey)
                    {
                        var fkAttribute = new ForeignKeyAttribute
                        {
                            ReferencingNonForeignKeyAttribute = attribute,
                            ReferencingRelationName = databaseSchemaColumn.ReferencedTableName,
                            ReferencingTableColumnName = databaseSchemaColumn.ReferencedColumnName
                        };

                        attribute.RefPropName = attribute.FieldName + "Obj";
                        table.ForeignKeyAttributes.Add(fkAttribute);
                    }

                    var extendedProperty =
                        extendedProperties.FirstOrDefault(
                            e => e.ObjectName == table.Name && e.ColumnName == attribute.Name);
                    if (extendedProperty != null) attribute.Comment = extendedProperty.Property;

                    table.Attributes.Add(attribute);
                }
                else if (databaseSchemaColumn.Type == "VIEW")
                {
                    var view = views.FirstOrDefault(t => t.Name == databaseSchemaColumn.TableName);
                    if (view == null)
                    {
                        view = new View
                        {
                            Comment = databaseSchemaColumn.TableComment,
                            FieldName =
                                "_" + (databaseSchemaColumn.TableName.First() + "").ToLower() +
                                databaseSchemaColumn.TableName.Substring(1),
                            Name = databaseSchemaColumn.TableName,
                            Attributes = new List<ISimpleAttribute>()
                        };

                        views.Add(view);
                    }

                    dataType = CommonTools.GetCSharpDataType(databaseSchemaColumn.DataType,
                        databaseSchemaColumn.Nullable);
                    lit = dataType == "string" || dataType.StartsWith("DateTime");


                    var attr = new SimpleAttribute
                    {
                        Name = databaseSchemaColumn.Name,
                        IsLiteralType = lit,
                        FieldName = "_" + (databaseSchemaColumn.Name.First() + "").ToLower() +
                                    databaseSchemaColumn.Name.Substring(1),
                        DataType = dataType,
                        Comment = databaseSchemaColumn.Comment
                    };

                    var extendedProp =
                        extendedProperties.FirstOrDefault(
                            e => e.ObjectName == view.Name && e.ColumnName == attr.Name);
                    if (extendedProp != null) attr.Comment = extendedProp.Property;

                    view.Attributes.Add(attr);
                }
            }

            if (parameters != null && parameters.Count > 0)
            {
                foreach (var parameter in parameters)
                {
                    var procedure = storedProcedures.FirstOrDefault(p => p.Name == parameter.Procedure);
                    if (procedure == null)
                    {
                        procedure = new StoredProcedure
                        {
                            Name = parameter.Procedure,
                            Parameters = new List<ProcedureParameter>()
                        };
                        storedProcedures.Add(procedure);
                    }

                    procedure.Parameters.Add(
                        new ProcedureParameter
                        {
                            DataType = parameter.DataType,
                            Name = parameter.Name,
                            Position = parameter.Position
                        });
                }

                foreach (var storedProcedure in storedProcedures) ProcessProcedureParameters(storedProcedure);
            }

            return new DatabaseSchema {Procedures = storedProcedures, Relations = tables, Views = views};
        }

        private List<IEnum> ReadEnums(string connectionString, IEnumerable<IConfigurationEnumTable> enumTables,
            IConfiguration configuration)
        {
            using (var connection = GetConnection(connectionString))
            {
                connection.Open();
                var enums = new List<IEnum>();
                foreach (var configurationEnumTable in enumTables)
                {
                    var query = GetEnumValueQuery(configuration, configurationEnumTable);

                    var type = configurationEnumTable.Type;
                    var values = new List<IEnumValue>();

                    using (var command = GetCommand(query, connection, null))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name;
                                try
                                {
                                    name = reader.GetString(0);
                                    if (string.IsNullOrWhiteSpace(name))
                                        throw new GenieException("Name should not be empty of an enum");
                                }
                                catch (Exception)
                                {
                                    throw new GenieException(
                                        $"Cannot read Name as string. in the enum table {configurationEnumTable.Table}");
                                }

                                object value = null;
                                try
                                {
                                    switch (type)
                                    {
                                        case "string":
                                            value = $"\"{reader.GetString(1)}\"";
                                            break;
                                        case "int":
                                            value = reader.GetInt32(1);
                                            break;
                                        case "double":
                                            value = reader.GetDouble(1);
                                            break;
                                        case "bool":
                                            value = reader.GetBoolean(1);
                                            break;
                                    }
                                }
                                catch (Exception e)
                                {
                                    throw new GenieException("Unable to read enum table using specified value type.",
                                        e);
                                }

                                name = name.Replace(" ", "_");
                                values.Add(new EnumValue {Name = name, FieldName = name.ToFieldName(), Value = value});
                            }

                            enums.Add(new Enum
                            {
                                Name = configurationEnumTable.Table + "Enum",
                                Values = values,
                                Type = type
                            });
                        }
                    }
                }

                connection.Close();

                return enums;
            }
        }

        internal abstract void Setup(IConfiguration configuration);
        protected abstract IDbConnection GetConnection(string connectionString);
        protected abstract IDbCommand GetCommand(string query, IDbConnection connection, IDbTransaction transaction);
        protected abstract DatabaseSchemaColumn ReadColumn(IDataReader reader);
        protected abstract DatabaseParameter ReadParameter(IDataReader reader);
        protected abstract ExtendedPropertyInfo ReadExtendedProperty(IDataReader reader);
        protected abstract string GetEnumValueQuery(IConfiguration configuration, IConfigurationEnumTable enumTable);
        protected abstract void ProcessProcedureParameters(IStoredProcedure storedProcedure);
    }
}