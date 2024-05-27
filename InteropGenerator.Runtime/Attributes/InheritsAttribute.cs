namespace InteropGenerator.Runtime.Attributes;

/// <summary>
/// Interop Generator attribute indicating the struct should inherit public fields and methods from parent T.
/// </summary>
/// <param name="parentOffset">Explicit parent offset, overriding size-based offsetting with multiple inheritance.</param>
/// <typeparam name="T"></typeparam>
[AttributeUsage(AttributeTargets.Struct, AllowMultiple = true)]
public sealed class InheritsAttribute<T>(int parentOffset = 0) : Attribute where T : unmanaged {
    public int ParentOffset { get; } = parentOffset;
}
