namespace InteropGenerator.Models;

internal sealed record CExporterTypeForceInfo(string TypeName) {
    public string GetAttribute() => $"[global::FFXIVClientStructs.Attributes.CExporterTypeForceAttribute(\"{TypeName}\")]";
};
