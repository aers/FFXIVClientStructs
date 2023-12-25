using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.STD.StdHelpers;

namespace FFXIVClientStructs.STD;

/// <summary>
/// A <see cref="StdVector{T,TMemorySpace,TDisposable}"/> using <see cref="DefaultMemorySpaceStatic"/> and <see cref="NonDisposableStatic{T}"/>.
/// </summary>
/// <typeparam name="T">The type of element.</typeparam>
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public unsafe struct StdVector<T> : IStdVector<T>
    where T : unmanaged {
    public StdVector<T, DefaultMemorySpaceStatic, NonDisposableStatic<T>> WithDefaultAllocator;
    public T* First {
        get => WithDefaultAllocator.First;
        set => WithDefaultAllocator.First = value;
    }
    public T* Last {
        get => WithDefaultAllocator.Last;
        set => WithDefaultAllocator.Last = value;
    }
    public T* End {
        get => WithDefaultAllocator.End;
        set => WithDefaultAllocator.End = value;
    }
    public long LongCapacity {
        get => WithDefaultAllocator.LongCapacity;
        set => WithDefaultAllocator.LongCapacity = value;
    }
    public int Count {
        get => WithDefaultAllocator.Count;
        set => WithDefaultAllocator.Count = value;
    }
    public long LongCount {
        get => WithDefaultAllocator.LongCount;
        set => WithDefaultAllocator.LongCount = value;
    }
    public int Capacity {
        get => WithDefaultAllocator.Capacity;
        set => WithDefaultAllocator.Capacity = value;
    }
    public ref T this[long index] => ref WithDefaultAllocator[index];
    public void Dispose() => WithDefaultAllocator.Dispose();
    public Span<T> AsSpan() => WithDefaultAllocator.AsSpan();
    public Span<T> AsSpan(long index) => WithDefaultAllocator.AsSpan(index);
    public Span<T> AsSpan(long index, int count) => WithDefaultAllocator.AsSpan(index, count);
    public void Add(in T item) => WithDefaultAllocator.Add(in item);
    public void AddRange(IEnumerable<T> items) => WithDefaultAllocator.AddRange(items);
    void IStdVector<T>.Clear() => WithDefaultAllocator.Clear();
    public IStdVector<T>.Enumerator GetEnumerator() => WithDefaultAllocator.GetEnumerator();
    public bool Contains(in T item) => WithDefaultAllocator.Contains(in item);
    public bool Exists(Predicate<T> match) => WithDefaultAllocator.Exists(match);
    public T? Find(Predicate<T> match) => WithDefaultAllocator.Find(match);
    public int FindIndex(Predicate<T> match) => WithDefaultAllocator.FindIndex(match);
    public int FindIndex(int startIndex, Predicate<T> match) => WithDefaultAllocator.FindIndex(startIndex, match);
    public int FindIndex(int startIndex, int count, Predicate<T> match) => WithDefaultAllocator.FindIndex(startIndex, count, match);
    public int FindLastIndex(Predicate<T> match) => WithDefaultAllocator.FindLastIndex(match);
    public int FindLastIndex(int startIndex, Predicate<T> match) => WithDefaultAllocator.FindLastIndex(startIndex, match);
    public int FindLastIndex(int startIndex, int count, Predicate<T> match) => WithDefaultAllocator.FindLastIndex(startIndex, count, match);
    public void ForEach(Action<T> action) => WithDefaultAllocator.ForEach(action);
    public int IndexOf(in T item) => WithDefaultAllocator.IndexOf(in item);
    public int IndexOf(in T item, int index) => WithDefaultAllocator.IndexOf(in item, index);
    public int IndexOf(in T item, int index, int count) => WithDefaultAllocator.IndexOf(in item, index, count);
    public void Insert(long index, in T item) => WithDefaultAllocator.Insert(index, in item);
    public void InsertRange(long index, IEnumerable<T> collection) => WithDefaultAllocator.InsertRange(index, collection);
    public int LastIndexOf(in T item) => WithDefaultAllocator.LastIndexOf(in item);
    public int LastIndexOf(in T item, int index) => WithDefaultAllocator.LastIndexOf(in item, index);
    public int LastIndexOf(in T item, int index, int count) => WithDefaultAllocator.LastIndexOf(in item, index, count);
    public bool Remove(in T item) => WithDefaultAllocator.Remove(in item);
    public long RemoveAll(Predicate<T> match) => WithDefaultAllocator.RemoveAll(match);
    public void RemoveAt(long index) => WithDefaultAllocator.RemoveAt(index);
    public void RemoveRange(long index, long count) => WithDefaultAllocator.RemoveRange(index, count);
    public void Reverse() => WithDefaultAllocator.Reverse();
    public void Reverse(long index, long count) => WithDefaultAllocator.Reverse(index, count);
    public void Sort() => WithDefaultAllocator.Sort();
    public void Sort(IComparer<T>? comparer) => WithDefaultAllocator.Sort(comparer);
    public void Sort(long index, long count, IComparer<T>? comparer) => WithDefaultAllocator.Sort(index, count, comparer);
    public void Sort(Comparison<T> comparison) => WithDefaultAllocator.Sort(comparison);
    public void Sort(long index, long count, Comparison<T> comparison) => WithDefaultAllocator.Sort(index, count, comparison);
    public T[] ToArray() => WithDefaultAllocator.ToArray();
    public T[] ToArray(long index) => WithDefaultAllocator.ToArray(index);
    public T[] ToArray(long index, long count) => WithDefaultAllocator.ToArray(index, count);
    public long LongFindIndex(Predicate<T> match) => WithDefaultAllocator.LongFindIndex(match);
    public long LongFindIndex(long startIndex, Predicate<T> match) => WithDefaultAllocator.LongFindIndex(startIndex, match);
    public long LongFindIndex(long startIndex, long count, Predicate<T> match) => WithDefaultAllocator.LongFindIndex(startIndex, count, match);
    public long LongFindLastIndex(Predicate<T> match) => WithDefaultAllocator.LongFindLastIndex(match);
    public long LongFindLastIndex(long startIndex, Predicate<T> match) => WithDefaultAllocator.LongFindLastIndex(startIndex, match);
    public long LongFindLastIndex(long startIndex, long count, Predicate<T> match) => WithDefaultAllocator.LongFindLastIndex(startIndex, count, match);
    public long LongIndexOf(in T item) => WithDefaultAllocator.LongIndexOf(in item);
    public long LongIndexOf(in T item, long index) => WithDefaultAllocator.LongIndexOf(in item, index);
    public long LongIndexOf(in T item, long index, long count) => WithDefaultAllocator.LongIndexOf(in item, index, count);
    public long LongLastIndexOf(in T item) => WithDefaultAllocator.LongLastIndexOf(in item);
    public long LongLastIndexOf(in T item, long index) => WithDefaultAllocator.LongLastIndexOf(in item, index);
    public long LongLastIndexOf(in T item, long index, long count) => WithDefaultAllocator.LongLastIndexOf(in item, index, count);
    public long EnsureCapacity(long capacity) => WithDefaultAllocator.EnsureCapacity(capacity);
    public long TrimExcess() => WithDefaultAllocator.TrimExcess();
    public void Resize(long newSize) => WithDefaultAllocator.Resize(newSize);
    public void Resize(long newSize, in T defaultValue) => WithDefaultAllocator.Resize(newSize, in defaultValue);
    public long SetCapacity(long newCapacity) => WithDefaultAllocator.SetCapacity(newCapacity);
}
