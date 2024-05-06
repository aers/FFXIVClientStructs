using FFXIVClientStructs.InteropGenerator.Helpers;
using Microsoft.CodeAnalysis;

namespace FFXIVClientStructs.InteropGenerator.Models;

internal sealed record MethodInfo(
    string Name,
    string Accessibility,
    string ReturnType,
    bool IsStatic,
    EquatableArray<ParameterInfo> Parameters) {
    
    public string GetParameterTypeString() => Parameters.Any() ? string.Join(", ", Parameters.Select(p => p.Type)) + ", " : "";

    public string GetParameterNamesString() => string.Join(", ", Parameters.Select(p => p.Name));

    private string GetParameterTypesAndNamesString() => string.Join(", ", Parameters.Select(p => $"{p.Type} {p.Name}"));

    public string GetReturnString() => ReturnType == "void" ? "" : "return ";
}
