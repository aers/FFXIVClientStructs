using System.Collections.Immutable;
using InteropGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using static InteropGenerator.Diagnostics.DiagnosticDescriptors;

namespace InteropGenerator.Diagnostics.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class FixedSizeArrayAttributeIsValidAnalyzer : DiagnosticAnalyzer {

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = [FixedSizeArrayFieldMustBeInternal, FixedSizeArrayFieldMustHaveProperlyNamedType, FixedSizeArrayFieldMustHaveProperNaming];

    public override void Initialize(AnalysisContext context) {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        context.RegisterCompilationStartAction(static context => {
            // get the attribute symbol
            if (context.Compilation.GetTypeByMetadataName(AttributeNames.FixedSizeArrayAttribute) is not { } fixedSizeArrayAttribute)
                return;

            context.RegisterSymbolAction(context => {
                    if (context.Symbol is not IFieldSymbol fieldSymbol)
                        return;

                    if (!fieldSymbol.HasAttributeWithType(fixedSizeArrayAttribute))
                        return;

                    if (fieldSymbol.DeclaredAccessibility != Accessibility.Internal) {
                        context.ReportDiagnostic(Diagnostic.Create(
                            FixedSizeArrayFieldMustBeInternal,
                            fieldSymbol.Locations.FirstOrDefault(),
                            fieldSymbol.Name));
                    }

                    if (!fieldSymbol.Type.Name.StartsWith("FixedSizeArray") ||
                        !int.TryParse(fieldSymbol.Type.Name[14..], out _)) {
                        context.ReportDiagnostic(Diagnostic.Create(
                            FixedSizeArrayFieldMustHaveProperlyNamedType,
                            fieldSymbol.Locations.FirstOrDefault(),
                            fieldSymbol.Name,
                            fieldSymbol.Type.ToDisplayString(new SymbolDisplayFormat(genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters))));
                    }

                    if (!fieldSymbol.Name.StartsWith("_")) {
                        context.ReportDiagnostic(Diagnostic.Create(
                            FixedSizeArrayFieldMustHaveProperNaming,
                            fieldSymbol.Locations.FirstOrDefault(),
                            fieldSymbol.Name));
                    }
                },
                SymbolKind.Field);
        });
    }
}
