using FFXIVClientStructs.InteropGenerator.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FFXIVClientStructs.InteropGenerator.Generator;

[Generator]
public sealed partial class InteropGenerator : IIncrementalGenerator {
    public void Initialize(IncrementalGeneratorInitializationContext context) {
        // parse all structs and drop invalid results
        IncrementalValuesProvider<StructInfo> structInfos =
            context.SyntaxProvider.ForAttributeWithMetadataName(
                    AttributeNames.GenerateInteropAttribute,
                    static (node, _) => node is StructDeclarationSyntax { AttributeLists.Count: > 0 },
                    static (context, token) => {
                        // not sure if the check is truly necessary
                        if (context.TargetSymbol is not INamedTypeSymbol structSymbol)
                            return null;
                        return InteropGenerator.ParseStructInfo(structSymbol, token);
                    })
                .Where(static si => si is not null)!;
        
        context.RegisterSourceOutput(structInfos,
            (sourceContext, item) => {
                sourceContext.AddSource($"{item.FullyQualifiedMetadataName}.InteropGenerator.g.cs", InteropGenerator.RenderStructInfo(item));
            });
    }
}
