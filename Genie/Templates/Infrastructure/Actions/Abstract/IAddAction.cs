#region Usings

#endregion

using Genie.Core.Base.Generating;

namespace Genie.Core.Templates.Infrastructure.Actions.Abstract
{
    internal class IAddActionTemplate : GenieTemplate
    {
        public IAddActionTemplate(string path) : base(path)
        {
        }

        public override string Generate()
        {
            L($@"


namespace {GenerationContext.BaseNamespace}.Infrastructure.Actions.Abstract
{{
    internal interface IAddAction
    {{
        void Run();
    }}
}}
");

            return E();
        }
    }
}