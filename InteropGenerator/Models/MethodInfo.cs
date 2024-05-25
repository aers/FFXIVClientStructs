using System.Collections.Immutable;
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
    
    public string GetDeclarationStringWithoutPartial() => $"{Modifiers.Replace(" partial", string.Empty)} {ReturnType} {Name}({GetParameterTypesAndNamesString()})";

    public string GetStringOverloadDeclarationString(string typeReplacement, ImmutableArray<string> paramsToOverload) {
        string parameterTypesAndNamesString = string.Join(", ",
            Parameters.Select(p => paramsToOverload.Contains(p.Name) ? $"{p.RefKind.GetParameterPrefix()}{typeReplacement} {p.Name}" : $"{p.RefKind.GetParameterPrefix()}{p.Type} {p.Name}"));

        return $"{Modifiers.Replace(" partial", string.Empty)} {ReturnType} {Name}({parameterTypesAndNamesString})";
    }

    public string GetParameterTypeString() => Parameters.Any() ? string.Join(", ", Parameters.Select(p => $"{p.RefKind.GetParameterPrefix()}{p.Type}")) + ", " : "";

    public string GetParameterNamesString() => string.Join(", ", Parameters.Select(p => $"{p.RefKind.GetParameterPrefix()}{p.Name}"));

    public string GetStringOverloadParameterNamesString(ImmutableArray<string> paramsToOverload) =>
        string.Join(", ", Parameters.Select(p => paramsToOverload.Contains(p.Name) ? $"{p.RefKind.GetParameterPrefix()}{p.Name}Ptr" : $"{p.RefKind.GetParameterPrefix()}{p.Name}"));

    private string GetParameterTypesAndNamesString() => string.Join(", ", Parameters.Select(p => $"{p.RefKind.GetParameterPrefix()}{p.Type} {p.Name}"));

    public string GetReturnString() => ReturnType == "void" ? "" : "return ";
}
