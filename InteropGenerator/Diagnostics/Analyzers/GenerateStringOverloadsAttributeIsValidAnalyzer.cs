using System.Collections.Immutable;
using InteropGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using static InteropGenerator.Diagnostics.DiagnosticDescriptors;

namespace InteropGenerator.Diagnostics.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class GenerateStringOverloadsAttributeIsValidAnalyzer : DiagnosticAnalyzer {

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = [GenerateStringOverloadsMethodMustHaveValidParameter, StringIgnoreMustTargetValidParameter];

    public override void Initialize(AnalysisContext context) {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        context.RegisterCompilationStartAction(static context => {
            // get the attribute symbol
            if (context.Compilation.GetTypeByMetadataName(AttributeNames.GenerateStringOverloads) is not { } generateStringOverloadsAttribute ||
                context.Compilation.GetTypeByMetadataName(AttributeNames.StringIgnore) is not { } stringIgnoreAttribute)
                return;

            context.RegisterSymbolAction(context => {
                if (context.Symbol is not IMethodSymbol methodSymbol)
                    return;

                if (!methodSymbol.HasAttributeWithType(generateStringOverloadsAttribute))
                    return;

                var hasValidParameter = false;

                foreach (IParameterSymbol parameterSymbol in methodSymbol.Parameters) {
                    bool hasStringIgnore = parameterSymbol.HasAttributeWithType(stringIgnoreAttribute);
                    if (parameterSymbol.Type is not IPointerTypeSymbol { PointedAtType.SpecialType: SpecialType.System_Byte }) {
                        if (hasStringIgnore) {
                            context.ReportDiagnostic(Diagnostic.Create(
                                StringIgnoreMustTargetValidParameter,
                                parameterSymbol.Locations.FirstOrDefault(),
                                parameterSymbol.Name,
                                parameterSymbol.Type.ToDisplayString()));
                        }
                    } else {
                        if (!hasStringIgnore)
                            hasValidParameter = true;
                    }
                }


                if (!hasValidParameter) {
                    context.ReportDiagnostic(Diagnostic.Create(
                        GenerateStringOverloadsMethodMustHaveValidParameter,
                        methodSymbol.Locations.FirstOrDefault(),
                        methodSymbol.Name));
                }
            },
                SymbolKind.Method);
        });
    }
}
