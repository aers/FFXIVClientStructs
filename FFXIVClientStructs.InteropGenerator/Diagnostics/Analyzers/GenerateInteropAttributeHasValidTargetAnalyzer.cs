using System.Collections.Immutable;
using FFXIVClientStructs.InteropGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using static FFXIVClientStructs.InteropGenerator.Diagnostics.DiagnosticDescriptors;

namespace FFXIVClientStructs.InteropGenerator.Diagnostics.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class GenerateInteropAttributeHasValidTargetAnalyzer : DiagnosticAnalyzer {
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = [GenerationRequiresPartialStruct, NestedStructMustBeContainedInPartialStruct, NestedStructCannotBeContainedInClass];

    public override void Initialize(AnalysisContext context) {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        context.RegisterCompilationStartAction(static context => {
            // get the attribute symbol
            if (context.Compilation.GetTypeByMetadataName(AttributeNames.GenerateInteropAttribute) is not { } generateAttribute)
                return;

            context.RegisterSymbolAction(context => {
                    if (context.Symbol is not INamedTypeSymbol { } typeSymbol)
                        return;

                    // check for attribute on the type
                    if (!typeSymbol.TryGetAttributeWithType(generateAttribute, out _))
                        return;

                    // get first syntax of symbol; since all need to be partial we can rely on the compiler to check any extras
                    if (typeSymbol.TryGetSyntaxNode(context.CancellationToken, out StructDeclarationSyntax? structSyntax)) {
                        // check struct itself
                        if (!structSyntax.HasModifier(SyntaxKind.PartialKeyword)) {
                            context.ReportDiagnostic(Diagnostic.Create(
                                GenerationRequiresPartialStruct,
                                structSyntax.Identifier.GetLocation(),
                                typeSymbol.Name));
                        }
                        // check any parents
                        SyntaxNode? parentNode = structSyntax.Parent;
                        while (parentNode is not null) {
                            if (parentNode is ClassDeclarationSyntax classSyntax) {
                                context.ReportDiagnostic(Diagnostic.Create(
                                    NestedStructCannotBeContainedInClass,
                                    classSyntax.Identifier.GetLocation(),
                                    typeSymbol.Name,
                                    classSyntax.Identifier));
                            } else if (parentNode is StructDeclarationSyntax parentSyntax) {
                                if (!parentSyntax.HasModifier(SyntaxKind.PartialKeyword)) {
                                    context.ReportDiagnostic(Diagnostic.Create(
                                        NestedStructMustBeContainedInPartialStruct,
                                        parentSyntax.Identifier.GetLocation(),
                                        parentSyntax.Identifier,
                                        typeSymbol.Name));
                                }
                            }
                            parentNode = parentNode.Parent;
                        }
                    }
                },
                SymbolKind.NamedType);
        });
    }
}
