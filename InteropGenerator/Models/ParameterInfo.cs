using Microsoft.CodeAnalysis;

namespace InteropGenerator.Models;

internal sealed record ParameterInfo(
    string Name,
    string Type,
    string? DefaultValue,
    RefKind RefKind,
    CExporterExcelInfo? CExporterExcelInfo,
    CExporterTypeForceInfo? CExporterTypeForceInfo) {
    public string GetDefaultValue() => DefaultValue is null ? string.Empty : $" = {DefaultValue}";
    public string GetAttributes() => (CExporterExcelInfo is null ? string.Empty : CExporterExcelInfo.GetAttribute()) + 
                                     (CExporterTypeForceInfo is null ? string.Empty : CExporterTypeForceInfo.GetAttribute());
};
