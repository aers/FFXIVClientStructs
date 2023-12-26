using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.STD.StdHelpers;

namespace FFXIVClientStructs.STD;

/// <summary>
/// A <see cref="StdVector{T,TMemorySpace,TOperation}"/> using <see cref="DefaultStaticMemorySpace"/> and <see cref="DefaultStaticNativeObjectOperation{T}"/>.
/// </summary>
/// <typeparam name="T">The type of element.</typeparam>
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public unsafe struct StdVector<T> : IContinuousStorageContainer<T>
    where T : unmanaged {
    public StdVector<T, DefaultStaticMemorySpace, DefaultStaticNativeObjectOperation<T>> WithOperationSpecs;
    public T* First {
        readonly get => WithOperationSpecs.First;
        set => WithOperationSpecs.First = value;
    }
    public T* Last {
        readonly get => WithOperationSpecs.Last;
        set => WithOperationSpecs.Last = value;
    }
    public T* End {
        readonly get => WithOperationSpecs.End;
        set => WithOperationSpecs.End = value;
    }
    public long LongCapacity {
        readonly get => WithOperationSpecs.LongCapacity;
        set => WithOperationSpecs.LongCapacity = value;
    }
    public int Count {
        readonly get => WithOperationSpecs.Count;
        set => WithOperationSpecs.Count = value;
    }
    public long LongCount {
        readonly get => WithOperationSpecs.LongCount;
        set => WithOperationSpecs.LongCount = value;
    }
    int IContinuousStorageContainer<T>.Capacity {
        readonly get => WithOperationSpecs.Capacity;
        set => WithOperationSpecs.Capacity = value;
    }
    public readonly ref T this[long index] => ref WithOperationSpecs[index];

    public static implicit operator Span<T>(in StdVector<T> value) => value.AsSpan();
    public static implicit operator ReadOnlySpan<T>(in StdVector<T> value) => value.AsSpan();
    public void Dispose() => WithOperationSpecs.Dispose();
    public readonly Span<T> AsSpan() => WithOperationSpecs.AsSpan();
    public readonly Span<T> AsSpan(long index) => WithOperationSpecs.AsSpan(index);
    public readonly Span<T> AsSpan(long index, int count) => WithOperationSpecs.AsSpan(index, count);
    public void AddCopy(in T item) => WithOperationSpecs.AddCopy(in item);
    public void AddMove(ref T item) => WithOperationSpecs.AddMove(ref item);
    public void AddRangeCopy(IEnumerable<T> collection) => WithOperationSpecs.AddRangeCopy(collection);
    public void AddSpanCopy(ReadOnlySpan<T> span) => WithOperationSpecs.AddSpanCopy(span);
    public void AddSpanMove(Span<T> span) => WithOperationSpecs.AddSpanMove(span);
    public readonly long BinarySearch(in T item) => WithOperationSpecs.BinarySearch(item);
    public readonly long BinarySearch(in T item, IComparer<T>? comparer) => WithOperationSpecs.BinarySearch(item, comparer);
    public readonly long BinarySearch(long index, long count, in T item, IComparer<T>? comparer) => WithOperationSpecs.BinarySearch(index, count, item, comparer);
    public void Clear() => WithOperationSpecs.Clear();
    public readonly IContinuousStorageContainer<T>.Enumerator GetEnumerator() => WithOperationSpecs.GetEnumerator();
    public readonly bool Contains(in T item) => WithOperationSpecs.Contains(in item);
    public readonly bool Contains(T* subsequence, IntPtr length) => WithOperationSpecs.Contains(subsequence, length);
    public readonly bool Contains(ReadOnlySpan<T> subsequence) => WithOperationSpecs.Contains(subsequence);
    public readonly int CompareTo(object? obj) => WithOperationSpecs.CompareTo(obj);
    public readonly int CompareTo(IContinuousStorageContainer<T>? other) => WithOperationSpecs.CompareTo(other);
    public readonly override bool Equals(object? obj) => obj is StdVector<T> v && Equals(v);
    public readonly bool Equals(IContinuousStorageContainer<T>? other) => other is StdVector<T> v && Equals(v);
    public readonly bool Equals(in StdVector<T> other) => WithOperationSpecs.Equals(other.WithOperationSpecs);
    public readonly bool Exists(Predicate<T> match) => WithOperationSpecs.Exists(match);
    public readonly T? Find(Predicate<T> match) => WithOperationSpecs.Find(match);
    public readonly int FindIndex(Predicate<T> match) => WithOperationSpecs.FindIndex(match);
    public readonly int FindIndex(int startIndex, Predicate<T> match) => WithOperationSpecs.FindIndex(startIndex, match);
    public readonly int FindIndex(int startIndex, int count, Predicate<T> match) => WithOperationSpecs.FindIndex(startIndex, count, match);
    public readonly int FindLastIndex(Predicate<T> match) => WithOperationSpecs.FindLastIndex(match);
    public readonly int FindLastIndex(int startIndex, Predicate<T> match) => WithOperationSpecs.FindLastIndex(startIndex, match);
    public readonly int FindLastIndex(int startIndex, int count, Predicate<T> match) => WithOperationSpecs.FindLastIndex(startIndex, count, match);
    public readonly void ForEach(Action<T> action) => WithOperationSpecs.ForEach(action);
    public readonly int IndexOf(in T item) => WithOperationSpecs.IndexOf(in item);
    public readonly int IndexOf(in T item, int index) => WithOperationSpecs.IndexOf(in item, index);
    public readonly int IndexOf(in T item, int index, int count) => WithOperationSpecs.IndexOf(in item, index, count);
    public readonly int IndexOf(ReadOnlySpan<T> subsequence) => WithOperationSpecs.IndexOf(subsequence);
    public readonly int IndexOf(ReadOnlySpan<T> subsequence, int index) => WithOperationSpecs.IndexOf(subsequence, index);
    public readonly int IndexOf(ReadOnlySpan<T> subsequence, int index, int count) => WithOperationSpecs.IndexOf(subsequence, index, count);
    public void InsertCopy(long index, in T item) => WithOperationSpecs.InsertCopy(index, in item);
    public void InsertMove(long index, ref T item) => WithOperationSpecs.InsertMove(index, ref item);
    public void InsertRangeCopy(long index, IEnumerable<T> collection) => WithOperationSpecs.InsertRangeCopy(index, collection);
    public void InsertSpanCopy(long index, ReadOnlySpan<T> span) => WithOperationSpecs.InsertSpanCopy(index, span);
    public void InsertSpanMove(long index, Span<T> span) => WithOperationSpecs.InsertSpanMove(index, span);
    public readonly int LastIndexOf(in T item) => WithOperationSpecs.LastIndexOf(in item);
    public readonly int LastIndexOf(in T item, int index) => WithOperationSpecs.LastIndexOf(in item, index);
    public readonly int LastIndexOf(in T item, int index, int count) => WithOperationSpecs.LastIndexOf(in item, index, count);
    public readonly int LastIndexOf(ReadOnlySpan<T> subsequence) => WithOperationSpecs.LastIndexOf(subsequence);
    public readonly int LastIndexOf(ReadOnlySpan<T> subsequence, int index) => WithOperationSpecs.LastIndexOf(subsequence, index);
    public readonly int LastIndexOf(ReadOnlySpan<T> subsequence, int index, int count) => WithOperationSpecs.LastIndexOf(subsequence, index, count);
    public bool Remove(in T item) => WithOperationSpecs.Remove(in item);
    public long RemoveAll(Predicate<T> match) => WithOperationSpecs.RemoveAll(match);
    public void RemoveAt(long index) => WithOperationSpecs.RemoveAt(index);
    public void RemoveRange(long index, long count) => WithOperationSpecs.RemoveRange(index, count);
    public void Reverse() => WithOperationSpecs.Reverse();
    public void Reverse(long index, long count) => WithOperationSpecs.Reverse(index, count);
    public void Sort() => WithOperationSpecs.Sort();
    public void Sort(long index, long count) => WithOperationSpecs.Sort(index, count);
    public void Sort(IComparer<T>? comparer) => WithOperationSpecs.Sort(comparer);
    public void Sort(long index, long count, IComparer<T>? comparer) => WithOperationSpecs.Sort(index, count, comparer);
    public void Sort(Comparison<T> comparison) => WithOperationSpecs.Sort(comparison);
    public void Sort(long index, long count, Comparison<T> comparison) => WithOperationSpecs.Sort(index, count, comparison);
    public readonly T[] ToArray() => WithOperationSpecs.ToArray();
    public readonly T[] ToArray(long index) => WithOperationSpecs.ToArray(index);
    public readonly T[] ToArray(long index, long count) => WithOperationSpecs.ToArray(index, count);
    public readonly long LongFindIndex(Predicate<T> match) => WithOperationSpecs.LongFindIndex(match);
    public readonly long LongFindIndex(long startIndex, Predicate<T> match) => WithOperationSpecs.LongFindIndex(startIndex, match);
    public readonly long LongFindIndex(long startIndex, long count, Predicate<T> match) => WithOperationSpecs.LongFindIndex(startIndex, count, match);
    public readonly long LongFindLastIndex(Predicate<T> match) => WithOperationSpecs.LongFindLastIndex(match);
    public readonly long LongFindLastIndex(long startIndex, Predicate<T> match) => WithOperationSpecs.LongFindLastIndex(startIndex, match);
    public readonly long LongFindLastIndex(long startIndex, long count, Predicate<T> match) => WithOperationSpecs.LongFindLastIndex(startIndex, count, match);
    public readonly long LongIndexOf(in T item) => WithOperationSpecs.LongIndexOf(in item);
    public readonly long LongIndexOf(in T item, long index) => WithOperationSpecs.LongIndexOf(in item, index);
    public readonly long LongIndexOf(in T item, long index, long count) => WithOperationSpecs.LongIndexOf(in item, index, count);
    public readonly long LongIndexOf(ReadOnlySpan<T> subsequence) => WithOperationSpecs.LongIndexOf(subsequence);
    public readonly long LongIndexOf(ReadOnlySpan<T> subsequence, long index) => WithOperationSpecs.LongIndexOf(subsequence, index);
    public readonly long LongIndexOf(ReadOnlySpan<T> subsequence, long index, long count) => WithOperationSpecs.LongIndexOf(subsequence, index, count);
    public readonly long LongIndexOf(T* subsequence, IntPtr subsequenceLength) => WithOperationSpecs.LongIndexOf(subsequence, subsequenceLength);
    public readonly long LongIndexOf(T* subsequence, IntPtr subsequenceLength, long index) => WithOperationSpecs.LongIndexOf(subsequence, subsequenceLength, index);
    public readonly long LongIndexOf(T* subsequence, IntPtr subsequenceLength, long index, long count) => WithOperationSpecs.LongIndexOf(subsequence, subsequenceLength, index, count);
    public readonly long LongLastIndexOf(in T item) => WithOperationSpecs.LongLastIndexOf(in item);
    public readonly long LongLastIndexOf(in T item, long index) => WithOperationSpecs.LongLastIndexOf(in item, index);
    public readonly long LongLastIndexOf(in T item, long index, long count) => WithOperationSpecs.LongLastIndexOf(in item, index, count);
    public readonly long LongLastIndexOf(ReadOnlySpan<T> subsequence) => WithOperationSpecs.LongLastIndexOf(subsequence);
    public readonly long LongLastIndexOf(ReadOnlySpan<T> subsequence, long index) => WithOperationSpecs.LongLastIndexOf(subsequence, index);
    public readonly long LongLastIndexOf(ReadOnlySpan<T> subsequence, long index, long count) => WithOperationSpecs.LongLastIndexOf(subsequence, index, count);
    public readonly long LongLastIndexOf(T* subsequence, IntPtr subsequenceLength) => WithOperationSpecs.LongLastIndexOf(subsequence, subsequenceLength);
    public readonly long LongLastIndexOf(T* subsequence, IntPtr subsequenceLength, long index) => WithOperationSpecs.LongLastIndexOf(subsequence, subsequenceLength, index);
    public readonly long LongLastIndexOf(T* subsequence, IntPtr subsequenceLength, long index, long count) => WithOperationSpecs.LongLastIndexOf(subsequence, subsequenceLength, index, count);
    public long EnsureCapacity(long capacity) => WithOperationSpecs.EnsureCapacity(capacity);
    public long TrimExcess() => WithOperationSpecs.TrimExcess();
    public void Resize(long newSize) => WithOperationSpecs.Resize(newSize);
    public void Resize(long newSize, in T defaultValue) => WithOperationSpecs.Resize(newSize, in defaultValue);
    public long SetCapacity(long newCapacity) => WithOperationSpecs.SetCapacity(newCapacity);
    public readonly override int GetHashCode() => HashCode.Combine((nint)First, (nint)Last, (nint)End);
    public readonly override string ToString() => $"{nameof(StdVector<T>)}<{typeof(T)}>({LongCount}/{LongCapacity})";

    [Obsolete($"Use {nameof(AsSpan)} instead.")]
    public ReadOnlySpan<T> Span {
        get {
            var size = Size();
            if (size >= 0x7FEFFFFF)
                throw new IndexOutOfRangeException($"Size exceeds max. Array index. (Size={size})");
            return new ReadOnlySpan<T>(First, (int)size);
        }
    }

    [Obsolete($"Use {nameof(LongCount)} instead.")]
    public ulong Size() {
        if (First == null || Last == null)
            return 0;

        return ((ulong)Last - (ulong)First) / (ulong)sizeof(T);
    }

    [Obsolete($"Use {nameof(LongCapacity)} instead.")]
    public ulong Capacity() {
        if (End == null || First == null)
            return 0;

        return ((ulong)End - (ulong)First) / (ulong)sizeof(T);
    }

    [Obsolete("Use index accessor instead.")]
    public T Get(ulong index) {
        if (index >= (ulong)LongCount)
            throw new IndexOutOfRangeException($"Index out of Range: {index}");

        return First[index];
    }
}
