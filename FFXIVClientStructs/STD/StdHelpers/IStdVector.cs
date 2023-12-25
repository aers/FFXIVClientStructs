using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace FFXIVClientStructs.STD.StdHelpers;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "PossibleInterfaceMemberAmbiguity")]
public unsafe interface IStdVector<T> : IDisposable, IList, IList<T>, IReadOnlyList<T>
    where T : unmanaged {
    /// <summary>
    /// Gets the pointer to the first element of the vector. <c>null</c> if empty.
    /// </summary>
    public T* First { get; set; }

    /// <summary>
    /// Gets the pointer to next of the last element of the vector. <c>null</c> if empty.
    /// </summary>
    public T* Last { get; set; }

    /// <summary>
    /// Gets the pointer to the end of the memory allocation. <c>null</c> if empty.
    /// </summary>
    public T* End { get; set; }

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
    
    /// <inheritdoc cref="List{T}.Add"/>
    void Add(in T item);
    
    /// <inheritdoc cref="List{T}.AddRange"/>
    void AddRange(IEnumerable<T> collection);
    
    /// <inheritdoc cref="List{T}.AddRange"/>
    void AddRange(ReadOnlySpan<T> span);
    
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
    
    /// <inheritdoc cref="List{T}.Insert"/>
    void Insert(long index, in T item);
    
    /// <inheritdoc cref="List{T}.InsertRange"/>
    void InsertRange(long index, IEnumerable<T> collection);
    
    /// <inheritdoc cref="List{T}.InsertRange"/>
    void InsertRange(long index, ReadOnlySpan<T> span);
    
    /// <inheritdoc cref="List{T}.LastIndexOf(T)"/>
    int LastIndexOf(in T item);
    
    /// <inheritdoc cref="List{T}.LastIndexOf(T,int)"/>
    int LastIndexOf(in T item, int index);
    
    /// <inheritdoc cref="List{T}.LastIndexOf(T,int,int)"/>
    int LastIndexOf(in T item, int index, int count);
    
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
    
    /// <inheritdoc cref="List{T}.LastIndexOf(T)"/>
    long LongLastIndexOf(in T item);
    
    /// <inheritdoc cref="List{T}.LastIndexOf(T, int)"/>
    long LongLastIndexOf(in T item, long index);
    
    /// <inheritdoc cref="List{T}.LastIndexOf(T,int,int)"/>
    long LongLastIndexOf(in T item, long index, long count);
    
    /// <summary>
    /// Determines if two instances of <see cref="IStdVector{T}"/> have same pointers.
    /// </summary>
    /// <param name="other">The other instance.</param>
    /// <returns><c>true</c> if equals.</returns>
    public bool PointerEquals(IStdVector<T> other) =>
        First == other.First && Last == other.Last && End == other.End;

    /// <see cref="List{T}.EnsureCapacity"/>
    long EnsureCapacity(long capacity);
    
    /// <see cref="List{T}.TrimExcess"/>
    long TrimExcess();
    
    /// <summary>
    /// Resizes this vector to the given size. In case of expansion, the data of new items are undefined.
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
    /// <param name="newCapacity">The new capacity. Must be at least <see cref="StdVector{T,TMemorySpace,TDisposable}.LongCount"/>.</param>
    /// <returns>The new capacity.</returns>
    /// <exception cref="ArgumentOutOfRangeException">When <paramref name="newCapacity"/> is less than <see cref="StdVector{T,TMemorySpace,TDisposable}.LongCount"/>.</exception>
    /// <exception cref="OutOfMemoryException">When failed to allocate memory as requested.</exception>
    long SetCapacity(long newCapacity);
    
    #region Collection interfaces
    void ICollection<T>.Add(T item) => Add(item);

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

    void IList<T>.Insert(int index, T item) => Insert(index, item);

    void IList<T>.RemoveAt(int index) => RemoveAt(index);
    
    void ICollection.CopyTo(Array array, int index) {
        if (array is not T[] typedArray)
            throw new ArgumentException(null, nameof(array));
        CopyTo(typedArray, index);
    }
    
    int IList.Add(object? value) {
        if (LongCount >= int.MaxValue)
            throw new NotSupportedException();
        Add((T)(value ?? throw new ArgumentNullException(nameof(value))));
        return Count - 1;
    }

    void IList.Clear() => Clear();

    bool IList.Contains(object? value) => value is T typedValue && Contains(typedValue);

    int IList.IndexOf(object? value) => value is T typedValue ? IndexOf(typedValue) : -1;

    void IList.Insert(int index, object? value) => Insert(index, (T)(value ?? throw new ArgumentNullException(nameof(value))));

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
    /// Enumerator for <see cref="IStdVector{T}"/>.
    /// </summary>
    public struct Enumerator : IEnumerator<T> {
        private readonly T* ownerFirst;
        private readonly T* ownerLast;
        private T* current;

        /// <summary>
        /// Initializes a new instance of <see cref="Enumerator"/> struct.
        /// </summary>
        /// <param name="owner">The owner of this enumerator.</param>
        public Enumerator(IStdVector<T> owner) {
            ownerFirst = owner.First;
            ownerLast = owner.Last;
            current = owner.First - 1;
        }

        /// <summary>
        /// Gets the reference to the current element.
        /// </summary>
        public readonly ref T Current {
            get {
                if (current < ownerFirst || current >= ownerLast)
                    throw new InvalidOperationException();
                return ref *current;
            }
        }

        /// <inheritdoc cref="IEnumerator{T}.Current"/>
        T IEnumerator<T>.Current => Current;

        /// <inheritdoc cref="IEnumerator.Current"/>
        object IEnumerator.Current => Current;

        /// <inheritdoc cref="IEnumerator.MoveNext"/>
        public bool MoveNext() {
            if (current >= ownerLast - 1)
                return false;
            ++current;
            return true;
        }

        /// <inheritdoc cref="IEnumerator.Reset"/>
        public void Reset() => current = ownerFirst - 1;

        /// <inheritdoc cref="IDisposable.Dispose"/>
        public void Dispose() { }
    }
}
