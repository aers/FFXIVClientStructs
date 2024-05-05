namespace FFXIVClientStructs.InteropGenerator.Runtime.Attributes;

/// <summary>
///     Marks the struct as a target for generation by the Interop Generator.
/// </summary>
[AttributeUsage(AttributeTargets.Struct)]
public sealed class GenerateInteropAttribute : Attribute;
