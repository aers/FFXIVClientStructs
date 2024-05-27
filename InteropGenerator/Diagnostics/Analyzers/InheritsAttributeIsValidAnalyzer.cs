using System.Collections.Immutable;
using InteropGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using static InteropGenerator.Diagnostics.DiagnosticDescriptors;

namespace InteropGenerator.Diagnostics.Analyzers;

[DiagnosticAnalyzer(Microsoft.CodeAnalysis.LanguageNames.CSharp)]
public sealed class InheritsAttributeIsValidAnalyzer : DiagnosticAnalyzer {

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = [InheritedStructIsNotMarkedInherited];

    public override void Initialize(AnalysisContext context) {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        context.RegisterCompilationStartAction(static context => {
            // get the attribute symbol
            if (context.Compilation.GetTypeByMetadataName(AttributeNames.GenerateInteropAttribute) is not { } generateAttribute)
                return;

            context.RegisterSymbolAction(context => {
                    if (context.Symbol is not INamedTypeSymbol { TypeKind: TypeKind.Struct } typeSymbol)
                        return;

                    foreach (AttributeData attributeData in typeSymbol.GetAttributes()) {
                        if (attributeData.AttributeClass is not { } attributeSymbol) continue;
                        if (!attributeSymbol.HasFullyQualifiedMetadataName(AttributeNames.InheritsAttribute)) continue;
                        if (attributeSymbol.TypeArguments.Length != 1) continue;
                        if (attributeSymbol.TypeArguments[0] is not INamedTypeSymbol inheritedTypeSymbol) continue;

                        if (!inheritedTypeSymbol.TryGetAttributeWithType(generateAttribute, out AttributeData? generateAttributeData) ||
                            !generateAttributeData.TryGetConstructorArgument(0, out bool? isInherited) ||
                            !isInherited.Value) {
                            context.ReportDiagnostic(Diagnostic.Create(
                                InheritedStructIsNotMarkedInherited,
                                inheritedTypeSymbol.Locations.FirstOrDefault(),
                                typeSymbol.Name,
                                inheritedTypeSymbol.Name));
                        }
                    }
                },
                SymbolKind.NamedType);

        });
    }
}
