using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Scriban;

namespace FFXIVClientStructs.Generators.StaticAddressGenerator
{
    [Generator]
    internal class StaticAddressGenerator : ISourceGenerator
    {
        private Template _saCodeTemplate;
        
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new StaticAddressSyntaxContextReceiver());

            _saCodeTemplate = Template.Parse(Templates.StaticAddresses);
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxContextReceiver is not StaticAddressSyntaxContextReceiver receiver) return;

            foreach (var structObj in receiver.Structs)
            {
                var filename = structObj.Namespace + "." + structObj.Name + ".StaticAddresses.generated.cs";
                var source = _saCodeTemplate.Render(new { Struct = structObj });
                context.AddSource(filename, SourceText.From(source, Encoding.UTF8));
            }

            var resolverTemplate = Template.Parse(Templates.InitializeStaticAddresses);
            var resolverSource = resolverTemplate.Render(new { receiver.Structs });
            context.AddSource("Resolver.StaticAddresses.generated.cs", resolverSource);
        }
    }
}