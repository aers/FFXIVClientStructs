using System.Collections;
using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct StdVector<T> : IList<T>, IList, IReadOnlyList<T> where T : unmanaged {
    public T* First;
    public T* Last;
    public T* End;

    public int Capacity {
        readonly get => checked((int)LongCapacity);
        set => LongCapacity = value;
    }

    public long LongCapacity {
        readonly get {
            if (First == null || End == null || First > End)
                return 0;

            var capacity = End - First;
            if (capacity > 0xFFFFFFFF)
                throw new OverflowException("Capacity exceeds max");
            return capacity;
        }
        set => Reallocate(value);
    }

    public readonly int Count => checked((int)LongCount);

    public readonly long LongCount {
        get {
            if (First == null || Last == null || First > Last)
                return 0;

            var capacity = Last - First;
            if (capacity > 0xFFFFFFFF)
                throw new OverflowException("Size exceeds max");
            return capacity;
        }
    }

    bool IList.IsFixedSize => false;

    bool ICollection<T>.IsReadOnly => false;

    bool IList.IsReadOnly => false;

    bool ICollection.IsSynchronized => false;

    object ICollection.SyncRoot => this;

    public readonly T this[int index] {
        get {
            if ((uint)index >= (uint)Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            return First[index];
        }
        set {
            if ((uint)index >= (uint)Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            First[index] = value;
        }
    }

    readonly object? IList.this[int index] {
        get => this[index];
        set {
            try {
                this[index] = (T)value!;
            } catch (InvalidCastException) {
                throw new ArgumentException("Invalid type", nameof(value));
            }
        }
    }

    public void Add(T value) {
        Resize(Count + 1);

        *Last++ = value;
    }

    private void Resize(long newSize) {
        if (newSize > LongCount) {
            Reserve(newSize);

            Unsafe.InitBlockUnaligned(Last, 0, (uint)((newSize - LongCount) * sizeof(T)));
            Last = First + newSize;
        } else if (newSize < LongCount)
            Last = First + newSize;
    }

    private void Reserve(long newCapacity) {
        if (newCapacity > LongCapacity) {
            if (newCapacity > uint.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(newCapacity), "vector<T> too long");

            var grownCapacity = (long)(LongCapacity * 1.5f);
            if (newCapacity <= grownCapacity && grownCapacity <= uint.MaxValue)
                newCapacity = grownCapacity;

            Reallocate(newCapacity);
        }
    }

    private void Reallocate(long newCapacity) {
        var newAlloc = IMemorySpace.GetDefaultSpace()->Malloc((ulong)(newCapacity * sizeof(T)), 16);
        if (LongCount != 0)
            Unsafe.CopyBlock(newAlloc, First, (uint)(LongCount * sizeof(T)));

        if (First != null)
            IMemorySpace.Free(First, (ulong)(LongCapacity * sizeof(T)));

        var size = Count;
        First = (T*)newAlloc;
        End = First + newCapacity;
        Last = First + size;
    }

    int IList.Add(object? value) {
        try {
            Add((T)value!);
        } catch (InvalidCastException) {
            throw new ArgumentException("Invalid type", nameof(value));
        }

        return Count - 1;
    }

    public void AddRange(IEnumerable<T> collection)
        => InsertRange(Count, collection);

    public void Clear() {
        Last = First;
    }

    public bool Contains(T value) {
        return Count != 0 && IndexOf(value) >= 0;
    }

    bool IList.Contains(object? value) {
        try {
            return Contains((T)value!);
        } catch (InvalidCastException) {
            throw new ArgumentException("Invalid type", nameof(value));
        }
    }

    public void CopyTo(T[] array) =>
        CopyTo(array, 0);

    void ICollection.CopyTo(Array array, int index) {
        ArgumentNullException.ThrowIfNull(array);

        if (array.Rank != 1) {
            throw new ArgumentException("Multi dimensional arrays are not supported", nameof(array));
        }

        if (array.GetLowerBound(0) != 0) {
            throw new ArgumentException("Array must have a lower bound of 0", nameof(array));
        }

        if (index < 0) {
            throw new ArgumentOutOfRangeException(nameof(index), index, "Index cannot be negative");
        }

        if (array.Length - index < Count) {
            throw new ArgumentException("Insufficient space for destination");
        }

        T[]? tArray = array as T[];
        if (tArray != null) {
            CopyTo(tArray, index);
        } else {
            object?[]? objects = array as object[];
            if (objects == null) {
                throw new ArgumentException("Invalid array type", nameof(array));
            }

            var count = Count;
            try {
                for (int i = 0; i < count; ++i)
                    objects[index + i] = First[i];
            } catch (ArrayTypeMismatchException) {
                throw new ArgumentException("Invalid array type", nameof(array));
            }
        }
    }

    public readonly void CopyTo(int index, T[] array, int arrayIndex, int count) {
        ArgumentNullException.ThrowIfNull(array);

        if (index < 0) {
            throw new ArgumentOutOfRangeException(nameof(index), index, "Index cannot be negative");
        }

        if (Count - index < count)
            throw new ArgumentException("Invalid offset and length");

        if (arrayIndex > array.Length) {
            throw new ArgumentOutOfRangeException(nameof(index), index, "Index is larger than array length");
        }

        if (array.Length - arrayIndex < count) {
            throw new ArgumentException("Insufficient space for destination");
        }

        for (int i = 0; i < count; ++i)
            array[arrayIndex + i] = First[index + i];
    }

    public readonly void CopyTo(T[] array, int index) =>
        CopyTo(0, array, index, Count);


    public int EnsureCapacity(int capacity) {
        if (capacity < 0) {
            throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Capacity cannot be negative");
        }
        Reserve(capacity);

        return Capacity;
    }

    public Enumerator GetEnumerator() {
        fixed (StdVector<T>* self = &this)
            return new Enumerator(self);
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator() =>
        GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        GetEnumerator();

    public readonly int IndexOf(T item) {
        var count = Count;
        for (var i = 0; i < count; ++i)
            if (this[i].Equals(item))
                return i;
        return -1;
    }

    readonly int IList.IndexOf(object? value) {
        try {
            return IndexOf((T)value!);
        } catch (InvalidCastException) {
            throw new ArgumentException("Invalid type", nameof(value));
        }
    }

    public void Insert(int index, T item) {
        // Note that insertions at the end are legal.
        if ((uint)index > (uint)Count) {
            throw new ArgumentOutOfRangeException(nameof(index), index, "Index is out of range");
        }
        var count = Count;
        Resize(count + 1);
        if (index < count)
            Unsafe.CopyBlock(First + index + 1, First + index, (uint)((count - index) * sizeof(T)));
        First[index] = item;
    }

    void IList.Insert(int index, object? value) {
        try {
            Insert(index, (T)value!);
        } catch (InvalidCastException) {
            throw new ArgumentException("Invalid type", nameof(value));
        }
    }

    public void InsertRange(int index, IEnumerable<T> collection) {
        if (collection == null) {
            throw new ArgumentNullException(nameof(collection));
        }

        if ((uint)index > (uint)Count) {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
        }

        if (collection is ICollection<T> c) {
            int count = c.Count;
            if (count > 0) {
                var vCount = Count;
                Resize(vCount + count);
                if (index < vCount) {
                    Unsafe.CopyBlock(First + index + count, First + index, (uint)((vCount - index) * sizeof(T)));
                }

                // If we're inserting a List into itself, we want to be able to deal with that.
                if (c is StdVector<T> self && self.First == First) {
                    // Copy first part of _items to insert location
                    Unsafe.CopyBlock(First + index, First, (uint)(index * sizeof(T)));
                    // Copy last part of _items back to inserted location
                    Unsafe.CopyBlock(First + index * 2, First + index + count, (uint)(vCount - index * sizeof(T)));
                } else {
                    foreach (var item in c) {
                        this[index++] = item;
                    }
                }
            }
        } else {
            foreach (var item in collection) {
                Insert(index++, item);
            }
        }
    }

    public bool Remove(T item) {
        int index = IndexOf(item);
        if (index >= 0) {
            RemoveAt(index);
            return true;
        }

        return false;
    }

    void IList.Remove(object? value) {
        try {
            Remove((T)value!);
        } catch (InvalidCastException) {
            throw new ArgumentException("Invalid type", nameof(value));
        }
    }

    public void RemoveAt(int index) =>
        RemoveRange(index, 1);

    public void RemoveRange(int index, int count) {
        if (index < 0) {
            throw new ArgumentOutOfRangeException(nameof(index), index, "Index cannot be negative");
        }

        if (count < 0) {
            throw new ArgumentOutOfRangeException(nameof(count), count, "Count cannot be negative");
        }

        if (Count - index < count)
            throw new ArgumentException("Invalid offset and length");

        if (count > 0) {
            Last -= count;
            if (index < Count) {
                Unsafe.CopyBlock(First + index, First + index + count, (uint)(Count - index * sizeof(T)));
            }
        }
    }

    public void TrimExcess() {
        LongCapacity = LongCount;
    }

    [Obsolete("Use other properties or GetEnumerator()", true)]
    public ReadOnlySpan<T> Span {
        get {
            var size = Size();
            if (size >= 0x7FEFFFFF)
                throw new IndexOutOfRangeException($"Size exceeds max. Array index. (Size={size})");
            return new ReadOnlySpan<T>(First, (int)size);
        }
    }

    [Obsolete("Use Count", true)]
    public ulong Size() {
        if (First == null || Last == null)
            return 0;

        return (ulong)(Last - First);
    }

    [Obsolete("Use Capacity", true)]
    public ulong Capacity2() {
        if (End == null || First == null)
            return 0;

        return (ulong)(End - First);
    }

    [Obsolete("Use this[value]", true)]
    public T Get(ulong index) {
        if (index >= Size())
            throw new IndexOutOfRangeException($"Index out of Range: {index}");

        return First[index];
    }

    public struct Enumerator : IEnumerator<T>, IEnumerator {
        private readonly StdVector<T>* vector;
        private long idx;

        internal Enumerator(StdVector<T>* vector) {
            this.vector = vector;
        }

        public readonly void Dispose() {
        }

        public bool MoveNext() {
            if (idx < vector->LongCount) {
                idx++;
                return true;
            }
            idx = vector->LongCount + 1;
            return false;
        }

        public readonly T Current => vector->First[idx - 1];

        readonly object? IEnumerator.Current {
            get {
                if (idx == 0 || idx == vector->LongCount + 1) {
                    throw new InvalidOperationException();
                }
                return Current;
            }
        }

        void IEnumerator.Reset() {
            idx = 0;
        }
    }
}
