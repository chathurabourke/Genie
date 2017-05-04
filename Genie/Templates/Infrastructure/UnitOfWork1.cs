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
    
    #line 1 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class UnitOfWork : UnitOfWorkBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Data;\r\nusing Syste" +
                    "m.Linq;\r\nusing ");
            
            #line 7 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Dapper;\r\nusing ");
            
            #line 8 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Interfaces;\r\nusing ");
            
            #line 9 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Models.Concrete;\r\nusing ");
            
            #line 10 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Repositories.Abstract;\r\nusing ");
            
            #line 11 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Repositories.Concrete;\r\n\r\nnamespace ");
            
            #line 13 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(@".Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
		private IProcedureContainer _procedureContainer;

        private readonly List<IOperation> _operations;
        private readonly HashSet<BaseModel> _objects;

        ");
            
            #line 22 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
foreach(var relation in _schema.Relations){
      
            
            #line default
            #line hidden
            this.Write("private I");
            
            #line 23 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relation.Name));
            
            #line default
            #line hidden
            this.Write("Repository ");
            
            #line 23 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relation.FieldName));
            
            #line default
            #line hidden
            this.Write("Repository;\r\n        ");
            
            #line 24 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
}
            
            #line default
            #line hidden
            this.Write("\r\n        ");
            
            #line 26 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
foreach(var view in _schema.Views){
      
            
            #line default
            #line hidden
            this.Write("private I");
            
            #line 27 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(view.Name));
            
            #line default
            #line hidden
            this.Write("Repository ");
            
            #line 27 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(view.FieldName));
            
            #line default
            #line hidden
            this.Write("Repository;\r\n        ");
            
            #line 28 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
}
            
            #line default
            #line hidden
            this.Write(@"
		public IProcedureContainer Procedures { get { return _procedureContainer ?? ( _procedureContainer = new ProcedureContainer(Context)); } }

        private IDapperContext Context { get;}
        private IDbTransaction Transaction { get; set; }

        public UnitOfWork(IDapperContext context)
        {
            Context = context;
            _objects = new HashSet<BaseModel>();
            _operations = new List<IOperation>();
        }
            
            
        ");
            
            #line 43 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
foreach(var relation in _schema.Relations){
      
            
            #line default
            #line hidden
            this.Write("public I");
            
            #line 44 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relation.Name));
            
            #line default
            #line hidden
            this.Write("Repository ");
            
            #line 44 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relation.Name));
            
            #line default
            #line hidden
            this.Write("Repository { get { return ");
            
            #line 44 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relation.FieldName));
            
            #line default
            #line hidden
            this.Write("Repository ?? (");
            
            #line 44 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relation.FieldName));
            
            #line default
            #line hidden
            this.Write("Repository = new ");
            
            #line 44 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relation.Name));
            
            #line default
            #line hidden
            this.Write("Repository(Context, this)); } }\r\n        ");
            
            #line 45 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
}
            
            #line default
            #line hidden
            this.Write("\r\n        ");
            
            #line 47 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
foreach(var view in _schema.Views){
      
            
            #line default
            #line hidden
            this.Write("public I");
            
            #line 48 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(view.Name));
            
            #line default
            #line hidden
            this.Write("Repository ");
            
            #line 48 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(view.Name));
            
            #line default
            #line hidden
            this.Write("Repository { get { return ");
            
            #line 48 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(view.FieldName));
            
            #line default
            #line hidden
            this.Write("Repository ?? (");
            
            #line 48 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(view.FieldName));
            
            #line default
            #line hidden
            this.Write("Repository = new ");
            
            #line 48 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(view.Name));
            
            #line default
            #line hidden
            this.Write("Repository(Context)); } }\r\n        ");
            
            #line 49 "D:\Projects\Genie\Genie\Templates\Infrastructure\UnitOfWork.tt"
}
            
            #line default
            #line hidden
            this.Write("            \r\n        public IDbTransaction BeginTransaction()\r\n        {\r\n      " +
                    "      if (Transaction != null)\r\n            {\r\n                throw new NullRef" +
                    "erenceException(\"Not finished previous transaction\");\r\n            }\r\n          " +
                    "  Transaction = Context.Connection.BeginTransaction();\r\n            return Trans" +
                    "action;\r\n        }\r\n\r\n\r\n        public void Commit()\r\n        {\r\n            var" +
                    " updated = _objects.Where(o => o.UpdatedProperties != null && o.UpdatedPropertie" +
                    "s.Count > 0).ToList();\r\n\r\n            try\r\n            {\r\n                if (up" +
                    "dated.Count > 0)\r\n                    _operations.AddRange(updated.Select(u => n" +
                    "ew Operation(OperationType.Update, u)));\r\n\r\n                if (_operations.Coun" +
                    "t > 0)\r\n                {\r\n                    var toAdd = _operations.Where(o =" +
                    "> o.Type == OperationType.Add).ToList();\r\n                    var toDelete = _op" +
                    "erations.Where(o => o.Type == OperationType.Remove).ToList();\r\n                 " +
                    "   var toUpdate = _operations.Where(o => o.Type == OperationType.Update).ToList(" +
                    ");\r\n\r\n                    var connection = Context.Connection;\r\n\t\t\t\t\tif (toAdd.C" +
                    "ount > 0)\r\n\t\t\t\t\t{\r\n                        foreach (var operation in toAdd)\r\n   " +
                    "                     {\r\n                            var newId = connection.Inser" +
                    "t(operation.Object);\r\n                            operation.Object.SetId((int)ne" +
                    "wId);\r\n                            operation.Object.DatabaseModelStatus = ModelS" +
                    "tatus.Retrieved;\r\n                            if (operation.Object.ActionsToRunW" +
                    "henAdding != null && operation.Object.ActionsToRunWhenAdding.Count > 0)\r\n       " +
                    "                     {\r\n                                foreach (var addAction i" +
                    "n operation.Object.ActionsToRunWhenAdding)\r\n                                    " +
                    "addAction.Run();\r\n                                operation.Object.ActionsToRunW" +
                    "henAdding.Clear();\r\n                            }\r\n                        }\r\n  " +
                    "                  }\r\n\r\n\t\t\t\t\tif (toUpdate.Count > 0)\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\tforeach (var " +
                    "operation in toUpdate)\r\n\t\t\t\t\t\t{\r\n                            connection.Update(o" +
                    "peration.Object);\r\n                            operation.Object.UpdatedPropertie" +
                    "s.Clear();\r\n                        }\r\n\t\t\t\t\t}\r\n\r\n\t\t\t\t\tif (toDelete.Count > 0)\r\n\t" +
                    "\t\t\t\t{\r\n                    \tforeach (var operation in toDelete)\r\n\t\t\t\t\t\t{\r\n      " +
                    "                      var deleted = connection.Delete(operation.Object);\r\n      " +
                    "                      if (deleted) { operation.Object.DatabaseModelStatus = Mode" +
                    "lStatus.Deleted; }\r\n                        }\r\n\t\t\t\t\t}\r\n                    _oper" +
                    "ations.Clear();\r\n                }\r\n            }\r\n            catch (Exception " +
                    "e)\r\n            {\r\n                throw new Exception(\"Unable to commit changes" +
                    "\", e);\r\n            }\r\n        }\r\n\r\n\r\n        public void Dispose()\r\n        {\r\n" +
                    "            if (Transaction != null)\r\n            {\r\n                Transaction" +
                    ".Dispose();\r\n            }\r\n        }\r\n\r\n        public void AddOp(IOperation op" +
                    "eration)\r\n        {\r\n            _operations.Add(operation);\r\n        }\r\n\r\n     " +
                    "   public void AddObj(BaseModel obj)\r\n        {\r\n            _objects.Add(obj);\r" +
                    "\n        }    \r\n    }\r\n}\r\n");
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
    public class UnitOfWorkBase
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
