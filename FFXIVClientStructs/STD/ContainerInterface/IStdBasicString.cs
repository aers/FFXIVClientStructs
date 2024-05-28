using System.Numerics;

namespace FFXIVClientStructs.STD.ContainerInterface;

public interface IStdBasicString<T> : IStdVector<T>
    where T : unmanaged, IBinaryNumber<T> {
    /// <summary>
    /// Appends the given string to this basic string.
    /// Fallback chars will be used for unsupported characters.
    /// </summary>
    /// <param name="str">The string to append.</param>
    public void AddString(ReadOnlySpan<char> str);

    /// <summary>
    /// Determines if this basic string contains the given string.
    /// </summary>
    /// <param name="str"></param>
    /// <returns><c>true</c> if contains.</returns>
    public bool ContainsString(ReadOnlySpan<char> str);

    /// <summary>
    /// Finds the first occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="str">The substring.</param>
    public int IndexOfString(ReadOnlySpan<char> str);

    /// <summary>
    /// Finds the first occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="str">The substring.</param>
    /// <param name="index">The first index in this basic string to search from.</param>
    public int IndexOfString(ReadOnlySpan<char> str, int index);

    /// <summary>
    /// Finds the first occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="str">The substring.</param>
    /// <param name="index">The first index in this basic string to search from.</param>
    /// <param name="count">The number of items to search from.</param>
    public int IndexOfString(ReadOnlySpan<char> str, int index, int count);

    /// <summary>
    /// Finds the last occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="str">The substring.</param>
    public int LastIndexOfString(ReadOnlySpan<char> str);

    /// <summary>
    /// Finds the last occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="str">The substring.</param>
    /// <param name="index">The first index in this basic string to search from.</param>
    public int LastIndexOfString(ReadOnlySpan<char> str, int index);

    /// <summary>
    /// Finds the last occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="str">The substring.</param>
    /// <param name="index">The first index in this basic string to search from.</param>
    /// <param name="count">The number of items to search from.</param>
    public int LastIndexOfString(ReadOnlySpan<char> str, int index, int count);

    /// <summary>
    /// Insert the given string to the specified index of this basic string.
    /// Fallback chars will be used for unsupported characters.
    /// </summary>
    /// <param name="index">The index to insert at.</param>
    /// <param name="str">The string to insert.</param>
    public void InsertString(long index, ReadOnlySpan<char> str);

    /// <summary>
    /// Finds the first occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="str">The substring.</param>
    public long LongIndexOfString(ReadOnlySpan<char> str);

    /// <summary>
    /// Finds the first occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="str">The substring.</param>
    /// <param name="index">The first index in this basic string to search from.</param>
    public long LongIndexOfString(ReadOnlySpan<char> str, long index);

    /// <summary>
    /// Finds the first occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="str">The substring.</param>
    /// <param name="index">The first index in this basic string to search from.</param>
    /// <param name="count">The number of items to search from.</param>
    public long LongIndexOfString(ReadOnlySpan<char> str, long index, long count);

    /// <summary>
    /// Finds the last occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="str">The substring.</param>
    public long LongLastIndexOfString(ReadOnlySpan<char> str);

    /// <summary>
    /// Finds the last occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="str">The substring.</param>
    /// <param name="index">The first index in this basic string to search from.</param>
    public long LongLastIndexOfString(ReadOnlySpan<char> str, long index);

    /// <summary>
    /// Finds the last occurrence of the given string in this basic string.
    /// </summary>
    /// <param name="str">The substring.</param>
    /// <param name="index">The first index in this basic string to search from.</param>
    /// <param name="count">The number of items to search from.</param>
    public long LongLastIndexOfString(ReadOnlySpan<char> str, long index, long count);
}
