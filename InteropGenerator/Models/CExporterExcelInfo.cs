namespace InteropGenerator.Models;

internal sealed record CExporterExcelInfo(string SheetName) {
    public string GetAttribute() => $"[global::FFXIVClientStructs.Attributes.CExporterExcelAttribute(\"{SheetName}\")]";
};
