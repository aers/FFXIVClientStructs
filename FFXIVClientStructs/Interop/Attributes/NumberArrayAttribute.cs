namespace FFXIVClientStructs.Interop.Attributes;

[AttributeUsage(AttributeTargets.Struct)]
public class NumberArrayAttribute : Attribute
{
    public NumberArrayAttribute(uint arrayIndex) {
        Index = arrayIndex;
    }

    public uint Index { get; }
}