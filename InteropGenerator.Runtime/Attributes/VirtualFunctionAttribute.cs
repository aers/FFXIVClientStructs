namespace InteropGenerator.Runtime.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class VirtualFunctionAttribute(uint index) : Attribute {

    public uint Index { get; } = index;
}
