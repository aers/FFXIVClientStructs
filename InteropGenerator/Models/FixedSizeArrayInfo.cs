using InteropGenerator.Helpers;

namespace InteropGenerator.Models;

internal sealed record FixedSizeArrayInfo(
    string FieldName,
    string Type,
    int Size,
    bool IsString,
    EquatableArray<string> InheritableAttributes) {
    public string GetPublicFieldName() =>
        // drop _, capitalize first letter
        // _someFieldName => SomeFieldName
        FieldName[1].ToString().ToUpper() + FieldName[2..];
}
