namespace InteropGenerator.Runtime.Attributes;

/// <summary>
///     InteropGenerator attribute marking a method as a stub for returning a static address from the native binary.
///     The stub should return a pointer to the type at the static address. If the type at the static address is a pointer,
///     set isPointer true and leave the return type as a single pointer.
/// </summary>
/// <param name="signature">Signature resolving to a reference to the native static address.</param>
/// <param name="relativeFollowOffset">
///     After resolving signature, offset by this amount and follow the 32-bit relative
///     address found there.
/// </param>
/// <param name="isPointer">
///     Set to true if the native static address is a pointer. This changes the code generation to
///     avoid necessitating double pointer return values.
/// </param>
[AttributeUsage(AttributeTargets.Method)]
public sealed class StaticAddressAttribute(string signature, byte relativeFollowOffset, bool isPointer = false) : Attribute {

    public string Signature { get; } = signature;
    public byte RelativeFollowOffset { get; } = relativeFollowOffset;
    public bool IsPointer { get; } = isPointer;
}
