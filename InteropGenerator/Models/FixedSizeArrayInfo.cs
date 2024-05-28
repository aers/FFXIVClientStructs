namespace InteropGenerator.Models;

internal sealed record FixedSizeArrayInfo(
    string FieldName,
    string Type,
    int Size,
    bool IsString) {
    public string GetPublicFieldName() =>
        // drop _, capitalize first letter
        // _someFieldName => SomeFieldName
        FieldName[1].ToString().ToUpper() + FieldName[2..];
}
