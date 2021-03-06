﻿#region Usings

using System.Collections.Generic;
using Genie.Core.Models.Abstract;

#endregion

namespace Genie.Core.Models.Concrete
{
    public class Relation : IRelation
    {
        public string Name { get; set; }
        public List<IAttribute> Attributes { get; set; }
        public List<IForeignKeyAttribute> ForeignKeyAttributes { get; set; }
        public List<IReferenceList> ReferenceLists { get; set; }
        public string FieldName { get; set; }
        public string Comment { get; set; }

        public IEnumerable<ISimpleAttribute> GetAttributes()
        {
            return Attributes;
        }

        public string GetName()
        {
            return Name;
        }

        public IEnumerable<IForeignKeyAttribute> GetForeignKeyAttributes()
        {
            return ForeignKeyAttributes;
        }

        public IEnumerable<IReferenceList> GetReferenceLists()
        {
            return ReferenceLists;
        }
    }
}