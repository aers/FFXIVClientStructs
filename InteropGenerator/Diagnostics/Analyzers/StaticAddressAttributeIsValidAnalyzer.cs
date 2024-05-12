using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using static InteropGenerator.Diagnostics.DiagnosticDescriptors;

namespace InteropGenerator.Diagnostics.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class StaticAddressAttributeIsValidAnalyzer() : MethodAttributeIsValidAnalyzerBase(AttributeNames.StaticAddressAttribute, [StaticAddressMethodMustNotHaveParameters, StaticAddressMethodMustBeStatic, StaticAddressMethodReturnMustBePointer]) {

    protected override void ValidateSpecific(SymbolAnalysisContext context, IMethodSymbol methodSymbol, MethodDeclarationSyntax methodSyntax) {
        if (!methodSymbol.Parameters.IsEmpty) {
            context.ReportDiagnostic(Diagnostic.Create(
                StaticAddressMethodMustNotHaveParameters,
                methodSyntax.GetLocation(),
                methodSymbol.Name));
        }

        if (!methodSymbol.IsStatic) {
            context.ReportDiagnostic(Diagnostic.Create(
                StaticAddressMethodMustBeStatic,
                methodSyntax.GetLocation(),
                methodSymbol.Name));
        }

        // validate return value is a pointer type
        if (methodSymbol.ReturnType.Kind != SymbolKind.PointerType) {
            context.ReportDiagnostic(Diagnostic.Create(
                StaticAddressMethodReturnMustBePointer,
                methodSyntax.GetLocation(),
                methodSymbol.Name,
                methodSymbol.ReturnType.Name));
        }
    }
}
