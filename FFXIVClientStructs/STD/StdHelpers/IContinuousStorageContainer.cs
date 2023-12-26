using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace FFXIVClientStructs.STD.StdHelpers;

/// <summary>
/// Base interface for containers with continuous data storage.
/// </summary>
/// <typeparam name="T">The element type.</typeparam>
/// <remarks>
/// Implementation for <see cref="ICollection"/> and its family will not work if
/// <see cref="LongCount"/> is above <see cref="int.MaxValue"/>. In such cases,
/// use <see cref="GetEnumerator"/>; return value itself is an <see cref="IEnumerable{T}"/>,
/// and <see cref="IDisposable.Dispose"/> is not required for these enumerators.
/// </remarks>
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "PossibleInterfaceMemberAmbiguity")]
public unsafe interface IContinuousStorageContainer<T> : IDisposable, IList, IList<T>, IReadOnlyList<T>
    where T : unmanaged {
    /// <summary>
    /// Gets the pointer to the first element of the vector. <c>null</c> if empty.
    /// </summary>
    public T* First { get; }

    /// <summary>
    /// Gets the pointer to next of the last element of the vector. <c>null</c> if empty.
    /// </summary>
    public T* Last { get; }

    /// <summary>
    /// Gets the pointer to the end of the memory allocation. <c>null</c> if empty.
    /// </summary>
    public T* End { get; }

    /// <inheritdoc cref="LongCount"/>
    new int Count { get; set; }

    /// <summary>
    /// Gets or sets the number of elements contained in this vector.
    /// </summary>
    long LongCount { get; set; }

    /// <inheritdoc cref="LongCapacity"/>
    int Capacity { get; set; }

    /// <summary>
    /// Gets or sets the total number of elements the internal data structure can hold without resizing.
    /// </summary>
    long LongCapacity { get; set; }

    #region Collection interfaces

    int ICollection.Count => Count;
    int ICollection<T>.Count => Count;
    int IReadOnlyCollection<T>.Count => Count;

    bool ICollection<T>.IsReadOnly => false;
    bool ICollection.IsSynchronized => false;
    object ICollection.SyncRoot => Array.Empty<byte>();

    bool IList.IsFixedSize => false;
    bool IList.IsReadOnly => false;

    #endregion

    /// <summary>
    /// Gets the reference of the element at given index.
    /// </summary>
    /// <param name="index">The index.</param>
    ref T this[long index] { get; }

    #region Collection interfaces

    T IReadOnlyList<T>.this[int index] => this[index];

    T IList<T>.this[int index] {
        get => this[index];
        set => this[index] = value;
    }

    object? IList.this[int index] {
        get => this[index];
        set => this[index] = (T)(value ?? throw new ArgumentNullException(nameof(value)));
    }

    #endregion

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

    /// <summary>
    /// Adds the item into the vector. The item will be copied.
    /// </summary>
    /// <param name="item">The item.</param>
    void AddCopy(in T item);

    /// <summary>
    /// Adds the item into the vector. The item will be moved.
    /// </summary>
    /// <param name="item">The item.</param>
    void AddMove(ref T item);

    /// <summary>
    /// Appends the collection into the vector. Items will be copied.
    /// </summary>
    /// <param name="collection">The collection.</param>
    void AddRangeCopy(IEnumerable<T> collection);

    /// <summary>
    /// Appends the span into the vector. Items will be copied.
    /// </summary>
    /// <param name="span">The span.</param>
    void AddSpanCopy(ReadOnlySpan<T> span);

    /// <summary>
    /// Appends the span into the vector. Items will be moved.
    /// </summary>
    /// <param name="span">The span.</param>
    void AddSpanMove(Span<T> span);

    /// <inheritdoc cref="List{T}.BinarySearch(T)"/>
    long BinarySearch(in T item);

    /// <inheritdoc cref="List{T}.BinarySearch(T,IComparer{T}?)"/>
    long BinarySearch(in T item, IComparer<T>? comparer);

    /// <inheritdoc cref="List{T}.BinarySearch(int,int,T,IComparer{T}?)"/>
    long BinarySearch(long index, long count, in T item, IComparer<T>? comparer);

    /// <inheritdoc cref="List{T}.Clear"/>
    new void Clear();

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

    /// <summary>
    /// Inserts the item into the vector. The item will be copied.
    /// </summary>
    /// <param name="index">The zero-based index of insertion.</param>
    /// <param name="item">The item.</param>
    void InsertCopy(long index, in T item);

    /// <summary>
    /// Inserts the item into the vector. The item will be moved.
    /// </summary>
    /// <param name="index">The zero-based index of insertion.</param>
    /// <param name="item">The item.</param>
    void InsertMove(long index, ref T item);

    /// <summary>
    /// Inserts the collection into the vector. Items will be copied.
    /// </summary>
    /// <param name="index">The zero-based index of insertion.</param>
    /// <param name="collection">The collection.</param>
    void InsertRangeCopy(long index, IEnumerable<T> collection);

    /// <summary>
    /// Inserts the span into the vector. Items will be copied.
    /// </summary>
    /// <param name="index">The zero-based index of insertion.</param>
    /// <param name="span">The span.</param>
    void InsertSpanCopy(long index, ReadOnlySpan<T> span);

    /// <summary>
    /// Inserts the span into the vector. Items will be moved.
    /// </summary>
    /// <param name="index">The zero-based index of insertion.</param>
    /// <param name="span">The span.</param>
    void InsertSpanMove(long index, Span<T> span);

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

    /// <inheritdoc cref="List{T}.Remove"/>
    bool Remove(in T item);

    /// <inheritdoc cref="List{T}.RemoveAll"/>
    long RemoveAll(Predicate<T> match);

    /// <inheritdoc cref="List{T}.RemoveAt"/>
    void RemoveAt(long index);

    /// <inheritdoc cref="List{T}.RemoveRange"/>
    void RemoveRange(long index, long count);

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

    /// <summary>
    /// Determines if two instances of <see cref="IContinuousStorageContainer{T}"/> have same pointers.
    /// </summary>
    /// <param name="other">The other instance.</param>
    /// <returns><c>true</c> if equals.</returns>
    public bool PointerEquals(IContinuousStorageContainer<T> other) =>
        First == other.First && Last == other.Last && End == other.End;

    /// <see cref="List{T}.EnsureCapacity"/>
    long EnsureCapacity(long capacity);

    /// <see cref="List{T}.TrimExcess"/>
    long TrimExcess();

    /// <summary>
    /// Resizes this vector to the given size. In case of expansion, the data of new items are set to zeroes.
    /// </summary>
    /// <param name="newSize">The new size.</param>
    void Resize(long newSize);

    /// <summary>
    /// Resizes this vector to the given size. In case of expansion, the data of new items are set to <paramref name="defaultValue"/>.
    /// </summary>
    /// <param name="newSize">The new size.</param>
    /// <param name="defaultValue">The value for the new items.</param>
    void Resize(long newSize, in T defaultValue);

    /// <summary>
    /// Sets the capacity of this vector.
    /// </summary>
    /// <param name="newCapacity">The new capacity. Must be at least <see cref="StdVector{T,TMemorySpace,TOperation}.LongCount"/>.</param>
    /// <returns>The new capacity.</returns>
    /// <exception cref="ArgumentOutOfRangeException">When <paramref name="newCapacity"/> is less than <see cref="StdVector{T,TMemorySpace,TOperation}.LongCount"/>.</exception>
    /// <exception cref="OutOfMemoryException">When failed to allocate memory as requested.</exception>
    long SetCapacity(long newCapacity);

    #region Collection interfaces

    void ICollection<T>.Add(T item) => AddCopy(item);

    void ICollection<T>.Clear() => Clear();

    bool ICollection<T>.Contains(T item) => Contains(item);

    void ICollection<T>.CopyTo(T[] array, int arrayIndex) {
        if (arrayIndex < 0 || arrayIndex > array.Length)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, null);
        if (array.Length - arrayIndex < LongCount)
            throw new ArgumentException(null, nameof(array));

        var i = (long)arrayIndex;
        for (var p = First; p < Last; p++, i++)
            array[i] = *p;
    }

    bool ICollection<T>.Remove(T item) => Remove(item);

    int IList<T>.IndexOf(T item) => IndexOf(item);

    void IList<T>.Insert(int index, T item) => InsertCopy(index, item);

    void IList<T>.RemoveAt(int index) => RemoveAt(index);

    void ICollection.CopyTo(Array array, int index) {
        if (array is not T[] typedArray)
            throw new ArgumentException(null, nameof(array));
        CopyTo(typedArray, index);
    }

    int IList.Add(object? value) {
        if (LongCount >= int.MaxValue)
            throw new NotSupportedException();
        AddCopy((T)(value ?? throw new ArgumentNullException(nameof(value))));
        return Count - 1;
    }

    void IList.Clear() => Clear();

    bool IList.Contains(object? value) => value is T typedValue && Contains(typedValue);

    int IList.IndexOf(object? value) => value is T typedValue ? IndexOf(typedValue) : -1;

    void IList.Insert(int index, object? value) => InsertCopy(index, (T)(value ?? throw new ArgumentNullException(nameof(value))));

    void IList.Remove(object? value) => Remove((T)(value ?? throw new ArgumentNullException(nameof(value))));

    void IList.RemoveAt(int index) => RemoveAt(index);

    #endregion

    /// <summary>
    /// Gets an enumerator for this vector.
    /// </summary>
    /// <returns>The enumerator returning references to items.</returns>
    new Enumerator GetEnumerator();

    /// <inheritdoc cref="IEnumerable{T}.GetEnumerator"/>
    IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

    /// <inheritdoc cref="IEnumerable.GetEnumerator"/>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    /// Enumerator for <see cref="IContinuousStorageContainer{T}"/>.
    /// </summary>
    public struct Enumerator : IEnumerable<T>, IEnumerator<T> {
        private readonly T* _ownerFirst;
        private readonly T* _ownerLast;
        private T* _current;

        /// <summary>
        /// Initializes a new instance of <see cref="Enumerator"/> struct.
        /// </summary>
        /// <param name="first">The pointer to the first item.</param>
        /// <param name="last">The pointer to past the last item.</param>
        public Enumerator(T* first, T* last) {
            _ownerFirst = first;
            _ownerLast = last;
            _current = first - 1;
        }

        /// <summary>
        /// Gets the reference to the current element.
        /// </summary>
        public readonly ref T Current {
            get {
                if (_current < _ownerFirst || _current >= _ownerLast)
                    throw new InvalidOperationException();
                return ref *_current;
            }
        }

        /// <inheritdoc cref="IEnumerator{T}.Current"/>
        T IEnumerator<T>.Current => Current;

        /// <inheritdoc cref="IEnumerator.Current"/>
        object IEnumerator.Current => Current;

        /// <inheritdoc cref="IEnumerator.MoveNext"/>
        public bool MoveNext() {
            if (_current >= _ownerLast - 1)
                return false;
            ++_current;
            return true;
        }

        /// <inheritdoc cref="IEnumerator.Reset"/>
        public void Reset() => _current = _ownerFirst - 1;

        /// <inheritdoc cref="IDisposable.Dispose"/>
        public void Dispose() { }

        /// <inheritdoc cref="IEnumerable{T}.GetEnumerator"/>
        public IEnumerator<T> GetEnumerator() => new Enumerator(_ownerFirst, _ownerLast);

        /// <inheritdoc cref="IEnumerable.GetEnumerator"/>
        IEnumerator IEnumerable.GetEnumerator() => new Enumerator(_ownerFirst, _ownerLast);
    }
}
