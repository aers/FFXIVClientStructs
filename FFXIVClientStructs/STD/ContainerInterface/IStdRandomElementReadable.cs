using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace FFXIVClientStructs.STD.ContainerInterface;

/// <summary>
/// Base interface for containers with items that are randomly accessible for reading.
/// </summary>
/// <typeparam name="T">The element type.</typeparam>
/// <remarks>
/// Implementation for <see cref="ICollection"/> and its family will not work if
/// <see cref="LongCount"/> is above <see cref="int.MaxValue"/>. In such cases,
/// use <see cref="IEnumerable{T}.GetEnumerator"/>; return value itself is an <see cref="IEnumerable{T}"/>,
/// and <see cref="IDisposable.Dispose"/> is not required for these enumerators.
/// </remarks>
[SuppressMessage("ReSharper", "PossibleInterfaceMemberAmbiguity")]
public unsafe partial interface IStdRandomElementReadable<T>
    : IList
        , IList<T>
        , IReadOnlyList<T>
        , IComparable
        , IComparable<IStdRandomElementReadable<T>>
        , IEquatable<IStdRandomElementReadable<T>>
    where T : unmanaged {

    /// <summary>
    /// Representative pointer for data to deal with inserting into itself.
    /// </summary>
    void* RepresentativePointer { get; }

    /// <inheritdoc cref="LongCount"/>
    new int Count { get; }

    /// <summary>
    /// Gets the number of elements contained in this vector.
    /// </summary>
    long LongCount { get; }

    /// <summary>
    /// Gets the read-only reference of the element at given index.
    /// </summary>
    /// <param name="index">The index. Negative numbers will be counted from the end of this span after inverting.</param>
    ref readonly T this[long index] { get; }

    /// <summary>
    /// Gets the read-only reference of the element at given index.
    /// </summary>
    /// <param name="index">The index. Negative numbers will be counted from the end of this span after inverting.</param>
    new ref readonly T this[int index] { get; }

    /// <summary>
    /// Gets the read-only reference of the element at given index.
    /// </summary>
    /// <param name="index">The index.</param>
    ref readonly T this[Index index] { get; }

    /// <inheritdoc cref="List{T}.BinarySearch(T)"/>
    long BinarySearch(in T item);

    /// <inheritdoc cref="List{T}.BinarySearch(T,IComparer{T}?)"/>
    long BinarySearch(in T item, IComparer<T>? comparer);

    /// <inheritdoc cref="List{T}.BinarySearch(int,int,T,IComparer{T}?)"/>
    long BinarySearch(long index, long count, in T item, IComparer<T>? comparer);

    /// <inheritdoc cref="List{T}.Contains"/>
    bool Contains(in T item);

    /// <summary>
    /// Determines if this vector contains the specified subsequence.
    /// </summary>
    /// <param name="subsequence">The pointer to the first item in the subsequence.</param>
    /// <param name="length">The length.</param>
    /// <returns><c>true</c> if the subsequence is contained within.</returns>
    bool Contains(T* subsequence, nint length);

    /// <summary>
    /// Determines if this vector contains the specified subsequence.
    /// </summary>
    /// <param name="subsequence">The subsequence.</param>
    /// <returns><c>true</c> if the subsequence is contained within.</returns>
    bool Contains(ReadOnlySpan<T> subsequence);

    /// <inheritdoc cref="List{T}.Exists"/>
    bool Exists(Predicate<T> match);

    /// <inheritdoc cref="List{T}.Find"/>
    T? Find(Predicate<T> match);

    /// <inheritdoc cref="List{T}.FindIndex(Predicate{T})"/>
    int FindIndex(Predicate<T> match);

    /// <inheritdoc cref="List{T}.FindIndex(int, Predicate{T})"/>
    int FindIndex(int startIndex, Predicate<T> match);

    /// <inheritdoc cref="List{T}.FindIndex(int,int,Predicate{T})"/>
    int FindIndex(int startIndex, int count, Predicate<T> match);

    /// <inheritdoc cref="List{T}.FindLastIndex(Predicate{T})"/>
    int FindLastIndex(Predicate<T> match);

    /// <inheritdoc cref="List{T}.FindLastIndex(int, Predicate{T})"/>
    int FindLastIndex(int startIndex, Predicate<T> match);

    /// <inheritdoc cref="List{T}.FindLastIndex(int,int,Predicate{T})"/>
    int FindLastIndex(int startIndex, int count, Predicate<T> match);

    /// <inheritdoc cref="List{T}.ForEach"/>
    void ForEach(Action<T> action);

    /// <inheritdoc cref="List{T}.IndexOf(T)"/>
    int IndexOf(in T item);

    /// <inheritdoc cref="List{T}.IndexOf(T,int)"/>
    int IndexOf(in T item, int index);

    /// <inheritdoc cref="List{T}.IndexOf(T,int,int)"/>
    int IndexOf(in T item, int index, int count);

    /// <inheritdoc cref="LongIndexOf(System.ReadOnlySpan{T})"/>
    int IndexOf(ReadOnlySpan<T> subsequence);

    /// <inheritdoc cref="LongIndexOf(System.ReadOnlySpan{T},long)"/>
    int IndexOf(ReadOnlySpan<T> subsequence, int index);

    /// <inheritdoc cref="LongIndexOf(System.ReadOnlySpan{T},long,long)"/>
    int IndexOf(ReadOnlySpan<T> subsequence, int index, int count);

    /// <inheritdoc cref="List{T}.LastIndexOf(T)"/>
    int LastIndexOf(in T item);

    /// <inheritdoc cref="List{T}.LastIndexOf(T,int)"/>
    int LastIndexOf(in T item, int index);

    /// <inheritdoc cref="List{T}.LastIndexOf(T,int,int)"/>
    int LastIndexOf(in T item, int index, int count);

    /// <inheritdoc cref="LongLastIndexOf(System.ReadOnlySpan{T})"/>
    int LastIndexOf(ReadOnlySpan<T> subsequence);

    /// <inheritdoc cref="LongLastIndexOf(System.ReadOnlySpan{T},long)"/>
    int LastIndexOf(ReadOnlySpan<T> subsequence, int index);

    /// <inheritdoc cref="LongLastIndexOf(System.ReadOnlySpan{T},long,long)"/>
    int LastIndexOf(ReadOnlySpan<T> subsequence, int index, int count);

    /// <inheritdoc cref="List{T}.FindIndex(Predicate{T})"/>
    long LongFindIndex(Predicate<T> match);

    /// <inheritdoc cref="List{T}.FindIndex(int, Predicate{T})"/>
    long LongFindIndex(long startIndex, Predicate<T> match);

    /// <inheritdoc cref="List{T}.FindIndex(int,int,Predicate{T})"/>
    long LongFindIndex(long startIndex, long count, Predicate<T> match);

    /// <inheritdoc cref="List{T}.FindLastIndex(Predicate{T})"/>
    long LongFindLastIndex(Predicate<T> match);

    /// <inheritdoc cref="List{T}.FindIndex(int, Predicate{T})"/>
    long LongFindLastIndex(long startIndex, Predicate<T> match);

    /// <inheritdoc cref="List{T}.FindIndex(int,int,Predicate{T})"/>
    long LongFindLastIndex(long startIndex, long count, Predicate<T> match);

    /// <inheritdoc cref="List{T}.IndexOf(T)"/>
    long LongIndexOf(in T item);

    /// <inheritdoc cref="List{T}.IndexOf(T, int)"/>
    long LongIndexOf(in T item, long index);

    /// <inheritdoc cref="List{T}.IndexOf(T,int,int)"/>
    long LongIndexOf(in T item, long index, long count);

    /// <summary>
    /// Finds the specified subsequence in this vector.
    /// </summary>
    /// <param name="subsequence">The subsequence to search for.</param>
    /// <returns>Offset of the subsequence, or -1 if not found.</returns>
    long LongIndexOf(ReadOnlySpan<T> subsequence);

    /// <summary>
    /// Finds the specified subsequence in this vector.
    /// </summary>
    /// <param name="subsequence">The subsequence to search for.</param>
    /// <param name="index">The index in this vector to begin looking from.</param>
    /// <returns>Offset of the subsequence, or -1 if not found.</returns>
    long LongIndexOf(ReadOnlySpan<T> subsequence, long index);

    /// <summary>
    /// Finds the specified subsequence in this vector.
    /// </summary>
    /// <param name="subsequence">The subsequence to search for.</param>
    /// <param name="index">The index in this vector to begin looking from.</param>
    /// <param name="count">The number of items to look in.</param>
    /// <returns>Offset of the subsequence, or -1 if not found.</returns>
    long LongIndexOf(ReadOnlySpan<T> subsequence, long index, long count);

    /// <summary>
    /// Finds the specified subsequence in this vector.
    /// </summary>
    /// <param name="subsequence">The subsequence to search for.</param>
    /// <param name="subsequenceLength">The length of the subsequence.</param>
    /// <returns>Offset of the subsequence, or -1 if not found.</returns>
    long LongIndexOf(T* subsequence, nint subsequenceLength);

    /// <summary>
    /// Finds the specified subsequence in this vector.
    /// </summary>
    /// <param name="subsequence">The subsequence to search for.</param>
    /// <param name="subsequenceLength">The length of the subsequence.</param>
    /// <param name="index">The index in this vector to begin looking from.</param>
    /// <returns>Offset of the subsequence, or -1 if not found.</returns>
    long LongIndexOf(T* subsequence, nint subsequenceLength, long index);

    /// <summary>
    /// Finds the specified subsequence in this vector.
    /// </summary>
    /// <param name="subsequence">The subsequence to search for.</param>
    /// <param name="subsequenceLength">The length of the subsequence.</param>
    /// <param name="index">The index in this vector to begin looking from.</param>
    /// <param name="count">The number of items to look in.</param>
    /// <returns>Offset of the subsequence, or -1 if not found.</returns>
    long LongIndexOf(T* subsequence, nint subsequenceLength, long index, long count);

    /// <inheritdoc cref="List{T}.LastIndexOf(T)"/>
    long LongLastIndexOf(in T item);

    /// <inheritdoc cref="List{T}.LastIndexOf(T, int)"/>
    long LongLastIndexOf(in T item, long index);

    /// <inheritdoc cref="List{T}.LastIndexOf(T,int,int)"/>
    long LongLastIndexOf(in T item, long index, long count);

    /// <summary>
    /// Finds the first index of the last occurrence of the given subsequence.
    /// </summary>
    /// <param name="subsequence">The subsequence to search for.</param>
    /// <returns>The first index, or -1 if not found.</returns>
    long LongLastIndexOf(ReadOnlySpan<T> subsequence);

    /// <summary>
    /// Finds the first index of the last occurrence of the given subsequence.
    /// </summary>
    /// <param name="subsequence">The subsequence to search for.</param>
    /// <param name="index">The first index in this container to search from.</param>
    /// <returns>The first index, or -1 if not found.</returns>
    long LongLastIndexOf(ReadOnlySpan<T> subsequence, long index);

    /// <summary>
    /// Finds the first index of the last occurrence of the given subsequence.
    /// </summary>
    /// <param name="subsequence">The subsequence to search for.</param>
    /// <param name="index">The first index in this container to search from.</param>
    /// <param name="count">The number of items in this container to search from.</param>
    /// <returns>The first index, or -1 if not found.</returns>
    long LongLastIndexOf(ReadOnlySpan<T> subsequence, long index, long count);

    /// <summary>
    /// Finds the first index of the last occurrence of the given subsequence.
    /// </summary>
    /// <param name="subsequence">The subsequence to search for.</param>
    /// <param name="subsequenceLength">The length of the subsequence.</param>
    /// <returns>The first index, or -1 if not found.</returns>
    long LongLastIndexOf(T* subsequence, nint subsequenceLength);

    /// <summary>
    /// Finds the first index of the last occurrence of the given subsequence.
    /// </summary>
    /// <param name="subsequence">The subsequence to search for.</param>
    /// <param name="subsequenceLength">The length of the subsequence.</param>
    /// <param name="index">The first index in this container to search from.</param>
    /// <returns>The first index, or -1 if not found.</returns>
    long LongLastIndexOf(T* subsequence, nint subsequenceLength, long index);

    /// <summary>
    /// Finds the first index of the last occurrence of the given subsequence.
    /// </summary>
    /// <param name="subsequence">The subsequence to search for.</param>
    /// <param name="subsequenceLength">The length of the subsequence.</param>
    /// <param name="index">The first index in this container to search from.</param>
    /// <param name="count">The number of items in this container to search from.</param>
    /// <returns>The first index, or -1 if not found.</returns>
    long LongLastIndexOf(T* subsequence, nint subsequenceLength, long index, long count);

    /// <inheritdoc cref="List{T}.ToArray"/>
    T[] ToArray();

    /// <summary>
    /// Copies the elements of this vector to a new array.
    /// </summary>
    /// <param name="index">The zero-based starting index of the range to copy to a new array.</param>
    /// <returns>The new array.</returns>
    T[] ToArray(long index);

    /// <summary>
    /// Copies the elements of this vector to a new array.
    /// </summary>
    /// <param name="index">The zero-based starting index of the range to copy to a new array.</param>
    /// <param name="count">The length of the range to copy to a new array.</param>
    /// <returns>The new array.</returns>
    T[] ToArray(long index, long count);
}
