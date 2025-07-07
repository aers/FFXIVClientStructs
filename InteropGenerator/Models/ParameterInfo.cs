using InteropGenerator.Helpers;
using Microsoft.CodeAnalysis;

namespace InteropGenerator.Models;

internal sealed record ParameterInfo(
    string Name,
    string Type,
    string? DefaultValue,
    RefKind RefKind,
    EquatableArray<string>? InheritableAttributes) {
    public string GetDefaultValue() => DefaultValue is null ? string.Empty : $" = {DefaultValue}";
    public string GetAttributeString() => InheritableAttributes is null ? string.Empty : string.Join("", InheritableAttributes);
}
