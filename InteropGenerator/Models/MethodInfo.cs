using InteropGenerator.Extensions;
using InteropGenerator.Helpers;

namespace InteropGenerator.Models;

internal sealed record MethodInfo(
    string Name,
    string Modifiers,
    string ReturnType,
    bool IsStatic,
    EquatableArray<ParameterInfo> Parameters) {

    public string GetDeclarationString() => $"{Modifiers} {ReturnType} {Name}({GetParameterTypesAndNamesString()})";
    public string GetParameterTypeString() => Parameters.Any() ? string.Join(", ", Parameters.Select(p => $"{p.RefKind.GetParameterPrefix()}{p.Type}")) + ", " : "";

    public string GetParameterNamesString() => string.Join(", ", Parameters.Select(p => $"{p.RefKind.GetParameterPrefix()}{p.Name}"));

    private string GetParameterTypesAndNamesString() => string.Join(", ", Parameters.Select(p => $"{p.RefKind.GetParameterPrefix()}{p.Type} {p.Name}"));

    public string GetReturnString() => ReturnType == "void" ? "" : "return ";
}
