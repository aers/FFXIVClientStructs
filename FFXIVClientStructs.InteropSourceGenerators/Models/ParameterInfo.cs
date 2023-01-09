using FFXIVClientStructs.InteropSourceGenerators.Extensions;
using LanguageExt;
using Microsoft.CodeAnalysis;
using static FFXIVClientStructs.InteropSourceGenerators.DiagnosticDescriptors;
using static LanguageExt.Prelude;

namespace FFXIVClientStructs.InteropSourceGenerators.Models;

internal sealed record ParameterInfo(string Name, string Type, Option<string> DefaultValue)
{
    public static Validation<DiagnosticInfo, ParameterInfo> GetFromSymbol(IParameterSymbol parameterSymbol)
    {
        return parameterSymbol.Type.IsUnmanagedType
            ? Success<DiagnosticInfo, ParameterInfo>(
                new ParameterInfo(
                    parameterSymbol.Name,
                    parameterSymbol.Type.GetFullyQualifiedNameWithGenerics(),
                    parameterSymbol.GetDefaultValueString()
                ))
            : Fail<DiagnosticInfo, ParameterInfo>(
                DiagnosticInfo.Create(
                    MethodUsesForbiddenType,
                    parameterSymbol,
                    parameterSymbol.ContainingSymbol.Name,
                    parameterSymbol.Type.GetFullyQualifiedNameWithGenerics()
                ));
    }
}