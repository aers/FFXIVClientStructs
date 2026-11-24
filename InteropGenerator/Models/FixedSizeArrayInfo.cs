using InteropGenerator.Helpers;
using Microsoft.CodeAnalysis;

namespace InteropGenerator.Models;

internal sealed record FixedSizeArrayInfo(
    string FieldName,
    Accessibility Accessibility,
    string Type,
    int Size,
    bool IsString,
    bool IsBitArray,
    int BitCount,
    EquatableArray<string> InheritableAttributes) {
    public string GetPublicFieldName() =>
        // drop _, capitalize first letter
        // _someFieldName => SomeFieldName
        FieldName[1].ToString().ToUpper() + FieldName[2..];
}
