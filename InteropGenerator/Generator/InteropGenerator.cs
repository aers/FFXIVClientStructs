using System.Collections.Immutable;
using InteropGenerator.Helpers;
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

        // code to group structs with the structs they inherit from
        // importantly we need to end up with a grouping that can be incremental for unchanged inheritance trees
        // not a fan of this design, revisit later
        IncrementalValueProvider<ImmutableArray<StructInfo>> structInfosWithInheritance = structInfos.Where(static sI => sI.InheritedStructs.Length != 0).Collect();
        IncrementalValueProvider<ImmutableArray<StructInfo>> structInfosInherited = structInfos.Where(static sI => sI.ExtraInheritedStructInfo != null).Collect();

        IncrementalValuesProvider<(StructInfo targetStruct, ImmutableArray<StructInfo> inheritedStructs)> structInfosWithInheritedStructs = structInfosWithInheritance.Combine(structInfosInherited).SelectMany(static (structInfos, token) => {
            ImmutableArray<StructInfo> structsWithInheritance = structInfos.Left;
            ImmutableArray<StructInfo> structsInherited = structInfos.Right;

            using ImmutableArrayBuilder<(StructInfo targetStruct, ImmutableArray<StructInfo> inheritedStructs)> structInheritanceGroupedBuilder = new();

            Dictionary<string, ImmutableArray<StructInfo>> tempInheritanceMap = new();

            foreach (StructInfo targetStruct in structsWithInheritance) {
                using ImmutableArrayBuilder<StructInfo> inheritedStructsBuilder = new();

                foreach (InheritanceInfo inheritedStruct in targetStruct.InheritedStructs) {
                    CollectInheritedStructs(inheritedStruct.InheritedTypeName, structsInherited, tempInheritanceMap, inheritedStructsBuilder);
                }

                structInheritanceGroupedBuilder.Add((targetStruct, inheritedStructsBuilder.ToImmutable()));
                token.ThrowIfCancellationRequested();
            }

            return structInheritanceGroupedBuilder.ToImmutable();
        });

        context.RegisterSourceOutput(structInfosWithInheritedStructs,
            static (sourceContext, item) => { sourceContext.AddSource($"{item.targetStruct.FullyQualifiedMetadataName}.Inheritance.InteropGenerator.g.cs", RenderInheritedStructInfo(item.targetStruct, item.inheritedStructs, sourceContext.CancellationToken)); });

        // get namespace config
        IncrementalValueProvider<GeneratorOptions> generatorOptionsProvider = context.AnalyzerConfigOptionsProvider.Select(static (options, _) => {
            if (!options.GlobalOptions.TryGetValue("build_property.InteropGenerator_InteropNamespace", out string? interopNamespace))
                interopNamespace = "InteropGenerator.Runtime.Generated";
            return new GeneratorOptions(
                interopNamespace);
        });
        
        // group structs with addresses to output resolver code
        IncrementalValueProvider<ImmutableArray<StructInfo>> structInfosWithAddresses = structInfos.Where(static sI => sI.HasSignatures()).Collect();

        context.RegisterSourceOutput(structInfosWithAddresses.Combine(generatorOptionsProvider),
            static (SourceProductionContext sourceContext, (ImmutableArray<StructInfo> StructInfos, GeneratorOptions GeneratorOptions) args) => {
                if (!args.StructInfos.IsEmpty)
                    sourceContext.AddSource($"{args.GeneratorOptions.InteropNamespace}.Addresses.g.cs", RenderResolverInitializer(args.StructInfos, args.GeneratorOptions.InteropNamespace));
            });

        // group structs with fixed arrays to output fixed array types
        IncrementalValueProvider<ImmutableArray<StructInfo>> structInfosWithFixedArrays = structInfos.Where(static sI => !sI.FixedSizeArrays.IsEmpty).Collect();

        context.RegisterSourceOutput(structInfosWithFixedArrays.Combine(generatorOptionsProvider),
            static (SourceProductionContext sourceContext, (ImmutableArray<StructInfo> StructInfos, GeneratorOptions GeneratorOptions) args) => {
                if (!args.StructInfos.IsEmpty)
                    sourceContext.AddSource($"{args.GeneratorOptions.InteropNamespace}.FixedArrays.g.cs", RenderFixedArrayTypes(args.StructInfos, args.GeneratorOptions.InteropNamespace));
            });
    }

    private static void CollectInheritedStructs(string inheritedTypeName, ImmutableArray<StructInfo> validInheritedTypes, Dictionary<string, ImmutableArray<StructInfo>> processedInheritanceMap, ImmutableArrayBuilder<StructInfo> inheritedStructsBuilder) {
        // check cache for existing processed inheritance tree
        if (processedInheritanceMap.TryGetValue(inheritedTypeName, out ImmutableArray<StructInfo> processedInheritance)) {
            inheritedStructsBuilder.AddRange(processedInheritance.AsSpan());
            return;
        }

        // find type in our list of inheritable structs
        StructInfo? targetInheritedStruct = validInheritedTypes.FirstOrDefault(sInfo => sInfo.FullyQualifiedMetadataName == inheritedTypeName);
        if (targetInheritedStruct == null)
            return;

        using ImmutableArrayBuilder<StructInfo> inheritanceHierarchyBuilder = new();
        inheritanceHierarchyBuilder.Add(targetInheritedStruct);

        // recursively add child types
        if (targetInheritedStruct.InheritedStructs.Length != 0) {
            foreach (InheritanceInfo inheritanceInfo in targetInheritedStruct.InheritedStructs) {
                CollectInheritedStructs(inheritanceInfo.InheritedTypeName, validInheritedTypes, processedInheritanceMap, inheritanceHierarchyBuilder);
            }
        }

        ImmutableArray<StructInfo> inheritanceHierarchy = inheritanceHierarchyBuilder.ToImmutable();
        inheritedStructsBuilder.AddRange(inheritanceHierarchy.AsSpan());
        processedInheritanceMap.Add(inheritedTypeName, inheritanceHierarchy);
    }
}
