namespace InteropGenerator.Runtime.Attributes;

/// <summary>
/// Marks the struct as a target for generation by the Interop Generator.
/// This is required to use any other features of the generator.
/// </summary>
[AttributeUsage(AttributeTargets.Struct)]
public sealed class GenerateInteropAttribute : Attribute;
