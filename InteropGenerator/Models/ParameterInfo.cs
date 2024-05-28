using Microsoft.CodeAnalysis;

namespace InteropGenerator.Models;

internal sealed record ParameterInfo(
    string Name,
    string Type,
    string? DefaultValue,
    RefKind RefKind) {
    public string GetDefaultValue() => DefaultValue is null ? string.Empty : $" = {DefaultValue}";
};
