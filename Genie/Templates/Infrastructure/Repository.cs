﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 14.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Genie.Templates.Infrastructure
{
    using Genie.Base;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "F:\Projects\Genie\Genie\Templates\Infrastructure\Repository.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class Repository : RepositoryBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("namespace ");
            
            #line 3 "F:\Projects\Genie\Genie\Templates\Infrastructure\Repository.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure\r\n{\r\n    public class Repository<T, TRepoQuery> : IRepository<T, T" +
                    "RepoQuery>\r\n        where T : BaseModel\r\n        where TRepoQuery : EnumBase<TRe" +
                    "poQuery, string>\r\n    {\r\n        public IDbConnection Conn { get; }\r\n        pub" +
                    "lic IDapperContext Context { get;}\r\n        public UnitOfWork UnitOfWork { get;}" +
                    "\r\n\r\n        public Repository(IDapperContext context, UnitOfWork unitOfWork)\r\n  " +
                    "      {\r\n            Context = context;\r\n            Conn = Context.Connection;\r" +
                    "\n            UnitOfWork = unitOfWork;\r\n        }\r\n\r\n        public virtual void " +
                    "Add(T entity, IDbTransaction transaction = null, int? commandTimeout = null)\r\n  " +
                    "      {\r\n            if (entity == null)\r\n            {\r\n                throw n" +
                    "ew ArgumentNullException(\"entity\", \"Add to DB null entity\");\r\n            }\r\n   " +
                    "         var insertedId = Conn.Insert(entity, transaction: transaction, commandT" +
                    "imeout: commandTimeout);\r\n            entity.DatabaseModelStatus = ModelStatus.R" +
                    "etrieved;\r\n            entity.DatabaseUnitOfWork = UnitOfWork;\r\n        }\r\n\r\n   " +
                    "     public virtual void Update(T entity, IDbTransaction transaction = null, int" +
                    "? commandTimeout = null)\r\n        {\r\n            if (entity == null)\r\n          " +
                    "  {\r\n                throw new ArgumentNullException(\"entity\", \"Update in DB nul" +
                    "l entity\");\r\n            }\r\n            Conn.Update(entity, transaction: transac" +
                    "tion, commandTimeout: commandTimeout);\r\n        }\r\n\r\n        public virtual void" +
                    " Remove(T entity, IDbTransaction transaction = null, int? commandTimeout = null)" +
                    "\r\n        {\r\n            if (entity == null)\r\n            {\r\n                thr" +
                    "ow new ArgumentNullException(\"entity\", \"Remove in DB null entity\");\r\n           " +
                    " }\r\n            var deleted = Conn.Delete(entity, transaction: transaction, comm" +
                    "andTimeout: commandTimeout);\r\n            if(deleted) { entity.DatabaseModelStat" +
                    "us = ModelStatus.Deleted; }\r\n        }\r\n\r\n        public virtual T GetByKey(obje" +
                    "ct id, IDbTransaction transaction = null, int? commandTimeout = null)\r\n        {" +
                    "\r\n            if (id == null)\r\n            {\r\n                throw new Argument" +
                    "NullException(\"id\");\r\n            }\r\n            var item = Conn.Get<T>(id, tran" +
                    "saction: transaction, commandTimeout: commandTimeout);\r\n            item.Databas" +
                    "eModelStatus = ModelStatus.Retrieved;\r\n            item.DatabaseUnitOfWork = Uni" +
                    "tOfWork;\r\n            return item;\r\n        }\r\n\r\n        public virtual IEnumera" +
                    "ble<T> GetAll(IDbTransaction transaction = null, int? commandTimeout = null)\r\n  " +
                    "      {\r\n            var items = Conn.GetAll<T>(transaction: transaction, comman" +
                    "dTimeout: commandTimeout).ToList();\r\n\r\n            foreach (var item in items) \r" +
                    "\n            {\r\n                item.DatabaseUnitOfWork = UnitOfWork;\r\n         " +
                    "       item.DatabaseModelStatus = ModelStatus.Retrieved;\r\n            }\r\n       " +
                    "     return items;\r\n        }\r\n\r\n        public virtual IEnumerable<T> GetBy(obj" +
                    "ect where = null, object order = null, IDbTransaction transaction = null, int? c" +
                    "ommandTimeout = null)\r\n        {\r\n            var items = Conn.GetBy<T>(where: w" +
                    "here, order: order, transaction: transaction, commandTimeout: commandTimeout).To" +
                    "List();\r\n\r\n            foreach (var item in items)\r\n            {\r\n             " +
                    "   item.DatabaseUnitOfWork = UnitOfWork;\r\n                item.DatabaseModelStat" +
                    "us = ModelStatus.Retrieved;\r\n            }\r\n            return items;\r\n        }" +
                    "\r\n\r\n        public IEnumerable<TSp> Exec<TSp>(TRepoQuery repoQuery, DynamicParam" +
                    "eters param = null, IDbTransaction transaction = null,\r\n                        " +
                    "                        int? commandTimeout = null)\r\n        {\r\n            retu" +
                    "rn Conn.Query<TSp>(repoQuery.Value, param, commandType: repoQuery.CmdType, trans" +
                    "action: transaction, commandTimeout: commandTimeout);\r\n        }\r\n\r\n        publ" +
                    "ic void Exec(TRepoQuery repoQuery, DynamicParameters param = null, IDbTransactio" +
                    "n transaction = null,\r\n                                    int? commandTimeout =" +
                    " null)\r\n        {\r\n            Conn.Execute(repoQuery.Value, param, commandType:" +
                    " repoQuery.CmdType, transaction: transaction, commandTimeout: commandTimeout);\r\n" +
                    "        }\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public class RepositoryBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
