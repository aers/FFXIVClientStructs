using System.Collections;
using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.STD.ContainerInterface;
using FFXIVClientStructs.STD.Helper;

namespace FFXIVClientStructs.STD;

/// <summary>
/// A <see cref="StdVector{T,TMemorySpace}"/> using <see cref="IStaticMemorySpace.Default"/> and <see cref="StdOps{T}"/>.
/// </summary>
/// <typeparam name="T">The type of element.</typeparam>
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public unsafe struct StdVector<T> : IStdVector<T>
    where T : unmanaged {
    public StdVector<T, IStaticMemorySpace.Default> WithOps;
    public T* First {
        readonly get => WithOps.First;
        set => WithOps.First = value;
    }
    public T* Last {
        readonly get => WithOps.Last;
        set => WithOps.Last = value;
    }
    public T* End {
        readonly get => WithOps.End;
        set => WithOps.End = value;
    }
    public long LongCapacity {
        readonly get => WithOps.LongCapacity;
        set => WithOps.LongCapacity = value;
    }
    public readonly void* RepresentativePointer => WithOps.RepresentativePointer;
    public int Count {
        readonly get => WithOps.Count;
        set => WithOps.Count = value;
    }
    public long LongCount {
        readonly get => WithOps.LongCount;
        set => WithOps.LongCount = value;
    }
    int IStdVector<T>.Capacity {
        readonly get => WithOps.Capacity;
        set => WithOps.Capacity = value;
    }
    public readonly ref T this[long index] => ref WithOps[index];

    public static implicit operator Span<T>(in StdVector<T> value) => value.AsSpan();
    public static implicit operator ReadOnlySpan<T>(in StdVector<T> value) => value.AsSpan();
    public void Dispose() => WithOps.Dispose();
    public readonly Span<T> AsSpan() => WithOps.AsSpan();
    public readonly Span<T> AsSpan(long index) => WithOps.AsSpan(index);
    public readonly Span<T> AsSpan(long index, int count) => WithOps.AsSpan(index, count);
    public readonly StdSpan<T> AsStdSpan() => WithOps.AsStdSpan();
    public readonly StdSpan<T> AsStdSpan(long index) => WithOps.AsStdSpan(index);
    public readonly StdSpan<T> AsStdSpan(long index, long count) => WithOps.AsStdSpan(index, count);
    public void AddCopy(in T item) => WithOps.AddCopy(in item);
    public void AddMove(ref T item) => WithOps.AddMove(ref item);
    public void AddRangeCopy(IEnumerable<T> collection) => WithOps.AddRangeCopy(collection);
    public void AddSpanCopy(ReadOnlySpan<T> span) => WithOps.AddSpanCopy(span);
    public void AddSpanMove(Span<T> span) => WithOps.AddSpanMove(span);
    public readonly long BinarySearch(in T item) => WithOps.BinarySearch(item);
    public readonly long BinarySearch(in T item, IComparer<T>? comparer) => WithOps.BinarySearch(item, comparer);
    public readonly long BinarySearch(long index, long count, in T item, IComparer<T>? comparer) => WithOps.BinarySearch(index, count, item, comparer);
    public void Clear() => WithOps.Clear();
    public readonly bool Contains(in T item) => WithOps.Contains(in item);
    public readonly bool Contains(T* subsequence, IntPtr length) => WithOps.Contains(subsequence, length);
    public readonly bool Contains(ReadOnlySpan<T> subsequence) => WithOps.Contains(subsequence);
    public readonly int CompareTo(object? obj) => WithOps.CompareTo(obj);
    public readonly int CompareTo(IStdRandomElementReadable<T>? other) => WithOps.CompareTo(other);
    public readonly void CopyTo(T[] array, int arrayIndex) => WithOps.CopyTo(array, arrayIndex);
    public readonly override bool Equals(object? obj) => obj is StdVector<T> v && Equals(v);
    public readonly bool Equals(IStdRandomElementReadable<T>? other) => other is StdVector<T> v && Equals(v);
    public readonly bool Equals(in StdVector<T> other) => WithOps.Equals(other.WithOps);
    public readonly bool Exists(Predicate<T> match) => WithOps.Exists(match);
    public readonly T? Find(Predicate<T> match) => WithOps.Find(match);
    public readonly int FindIndex(Predicate<T> match) => WithOps.FindIndex(match);
    public readonly int FindIndex(int startIndex, Predicate<T> match) => WithOps.FindIndex(startIndex, match);
    public readonly int FindIndex(int startIndex, int count, Predicate<T> match) => WithOps.FindIndex(startIndex, count, match);
    public readonly int FindLastIndex(Predicate<T> match) => WithOps.FindLastIndex(match);
    public readonly int FindLastIndex(int startIndex, Predicate<T> match) => WithOps.FindLastIndex(startIndex, match);
    public readonly int FindLastIndex(int startIndex, int count, Predicate<T> match) => WithOps.FindLastIndex(startIndex, count, match);
    public readonly void ForEach(Action<T> action) => WithOps.ForEach(action);
    public readonly UnmanagedArrayEnumerator<T> GetEnumerator() => WithOps.GetEnumerator();
    readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
    readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public readonly int IndexOf(in T item) => WithOps.IndexOf(in item);
    public readonly int IndexOf(in T item, int index) => WithOps.IndexOf(in item, index);
    public readonly int IndexOf(in T item, int index, int count) => WithOps.IndexOf(in item, index, count);
    public readonly int IndexOf(ReadOnlySpan<T> subsequence) => WithOps.IndexOf(subsequence);
    public readonly int IndexOf(ReadOnlySpan<T> subsequence, int index) => WithOps.IndexOf(subsequence, index);
    public readonly int IndexOf(ReadOnlySpan<T> subsequence, int index, int count) => WithOps.IndexOf(subsequence, index, count);
    public void InsertCopy(long index, in T item) => WithOps.InsertCopy(index, in item);
    public void InsertMove(long index, ref T item) => WithOps.InsertMove(index, ref item);
    public void InsertRangeCopy(long index, IEnumerable<T> collection) => WithOps.InsertRangeCopy(index, collection);
    public void InsertSpanCopy(long index, ReadOnlySpan<T> span) => WithOps.InsertSpanCopy(index, span);
    public void InsertSpanMove(long index, Span<T> span) => WithOps.InsertSpanMove(index, span);
    public readonly int LastIndexOf(in T item) => WithOps.LastIndexOf(in item);
    public readonly int LastIndexOf(in T item, int index) => WithOps.LastIndexOf(in item, index);
    public readonly int LastIndexOf(in T item, int index, int count) => WithOps.LastIndexOf(in item, index, count);
    public readonly int LastIndexOf(ReadOnlySpan<T> subsequence) => WithOps.LastIndexOf(subsequence);
    public readonly int LastIndexOf(ReadOnlySpan<T> subsequence, int index) => WithOps.LastIndexOf(subsequence, index);
    public readonly int LastIndexOf(ReadOnlySpan<T> subsequence, int index, int count) => WithOps.LastIndexOf(subsequence, index, count);
    public bool Remove(in T item) => WithOps.Remove(in item);
    public long RemoveAll(Predicate<T> match) => WithOps.RemoveAll(match);
    public void RemoveAt(long index) => WithOps.RemoveAt(index);
    public void RemoveRange(long index, long count) => WithOps.RemoveRange(index, count);
    public void Reverse() => WithOps.Reverse();
    public void Reverse(long index, long count) => WithOps.Reverse(index, count);
    public void Sort() => WithOps.Sort();
    public void Sort(long index, long count) => WithOps.Sort(index, count);
    public void Sort(IComparer<T>? comparer) => WithOps.Sort(comparer);
    public void Sort(long index, long count, IComparer<T>? comparer) => WithOps.Sort(index, count, comparer);
    public void Sort(Comparison<T> comparison) => WithOps.Sort(comparison);
    public void Sort(long index, long count, Comparison<T> comparison) => WithOps.Sort(index, count, comparison);
    public readonly T[] ToArray() => WithOps.ToArray();
    public readonly T[] ToArray(long index) => WithOps.ToArray(index);
    public readonly T[] ToArray(long index, long count) => WithOps.ToArray(index, count);
    public readonly long LongFindIndex(Predicate<T> match) => WithOps.LongFindIndex(match);
    public readonly long LongFindIndex(long startIndex, Predicate<T> match) => WithOps.LongFindIndex(startIndex, match);
    public readonly long LongFindIndex(long startIndex, long count, Predicate<T> match) => WithOps.LongFindIndex(startIndex, count, match);
    public readonly long LongFindLastIndex(Predicate<T> match) => WithOps.LongFindLastIndex(match);
    public readonly long LongFindLastIndex(long startIndex, Predicate<T> match) => WithOps.LongFindLastIndex(startIndex, match);
    public readonly long LongFindLastIndex(long startIndex, long count, Predicate<T> match) => WithOps.LongFindLastIndex(startIndex, count, match);
    public readonly long LongIndexOf(in T item) => WithOps.LongIndexOf(in item);
    public readonly long LongIndexOf(in T item, long index) => WithOps.LongIndexOf(in item, index);
    public readonly long LongIndexOf(in T item, long index, long count) => WithOps.LongIndexOf(in item, index, count);
    public readonly long LongIndexOf(ReadOnlySpan<T> subsequence) => WithOps.LongIndexOf(subsequence);
    public readonly long LongIndexOf(ReadOnlySpan<T> subsequence, long index) => WithOps.LongIndexOf(subsequence, index);
    public readonly long LongIndexOf(ReadOnlySpan<T> subsequence, long index, long count) => WithOps.LongIndexOf(subsequence, index, count);
    public readonly long LongIndexOf(T* subsequence, IntPtr subsequenceLength) => WithOps.LongIndexOf(subsequence, subsequenceLength);
    public readonly long LongIndexOf(T* subsequence, IntPtr subsequenceLength, long index) => WithOps.LongIndexOf(subsequence, subsequenceLength, index);
    public readonly long LongIndexOf(T* subsequence, IntPtr subsequenceLength, long index, long count) => WithOps.LongIndexOf(subsequence, subsequenceLength, index, count);
    public readonly long LongLastIndexOf(in T item) => WithOps.LongLastIndexOf(in item);
    public readonly long LongLastIndexOf(in T item, long index) => WithOps.LongLastIndexOf(in item, index);
    public readonly long LongLastIndexOf(in T item, long index, long count) => WithOps.LongLastIndexOf(in item, index, count);
    public readonly long LongLastIndexOf(ReadOnlySpan<T> subsequence) => WithOps.LongLastIndexOf(subsequence);
    public readonly long LongLastIndexOf(ReadOnlySpan<T> subsequence, long index) => WithOps.LongLastIndexOf(subsequence, index);
    public readonly long LongLastIndexOf(ReadOnlySpan<T> subsequence, long index, long count) => WithOps.LongLastIndexOf(subsequence, index, count);
    public readonly long LongLastIndexOf(T* subsequence, IntPtr subsequenceLength) => WithOps.LongLastIndexOf(subsequence, subsequenceLength);
    public readonly long LongLastIndexOf(T* subsequence, IntPtr subsequenceLength, long index) => WithOps.LongLastIndexOf(subsequence, subsequenceLength, index);
    public readonly long LongLastIndexOf(T* subsequence, IntPtr subsequenceLength, long index, long count) => WithOps.LongLastIndexOf(subsequence, subsequenceLength, index, count);
    public long EnsureCapacity(long capacity) => WithOps.EnsureCapacity(capacity);
    public long TrimExcess() => WithOps.TrimExcess();
    public void Resize(long newSize) => WithOps.Resize(newSize);
    public void Resize(long newSize, in T defaultValue) => WithOps.Resize(newSize, in defaultValue);
    public long SetCapacity(long newCapacity) => WithOps.SetCapacity(newCapacity);
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
