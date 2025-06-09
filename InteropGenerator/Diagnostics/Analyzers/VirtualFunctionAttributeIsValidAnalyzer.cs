using InteropGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using static InteropGenerator.Diagnostics.DiagnosticDescriptors;

namespace InteropGenerator.Diagnostics.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class VirtualFunctionAttributeIsValidAnalyzer() : MethodAttributeIsValidAnalyzerBase(InteropTypeNames.VirtualFunctionAttribute, [VirtualFunctionMethodMustNotBeStatic, VirtualFunctionIndexOutOfBounds]) {

    protected override void ValidateSpecific(SymbolAnalysisContext context, IMethodSymbol methodSymbol, MethodDeclarationSyntax methodSyntax, AttributeData attributeData) {
        if (methodSymbol.IsStatic) {
            context.ReportDiagnostic(Diagnostic.Create(
                VirtualFunctionMethodMustNotBeStatic,
                methodSyntax.GetLocation(),
                methodSymbol.Name));
        }

        // get the attribute symbol
        if (context.Compilation.GetTypeByMetadataName(InteropTypeNames.VirtualTableAttribute) is not { } virtualTableAttribute)
            return;

        if (methodSymbol.ContainingType is not { } containingStructSymbol)
            return;

        if (!containingStructSymbol.TryGetAttributeWithType(virtualTableAttribute, out AttributeData? virtualTableAttributeData))
            return;

        if (!virtualTableAttributeData.TryGetConstructorArgument(2, out uint? functionCount))
            return;

        if (functionCount == 0)
            return;

        if (!attributeData.TryGetConstructorArgument(0, out uint? index))
            return;

        if (index >= functionCount) {
            context.ReportDiagnostic(Diagnostic.Create(
                VirtualFunctionIndexOutOfBounds,
                methodSyntax.GetLocation(),
                methodSymbol.Name,
                index,
                functionCount));
        }
    }
}
