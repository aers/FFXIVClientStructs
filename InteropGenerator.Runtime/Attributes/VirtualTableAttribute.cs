using System.Collections.Immutable;

namespace InteropGenerator.Runtime.Attributes;

/// <summary>
///     InteropGenerator attribute that generates a static reference to the address of a native class's virtual table.
/// </summary>
/// <param name="signature">Signature resolving to a reference to the native virtual table address.</param>
/// <param name="relativeFollowOffsets">
///     After resolving signature, offset by this amount and follow the 32-bit relative
///     address found there. Repeats for each entry.
/// </param>
[AttributeUsage(AttributeTargets.Struct)]
public sealed class VirtualTableAttribute(string signature, ushort[] relativeFollowOffsets) : Attribute {
    public VirtualTableAttribute(string signature, ushort relativeFollowOffset) : this(signature, [relativeFollowOffset]) { }
    public string Signature { get; } = signature;
    public ushort[] RelativeFollowOffsets { get; } = relativeFollowOffsets;
}
