// sourced from https://github.com/Sergio0694/ComputeSharp/blob/main/src/ComputeSharp.SourceGeneration/Extensions/ISymbolExtensions.cs

using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;

namespace InteropGenerator.Extensions;

/// <summary>
///     Extension methods for <see cref="ISymbol" /> types.
/// </summary>
// ReSharper disable once InconsistentNaming
public static class ISymbolExtensions {
    public static string GetFullyQualifiedName(this ISymbol symbol) => symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);

    private static readonly SymbolDisplayFormat ContainingTypesAndNamespaces = new SymbolDisplayFormat(typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces);
    public static string GetNameWithContainingTypeAndNamespace(this ISymbol symbol) => symbol.ToDisplayString(ContainingTypesAndNamespaces);

    /// <summary>
    ///     Checks whether or not a given symbol has an attribute with the specified type.
    /// </summary>
    /// <param name="symbol">The input <see cref="ISymbol" /> instance to check.</param>
    /// <param name="typeSymbol">The <see cref="ITypeSymbol" /> instance for the attribute type to look for.</param>
    /// <returns>Whether or not <paramref name="symbol" /> has an attribute with the specified type.</returns>
    public static bool HasAttributeWithType(this ISymbol symbol, ITypeSymbol typeSymbol) => TryGetAttributeWithType(symbol, typeSymbol, out _);

    /// <summary>
    ///     Tries to get an attribute with the specified type.
    /// </summary>
    /// <param name="symbol">The input <see cref="ISymbol" /> instance to check.</param>
    /// <param name="typeSymbol">The <see cref="ITypeSymbol" /> instance for the attribute type to look for.</param>
    /// <param name="attributeData">The resulting attribute, if it was found.</param>
    /// <returns>Whether or not <paramref name="symbol" /> has an attribute with the specified name.</returns>
    public static bool TryGetAttributeWithType(this ISymbol symbol, ITypeSymbol typeSymbol, [NotNullWhen(true)] out AttributeData? attributeData) {
        foreach (AttributeData? attribute in symbol.GetAttributes()) {
            if (SymbolEqualityComparer.Default.Equals(attribute.AttributeClass, typeSymbol)) {
                attributeData = attribute;

                return true;
            }
        }

        attributeData = null;

        return false;
    }

    /// <summary>
    ///     Tries to get an attribute with the specified fully qualified metadata name.
    /// </summary>
    /// <param name="symbol">The input <see cref="ISymbol" /> instance to check.</param>
    /// <param name="name">The attribute name to look for.</param>
    /// <param name="attributeData">The resulting attribute data, if found.</param>
    /// <returns>Whether or not <paramref name="symbol" /> has an attribute with the specified name.</returns>
    public static bool TryGetAttributeWithFullyQualifiedMetadataName(this ISymbol symbol, string name, [NotNullWhen(true)] out AttributeData? attributeData) {
        foreach (AttributeData? attribute in symbol.GetAttributes()) {
            if (attribute.AttributeClass is { } attributeSymbol &&
                attributeSymbol.HasFullyQualifiedMetadataName(name)) {
                attributeData = attribute;

                return true;
            }
        }

        attributeData = null;

        return false;
    }

    /// <summary>
    ///     Tries to get a syntax node with a given type from an input symbol.
    /// </summary>
    /// <typeparam name="T">The type of syntax node to look for.</typeparam>
    /// <param name="symbol">The input <see cref="ISymbol" /> instance to get the syntax node for.</param>
    /// <param name="token">The <see cref="CancellationToken" /> used to cancel the operation, if needed.</param>
    /// <param name="syntaxNode">The resulting <typeparamref name="T" /> syntax node, if found.</param>
    /// <returns>Whether or not a syntax node of type <typeparamref name="T" /> was retrieved successfully.</returns>
    public static bool TryGetSyntaxNode<T>(this ISymbol symbol, CancellationToken token, [NotNullWhen(true)] out T? syntaxNode)
        where T : SyntaxNode {
        // If there are no syntax references, there is nothing to do
        if (symbol.DeclaringSyntaxReferences is not [{ } syntaxReference, ..]) {
            syntaxNode = null;

            return false;
        }

        // Get the target node, and check that it's of the desired type
        var candidateNode = syntaxReference.GetSyntax(token) as T;

        syntaxNode = candidateNode;

        return candidateNode is not null;
    }
}
