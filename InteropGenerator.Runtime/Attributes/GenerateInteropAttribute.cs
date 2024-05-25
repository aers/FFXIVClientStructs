namespace InteropGenerator.Runtime.Attributes;

/// <summary>
///     Marks the struct as a target for generation by the Interop Generator.
///     This is required to use any other features of the generator.
///     <param name="isInherited">Set to true if this struct is inherited by another one with the Inherits attribute.</param>
/// </summary>
[AttributeUsage(AttributeTargets.Struct)]
public sealed class GenerateInteropAttribute(bool isInherited = false) : Attribute {
    public bool IsInherited { get; } = isInherited;
}
