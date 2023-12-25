using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.STD.StdHelpers;

namespace FFXIVClientStructs.STD;

/// <summary>
/// A <see cref="StdVector{T,TMemorySpace,TDisposable}"/> using <see cref="DefaultMemorySpaceStatic"/> and <see cref="NativeObjectOperationStatic{T}"/>.
/// </summary>
/// <typeparam name="T">The type of element.</typeparam>
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public unsafe struct StdVector<T> : IStdVector<T>
    where T : unmanaged {
    public StdVector<T, DefaultMemorySpaceStatic, NativeObjectOperationStatic<T>> WithDefaultAllocator;
    public T* First {
        readonly get => WithDefaultAllocator.First;
        set => WithDefaultAllocator.First = value;
    }
    public T* Last {
        readonly get => WithDefaultAllocator.Last;
        set => WithDefaultAllocator.Last = value;
    }
    public T* End {
        readonly get => WithDefaultAllocator.End;
        set => WithDefaultAllocator.End = value;
    }
    public long LongCapacity {
        readonly get => WithDefaultAllocator.LongCapacity;
        set => WithDefaultAllocator.LongCapacity = value;
    }
    public int Count {
        readonly get => WithDefaultAllocator.Count;
        set => WithDefaultAllocator.Count = value;
    }
    public long LongCount {
        readonly get => WithDefaultAllocator.LongCount;
        set => WithDefaultAllocator.LongCount = value;
    }
    int IStdVector<T>.Capacity {
        readonly get => WithDefaultAllocator.Capacity;
        set => WithDefaultAllocator.Capacity = value;
    }
    public readonly ref T this[long index] => ref WithDefaultAllocator[index];

    public static implicit operator Span<T>(in StdVector<T> value) => value.AsSpan();
    public static implicit operator ReadOnlySpan<T>(in StdVector<T> value) => value.AsSpan();
    public void Dispose() => WithDefaultAllocator.Dispose();
    public readonly Span<T> AsSpan() => WithDefaultAllocator.AsSpan();
    public readonly Span<T> AsSpan(long index) => WithDefaultAllocator.AsSpan(index);
    public readonly Span<T> AsSpan(long index, int count) => WithDefaultAllocator.AsSpan(index, count);
    public void AddCopy(in T item) => WithDefaultAllocator.AddCopy(in item);
    public void AddMove(ref T item) => WithDefaultAllocator.AddMove(ref item);
    public void AddRangeCopy(IEnumerable<T> collection) => WithDefaultAllocator.AddRangeCopy(collection);
    public void AddSpanCopy(ReadOnlySpan<T> span) => WithDefaultAllocator.AddSpanCopy(span);
    public void AddSpanMove(Span<T> span) => WithDefaultAllocator.AddSpanMove(span);
    public readonly long BinarySearch(in T item) => WithDefaultAllocator.BinarySearch(item);
    public readonly long BinarySearch(in T item, IComparer<T>? comparer) => WithDefaultAllocator.BinarySearch(item, comparer);
    public readonly long BinarySearch(long index, long count, in T item, IComparer<T>? comparer) => WithDefaultAllocator.BinarySearch(index, count, item, comparer);
    public void Clear() => WithDefaultAllocator.Clear();
    public readonly IStdVector<T>.Enumerator GetEnumerator() => WithDefaultAllocator.GetEnumerator();
    public readonly bool Contains(in T item) => WithDefaultAllocator.Contains(in item);
    public readonly bool Exists(Predicate<T> match) => WithDefaultAllocator.Exists(match);
    public readonly T? Find(Predicate<T> match) => WithDefaultAllocator.Find(match);
    public readonly int FindIndex(Predicate<T> match) => WithDefaultAllocator.FindIndex(match);
    public readonly int FindIndex(int startIndex, Predicate<T> match) => WithDefaultAllocator.FindIndex(startIndex, match);
    public readonly int FindIndex(int startIndex, int count, Predicate<T> match) => WithDefaultAllocator.FindIndex(startIndex, count, match);
    public readonly int FindLastIndex(Predicate<T> match) => WithDefaultAllocator.FindLastIndex(match);
    public readonly int FindLastIndex(int startIndex, Predicate<T> match) => WithDefaultAllocator.FindLastIndex(startIndex, match);
    public readonly int FindLastIndex(int startIndex, int count, Predicate<T> match) => WithDefaultAllocator.FindLastIndex(startIndex, count, match);
    public readonly void ForEach(Action<T> action) => WithDefaultAllocator.ForEach(action);
    public readonly int IndexOf(in T item) => WithDefaultAllocator.IndexOf(in item);
    public readonly int IndexOf(in T item, int index) => WithDefaultAllocator.IndexOf(in item, index);
    public readonly int IndexOf(in T item, int index, int count) => WithDefaultAllocator.IndexOf(in item, index, count);
    public void InsertCopy(long index, in T item) => WithDefaultAllocator.InsertCopy(index, in item);
    public void InsertMove(long index, ref T item) => WithDefaultAllocator.InsertMove(index, ref item);
    public void InsertRangeCopy(long index, IEnumerable<T> collection) => WithDefaultAllocator.InsertRangeCopy(index, collection);
    public void InsertSpanCopy(long index, ReadOnlySpan<T> span) => WithDefaultAllocator.InsertSpanCopy(index, span);
    public void InsertSpanMove(long index, Span<T> span) => WithDefaultAllocator.InsertSpanMove(index, span);
    public readonly int LastIndexOf(in T item) => WithDefaultAllocator.LastIndexOf(in item);
    public readonly int LastIndexOf(in T item, int index) => WithDefaultAllocator.LastIndexOf(in item, index);
    public readonly int LastIndexOf(in T item, int index, int count) => WithDefaultAllocator.LastIndexOf(in item, index, count);
    public bool Remove(in T item) => WithDefaultAllocator.Remove(in item);
    public long RemoveAll(Predicate<T> match) => WithDefaultAllocator.RemoveAll(match);
    public void RemoveAt(long index) => WithDefaultAllocator.RemoveAt(index);
    public void RemoveRange(long index, long count) => WithDefaultAllocator.RemoveRange(index, count);
    public void Reverse() => WithDefaultAllocator.Reverse();
    public void Reverse(long index, long count) => WithDefaultAllocator.Reverse(index, count);
    public void Sort() => WithDefaultAllocator.Sort();
    public void Sort(long index, long count) => WithDefaultAllocator.Sort(index, count);
    public void Sort(IComparer<T>? comparer) => WithDefaultAllocator.Sort(comparer);
    public void Sort(long index, long count, IComparer<T>? comparer) => WithDefaultAllocator.Sort(index, count, comparer);
    public void Sort(Comparison<T> comparison) => WithDefaultAllocator.Sort(comparison);
    public void Sort(long index, long count, Comparison<T> comparison) => WithDefaultAllocator.Sort(index, count, comparison);
    public readonly T[] ToArray() => WithDefaultAllocator.ToArray();
    public readonly T[] ToArray(long index) => WithDefaultAllocator.ToArray(index);
    public readonly T[] ToArray(long index, long count) => WithDefaultAllocator.ToArray(index, count);
    public readonly long LongFindIndex(Predicate<T> match) => WithDefaultAllocator.LongFindIndex(match);
    public readonly long LongFindIndex(long startIndex, Predicate<T> match) => WithDefaultAllocator.LongFindIndex(startIndex, match);
    public readonly long LongFindIndex(long startIndex, long count, Predicate<T> match) => WithDefaultAllocator.LongFindIndex(startIndex, count, match);
    public readonly long LongFindLastIndex(Predicate<T> match) => WithDefaultAllocator.LongFindLastIndex(match);
    public readonly long LongFindLastIndex(long startIndex, Predicate<T> match) => WithDefaultAllocator.LongFindLastIndex(startIndex, match);
    public readonly long LongFindLastIndex(long startIndex, long count, Predicate<T> match) => WithDefaultAllocator.LongFindLastIndex(startIndex, count, match);
    public readonly long LongIndexOf(in T item) => WithDefaultAllocator.LongIndexOf(in item);
    public readonly long LongIndexOf(in T item, long index) => WithDefaultAllocator.LongIndexOf(in item, index);
    public readonly long LongIndexOf(in T item, long index, long count) => WithDefaultAllocator.LongIndexOf(in item, index, count);
    public readonly long LongLastIndexOf(in T item) => WithDefaultAllocator.LongLastIndexOf(in item);
    public readonly long LongLastIndexOf(in T item, long index) => WithDefaultAllocator.LongLastIndexOf(in item, index);
    public readonly long LongLastIndexOf(in T item, long index, long count) => WithDefaultAllocator.LongLastIndexOf(in item, index, count);
    public long EnsureCapacity(long capacity) => WithDefaultAllocator.EnsureCapacity(capacity);
    public long TrimExcess() => WithDefaultAllocator.TrimExcess();
    public void Resize(long newSize) => WithDefaultAllocator.Resize(newSize);
    public void Resize(long newSize, in T defaultValue) => WithDefaultAllocator.Resize(newSize, in defaultValue);
    public long SetCapacity(long newCapacity) => WithDefaultAllocator.SetCapacity(newCapacity);
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
