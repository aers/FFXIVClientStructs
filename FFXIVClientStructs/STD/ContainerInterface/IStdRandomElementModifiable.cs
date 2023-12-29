namespace FFXIVClientStructs.STD.ContainerInterface;

/// <summary>
/// Base interface for containers with items that are randomly accessible for mutation.
/// </summary>
/// <typeparam name="T">The element type.</typeparam>
public partial interface IStdRandomElementModifiable<T>
    : IDisposable
        , IStdRandomElementReadable<T>
    where T : unmanaged {
    
    /// <summary>
    /// Gets the reference of the element at given index.
    /// </summary>
    /// <param name="index">The index.</param>
    new ref T this[long index] { get; }

    /// <inheritdoc/>
    ref readonly T IStdRandomElementReadable<T>.this[long index] => ref this[index];

    /// <inheritdoc cref="List{T}.Reverse()"/>
    void Reverse();
    
    /// <inheritdoc cref="List{T}.Reverse(int,int)"/>
    void Reverse(long index, long count);
    
    /// <inheritdoc cref="List{T}.Sort()"/>
    void Sort();
    
    /// <summary>
    /// Sorts the elements in a range of elements in this vector using the default comparer.
    /// </summary>
    /// <param name="index">The zero-based starting index of the range to sort.</param>
    /// <param name="count">The length of the range to sort.</param>
    void Sort(long index, long count);
    
    /// <inheritdoc cref="List{T}.Sort(IComparer{T})"/>
    void Sort(IComparer<T>? comparer);
    
    /// <inheritdoc cref="List{T}.Sort(int,int,IComparer{T})"/>
    void Sort(long index, long count, IComparer<T>? comparer);
    
    /// <inheritdoc cref="List{T}.Sort(Comparison{T})"/>
    void Sort(Comparison<T> comparison);
    
    /// <summary>
    /// Sorts the elements in a range of elements in this vector using the specified comparison.
    /// </summary>
    /// <param name="index">The zero-based starting index of the range to sort.</param>
    /// <param name="count">The length of the range to sort.</param>
    /// <param name="comparison">The <see cref="Comparison{T}"/> to use when comparing elements.</param>
    void Sort(long index, long count, Comparison<T> comparison);
}
