using Microsoft.CodeAnalysis;

namespace FFXIVClientStructs.InteropSourceGenerators.Extensions;

internal static class TypeSymbolExtensions
{
    public static string GetFullyQualifiedNameWithGenerics(this ITypeSymbol typeSymbol)
    {
        return typeSymbol.ToDisplayString(
            SymbolDisplayFormat.FullyQualifiedFormat.WithMiscellaneousOptions(
                SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier |
                SymbolDisplayMiscellaneousOptions.UseSpecialTypes).WithGenericsOptions(
                SymbolDisplayGenericsOptions.IncludeTypeParameters |
                SymbolDisplayGenericsOptions.IncludeTypeConstraints));
    }
}