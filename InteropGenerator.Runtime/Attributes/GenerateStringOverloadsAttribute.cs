namespace InteropGenerator.Runtime.Attributes;

/// <summary>
///     Interop Generator attribute marking the method for string overload generation.
///     Native functions often take C-string arguments - a byte pointer to a null terminated string. This attribute will
///     generate method overloads to ease calling these functions.
///     Generates two overloads, one taking C# string objects and one taking ReadOnlySpan&lt;byte> structs in place of the
///     byte pointers.
///     In cases where a function has a C string byte* argument and a byte* argument that represents something else, the
///     [StringIgnore] attribute can be applied to a method parameter to ignore it.
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public sealed class GenerateStringOverloadsAttribute : Attribute {
}
