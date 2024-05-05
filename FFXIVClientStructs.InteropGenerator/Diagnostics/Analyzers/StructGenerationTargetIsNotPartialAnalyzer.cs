using System.Collections.Immutable;
using FFXIVClientStructs.InteropGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using static FFXIVClientStructs.InteropGenerator.Diagnostics.DiagnosticDescriptors;

namespace FFXIVClientStructs.InteropGenerator.Diagnostics.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class StructGenerationTargetIsNotPartialAnalyzer : DiagnosticAnalyzer {
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = [GenerationRequiresPartialStruct];

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
                    if (!structSyntax.HasModifier(SyntaxKind.PartialKeyword)) {
                        context.ReportDiagnostic(Diagnostic.Create(
                            GenerationRequiresPartialStruct,
                            structSyntax.Identifier.GetLocation(),
                            typeSymbol.Name));
                    }
                }
            }, SymbolKind.NamedType);
        });
    }
}
