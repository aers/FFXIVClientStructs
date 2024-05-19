using System.Collections.Immutable;
using System.Runtime.InteropServices;
using InteropGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using static InteropGenerator.Diagnostics.DiagnosticDescriptors;

namespace InteropGenerator.Diagnostics.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class GenerateInteropAttributeIsValidAnalyzer : DiagnosticAnalyzer {
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = [GenerationRequiresPartialStruct, NestedStructMustBeContainedInPartialStruct, NestedStructCannotBeContainedInClass, GenerationTargetMustUseStructLayoutAttribute, GenerationTargetMustUseLayoutKindExplicit, GenerationTargetMustHaveExplicitSize];

    public override void Initialize(AnalysisContext context) {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        context.RegisterCompilationStartAction(static context => {
            // get the attribute symbol
            if (context.Compilation.GetTypeByMetadataName(AttributeNames.GenerateInteropAttribute) is not { } generateAttribute ||
                context.Compilation.GetTypeByMetadataName("System.Runtime.InteropServices.StructLayoutAttribute") is not { } structLayoutAttribute)
                return;

            context.RegisterSymbolAction(context => {
                    if (context.Symbol is not INamedTypeSymbol { TypeKind: TypeKind.Struct } typeSymbol)
                        return;

                    // check for attribute on the type
                    if (!typeSymbol.HasAttributeWithType(generateAttribute))
                        return;

                    // get first syntax of symbol; since all need to be partial we can rely on the compiler to check any extras
                    if (typeSymbol.TryGetSyntaxNode(context.CancellationToken, out StructDeclarationSyntax? structSyntax)) {
                        // check for structlayout
                        if (!typeSymbol.TryGetAttributeWithType(structLayoutAttribute, out AttributeData? structLayoutAttributeData)) {
                            context.ReportDiagnostic(Diagnostic.Create(
                                GenerationTargetMustUseStructLayoutAttribute,
                                structSyntax.Identifier.GetLocation(),
                                typeSymbol.Name));
                        } else {
                            // can't use TryGetConstructorArgument on non-builtin types
                            if (structLayoutAttributeData.ConstructorArguments.Length >= 1 &&
                                !structLayoutAttributeData.ConstructorArguments[0].IsNull &&
                                (LayoutKind) structLayoutAttributeData.ConstructorArguments[0].Value! != LayoutKind.Explicit) {
                                context.ReportDiagnostic(Diagnostic.Create(
                                    GenerationTargetMustUseLayoutKindExplicit,
                                    structLayoutAttributeData.GetLocation(),
                                    typeSymbol.Name));
                            }
                            if (!structLayoutAttributeData.TryGetNamedArgument("Size", out int? size) ||
                                size == 0) {
                                context.ReportDiagnostic(Diagnostic.Create(
                                    GenerationTargetMustHaveExplicitSize,
                                    structLayoutAttributeData.GetLocation(),
                                    typeSymbol.Name));
                            }
                        }

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
