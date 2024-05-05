using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FFXIVClientStructs.InteropGenerator.Extensions;

/// <summary>
///     Extension methods for <see cref="MemberDeclarationSyntax" /> types.
/// </summary>
internal static class MemberDeclarationSyntaxExtensions {
    public static bool HasModifier(this MemberDeclarationSyntax memberDeclaration, SyntaxKind modifierKind) {
        return memberDeclaration.Modifiers.Any(modifier => modifier.IsKind(modifierKind));
    }
}
