using InteropGenerator.Helpers;

namespace InteropGenerator.Models;

internal sealed record FieldInfo(
    string Name,
    string Type,
    int Offset,
    EquatableArray<string> InheritableAttributes
);
