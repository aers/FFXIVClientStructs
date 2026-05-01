namespace InteropGenerator.Runtime.Attributes;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public sealed class BitFieldAttribute<T>(string name, int index, int length = 1) : Attribute {
    public string Name { get; } = name;
    public int Index { get; } = index;
    public int Length { get; } = length;
}
