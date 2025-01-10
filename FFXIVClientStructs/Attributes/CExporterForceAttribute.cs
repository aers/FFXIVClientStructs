namespace FFXIVClientStructs.Attributes;

/// <summary>
/// Forces the export of a field type. This is useful for fields that get ignored by the exporter either due to <see cref="CExportIgnoreAttribute"/> or <see cref="CExporterExcelBeginAttribute"/>.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
internal class CExporterForceAttribute : Attribute;
