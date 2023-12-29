using System.Diagnostics.CodeAnalysis;

namespace FFXIVClientStructs.STD.ContainerInterface;

/// <summary>
/// Base interface for containers with continuous data storage.
/// </summary>
/// <typeparam name="T">The element type.</typeparam>
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public interface IStdVector<T> : IStdRandomMutable<T>
    where T : unmanaged {

    /// <inheritdoc cref="LongCapacity"/>
    int Capacity { get; set; }

    /// <summary>
    /// Gets or sets the total number of elements the internal data structure can hold without resizing.
    /// </summary>
    long LongCapacity { get; set; }

    /// <summary>
    /// Gets the <see cref="Span{T}"/> view of this vector.
    /// </summary>
    /// <returns>The span.</returns>
    Span<T> AsSpan();

    /// <summary>
    /// Gets the <see cref="Span{T}"/> view of this vector.
    /// </summary>
    /// <param name="index">The starting index.</param>
    /// <returns>The span.</returns>
    Span<T> AsSpan(long index);

    /// <summary>
    /// Gets the <see cref="Span{T}"/> view of this vector.
    /// </summary>
    /// <param name="index">The starting index.</param>
    /// <param name="count">The number of items.</param>
    /// <returns>The span.</returns>
    Span<T> AsSpan(long index, int count);

    /// <see cref="List{T}.EnsureCapacity"/>
    long EnsureCapacity(long capacity);

    /// <see cref="List{T}.TrimExcess"/>
    long TrimExcess();

    /// <summary>
    /// Sets the capacity of this vector.
    /// </summary>
    /// <param name="newCapacity">The new capacity. Must be at least <see cref="StdVector{T,TMemorySpace}.LongCount"/>.</param>
    /// <returns>The new capacity.</returns>
    /// <exception cref="ArgumentOutOfRangeException">When <paramref name="newCapacity"/> is less than <see cref="StdVector{T,TMemorySpace}.LongCount"/>.</exception>
    /// <exception cref="OutOfMemoryException">When failed to allocate memory as requested.</exception>
    long SetCapacity(long newCapacity);
}
