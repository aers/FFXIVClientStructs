using System.Collections.Immutable;
using FFXIVClientStructs.InteropSourceGenerators.Extensions;
using LanguageExt;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static FFXIVClientStructs.InteropSourceGenerators.DiagnosticDescriptors;
using static LanguageExt.Prelude;

namespace FFXIVClientStructs.InteropSourceGenerators.Models;

internal sealed record StructInfo(string Name, string Namespace, ImmutableArray<string> Hierarchy)
{
    public static Validation<DiagnosticInfo, StructInfo> GetFromSyntax(StructDeclarationSyntax structSyntax)
    {
        Validation<DiagnosticInfo, StructDeclarationSyntax> validSyntax =
            structSyntax.HasModifier(SyntaxKind.PartialKeyword)
                ? Success<DiagnosticInfo, StructDeclarationSyntax>(structSyntax)
                : Fail<DiagnosticInfo, StructDeclarationSyntax>(
                    DiagnosticInfo.Create(
                        StructMustBePartial,
                        structSyntax,
                        structSyntax.Identifier.ToString()
                    ));
        Validation<DiagnosticInfo, Seq<string>> validHierarchy = GetHierarchy(structSyntax);

        return (validSyntax, validHierarchy).Apply(static (syntax, hierarchy) =>
            new StructInfo(
                syntax.GetNameWithTypeDeclarationList(),
                syntax.GetContainingFileScopedNamespace(),
                hierarchy.Reverse().ToImmutableArray()));
    }

    private static Validation<DiagnosticInfo, Seq<string>> GetHierarchy(StructDeclarationSyntax structSyntax)
    {
        Seq<string> hierarchy = new();

        TypeDeclarationSyntax? potentialContainingStruct = structSyntax.Parent as TypeDeclarationSyntax;

        while (potentialContainingStruct != null)
            if (potentialContainingStruct is StructDeclarationSyntax containingStructSyntax)
            {
                hierarchy = hierarchy.Add(containingStructSyntax.GetNameWithTypeDeclarationList());
                potentialContainingStruct = potentialContainingStruct.Parent as TypeDeclarationSyntax;
            }
            else
            {
                return Fail<DiagnosticInfo, Seq<string>>(
                    DiagnosticInfo.Create(
                        NestedStructMustBeContainedInStructs,
                        structSyntax,
                        structSyntax.Identifier.ToString()
                    ));
            }

        return Success<DiagnosticInfo, Seq<string>>(hierarchy);
    }
}