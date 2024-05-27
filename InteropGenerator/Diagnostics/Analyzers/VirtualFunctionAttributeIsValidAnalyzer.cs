using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using static InteropGenerator.Diagnostics.DiagnosticDescriptors;

namespace InteropGenerator.Diagnostics.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class VirtualFunctionAttributeIsValidAnalyzer() : MethodAttributeIsValidAnalyzerBase(AttributeNames.VirtualFunctionAttribute, [VirtualFunctionMethodMustNotBeStatic]) {

    protected override void ValidateSpecific(SymbolAnalysisContext context, IMethodSymbol methodSymbol, MethodDeclarationSyntax methodSyntax) {
        if (methodSymbol.IsStatic) {
            context.ReportDiagnostic(Diagnostic.Create(
                VirtualFunctionMethodMustNotBeStatic,
                methodSyntax.GetLocation(),
                methodSymbol.Name));
        }
    }
}
