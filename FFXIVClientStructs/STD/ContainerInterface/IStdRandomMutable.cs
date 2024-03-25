namespace FFXIVClientStructs.STD.ContainerInterface;

/// <summary>
/// Base interface for mutable containers with items that are randomly accessible.
/// </summary>
/// <typeparam name="T">The element type.</typeparam>
public partial interface IStdRandomMutable<T>
    : IStdRandomElementModifiable<T> where T : unmanaged {

    /// <inheritdoc cref="LongCount"/>
    new int Count { get; set; }

    /// <inheritdoc/>
    int IStdRandomElementReadable<T>.Count => Count;

    /// <summary>
    /// Gets or sets the number of elements contained in this container.
    /// </summary>
    new long LongCount { get; set; }

    /// <inheritdoc/>
    long IStdRandomElementReadable<T>.LongCount => LongCount;

    /// <summary>
    /// Adds the item into the container. The item will be copied.
    /// </summary>
    /// <param name="item">The item.</param>
    void AddCopy(in T item);

    /// <summary>
    /// Adds the item into the container. The item will be moved.
    /// </summary>
    /// <param name="item">The item.</param>
    void AddMove(ref T item);

    /// <summary>
    /// Appends the collection into the container. Items will be copied.
    /// </summary>
    /// <param name="collection">The collection.</param>
    void AddRangeCopy(IEnumerable<T> collection);

    /// <summary>
    /// Appends the span into the container. Items will be copied.
    /// </summary>
    /// <param name="span">The span.</param>
    void AddSpanCopy(ReadOnlySpan<T> span);

    /// <summary>
    /// Appends the span into the container. Items will be moved.
    /// </summary>
    /// <param name="span">The span.</param>
    void AddSpanMove(Span<T> span);

    /// <summary>
    /// Clears the content of this container.
    /// </summary>
    new void Clear();

    /// <summary>
    /// Inserts the item into the container. The item will be copied.
    /// </summary>
    /// <param name="index">The zero-based index of insertion.</param>
    /// <param name="item">The item.</param>
    void InsertCopy(long index, in T item);

    /// <summary>
    /// Inserts the item into the container. The item will be moved.
    /// </summary>
    /// <param name="index">The zero-based index of insertion.</param>
    /// <param name="item">The item.</param>
    void InsertMove(long index, ref T item);

    /// <summary>
    /// Inserts the collection into the container. Items will be copied.
    /// </summary>
    /// <param name="index">The zero-based index of insertion.</param>
    /// <param name="collection">The collection.</param>
    void InsertRangeCopy(long index, IEnumerable<T> collection);

    /// <summary>
    /// Inserts the span into the container. Items will be copied.
    /// </summary>
    /// <param name="index">The zero-based index of insertion.</param>
    /// <param name="span">The span.</param>
    void InsertSpanCopy(long index, ReadOnlySpan<T> span);

    /// <summary>
    /// Inserts the span into the container. Items will be moved.
    /// </summary>
    /// <param name="index">The zero-based index of insertion.</param>
    /// <param name="span">The span.</param>
    void InsertSpanMove(long index, Span<T> span);

    /// <summary>
    /// Removes the first item that equals to <paramref name="item"/>.
    /// </summary>
    /// <param name="item">The item to remove.</param>
    /// <returns><c>true</c> if removed.</returns>
    bool Remove(in T item);

    /// <summary>
    /// Removes all the items that matches the given predicate.
    /// </summary>
    /// <param name="match">The predicate to test for deletion.</param>
    /// <returns>Number of items deleted.</returns>
    long RemoveAll(Predicate<T> match);

    /// <summary>
    /// Removes the element at the given index.
    /// </summary>
    /// <param name="index">The index of item.</param>
    void RemoveAt(long index);

    /// <summary>
    /// Removes the elements in the given range.
    /// </summary>
    /// <param name="index">The index of the first item to delete.</param>
    /// <param name="count">The number of items to delete.</param>
    void RemoveRange(long index, long count);

    /// <summary>
    /// Resizes this container to the given size. In case of expansion, the data of new items are set to zeroes.
    /// </summary>
    /// <param name="newSize">The new size.</param>
    void Resize(long newSize);

    /// <summary>
    /// Resizes this container to the given size. In case of expansion, the data of new items are set to <paramref name="defaultValue"/>.
    /// </summary>
    /// <param name="newSize">The new size.</param>
    /// <param name="defaultValue">The value for the new items.</param>
    void Resize(long newSize, in T defaultValue);
}
