using System.Numerics;
using System.Text;

namespace FFXIVClientStructs.STD.StdHelpers;

public interface IStdBasicString<T> : IContinuousStorageContainer<T>, IComparable, IComparable<IStdBasicString<T>>, IEquatable<IStdBasicString<T>> 
    where T : unmanaged, IBinaryNumber<T> {
    /// <summary>
    /// Gets the encoding implied by the container.
    /// </summary>
    public Encoding? IntrinsicEncoding { get; }

    /// <summary>
    /// Decodes the buffer using the specified encoding.
    /// </summary>
    /// <param name="encoding">The encoding.</param>
    /// <returns>The decoded string.</returns>
    public string Decode(Encoding encoding);

    /// <summary>
    /// Appends the given string to this basic string.
    /// Fallback chars will be used for unsupported characters.
    /// </summary>
    /// <param name="encoding">The encoding.</param>
    /// <param name="str">The string to append.</param>
    public void AddString(Encoding encoding, ReadOnlySpan<char> str);

    /// <summary>
    /// Determines if this basic string contains the given string.
    /// </summary>
    /// <param name="encoding"></param>
    /// <param name="str"></param>
    /// <returns><c>true</c> if contains.</returns>
    public bool ContainsString(Encoding encoding, ReadOnlySpan<char> str);

    /// <summary>
    /// Finds the first occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="encoding">The encoding to interpret the string as.</param>
    /// <param name="str">The substring.</param>
    public int IndexOfString(Encoding encoding, ReadOnlySpan<char> str);

    /// <summary>
    /// Finds the first occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="encoding">The encoding to interpret the string as.</param>
    /// <param name="str">The substring.</param>
    /// <param name="index">The first index in this basic string to search from.</param>
    public int IndexOfString(Encoding encoding, ReadOnlySpan<char> str, int index);

    /// <summary>
    /// Finds the first occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="encoding">The encoding to interpret the string as.</param>
    /// <param name="str">The substring.</param>
    /// <param name="index">The first index in this basic string to search from.</param>
    /// <param name="count">The number of items to search from.</param>
    public int IndexOfString(Encoding encoding, ReadOnlySpan<char> str, int index, int count);

    /// <summary>
    /// Finds the last occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="encoding">The encoding to interpret the string as.</param>
    /// <param name="str">The substring.</param>
    public int LastIndexOfString(Encoding encoding, ReadOnlySpan<char> str);

    /// <summary>
    /// Finds the last occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="encoding">The encoding to interpret the string as.</param>
    /// <param name="str">The substring.</param>
    /// <param name="index">The first index in this basic string to search from.</param>
    public int LastIndexOfString(Encoding encoding, ReadOnlySpan<char> str, int index);

    /// <summary>
    /// Finds the last occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="encoding">The encoding to interpret the string as.</param>
    /// <param name="str">The substring.</param>
    /// <param name="index">The first index in this basic string to search from.</param>
    /// <param name="count">The number of items to search from.</param>
    public int LastIndexOfString(Encoding encoding, ReadOnlySpan<char> str, int index, int count);

    /// <summary>
    /// Insert the given string to the specified index of this basic string.
    /// Fallback chars will be used for unsupported characters.
    /// </summary>
    /// <param name="encoding">The encoding.</param>
    /// <param name="index">The index to insert at.</param>
    /// <param name="str">The string to insert.</param>
    public void InsertString(Encoding encoding, long index, ReadOnlySpan<char> str);

    /// <summary>
    /// Finds the first occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="encoding">The encoding to interpret the string as.</param>
    /// <param name="str">The substring.</param>
    public long LongIndexOfString(Encoding encoding, ReadOnlySpan<char> str);

    /// <summary>
    /// Finds the first occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="encoding">The encoding to interpret the string as.</param>
    /// <param name="str">The substring.</param>
    /// <param name="index">The first index in this basic string to search from.</param>
    public long LongIndexOfString(Encoding encoding, ReadOnlySpan<char> str, long index);

    /// <summary>
    /// Finds the first occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="encoding">The encoding to interpret the string as.</param>
    /// <param name="str">The substring.</param>
    /// <param name="index">The first index in this basic string to search from.</param>
    /// <param name="count">The number of items to search from.</param>
    public long LongIndexOfString(Encoding encoding, ReadOnlySpan<char> str, long index, long count);

    /// <summary>
    /// Finds the last occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="encoding">The encoding to interpret the string as.</param>
    /// <param name="str">The substring.</param>
    public long LongLastIndexOfString(Encoding encoding, ReadOnlySpan<char> str);

    /// <summary>
    /// Finds the last occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="encoding">The encoding to interpret the string as.</param>
    /// <param name="str">The substring.</param>
    /// <param name="index">The first index in this basic string to search from.</param>
    public long LongLastIndexOfString(Encoding encoding, ReadOnlySpan<char> str, long index);

    /// <summary>
    /// Finds the last occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="encoding">The encoding to interpret the string as.</param>
    /// <param name="str">The substring.</param>
    /// <param name="index">The first index in this basic string to search from.</param>
    /// <param name="count">The number of items to search from.</param>
    public long LongLastIndexOfString(Encoding encoding, ReadOnlySpan<char> str, long index, long count);
}
