namespace FFXIVClientStructs.Interop.Attributes;

[AttributeUsage(AttributeTargets.Struct)]
public class VTableAddressAttribute : Attribute {
    public VTableAddressAttribute(string signature, int offset, bool isPointer = false) {
        Signature = signature;
        Offset = offset;
        IsPointer = isPointer;
    }

    public string Signature { get; }
    public int Offset { get; }
    public bool IsPointer { get; }
}
