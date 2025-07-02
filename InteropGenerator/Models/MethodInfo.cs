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
    EquatableArray<ParameterInfo> Parameters,
    ObsoleteInfo? ObsoleteInfo,
    CExporterExcelInfo? CExporterExcelInfo) {

    public string GetDeclarationString() => $"{Modifiers} {ReturnType} {Name}({GetParameterTypesAndNamesString()}){GenericConstraints}";

    public string GetDeclarationStringWithAttributes() => $"{Modifiers} {ReturnType} {Name}({GetParameterTypesAndNamesStringWithAttributes()}){GenericConstraints}";

    public string GetDeclarationStringWithoutPartial() => $"{Modifiers.Replace(" partial", string.Empty)} {ReturnType} {Name}({GetParameterTypesAndNamesStringWithAttributesAndDefaults()}){GenericConstraints}";

    public string GetDeclarationStringForDelegateType(string structType) {
        var paramTypesAndNames = $"{structType}* thisPtr";
        if (!Parameters.IsEmpty) {
            paramTypesAndNames += $", {GetParameterTypesAndNamesString()}";
        }
        return $"{Modifiers.Replace(" partial", string.Empty)} delegate {ReturnType} {Name}({paramTypesAndNames});";
    }

    public string GetDeclarationStringForStringOverload(string typeReplacement, ImmutableArray<string> paramsToOverload) {
        string parameterTypesAndNamesString = string.Join(", ",
            Parameters.Select(p => paramsToOverload.Contains(p.Name) ? $"{p.RefKind.GetStringPrefix()}{typeReplacement} {p.Name}" : $"{p.RefKind.GetStringPrefix()}{p.Type} {p.Name}{p.GetDefaultValue()}"));

        return $"{Modifiers.Replace(" partial", string.Empty)} {ReturnType} {Name}({parameterTypesAndNamesString}){GenericConstraints}";
    }

    public string GetParameterTypeStringWithTrailingType() => Parameters.Any() ? string.Join(", ", Parameters.Select(p => $"{p.RefKind.GetStringPrefix()}{p.Type}")) + ", " : "";

    public string GetParameterTypeStringForCref() => Parameters.Any() ? string.Join(", ", Parameters.Select(p => $"{p.RefKind.GetStringPrefix()}{p.Type.Replace('<', '{').Replace('>', '}')}")) : "";


    public string GetParameterNamesString() => string.Join(", ", Parameters.Select(p => $"{p.RefKind.GetStringPrefix()}{p.Name}"));

    public string GetParameterNamesStringForStringOverload(ImmutableArray<string> paramsToOverload) =>
        string.Join(", ", Parameters.Select(p => paramsToOverload.Contains(p.Name) ? $"{p.RefKind.GetStringPrefix()}{p.Name}Ptr" : $"{p.RefKind.GetStringPrefix()}{p.Name}"));

    public string GetParameterTypesAndNamesString() => string.Join(", ", Parameters.Select(p => $"{p.RefKind.GetStringPrefix()}{p.Type} {p.Name}"));

    private string GetParameterTypesAndNamesStringWithDefaults() => string.Join(", ", Parameters.Select(p => $"{p.RefKind.GetStringPrefix()}{p.Type} {p.Name}{p.GetDefaultValue()}"));

    public string GetParameterTypesAndNamesStringWithAttributes() => string.Join(", ", Parameters.Select(p => $"{p.GetAttributes()}{p.RefKind.GetStringPrefix()}{p.Type} {p.Name}"));

    public string GetParameterTypesAndNamesStringWithAttributesAndDefaults() => string.Join(", ", Parameters.Select(p => $"{p.GetAttributes()}{p.RefKind.GetStringPrefix()}{p.Type} {p.Name}{p.GetDefaultValue()}"));
    
    public string GetReturnString() => ReturnType == "void" ? "" : "return ";
}
