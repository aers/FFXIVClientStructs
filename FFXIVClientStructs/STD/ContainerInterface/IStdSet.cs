using System.Collections;
using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.STD.Helper;

namespace FFXIVClientStructs.STD.ContainerInterface;

[SuppressMessage("ReSharper", "PossibleInterfaceMemberAmbiguity")]
public interface IStdSet<T> : IReadOnlySet<T>, ISet<T>, ICollection, IDisposable where T : unmanaged {
    /// <summary>
    /// Gets the number of items, in <see cref="long"/>.
    /// </summary>
    long LongCount { get; }
    
    /// <summary>
    /// Gets the number of items.
    /// </summary>
    new int Count { get; }

    #region Collection interfaces

    int ICollection.Count => Count;
    int ICollection<T>.Count => Count;
    int IReadOnlyCollection<T>.Count => Count;

    bool ICollection<T>.IsReadOnly => false;
    bool ICollection.IsSynchronized => false;
    object ICollection.SyncRoot => Array.Empty<byte>();

    #endregion
    
    /// <summary>
    /// Returns an <see cref="IEnumerable{T}"/> that iterates over the set in sorted order.
    /// </summary>
    /// <returns>An enumerator that iterates over the set in sorted order.</returns>
    new RedBlackTree<T>.Enumerator GetEnumerator();
    
    /// <summary>
    /// Returns an <see cref="IEnumerable{T}"/> that iterates over the set in reverse order.
    /// </summary>
    /// <returns>An enumerator that iterates over the set in reverse order.</returns>
    RedBlackTree<T>.Enumerator Reverse();
    
    /// <summary>
    /// Adds an item as a copy of <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>Whether an item has been added.</returns>
    bool AddCopy(in T value);
    
    /// <summary>
    /// Adds an item as a move of <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>Whether an item has been moved.</returns>
    bool AddMove(ref T value);
    
    /// <summary>
    /// Determines if the set contains <paramref name="item"/>.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns><c>true</c> if contains.</returns>
    bool Contains(in T item);

    /// <summary>
    /// Removes the given item, if it exists.
    /// </summary>
    /// <param name="item">The item to remove.</param>
    /// <returns><c>true</c> if the item existed and got removed.</returns>
    public bool Remove(in T item);
    
    /// <summary>
    /// Returns the minimum value.
    /// </summary>
    /// <returns>The minimum value.</returns>
    ref readonly T Min();
    
    /// <summary>
    /// Returns the maximum value.
    /// </summary>
    /// <returns>The maximum value.</returns>
    ref readonly T Max();
    
    /// <summary>
    /// Creates a new array, containing data of the set in sorted order.
    /// </summary>
    /// <returns>The new array.</returns>
    T[] ToArray();
    
    /// <summary>
    /// Creates a new array, containing data of the set in reverse order.
    /// </summary>
    /// <returns>The new array.</returns>
    T[] ToArrayReverse();

    #region Collection interfaces

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

    void ICollection.CopyTo(Array array, int index) {
        if (array is not T[] typedArray)
            throw new ArgumentException(null, nameof(array));
        CopyTo(typedArray, index);
    }

    void ICollection<T>.Add(T item) => AddCopy(item);

    bool ICollection<T>.Contains(T item) => Contains(item);

    bool ICollection<T>.Remove(T item) => Remove(item);

    bool ISet<T>.Add(T item) => AddCopy(item);

    bool IReadOnlySet<T>.Contains(T item) => Contains(item);

    #endregion
}
