namespace FFXIVClientStructs.Attributes;

/// <summary>
/// Forces the export of a type to be set . This is useful for fields that get ignored by the exporter either due to <see cref="CExportIgnoreAttribute"/> or <see cref="CExporterExcelBeginAttribute"/>.
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter)]
internal class CExporterTypeForceAttribute(string typeName) : Attribute {
    public string TypeName { get; } = typeName;
}
