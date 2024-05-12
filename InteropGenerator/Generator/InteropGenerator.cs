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

        IncrementalValueProvider<GeneratorOptions> generatorOptionsProvider = context.AnalyzerConfigOptionsProvider.Select(static (options, _) => {
            if (!options.GlobalOptions.TryGetValue("build_property.InteropGenerator_InteropNamespace", out string? interopNamespace))
                interopNamespace = "InteropGenerator";

            return new GeneratorOptions(
                interopNamespace);
        });

        IncrementalValueProvider<ImmutableArray<StructInfo>> structInfosWithAddresses = structInfos.Where(static sI => sI.HasSignatures()).Collect();

        context.RegisterSourceOutput(structInfosWithAddresses.Combine(generatorOptionsProvider),
            static (SourceProductionContext sourceContext, (ImmutableArray<StructInfo> StructInfos, GeneratorOptions GeneratorOptions) args) => {
                if (!args.StructInfos.IsEmpty)
                    sourceContext.AddSource($"{args.GeneratorOptions.InteropNamespace}.Interop.InteropGenerator.g.cs", RenderResolverInitializer(args.StructInfos, args.GeneratorOptions.InteropNamespace));
            });
    }
}
