namespace FFXIVClientStructs.Attributes;

/// <summary>
/// Forces the exporter to ignore a field or struct.
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Struct)]
internal class CExportIgnoreAttribute : Attribute;
