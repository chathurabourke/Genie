#region Usings

#endregion

using Genie.Core.Base.Generating;

namespace Genie.Core.Templates.Infrastructure.Filters.Concrete
{
    internal class BoolFilterTemplate : GenieTemplate
    {
        public BoolFilterTemplate(string path) : base(path)
        {
        }

        public override string Generate()
        {
            L($@"

using {GenerationContext.BaseNamespace}.Infrastructure.Filters.Abstract;

namespace {GenerationContext.BaseNamespace}.Infrastructure.Filters.Concrete
{{
    public class BoolFilter<T, TQ> : IBoolFilter<T, TQ> where T : IFilterContext
    {{
        private readonly string _propertyName;
        private readonly T _parent;
        private readonly TQ _q;

        internal BoolFilter(string propertyName, T parent, TQ q)
        {{
            _parent = parent;
            _propertyName = propertyName;
            _q = q;
        }}

        public IExpressionJoin<T, TQ> Is(bool value)
        {{
            _parent.Add(QueryMaker.EqualsTo(_propertyName, value ? ""1"": ""0"", false));
            return new ExpressionJoin<T, TQ>(_parent, _q);
        }}

        public IExpressionJoin<T, TQ> IsFalse()
        {{
            _parent.Add(QueryMaker.IsFalse(_propertyName));
            return new ExpressionJoin<T, TQ>(_parent, _q);
        }}

        public IExpressionJoin<T, TQ> IsTrue()
        {{
            _parent.Add(QueryMaker.IsTrue(_propertyName));
            return new ExpressionJoin<T, TQ>(_parent, _q);
        }}

        public IExpressionJoin<T, TQ> IsNull()
        {{
            _parent.Add(QueryMaker.IsNull(_propertyName));
            return new ExpressionJoin<T, TQ>(_parent, _q);
        }}

        public IExpressionJoin<T, TQ> IsNotNull()
        {{
            _parent.Add(QueryMaker.IsNotNull(_propertyName));
            return new ExpressionJoin<T, TQ>(_parent, _q);
        }}

		public IExpressionJoin<T, TQ> IsNull(bool isNull)
        {{
			_parent.Add(isNull ? QueryMaker.IsNull(_propertyName) : QueryMaker.IsNotNull(_propertyName));
			return new ExpressionJoin<T, TQ>(_parent, _q);
        }}
    }}
}}
");

            return E();
        }
    }
}