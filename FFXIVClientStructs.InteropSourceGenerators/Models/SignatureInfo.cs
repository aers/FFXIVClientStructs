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
        return signature.Split(' ').All(subString => subString.Length == 2);
    }

    public string GetByteArrayString()
    {
        return "new byte[] {" + string.Join(", ", Signature.Replace("??", "00").Split().Select(s => "0x" + s)) + "}";
    }

    public string GetMaskArrayString()
    {
        return "new bool[] {" + string.Join(", ", Signature.Split().Select(s => s == "??" ? "false" : "true")) + "}";
    }
}