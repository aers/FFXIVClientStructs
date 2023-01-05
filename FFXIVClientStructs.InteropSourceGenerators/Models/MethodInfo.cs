using System.Collections.Immutable;
using FFXIVClientStructs.InteropSourceGenerators.Extensions;
using LanguageExt;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static FFXIVClientStructs.InteropSourceGenerators.DiagnosticDescriptors;
using static LanguageExt.Prelude;

namespace FFXIVClientStructs.InteropSourceGenerators.Models;

internal sealed record MethodInfo(string Name, string Modifiers, string ReturnType, bool IsStatic,
    ImmutableArray<ParameterInfo> Parameters)
{
    public static Validation<DiagnosticInfo, MethodInfo> GetFromRoslyn(MethodDeclarationSyntax methodSyntax,
        IMethodSymbol methodSymbol)
    {
        Validation<DiagnosticInfo, MethodDeclarationSyntax> validSyntax =
            methodSyntax.HasModifier(SyntaxKind.PartialKeyword)
                ? Success<DiagnosticInfo, MethodDeclarationSyntax>(methodSyntax)
                : Fail<DiagnosticInfo, MethodDeclarationSyntax>(
                    DiagnosticInfo.Create(
                        MethodMustBePartial,
                        methodSyntax,
                        methodSymbol.Name
                    ));
        Validation<DiagnosticInfo, IMethodSymbol> validSymbol =
            methodSymbol.ReturnType.IsUnmanagedType
                ? Success<DiagnosticInfo, IMethodSymbol>(methodSymbol)
                : Fail<DiagnosticInfo, IMethodSymbol>(DiagnosticInfo.Create(
                    MethodUsesForbiddenType,
                    methodSyntax,
                    methodSymbol.Name,
                    methodSymbol.ReturnType.GetFullyQualifiedNameWithGenerics()
                ));
        Validation<DiagnosticInfo, IEnumerable<ParameterInfo>> paramInfos =
            methodSymbol.Parameters.Select(ParameterInfo.GetFromSymbol).Sequence();

        return (validSyntax, validSymbol, paramInfos).Apply(static (syntax, symbol, pInfos) =>
            new MethodInfo(
                symbol.Name,
                syntax.Modifiers.ToString(),
                symbol.ReturnType.GetFullyQualifiedNameWithGenerics(),
                symbol.IsStatic,
                pInfos.ToImmutableArray()
            ));
    }
}