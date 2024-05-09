namespace InteropGenerator.Runtime.Attributes;

/// <summary>
/// InteropGenerator attribute marking a method as a stub for calling a native class member function.
/// The stub method signature should match the native function's signature, and supports static functions.
/// If the function is not static, the "this" argument (nearly always the first pointer argument) should not be included.
/// </summary>
/// <param name="signature">Signature resolving to the native address of the member function or a relative offset to the native address.</param>
/// <param name="relativeFollowOffset">After resolving signature, offset by this amount and follow the 32-bit relative address found there. This is handled automatically for CALL (E8) and JMP (E9) signatures.</param>
[AttributeUsage(AttributeTargets.Method)]
public sealed class MemberFunctionAttribute(string signature, byte relativeFollowOffset = 0) : Attribute {
    public string Signature { get; } = signature;
    public byte RelativeFollowOffset { get; } = relativeFollowOffset;
}
