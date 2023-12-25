using System.Numerics;
using System.Text;

namespace FFXIVClientStructs.STD.StdHelpers;

public unsafe interface IStdBasicString<T> : IStdVector<T>, IComparable, IComparable<IStdBasicString<T>>, IEquatable<IStdBasicString<T>> 
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
    /// Insert the given string to the specified index of this basic string.
    /// Fallback chars will be used for unsupported characters.
    /// </summary>
    /// <param name="encoding">The encoding.</param>
    /// <param name="index">The index to insert at.</param>
    /// <param name="str">The string to insert.</param>
    public void InsertString(Encoding encoding, long index, ReadOnlySpan<char> str);
}
