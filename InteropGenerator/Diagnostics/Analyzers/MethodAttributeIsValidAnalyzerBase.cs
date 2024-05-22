using System.Collections.Immutable;
using InteropGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using static InteropGenerator.Diagnostics.DiagnosticDescriptors;

namespace InteropGenerator.Diagnostics.Analyzers;

public abstract class MethodAttributeIsValidAnalyzerBase(
    string attributeFullyQualifiedMetadataName,
    ImmutableArray<DiagnosticDescriptor> descriptors) : DiagnosticAnalyzer {

    public sealed override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
        [GenerationRequiresPartialMethod, MethodParameterMustBeUnmanaged, MethodReturnMustBeUnmanaged, ..descriptors];

    public sealed override void Initialize(AnalysisContext context) {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        context.RegisterCompilationStartAction(compilationStartAnalysisContext => {
            // get the attribute symbol
            if (compilationStartAnalysisContext.Compilation.GetTypeByMetadataName(attributeFullyQualifiedMetadataName) is not { } attributeSymbol)
                return;

            compilationStartAnalysisContext.RegisterSymbolAction(symbolContext => {
                    if (symbolContext.Symbol is not IMethodSymbol methodSymbol)
                        return;

                    if (!methodSymbol.HasAttributeWithType(attributeSymbol))
                        return;

                    // validate method is partial
                    if (!methodSymbol.TryGetSyntaxNode(symbolContext.CancellationToken, out MethodDeclarationSyntax? methodSyntax))
                        return;

                    if (!methodSyntax.HasModifier(SyntaxKind.PartialKeyword)) {
                        symbolContext.ReportDiagnostic(Diagnostic.Create(
                            GenerationRequiresPartialMethod,
                            methodSyntax.GetLocation(),
                            methodSymbol.Name));
                    }


                    // validate parameters are unmanaged types
                    foreach (IParameterSymbol paramSymbol in methodSymbol.Parameters) {
                        if (!paramSymbol.Type.IsUnmanagedType) {
                            symbolContext.ReportDiagnostic(Diagnostic.Create(
                                MethodParameterMustBeUnmanaged,
                                paramSymbol.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax().GetLocation(),
                                paramSymbol.Name,
                                methodSymbol.Name,
                                paramSymbol.Type.Name));
                        }
                    }

                    // validate return value is unmanaged type
                    if (methodSymbol is { ReturnsVoid: false, ReturnType.IsUnmanagedType: false }
                        or { ReturnType: IPointerTypeSymbol { PointedAtType.IsUnmanagedType: false } }) {
                        symbolContext.ReportDiagnostic(Diagnostic.Create(
                            MethodReturnMustBeUnmanaged,
                            methodSyntax.GetLocation(),
                            methodSymbol.Name,
                            methodSymbol.ReturnType.Name));
                    }

                    ValidateSpecific(symbolContext, methodSymbol, methodSyntax);
                },
                SymbolKind.Method);
        });
    }

    protected abstract void ValidateSpecific(SymbolAnalysisContext context, IMethodSymbol methodSymbol, MethodDeclarationSyntax methodSyntax);
}
