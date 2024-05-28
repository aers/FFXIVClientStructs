namespace InteropGenerator.Models;

internal sealed record StaticAddressInfo(
    MethodInfo MethodInfo,
    SignatureInfo SignatureInfo,
    bool IsPointer);
