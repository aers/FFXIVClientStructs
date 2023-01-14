namespace FFXIVClientStructs.Interop.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class StaticAddressAttribute : Attribute
{
    public StaticAddressAttribute(string signature, int offset, bool isPointer = false)
    {
        Signature = signature;
        Offset = offset;
        IsPointer = isPointer;
    }

    public string Signature { get; }
    public int Offset { get; }
    public bool IsPointer { get; }
}