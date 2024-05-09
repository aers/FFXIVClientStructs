namespace InteropGenerator.Models;

internal sealed record StaticAddressInfo(
    MethodInfo MethodInfo,
    string Signature,
    byte Offset,
    bool IsPointer);
