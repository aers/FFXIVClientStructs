using System.Collections.Immutable;
using InteropGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using static InteropGenerator.Diagnostics.DiagnosticDescriptors;

namespace InteropGenerator.Diagnostics.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class MethodIsValidForGenerationAnalyzer : DiagnosticAnalyzer {

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = [GenerationRequiresPartialMethod, MethodParameterMustBeUnmanaged, MethodReturnMustBeUnmanaged];

    public override void Initialize(AnalysisContext context) {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        context.RegisterCompilationStartAction(static context => {
            // get the attribute symbols
            if (context.Compilation.GetTypeByMetadataName(AttributeNames.MemberFunctionAttribute) is not { } memberFunctionAttribute ||
                context.Compilation.GetTypeByMetadataName(AttributeNames.VirtualFunctionAttribute) is not { } virtualFunctionAttribute)
                return;

            context.RegisterSymbolAction(context => {
                    if (context.Symbol is not IMethodSymbol { } methodSymbol)
                        return;

                    if (!methodSymbol.HasAttributeWithType(memberFunctionAttribute) &&
                        !methodSymbol.HasAttributeWithType(virtualFunctionAttribute))
                        return;

                    // validate method is partial
                    if (methodSymbol.TryGetSyntaxNode(context.CancellationToken, out MethodDeclarationSyntax? methodSyntax)) {
                        if (!methodSyntax.HasModifier(SyntaxKind.PartialKeyword)) {
                            context.ReportDiagnostic(Diagnostic.Create(
                                GenerationRequiresPartialMethod,
                                methodSyntax.Identifier.GetLocation(),
                                methodSymbol.Name));
                        }
                    }
                    
                    // validate parameters are unmanaged types
                    foreach (IParameterSymbol paramSymbol in methodSymbol.Parameters) {
                        if (!paramSymbol.Type.IsUnmanagedType) {
                            context.ReportDiagnostic(Diagnostic.Create(
                                MethodParameterMustBeUnmanaged,
                                paramSymbol.Locations.FirstOrDefault(),
                                paramSymbol.Name,
                                methodSymbol.Name,
                                paramSymbol.Type.Name));
                        }
                    }
                    
                    // validate return value is unmanaged type
                    if (methodSymbol is {ReturnsVoid: false, ReturnType.IsUnmanagedType: false }) {
                        context.ReportDiagnostic(Diagnostic.Create(
                            MethodReturnMustBeUnmanaged,
                            methodSymbol.Locations.FirstOrDefault(),
                            methodSymbol.Name,
                            methodSymbol.ReturnType.Name));
                    }
                },
                SymbolKind.Method);
        });
    }
}
