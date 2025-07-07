namespace InteropGenerator.Runtime.Attributes;

/// <summary>
///     InteropGenerator attribute that generates a static reference to the address of a native class's virtual table.
/// </summary>
/// <param name="signature">Signature resolving to a reference to the native virtual table address.</param>
/// <param name="relativeFollowOffsets">
///     After resolving signature, offset by this amount and follow the 32-bit relative
///     address found there. Repeats for each entry.
/// </param>
/// <param name="functionCount">Optional count of functions in the virtual table. Used to set the size of the table struct.</param>
[AttributeUsage(AttributeTargets.Struct)]
public sealed class VirtualTableAttribute(string signature, ushort[] relativeFollowOffsets, uint functionCount = 0) : Attribute {
    public VirtualTableAttribute(string signature, ushort relativeFollowOffset, uint functionCount = 0) : this(signature, [relativeFollowOffset], functionCount) { }
    public string Signature { get; } = signature;
    public ushort[] RelativeFollowOffsets { get; } = relativeFollowOffsets;
    public uint FunctionCount { get; } = functionCount;
}
