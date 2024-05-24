namespace InteropGenerator.Runtime.Attributes;

[AttributeUsage(AttributeTargets.Struct, AllowMultiple = true)]
public sealed class InheritsAttribute<T>(int parentOffset = 0) : Attribute where T : unmanaged {
    public int ParentOffset { get; } = parentOffset;
}
