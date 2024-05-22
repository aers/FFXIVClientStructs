using System.Collections.Immutable;
using InteropGenerator.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace InteropGenerator.Generator;

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
                        return ParseStructInfo(structSymbol, token);
                    })
                .Where(static si => si is not null)!;

        context.RegisterSourceOutput(structInfos,
            static (sourceContext, item) => { sourceContext.AddSource($"{item.FullyQualifiedMetadataName}.InteropGenerator.g.cs", RenderStructInfo(item, sourceContext.CancellationToken)); });

        IncrementalValueProvider<ImmutableArray<StructInfo>> structInfosWithAddresses = structInfos.Where(static sI => sI.HasSignatures()).Collect();

        context.RegisterSourceOutput(structInfosWithAddresses,
            static (sourceContext, structInfos) => {
                if (!structInfos.IsEmpty)
                    sourceContext.AddSource("InteropGenerator.Runtime.Generated.Addresses.g.cs", RenderResolverInitializer(structInfos));
            });

        IncrementalValueProvider<ImmutableArray<StructInfo>> structInfosWithFixedArrays = structInfos.Where(static sI => !sI.FixedSizeArrays.IsEmpty).Collect();

        context.RegisterSourceOutput(structInfosWithFixedArrays,
            static (sourceContext, structInfos) => {
                if (!structInfos.IsEmpty)
                    sourceContext.AddSource("InteropGenerator.Runtime.Generated.FixedArrays.g.cs", RenderFixedArrayTypes(structInfos));
            });
    }
}
