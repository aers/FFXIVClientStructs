namespace InteropGenerator.Runtime.Attributes;

/// <summary>
///     Interop Generator attribute marking the field as a fixed size array.
///     The field should be private and have a type of "FixedSizeArray#&lt;T>", where # is the integer size of the array
///     and T is the type contained in the array.
///     For example, "private FixedSizeArray10&lt;int> _tenIntArray;" is a valid declaration.
/// </summary>
/// <param name="isString">Can be set to true on byte and char arrays to generate C# string accessors.</param>
/// <param name="isBitArray">Can be set to true on byte arrays to generate a BitArray accessor.</param>
/// <param name="bitCount">Must be set to the bit count when <paramref name="isBitArray"/> is true.</param>
[AttributeUsage(AttributeTargets.Field)]
public sealed class FixedSizeArrayAttribute(bool isString = false, bool isBitArray = false, int bitCount = 0) : Attribute {
    public bool IsString { get; } = isString;
    public bool IsBitArray { get; } = isBitArray;
    public int BitCount { get; } = bitCount;
}
