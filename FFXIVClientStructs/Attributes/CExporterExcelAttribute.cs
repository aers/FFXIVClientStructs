namespace FFXIVClientStructs.Attributes;

/// <summary>
/// Represents the fields that follows this attribute should be set to the given sheet struct group.
/// Must end group with <see cref="CExporterExcelEndAttribute"/>.
/// </summary>
/// <param name="SheetName">The sheet to be used.</param>
/// <example>[FieldOffset(0xD80 + 0x00), CExporterExcel("InstanceContent")] public uint NewPlayerBonusGil;</example>
[AttributeUsage(AttributeTargets.Field)]
internal class CExporterExcelBeginAttribute(string SheetName) : Attribute {
    public string SheetName { get; } = SheetName;
}

/// <summary>
/// Represents the end of a sheet struct group.
/// Must be used after <see cref="CExporterExcelBeginAttribute"/> to have an effect.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
internal class CExporterExcelEndAttribute : Attribute;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Method)]
internal class CExporterExcelAttribute(string SheetName) : Attribute {
    public string SheetName { get; } = SheetName;
}
