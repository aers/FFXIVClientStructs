using System.Text;
using FFXIVClientStructs.STD.StdHelpers;

namespace FFXIVClientStructs.STD;

/// <summary>
/// A <see cref="StdBasicString{T,TMemorySpace}"/> using <see cref="DefaultMemorySpaceStatic"/> and <see cref="char"/>.<br />
/// Encoding contained within is assumed to be UTF-16.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct StdWString : IStdBasicString<char> {
    [FieldOffset(0x0)] public StdBasicString<char, DefaultMemorySpaceStatic> BasicString;

    public readonly Encoding IntrinsicEncoding => Encoding.Unicode;
    public readonly char* First => BasicString.First;
    public readonly char* Last => BasicString.Last;
    public readonly char* End => BasicString.End;
    public long LongCapacity {
        readonly get => BasicString.LongCapacity;
        set => BasicString.LongCapacity = value;
    }
    public long LongCount {
        readonly get => BasicString.LongCount;
        set => BasicString.LongCount = value;
    }
    public int Capacity {
        readonly get => BasicString.Capacity;
        set => BasicString.Capacity = value;
    }
    public int Count {
        readonly get => BasicString.Count;
        set => BasicString.Count = value;
    }
    public readonly ref char this[long index] => ref BasicString[index];

    public static implicit operator ReadOnlySpan<char>(in StdWString value) => value.AsSpan();

    public void Dispose() => BasicString.Dispose();
    public readonly Span<char> AsSpan() => BasicString.AsSpan();
    public readonly Span<char> AsSpan(long index) => BasicString.AsSpan(index);
    public readonly Span<char> AsSpan(long index, int count) => BasicString.AsSpan(index, count);
    public void Add(in char item) => BasicString.Add(in item);
    public void AddRange(IEnumerable<char> collection) => BasicString.AddRange(collection);
    public void AddSpan(ReadOnlySpan<char> span) => BasicString.AddSpan(span);
    public void AddString(Encoding encoding, ReadOnlySpan<char> str) => BasicString.AddString(encoding, str);
    public void AddString(ReadOnlySpan<char> str) => BasicString.AddString(IntrinsicEncoding, str);
    public readonly long BinarySearch(in char item) => BasicString.BinarySearch(in item);
    public readonly long BinarySearch(in char item, IComparer<char>? comparer) => BasicString.BinarySearch(in item, comparer);
    public readonly long BinarySearch(long index, long count, in char item, IComparer<char>? comparer) => BasicString.BinarySearch(index, count, in item, comparer);
    public void Clear() => BasicString.Clear();
    public readonly bool Contains(in char item) => BasicString.Contains(in item);
    public readonly override bool Equals(object? obj) => obj is StdWString s && Equals(s);
    public readonly bool Equals(IStdBasicString<char>? other) => BasicString.Equals(other);
    public readonly bool Equals(in StdWString other) => BasicString.Equals(other.BasicString);
    public readonly bool Exists(Predicate<char> match) => BasicString.Exists(match);
    public readonly char? Find(Predicate<char> match) => BasicString.Find(match);
    public readonly int FindIndex(Predicate<char> match) => BasicString.FindIndex(match);
    public readonly int FindIndex(int startIndex, Predicate<char> match) => BasicString.FindIndex(startIndex, match);
    public readonly int FindIndex(int startIndex, int count, Predicate<char> match) => BasicString.FindIndex(startIndex, count, match);
    public readonly int FindLastIndex(Predicate<char> match) => BasicString.FindLastIndex(match);
    public readonly int FindLastIndex(int startIndex, Predicate<char> match) => BasicString.FindLastIndex(startIndex, match);
    public readonly int FindLastIndex(int startIndex, int count, Predicate<char> match) => BasicString.FindLastIndex(startIndex, count, match);
    public readonly void ForEach(Action<char> action) => BasicString.ForEach(action);
    public readonly IStdVector<char>.Enumerator GetEnumerator() => BasicString.GetEnumerator();
    public readonly override int GetHashCode() => BasicString.GetHashCode();
    public readonly override string ToString() => Decode(Encoding.Unicode);
    public readonly int IndexOf(in char item) => BasicString.IndexOf(in item);
    public readonly int IndexOf(in char item, int index) => BasicString.IndexOf(in item, index);
    public readonly int IndexOf(in char item, int index, int count) => BasicString.IndexOf(in item, index, count);
    public void Insert(long index, in char item) => BasicString.Insert(index, in item);
    public void InsertRange(long index, IEnumerable<char> collection) => BasicString.InsertRange(index, collection);
    public void InsertSpan(long index, ReadOnlySpan<char> span) => BasicString.InsertSpan(index, span);
    public void InsertString(Encoding encoding, long index, ReadOnlySpan<char> str) => BasicString.InsertString(encoding, index, str);
    public void InsertString(long index, ReadOnlySpan<char> str) => BasicString.InsertString(IntrinsicEncoding, index, str);
    public readonly int LastIndexOf(in char item) => BasicString.LastIndexOf(in item);
    public readonly int LastIndexOf(in char item, int index) => BasicString.LastIndexOf(in item, index);
    public readonly int LastIndexOf(in char item, int index, int count) => BasicString.LastIndexOf(in item, index, count);
    public bool Remove(in char item) => BasicString.Remove(in item);
    public long RemoveAll(Predicate<char> match) => BasicString.RemoveAll(match);
    public void RemoveAt(long index) => BasicString.RemoveAt(index);
    public void RemoveRange(long index, long count) => BasicString.RemoveRange(index, count);
    public void Reverse() => BasicString.Reverse();
    public void Reverse(long index, long count) => BasicString.Reverse(index, count);
    public void Sort() => BasicString.Sort();
    public void Sort(long index, long count) => BasicString.Sort(index, count);
    public void Sort(IComparer<char>? comparer) => BasicString.Sort(comparer);
    public void Sort(long index, long count, IComparer<char>? comparer) => BasicString.Sort(index, count, comparer);
    public void Sort(Comparison<char> comparison) => BasicString.Sort(comparison);
    public void Sort(long index, long count, Comparison<char> comparison) => BasicString.Sort(index, count, comparison);
    public readonly char[] ToArray() => BasicString.ToArray();
    public readonly char[] ToArray(long index) => BasicString.ToArray(index);
    public readonly char[] ToArray(long index, long count) => BasicString.ToArray(index, count);
    public readonly long LongFindIndex(Predicate<char> match) => BasicString.LongFindIndex(match);
    public readonly long LongFindIndex(long startIndex, Predicate<char> match) => BasicString.LongFindIndex(startIndex, match);
    public readonly long LongFindIndex(long startIndex, long count, Predicate<char> match) => BasicString.LongFindIndex(startIndex, count, match);
    public readonly long LongFindLastIndex(Predicate<char> match) => BasicString.LongFindLastIndex(match);
    public readonly long LongFindLastIndex(long startIndex, Predicate<char> match) => BasicString.LongFindLastIndex(startIndex, match);
    public readonly long LongFindLastIndex(long startIndex, long count, Predicate<char> match) => BasicString.LongFindLastIndex(startIndex, count, match);
    public readonly long LongIndexOf(in char item) => BasicString.LongIndexOf(in item);
    public readonly long LongIndexOf(in char item, long index) => BasicString.LongIndexOf(in item, index);
    public readonly long LongIndexOf(in char item, long index, long count) => BasicString.LongIndexOf(in item, index, count);
    public readonly long LongLastIndexOf(in char item) => BasicString.LongLastIndexOf(in item);
    public readonly long LongLastIndexOf(in char item, long index) => BasicString.LongLastIndexOf(in item, index);
    public readonly long LongLastIndexOf(in char item, long index, long count) => BasicString.LongLastIndexOf(in item, index, count);
    public long EnsureCapacity(long capacity) => BasicString.EnsureCapacity(capacity);
    public long TrimExcess() => BasicString.TrimExcess();
    public void Resize(long newSize) => BasicString.Resize(newSize);
    public void Resize(long newSize, in char defaultValue) => BasicString.Resize(newSize, in defaultValue);
    public void ResizeUndefined(long newSize) => BasicString.ResizeUndefined(newSize);
    public long SetCapacity(long newCapacity) => BasicString.SetCapacity(newCapacity);
    public readonly int CompareTo(object? obj) => BasicString.CompareTo(obj);
    public readonly int CompareTo(IStdBasicString<char>? other) => BasicString.CompareTo(other);
    public readonly string Decode(Encoding encoding) => BasicString.Decode(encoding);
}
