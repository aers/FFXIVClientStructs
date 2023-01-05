using LanguageExt;
using Microsoft.CodeAnalysis;
using static FFXIVClientStructs.InteropSourceGenerators.DiagnosticDescriptors;
using static LanguageExt.Prelude;

namespace FFXIVClientStructs.InteropSourceGenerators.Models;

internal sealed record SignatureInfo(string Signature)
{
    public static Validation<DiagnosticInfo, SignatureInfo> GetValidatedSignature(string signature,
        IMethodSymbol location)
    {
        return IsValid(signature)
            ? Success<DiagnosticInfo, SignatureInfo>(new SignatureInfo(signature))
            : Fail<DiagnosticInfo, SignatureInfo>(
                DiagnosticInfo.Create(
                    InvalidSignature,
                    location,
                    signature
                ));
    }

    private static bool IsValid(string signature)
    {
        return signature.Split(' ').Any(subString => subString.Length != 2);
    }
}