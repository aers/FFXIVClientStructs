global using StdString = FFXIVClientStructs.STD.StdBasicString<byte>;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.STD;

// std::string aka std::basic_string from msvc
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct StdBasicString<T> : IList<T>, IList, IReadOnlyList<T> where T : unmanaged {
    // if (Length < 16) uses Buffer else uses BufferPtr
    [FieldOffset(0x0)] public T* BufferPtr;
    [FieldOffset(0x0)] public fixed byte SmallBufferRaw[16];
    [FieldOffset(0x10)] public ulong _Length;
    [FieldOffset(0x18)] public ulong _Capacity;

    private static int SmallStringCapacity => Math.Max(16 / sizeof(T), 1) - 1;
    public readonly bool IsSmallStringOptimized => LongCapacity < SmallStringCapacity;
    private readonly T* SmallBuffer {
        get {
            fixed (byte* buffer = SmallBufferRaw)
                return (T*)buffer;
        }
    }

    public readonly T* Data => IsSmallStringOptimized ? SmallBuffer : BufferPtr;

    public readonly ReadOnlySpan<T> AsSpan() =>
        new(Data, checked((int)_Length));

    public readonly override string ToString() {
        var span = AsSpan();
        if (typeof(T) == typeof(byte)) {
            fixed (byte* ptr = MemoryMarshal.AsBytes(span))
                return Marshal.PtrToStringAnsi((nint)ptr, span.Length);
        }
        else if (typeof(T) == typeof(char)) {
            fixed (char* ptr = MemoryMarshal.Cast<T, char>(span))
                return Marshal.PtrToStringUni((nint)ptr, span.Length);
        } else {
            return base.ToString()!;
        }
    }

    //

    public int Capacity {
        readonly get => checked((int)LongCapacity);
        set => LongCapacity = value;
    }

    public long LongCapacity {
        readonly get => checked((long)_Capacity);
        set => Reallocate(value);
    }

    public readonly int Count => checked((int)LongCount);

    public readonly long LongCount => checked((long)_Length);

    readonly bool IList.IsFixedSize => false;

    readonly bool ICollection<T>.IsReadOnly => false;

    readonly bool IList.IsReadOnly => false;

    readonly bool ICollection.IsSynchronized => false;

    readonly object ICollection.SyncRoot => this;

    public readonly T this[int index] {
        get {
            if ((uint)index >= (uint)Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            return Data[index];
        }
        set {
            if ((uint)index >= (uint)Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            Data[index] = value;
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
        var count = LongCount;
        Resize(count + 1);

        Data[count] = value;
    }

    private void Resize(long newSize) {
        if (newSize > LongCount) {
            Reserve(newSize);

            Unsafe.InitBlockUnaligned(Data + LongCount, 0, (uint)((newSize - LongCount + 1) * sizeof(T)));
            _Length += (ulong)newSize;
            Data[_Length] = default;
        } else if (newSize < LongCount) {
            _Length = (ulong)newSize;
            Data[_Length] = default;
        }
    }

    private void Reserve(long newCapacity) {
        if (newCapacity > LongCapacity) {
            if (newCapacity > uint.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(newCapacity), "basic_string<T> too long");

            var grownCapacity = (long)(LongCapacity * 1.5f);
            if (newCapacity <= grownCapacity && grownCapacity <= uint.MaxValue)
                newCapacity = grownCapacity;

            Reallocate(newCapacity);
        }
    }

    private void Reallocate(long newCapacity) {
        var newAlloc = IMemorySpace.GetDefaultSpace()->Malloc((ulong)((newCapacity + 1) * sizeof(T)), 16);
        if (LongCount != 0)
            Unsafe.CopyBlock(newAlloc, Data, (uint)(LongCount * sizeof(T)));
        Unsafe.InitBlockUnaligned((T*)newAlloc + LongCount, 0, (uint)sizeof(T));

        if (!IsSmallStringOptimized)
            IMemorySpace.Free(Data, (ulong)((LongCapacity + 1) * sizeof(T)));

        BufferPtr = (T*)newAlloc;
        _Capacity = (ulong)newCapacity;
    }

    int IList.Add(object? value) {
        try {
            Add((T)value!);
        } catch (InvalidCastException) {
            throw new ArgumentException("Invalid type", nameof(value));
        }

        return Count - 1;
    }

    public void AddRange(IEnumerable<T> collection) =>
        InsertRange(Count, collection);

    public void Clear() {
        _Length = 0;
        Data[_Length] = default;
    }

    public readonly bool Contains(T value) {
        return Count != 0 && IndexOf(value) >= 0;
    }

    readonly bool IList.Contains(object? value) {
        try {
            return Contains((T)value!);
        } catch (InvalidCastException) {
            throw new ArgumentException("Invalid type", nameof(value));
        }
    }

    public readonly void CopyTo(T[] array) =>
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

        if (array is T[] tArray) {
            CopyTo(tArray, index);
        } else {
            if (array is not object[] objects) {
                throw new ArgumentException("Invalid array type", nameof(array));
            }

            var count = Count;
            try {
                for (var i = 0; i < count; ++i)
                    objects[index + i] = Data[i];
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

        for (var i = 0; i < count; ++i)
            array[arrayIndex + i] = Data[index + i];
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
        fixed (StdBasicString<T>* self = &this)
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
            Unsafe.CopyBlock(Data + index + 1, Data + index, (uint)((count - index) * sizeof(T)));
        Data[index] = item;
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
            var count = c.Count;
            if (count > 0) {
                var vCount = Count;
                Resize(vCount + count);
                if (index < vCount) {
                    Unsafe.CopyBlock(Data + index + count, Data + index, (uint)((vCount - index) * sizeof(T)));
                }

                // If we're inserting a List into itself, we want to be able to deal with that.
                if (c is StdBasicString<T> self && self.Data == Data) {
                    // Copy first part of _items to insert location
                    Unsafe.CopyBlock(Data + index, Data, (uint)(index * sizeof(T)));
                    // Copy last part of _items back to inserted location
                    Unsafe.CopyBlock(Data + index * 2, Data + index + count, (uint)(vCount - index * sizeof(T)));
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
        var index = IndexOf(item);
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
            _Length -= (ulong)count;
            if (index < Count) {
                Unsafe.CopyBlock(Data + index, Data + index + count, (uint)(Count - index * sizeof(T)));
            }
            Data[_Length] = default;
        }
    }

    public void TrimExcess() {
        LongCapacity = LongCount;
    }

    public struct Enumerator : IEnumerator<T>, IEnumerator {
        private readonly StdBasicString<T>* str;
        private long idx;

        internal Enumerator(StdBasicString<T>* str) {
            this.str = str;
        }

        public readonly void Dispose() {
        }

        public bool MoveNext() {
            if (idx < str->LongCount) {
                idx++;
                return true;
            }
            idx = str->LongCount + 1;
            return false;
        }

        public readonly T Current => str->Data[idx - 1];

        readonly object? IEnumerator.Current {
            get {
                if (idx == 0 || idx == str->LongCount + 1)
                    throw new InvalidOperationException();

                return Current;
            }
        }

        void IEnumerator.Reset() {
            idx = 0;
        }
    }
}
