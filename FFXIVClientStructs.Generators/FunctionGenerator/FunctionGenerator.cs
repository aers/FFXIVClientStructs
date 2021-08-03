using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Scriban;

namespace FFXIVClientStructs.Generators.FunctionGenerator
{
    [Generator]
    internal class FunctionGenerator : ISourceGenerator
    {
        private Template _mfCodeTemplate;
        private Template _vfCodeTemplate;

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new FunctionSyntaxContextReceiver());

            _mfCodeTemplate = Template.Parse(Templates.MemberFunctions);
            _vfCodeTemplate = Template.Parse(Templates.VirtualFunctions);
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxContextReceiver is not FunctionSyntaxContextReceiver receiver) return;

            foreach (var structObj in receiver.Structs)
            {
                if (structObj.MemberFunctions.Any())
                {
                    var filename = structObj.Namespace + "." + structObj.Name + ".MemberFunctions.generated.cs";
                    var source = _mfCodeTemplate.Render(new { Struct = structObj });
                    context.AddSource(filename, SourceText.From(source, Encoding.UTF8));
                }

                if (structObj.VirtualFunctions.Any())
                {
                    var filename = structObj.Namespace + "." + structObj.Name + ".VirtualFunctions.generated.cs";
                    var source = _vfCodeTemplate.Render(new { Struct = structObj });
                    context.AddSource(filename, SourceText.From(source, Encoding.UTF8));
                }
            }

            var resolverTemplate = Template.Parse(Templates.InitializeMemberFunctions);
            var resolverSource = resolverTemplate.Render(new { receiver.Structs});
            context.AddSource("Resolver.MemberFunctions.Generated.cs", resolverSource);
        }
    }
}
