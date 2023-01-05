using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FFXIVClientStructs.InteropSourceGenerators.Extensions;

internal static class SyntaxNodeExtensions
{
    public static string GetContainingFileScopedNamespace(this SyntaxNode syntaxNode)
    {
        SyntaxNode? potentialNamespaceParentNode = syntaxNode;

        while (potentialNamespaceParentNode != null &&
               potentialNamespaceParentNode is not FileScopedNamespaceDeclarationSyntax)
            potentialNamespaceParentNode = potentialNamespaceParentNode.Parent;

        if (potentialNamespaceParentNode is FileScopedNamespaceDeclarationSyntax namespaceNode)
            return namespaceNode.Name.ToString();

        return string.Empty;
    }
}