﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 14.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Genie.Templates.Infrastructure.Filters
{
    using Genie.Base;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\Genie\Genie\Templates\Infrastructure\Filters\Filters.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class Filters : FiltersBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\nusing System;\r\nusing System.Data;\r\nusing System.Collections.Generic;\r\n\r\nnamespa" +
                    "ce ");
            
            #line 8 "D:\Projects\Genie\Genie\Templates\Infrastructure\Filters\Filters.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Filters\r\n{\r\n\t\r\n\tpublic class BaseQueryContext<T>\r\n    {\r\n        " +
                    "protected int? _page;\r\n        protected int? _pageSize;\r\n        protected int?" +
                    " _limit;\r\n        protected int? _skip;\r\n        protected int? _take;\r\n        " +
                    "protected T Instance;\r\n\r\n        public T Page(int pageSize, int page)\r\n        " +
                    "{\r\n            _page = page;\r\n            _pageSize = pageSize;\r\n            ret" +
                    "urn Instance;\r\n        }\r\n\r\n        public T Top(int limit)\r\n        {\r\n        " +
                    "    _limit = limit;\r\n            return Instance;\r\n        }\r\n\r\n        public T" +
                    " Skip(int skip)\r\n        {\r\n            _skip = skip;\r\n            return Instan" +
                    "ce;\r\n        }\r\n\r\n        public T Take(int take)\r\n        {\r\n            _take " +
                    "= take;\r\n            return Instance;\r\n        }\r\n    }\r\n\r\n    public  abstract " +
                    "class BaseFilterContext\r\n    {\r\n        protected BaseFilterContext() { Expressi" +
                    "ons = new Queue<string>(); }\r\n        protected Queue<string> Expressions { get;" +
                    " set; } \r\n        internal void And() { Expressions.Enqueue(\"and\"); }\r\n        i" +
                    "nternal void Or() { Expressions.Enqueue(\"or\"); }\r\n        internal void Add(stri" +
                    "ng expression) { Expressions.Enqueue(expression); }\r\n        internal Queue<stri" +
                    "ng> GetFilterExpressions() { return Expressions; }\r\n    }\r\n\r\n    public class Ex" +
                    "pressionJoin<T,TQ> where T: BaseFilterContext\r\n    {\r\n        private readonly T" +
                    " _t;\r\n        private readonly TQ _q;\r\n\r\n        internal ExpressionJoin(T t, TQ" +
                    " q)\r\n        {\r\n            _t = t;\r\n            _q = q;\r\n        } \r\n\r\n        " +
                    "public T And { get { _t.And(); return _t; } }\r\n        public T Or { get { _t.Or" +
                    "(); return _t; } }\r\n\r\n        public TQ Filter()\r\n        {\r\n            return " +
                    "_q;\r\n        }\r\n    }\r\n\r\n\tpublic class StringFilter<T,Q> where T: BaseFilterCont" +
                    "ext\r\n\t{\r\n\t\tprivate readonly string _propertyName;\r\n        private readonly T _p" +
                    "arent;\r\n        private readonly Q _q;\r\n\r\n        internal StringFilter(string p" +
                    "ropertyName, T parent, Q q)\r\n        {\r\n            _parent = parent;\r\n         " +
                    "   _propertyName = propertyName;\r\n            _q = q;\r\n        } \r\n\r\n        pub" +
                    "lic ExpressionJoin<T,Q> Equals(string str)\r\n        {\r\n            _parent.Add(s" +
                    "tring.Format(\"[{0}] = \'{1}\'\", _propertyName, str));\r\n            return new Expr" +
                    "essionJoin<T,Q>(_parent, _q);\r\n        }\r\n\r\n        public ExpressionJoin<T, Q> " +
                    "NotEquals(string str)\r\n        {\r\n            _parent.Add(string.Format(\"[{0}] !" +
                    "= \'{1}\'\", _propertyName, str));\r\n            return new ExpressionJoin<T, Q>(_pa" +
                    "rent, _q);\r\n        }\r\n\r\n        public ExpressionJoin<T,Q> Contains(string str)" +
                    "\r\n        {\r\n            _parent.Add(string.Format(\"[{0}] LIKE \'%{1}%\'\", _proper" +
                    "tyName, str));\r\n            return new ExpressionJoin<T,Q>(_parent, _q);\r\n      " +
                    "  }\r\n\r\n        public ExpressionJoin<T,Q> StartsWith(string str)\r\n        {\r\n   " +
                    "         _parent.Add(string.Format(\"[{0}] LIKE \'{1}%\'\", _propertyName, str));\r\n " +
                    "           return new ExpressionJoin<T,Q>(_parent, _q);\r\n        }\r\n\r\n        pu" +
                    "blic ExpressionJoin<T,Q> EndsWith(string str)\r\n        {\r\n            _parent.Ad" +
                    "d(string.Format(\"[{0}] LIKE \'%{1}\'\", _propertyName, str));\r\n            return n" +
                    "ew ExpressionJoin<T,Q>(_parent, _q);\r\n        }\r\n\r\n        public ExpressionJoin" +
                    "<T,Q> NotStartsWith(string str)\r\n        {\r\n            _parent.Add(string.Forma" +
                    "t(\"[{0}] NOT LIKE \'{1}%\'\", _propertyName, str));\r\n            return new Express" +
                    "ionJoin<T,Q>(_parent, _q);\r\n        }\r\n\r\n        public ExpressionJoin<T,Q> NotE" +
                    "ndsWith(string str)\r\n        {\r\n            _parent.Add(string.Format(\"[{0}] NOT" +
                    " LIKE \'%{1}\'\", _propertyName, str));\r\n            return new ExpressionJoin<T,Q>" +
                    "(_parent, _q);\r\n        }\r\n\r\n        public ExpressionJoin<T,Q> IsEmpty()\r\n     " +
                    "   {\r\n            _parent.Add(string.Format(\"[{0}] = \'\'\", _propertyName));\r\n    " +
                    "        return new ExpressionJoin<T,Q>(_parent, _q);\r\n        }\r\n\r\n        publi" +
                    "c ExpressionJoin<T,Q> IsNotEmpty()\r\n        {\r\n            _parent.Add(string.Fo" +
                    "rmat(\"[{0}] != \'\'\", _propertyName));\r\n            return new ExpressionJoin<T,Q>" +
                    "(_parent, _q);\r\n        }\r\n\r\n        public ExpressionJoin<T,Q> IsNull()\r\n      " +
                    "  {\r\n            _parent.Add(string.Format(\"[{0}] IS NULL\", _propertyName));\r\n  " +
                    "          return new ExpressionJoin<T,Q>(_parent, _q);\r\n        }\r\n\t}\r\n\r\n    pub" +
                    "lic class NumberFilter<T, Q> where T : BaseFilterContext\r\n    {\r\n        private" +
                    " readonly string _propertyName;\r\n        private readonly T _parent;\r\n        pr" +
                    "ivate readonly Q _q;\r\n\r\n        internal NumberFilter(string propertyName, T par" +
                    "ent, Q q)\r\n        {\r\n            _parent = parent;\r\n            _propertyName =" +
                    " propertyName;\r\n            _q = q;\r\n        }\r\n\r\n        public ExpressionJoin<" +
                    "T, Q> Equals(double number)\r\n        {\r\n            _parent.Add(string.Format(\"[" +
                    "{0}] = {1}\", _propertyName, number));\r\n            return new ExpressionJoin<T, " +
                    "Q>(_parent, _q);\r\n        }\r\n\r\n        public ExpressionJoin<T, Q> NotEquals(dou" +
                    "ble number)\r\n        {\r\n            _parent.Add(string.Format(\"[{0}] != {1}\", _p" +
                    "ropertyName, number));\r\n            return new ExpressionJoin<T, Q>(_parent, _q)" +
                    ";\r\n        }\r\n\r\n        public ExpressionJoin<T, Q> LargerThan(double number)\r\n " +
                    "       {\r\n            _parent.Add(string.Format(\"[{0}] > {1}\", _propertyName, nu" +
                    "mber));\r\n            return new ExpressionJoin<T, Q>(_parent, _q);\r\n        }\r\n\r" +
                    "\n        public ExpressionJoin<T, Q> LessThan(double number)\r\n        {\r\n       " +
                    "     _parent.Add(string.Format(\"[{0}] < {1}\", _propertyName, number));\r\n        " +
                    "    return new ExpressionJoin<T, Q>(_parent, _q);\r\n        }\r\n\r\n        public E" +
                    "xpressionJoin<T, Q> LargerThanOrEqualTo(double number)\r\n        {\r\n            _" +
                    "parent.Add(string.Format(\"[{0}] >= {1}\", _propertyName, number));\r\n            r" +
                    "eturn new ExpressionJoin<T, Q>(_parent, _q);\r\n        }\r\n\r\n        public Expres" +
                    "sionJoin<T, Q> LessThanOrEqualTo(double number)\r\n        {\r\n            _parent." +
                    "Add(string.Format(\"[{0}] <= {1}\", _propertyName, number));\r\n            return n" +
                    "ew ExpressionJoin<T, Q>(_parent, _q);\r\n        }\r\n\r\n        public ExpressionJoi" +
                    "n<T, Q> Between(double from, double to)\r\n        {\r\n            _parent.Add(stri" +
                    "ng.Format(\"[{0}] <= {1} and {0} >= {2}\", _propertyName, from, to));\r\n           " +
                    " return new ExpressionJoin<T, Q>(_parent, _q);\r\n        }\r\n\r\n        public Expr" +
                    "essionJoin<T,Q> IsNull()\r\n        {\r\n            _parent.Add(string.Format(\"[{0}" +
                    "] IS NULL\", _propertyName));\r\n            return new ExpressionJoin<T,Q>(_parent" +
                    ", _q);\r\n        }\r\n    }\r\n\r\n    public class DateFilter<T, Q> where T : BaseFilt" +
                    "erContext\r\n    {\r\n        private readonly string _propertyName;\r\n        privat" +
                    "e readonly T _parent;\r\n        private readonly Q _q;\r\n\r\n        internal DateFi" +
                    "lter(string propertyName, T parent, Q q)\r\n        {\r\n            _parent = paren" +
                    "t;\r\n            _propertyName = propertyName;\r\n            _q = q;\r\n        }\r\n\r" +
                    "\n        public ExpressionJoin<T, Q> Equals(DateTime date)\r\n        {\r\n         " +
                    "   _parent.Add(string.Format(\"[{0}] = \'{1}\'\", _propertyName, date));\r\n          " +
                    "  return new ExpressionJoin<T, Q>(_parent, _q);\r\n        }\r\n\r\n        public Exp" +
                    "ressionJoin<T, Q> NotEquals(DateTime date)\r\n        {\r\n            _parent.Add(s" +
                    "tring.Format(\"[{0}] != \'{1}\'\", _propertyName, date));\r\n            return new Ex" +
                    "pressionJoin<T, Q>(_parent, _q);\r\n        }\r\n\r\n        public ExpressionJoin<T, " +
                    "Q> LargerThan(DateTime number)\r\n        {\r\n            _parent.Add(string.Format" +
                    "(\"[{0}] > \'{1}\'\", _propertyName, number));\r\n            return new ExpressionJoi" +
                    "n<T, Q>(_parent, _q);\r\n        }\r\n\r\n        public ExpressionJoin<T, Q> LessThan" +
                    "(DateTime date)\r\n        {\r\n            _parent.Add(string.Format(\"[{0}] < \'{1}\'" +
                    "\", _propertyName, date));\r\n            return new ExpressionJoin<T, Q>(_parent, " +
                    "_q);\r\n        }\r\n\r\n        public ExpressionJoin<T, Q> LargerThanOrEqualTo(DateT" +
                    "ime date)\r\n        {\r\n            _parent.Add(string.Format(\"[{0}] >= \'{1}\'\", _p" +
                    "ropertyName, date));\r\n            return new ExpressionJoin<T, Q>(_parent, _q);\r" +
                    "\n        }\r\n\r\n        public ExpressionJoin<T, Q> LessThanOrEqualTo(DateTime dat" +
                    "e)\r\n        {\r\n            _parent.Add(string.Format(\"[{0}] <= \'{1}\'\", _property" +
                    "Name, date));\r\n            return new ExpressionJoin<T, Q>(_parent, _q);\r\n      " +
                    "  }\r\n\r\n        public ExpressionJoin<T, Q> Between(DateTime from, DateTime to)\r\n" +
                    "        {\r\n            _parent.Add(string.Format(\"[{0}] <= \'{1}\' and {0} >= \'{2}" +
                    "\'\", _propertyName, from, to));\r\n            return new ExpressionJoin<T, Q>(_par" +
                    "ent, _q);\r\n        }\r\n\r\n        public ExpressionJoin<T,Q> IsNull()\r\n        {\r\n" +
                    "            _parent.Add(string.Format(\"[{0}] IS NULL\", _propertyName));\r\n       " +
                    "     return new ExpressionJoin<T,Q>(_parent, _q);\r\n        }\r\n    }\r\n\r\n    publi" +
                    "c class BoolFilter<T, Q> where T : BaseFilterContext\r\n    {\r\n        private rea" +
                    "donly string _propertyName;\r\n        private readonly T _parent;\r\n        privat" +
                    "e readonly Q _q;\r\n\r\n        internal BoolFilter(string propertyName, T parent, Q" +
                    " q)\r\n        {\r\n            _parent = parent;\r\n            _propertyName = prope" +
                    "rtyName;\r\n            _q = q;\r\n        }\r\n\r\n        public ExpressionJoin<T, Q> " +
                    "Is(bool value)\r\n        {\r\n            _parent.Add(string.Format(\"[{0}] = {1}\", " +
                    "_propertyName, value ? 1 : 0));\r\n            return new ExpressionJoin<T, Q>(_pa" +
                    "rent, _q);\r\n        }\r\n\r\n        public ExpressionJoin<T, Q> IsFalse()\r\n        " +
                    "{\r\n            _parent.Add(string.Format(\"[{0}] != 0\", _propertyName));\r\n       " +
                    "     return new ExpressionJoin<T, Q>(_parent, _q);\r\n        }\r\n\r\n        public " +
                    "ExpressionJoin<T, Q> IsTrue()\r\n        {\r\n            _parent.Add(string.Format(" +
                    "\"[{0}] != 1\", _propertyName));\r\n            return new ExpressionJoin<T, Q>(_par" +
                    "ent, _q);\r\n        }\r\n\r\n        public ExpressionJoin<T,Q> IsNull()\r\n        {\r\n" +
                    "            _parent.Add(string.Format(\"[{0}] IS NULL\", _propertyName));\r\n       " +
                    "     return new ExpressionJoin<T,Q>(_parent, _q);\r\n        }\r\n    }\r\n\r\n\r\n    pub" +
                    "lic abstract class BaseOrderContext\r\n    {\r\n        protected BaseOrderContext()" +
                    " { Expressions = new Queue<string>(); }\r\n        protected Queue<string> Express" +
                    "ions { get; set; }\r\n        internal void And() { Expressions.Enqueue(\",\"); }\r\n " +
                    "       internal void Add(string expression) { Expressions.Enqueue(expression); }" +
                    "\r\n        internal Queue<string> GetOrderExpressions() { return Expressions; }\r\n" +
                    "    }\r\n\r\n    public class OrderJoin<T, TQ> where T : BaseOrderContext\r\n    {\r\n  " +
                    "      private readonly T _t;\r\n        private readonly TQ _q;\r\n\r\n        interna" +
                    "l OrderJoin(T t, TQ q)\r\n        {\r\n            _t = t;\r\n            _q = q;\r\n   " +
                    "     }\r\n\r\n        public T And { get { _t.And(); return _t; } }\r\n\r\n        publi" +
                    "c TQ Order()\r\n        {\r\n            return _q;\r\n        }\r\n    }\r\n\r\n    public " +
                    "class OrderElement<T, Q> where T : BaseOrderContext\r\n    {\r\n        private read" +
                    "only string _propertyName;\r\n        private readonly T _parent;\r\n        private" +
                    " readonly Q _q;\r\n\r\n        internal OrderElement(string propertyName, T parent, " +
                    "Q q)\r\n        {\r\n            _parent = parent;\r\n            _propertyName = prop" +
                    "ertyName;\r\n            _q = q;\r\n        }\r\n\r\n        public OrderJoin<T, Q> Asce" +
                    "nding()\r\n        {\r\n            _parent.Add(string.Format(\"[{0}] ASC\", _property" +
                    "Name));\r\n            return new OrderJoin<T, Q>(_parent , _q);\r\n        }\r\n\r\n   " +
                    "     public OrderJoin<T, Q> Descending()\r\n        {\r\n            _parent.Add(str" +
                    "ing.Format(\"[{0}] DESC\", _propertyName));\r\n            return new OrderJoin<T, Q" +
                    ">(_parent, _q);\r\n        }\r\n    }\r\n}");
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
    public class FiltersBase
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