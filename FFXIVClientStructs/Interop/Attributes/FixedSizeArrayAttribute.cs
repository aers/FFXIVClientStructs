namespace FFXIVClientStructs.Interop.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class FixedSizeArrayAttribute<T> : Attribute where T : unmanaged
{
    public FixedSizeArrayAttribute(int count)
    {
        this.Count = count;
    }

    public int Count { get; }
}
