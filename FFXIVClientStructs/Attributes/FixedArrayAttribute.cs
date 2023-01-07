namespace FFXIVClientStructs.Attributes; 


/// <summary>
/// Describes a Fixed Buffer to assist with automatic parsing.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public class FixedArrayAttribute : Attribute {
    public FixedArrayAttribute(Type type, int count) {
        Type = type;
        Count = count;
    }

    public Type Type { get; }
    public int Count { get; }
}