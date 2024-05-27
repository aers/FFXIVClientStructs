using System.Collections.Immutable;
using InteropGenerator.Extensions;
using InteropGenerator.Helpers;

namespace InteropGenerator.Models;

internal sealed record MethodInfo(
    string Name,
    string Modifiers,
    string ReturnType,
    string GenericConstraints,
    bool IsStatic,
    EquatableArray<ParameterInfo> Parameters) {

    public string GetDeclarationString() => $"{Modifiers} {ReturnType} {Name}({GetParameterTypesAndNamesString()}){GenericConstraints}";

    public string GetDeclarationStringWithoutPartial() => $"{Modifiers.Replace(" partial", string.Empty)} {ReturnType} {Name}({GetParameterTypesAndNamesStringWithDefaults()}){GenericConstraints}";

    public string GetStringOverloadDeclarationString(string typeReplacement, ImmutableArray<string> paramsToOverload) {
        string parameterTypesAndNamesString = string.Join(", ",
            Parameters.Select(p => paramsToOverload.Contains(p.Name) ? $"{p.RefKind.GetParameterPrefix()}{typeReplacement} {p.Name}" : $"{p.RefKind.GetParameterPrefix()}{p.Type} {p.Name}{p.GetDefaultValue()}"));

        return $"{Modifiers.Replace(" partial", string.Empty)} {ReturnType} {Name}({parameterTypesAndNamesString}){GenericConstraints}";
    }

    public string GetParameterTypeStringWithTrailingType() => Parameters.Any() ? string.Join(", ", Parameters.Select(p => $"{p.RefKind.GetParameterPrefix()}{p.Type}")) + ", " : "";
    
    public string GetParameterTypeStringForCref() => Parameters.Any() ? string.Join(", ", Parameters.Select(p => $"{p.RefKind.GetParameterPrefix()}{p.Type.Replace('<', '{').Replace('>', '}')}")) : "";


    public string GetParameterNamesString() => string.Join(", ", Parameters.Select(p => $"{p.RefKind.GetParameterPrefix()}{p.Name}"));

    public string GetStringOverloadParameterNamesString(ImmutableArray<string> paramsToOverload) =>
        string.Join(", ", Parameters.Select(p => paramsToOverload.Contains(p.Name) ? $"{p.RefKind.GetParameterPrefix()}{p.Name}Ptr" : $"{p.RefKind.GetParameterPrefix()}{p.Name}"));

    private string GetParameterTypesAndNamesString() => string.Join(", ", Parameters.Select(p => $"{p.RefKind.GetParameterPrefix()}{p.Type} {p.Name}"));
    
    private string GetParameterTypesAndNamesStringWithDefaults() => string.Join(", ", Parameters.Select(p => $"{p.RefKind.GetParameterPrefix()}{p.Type} {p.Name}{p.GetDefaultValue()}"));


    public string GetReturnString() => ReturnType == "void" ? "" : "return ";
}
