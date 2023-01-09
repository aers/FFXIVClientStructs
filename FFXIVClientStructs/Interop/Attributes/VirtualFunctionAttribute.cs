namespace FFXIVClientStructs.Interop.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class VirtualFunctionAttribute : Attribute
{
    public VirtualFunctionAttribute(uint index)
    {
        this.Index = index;
    }
    
    public uint Index { get; }
}