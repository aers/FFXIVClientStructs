namespace FFXIVClientStructs.Attributes;

/// <summary>
/// Forces the export of a type to be set . This is useful for fields that get ignored by the exporter either due to <see cref="CExporterIgnoreAttribute"/> or <see cref="CExporterExcelBeginAttribute"/>.
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter)]
internal class CExporterTypeForceAttribute(string typeName, bool dontCheck = false) : Attribute {
    public string TypeName { get; } = typeName;
    public bool DontCheck { get; } = dontCheck;
}
