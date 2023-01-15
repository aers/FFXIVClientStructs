using LanguageExt;
using Microsoft.CodeAnalysis;

namespace FFXIVClientStructs.InteropSourceGenerators.Extensions;

internal static class SymbolExtensions
{
    public static Option<AttributeData> GetFirstAttributeDataByTypeName(this ISymbol symbol, string typeName)
    {
        return symbol.GetAttributes()
            .FirstOrDefault(attributeData => attributeData.AttributeClass?.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithGenericsOptions(SymbolDisplayGenericsOptions.None)) == "global::" + typeName);
    }
}