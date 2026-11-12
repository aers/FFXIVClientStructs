using Microsoft.CodeAnalysis;

namespace InteropGenerator.Extensions;

/// <summary>
///     Extension methods for <see cref="IParameterSymbol" /> types.
/// </summary>
// ReSharper disable once InconsistentNaming
internal static class IParameterSymbolExtensions {
    public static string? GetDefaultValueString(this IParameterSymbol symbol) {
        if (!symbol.HasExplicitDefaultValue)
            return null;

        object? defaultValue = symbol.ExplicitDefaultValue;

        if (defaultValue is null)
            return "null";

        if (defaultValue is bool boolValue)
            return boolValue.ToLowercaseString();

        if (defaultValue is float floatValue)
            return defaultValue + "f";

        var type = symbol.Type;

        if (type is INamedTypeSymbol { OriginalDefinition.SpecialType: SpecialType.System_Nullable_T } nullable)
            type = nullable.TypeArguments[0];

        if (type is not INamedTypeSymbol { TypeKind: TypeKind.Enum } enumType)
            return defaultValue.ToString();

        var member = enumType.GetMembers().OfType<IFieldSymbol>().FirstOrDefault(f => f.HasConstantValue && Equals(f.ConstantValue, defaultValue));
        var enumNameFullyQualified = enumType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);

        return member is not null ? $"{enumNameFullyQualified}.{member.Name}" : $"({enumNameFullyQualified}){defaultValue}";
    }
}
