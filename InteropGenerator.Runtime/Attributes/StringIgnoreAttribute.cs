namespace InteropGenerator.Runtime.Attributes;

/// <summary>
///     Interop Generator attribute used to mark a method parameter as ignored when using the GenerateStringOverloads
///     attribute on the method.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter)]
public sealed class StringIgnoreAttribute : Attribute {
}
