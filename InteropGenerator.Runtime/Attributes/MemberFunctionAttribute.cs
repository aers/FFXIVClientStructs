namespace InteropGenerator.Runtime.Attributes;

/// <summary>
///     InteropGenerator attribute marking a method as a stub for calling a native class member function.
///     The stub method signature should match the native function's signature, and supports static functions.
///     If the function is not static, the "this" argument (nearly always the first pointer argument) should not be
///     included.
/// </summary>
/// <param name="signature">
///     Signature resolving to the native address of the member function or a relative offset to the
///     native address.
/// </param>
/// <param name="relativeFollowOffsets">
///     After resolving signature, offset by this amount and follow the 32-bit relative
///     address found there. Repeats for each entry.
/// </param>
[AttributeUsage(AttributeTargets.Method)]
public sealed class MemberFunctionAttribute(string signature, ushort[] relativeFollowOffsets) : Attribute {
    public MemberFunctionAttribute(string signature, ushort relativeFollowOffset) : this(signature, [relativeFollowOffset]) { }
    public MemberFunctionAttribute(string signature) : this(signature, []) { }

    public string Signature { get; } = signature;
    public ushort[] RelativeFollowOffsets { get; } = relativeFollowOffsets;
}
