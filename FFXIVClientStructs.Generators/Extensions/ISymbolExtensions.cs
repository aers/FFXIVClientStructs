using Microsoft.CodeAnalysis;

namespace FFXIVClientStructs.Generators.Extensions;

// ReSharper disable once InconsistentNaming
internal static class ISymbolExtensions {

    private static readonly SymbolDisplayFormat ContainingTypesAndNamespaces = new(typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces);
    public static string GetNameWithContainingTypeAndNamespace(this ISymbol symbol) => symbol.ToDisplayString(ContainingTypesAndNamespaces);
}
