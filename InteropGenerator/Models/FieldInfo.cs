namespace InteropGenerator.Models;

internal sealed record FieldInfo(
    string Name,
    string Type,
    int Offset,
    ObsoleteInfo? ObsoleteInfo);
