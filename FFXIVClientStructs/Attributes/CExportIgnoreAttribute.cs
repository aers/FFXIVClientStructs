namespace FFXIVClientStructs.Attributes;

/// <summary>
/// Forces the exporter to ignore a field or struct.
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Struct | AttributeTargets.Property)]
internal class CExportIgnoreAttribute : Attribute;
