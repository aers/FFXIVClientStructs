namespace InteropGenerator.Runtime.Attributes;

/// <summary>
/// Interop Generator attribute marking the field as a fixed size array.
///
/// The field should be private and have a type of "FixedSizeArray#&lt;T>", where # is the integer size of the array and T is the type contained in the array.
///
/// For example, "private FixedSizeArray10&lt;int> _tenIntArray;" is a valid declaration.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public sealed class FixedSizeArrayAttribute : Attribute {
    
}
