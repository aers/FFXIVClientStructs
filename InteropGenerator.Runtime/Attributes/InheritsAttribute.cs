namespace InteropGenerator.Runtime.Attributes;

/// <summary>
/// Interop Generator attribute indicating the struct should inherit public fields and methods from parent T.
/// </summary>
/// <param name="parentOffset">Explicit parent offset, overriding size-based offsetting with multiple inheritance.</param>
/// <typeparam name="T"></typeparam>
[AttributeUsage(AttributeTargets.Struct, AllowMultiple = true)]
public sealed class InheritsAttribute<T>(int parentOffset, string vtableSignature, ushort[] relativeFollowOffsets) : Attribute where T : unmanaged {
    public int ParentOffset { get; } = parentOffset;
    public string VtableSignature { get; } = vtableSignature;
    public ushort[] RelativeFollowOffsets { get; } = relativeFollowOffsets;
    
    public InheritsAttribute(int parentOffset = 0) : this(parentOffset, string.Empty, []) { }
    public InheritsAttribute(string vtableSignature, ushort[] relativeFollowOffsets) : this(0, vtableSignature, relativeFollowOffsets) { }
    public InheritsAttribute(string vtableSignature, ushort relativeFollowOffset) : this(0, vtableSignature, [relativeFollowOffset]) { }
}
