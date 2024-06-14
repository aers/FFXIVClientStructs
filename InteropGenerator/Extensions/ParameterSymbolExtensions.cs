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
            return defaultValue.ToString() + "f";

        return defaultValue.ToString();
    }
}
