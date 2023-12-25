using System.Text;
using FFXIVClientStructs.STD.StdHelpers;

namespace FFXIVClientStructs.STD;

/// <summary>
/// A <see cref="StdBasicString{T,TMemorySpace}"/> using <see cref="DefaultMemorySpaceStatic"/> and <see cref="byte"/>.<br />
/// Encoding contained within is assumed to be the system default encoding.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct StdString : IStdBasicString<byte> {
    [FieldOffset(0x0)] public StdBasicString<byte, DefaultMemorySpaceStatic> BasicString;
    [FieldOffset(0x0)] public byte* BufferPtr;
    [FieldOffset(0x0)] public fixed byte Buffer[16];
    /// <summary>
    /// This string's length, as a <see cref="ulong"/>.
    /// </summary>
    [FieldOffset(0x10)] public ulong Length;
    [FieldOffset(0x18)] public ulong Capacity;

    public readonly Encoding IntrinsicEncoding =>
        CodePagesEncodingProvider.Instance.GetEncoding(0)
        ?? throw new NotSupportedException();
    public byte* First => BasicString.First;
    public byte* Last => BasicString.Last;
    public byte* End => BasicString.End;
    public long LongCapacity {
        get => BasicString.LongCapacity;
        set => BasicString.LongCapacity = value;
    }
    public long LongCount {
        get => BasicString.LongCount;
        set => BasicString.LongCount = value;
    }
    int IStdVector<byte>.Capacity {
        get => BasicString.Capacity;
        set => BasicString.Capacity = value;
    }
    public int Count {
        get => BasicString.Count;
        set => BasicString.Count = value;
    }
    public ref byte this[long index] => ref BasicString[index];

    public static implicit operator ReadOnlySpan<byte>(in StdString value) => value.AsSpan();

    public readonly Span<byte> AsSpan() => BasicString.AsSpan();
    public readonly Span<byte> AsSpan(long index) => BasicString.AsSpan(index);
    public readonly Span<byte> AsSpan(long index, int count) => BasicString.AsSpan(index, count);
    public void Add(in byte item) => BasicString.Add(in item);
    public void AddRange(IEnumerable<byte> collection) => BasicString.AddRange(collection);
    public void AddSpan(ReadOnlySpan<byte> span) => BasicString.AddSpan(span);
    public void AddString(Encoding encoding, ReadOnlySpan<char> str) => BasicString.AddString(encoding, str);
    public void AddString(ReadOnlySpan<char> str) => BasicString.AddString(IntrinsicEncoding, str);
    public readonly long BinarySearch(in byte item) => BasicString.BinarySearch(in item);
    public readonly long BinarySearch(in byte item, IComparer<byte>? comparer) => BasicString.BinarySearch(in item, comparer);
    public readonly long BinarySearch(long index, long count, in byte item, IComparer<byte>? comparer) => BasicString.BinarySearch(index, count, in item, comparer);
    public void Clear() => BasicString.Clear();
    public readonly bool Contains(in byte item) => BasicString.Contains(in item);
    public void Dispose() => BasicString.Dispose();
    public readonly override bool Equals(object? obj) => obj is StdString s && Equals(s);
    public readonly bool Equals(IStdBasicString<byte>? other) => BasicString.Equals(other);
    public readonly bool Equals(in StdString other) => BasicString.Equals(other.BasicString);
    public readonly bool Exists(Predicate<byte> match) => BasicString.Exists(match);
    public readonly byte? Find(Predicate<byte> match) => BasicString.Find(match);
    public readonly int FindIndex(Predicate<byte> match) => BasicString.FindIndex(match);
    public readonly int FindIndex(int startIndex, Predicate<byte> match) => BasicString.FindIndex(startIndex, match);
    public readonly int FindIndex(int startIndex, int count, Predicate<byte> match) => BasicString.FindIndex(startIndex, count, match);
    public readonly int FindLastIndex(Predicate<byte> match) => BasicString.FindLastIndex(match);
    public readonly int FindLastIndex(int startIndex, Predicate<byte> match) => BasicString.FindLastIndex(startIndex, match);
    public readonly int FindLastIndex(int startIndex, int count, Predicate<byte> match) => BasicString.FindLastIndex(startIndex, count, match);
    public readonly void ForEach(Action<byte> action) => BasicString.ForEach(action);
    public readonly IStdVector<byte>.Enumerator GetEnumerator() => BasicString.GetEnumerator();
    public readonly override int GetHashCode() => BasicString.GetHashCode();
    public readonly override string ToString() => Decode(IntrinsicEncoding);
    public readonly int IndexOf(in byte item) => BasicString.IndexOf(in item);
    public readonly int IndexOf(in byte item, int index) => BasicString.IndexOf(in item, index);
    public readonly int IndexOf(in byte item, int index, int count) => BasicString.IndexOf(in item, index, count);
    public void Insert(long index, in byte item) => BasicString.Insert(index, in item);
    public void InsertRange(long index, IEnumerable<byte> collection) => BasicString.InsertRange(index, collection);
    public void InsertSpan(long index, ReadOnlySpan<byte> span) => BasicString.InsertSpan(index, span);
    public void InsertString(Encoding encoding, long index, ReadOnlySpan<char> str) => BasicString.InsertString(encoding, index, str);
    public void InsertString(long index, ReadOnlySpan<char> str) => BasicString.InsertString(IntrinsicEncoding, index, str);
    public readonly int LastIndexOf(in byte item) => BasicString.LastIndexOf(in item);
    public readonly int LastIndexOf(in byte item, int index) => BasicString.LastIndexOf(in item, index);
    public readonly int LastIndexOf(in byte item, int index, int count) => BasicString.LastIndexOf(in item, index, count);
    public bool Remove(in byte item) => BasicString.Remove(in item);
    public long RemoveAll(Predicate<byte> match) => BasicString.RemoveAll(match);
    public void RemoveAt(long index) => BasicString.RemoveAt(index);
    public void RemoveRange(long index, long count) => BasicString.RemoveRange(index, count);
    public void Reverse() => BasicString.Reverse();
    public void Reverse(long index, long count) => BasicString.Reverse(index, count);
    public void Sort() => BasicString.Sort();
    public void Sort(long index, long count) => BasicString.Sort(index, count);
    public void Sort(IComparer<byte>? comparer) => BasicString.Sort(comparer);
    public void Sort(long index, long count, IComparer<byte>? comparer) => BasicString.Sort(index, count, comparer);
    public void Sort(Comparison<byte> comparison) => BasicString.Sort(comparison);
    public void Sort(long index, long count, Comparison<byte> comparison) => BasicString.Sort(index, count, comparison);
    public readonly byte[] ToArray() => BasicString.ToArray();
    public readonly byte[] ToArray(long index) => BasicString.ToArray(index);
    public readonly byte[] ToArray(long index, long count) => BasicString.ToArray(index, count);
    public readonly long LongFindIndex(Predicate<byte> match) => BasicString.LongFindIndex(match);
    public readonly long LongFindIndex(long startIndex, Predicate<byte> match) => BasicString.LongFindIndex(startIndex, match);
    public readonly long LongFindIndex(long startIndex, long count, Predicate<byte> match) => BasicString.LongFindIndex(startIndex, count, match);
    public readonly long LongFindLastIndex(Predicate<byte> match) => BasicString.LongFindLastIndex(match);
    public readonly long LongFindLastIndex(long startIndex, Predicate<byte> match) => BasicString.LongFindLastIndex(startIndex, match);
    public readonly long LongFindLastIndex(long startIndex, long count, Predicate<byte> match) => BasicString.LongFindLastIndex(startIndex, count, match);
    public readonly long LongIndexOf(in byte item) => BasicString.LongIndexOf(in item);
    public readonly long LongIndexOf(in byte item, long index) => BasicString.LongIndexOf(in item, index);
    public readonly long LongIndexOf(in byte item, long index, long count) => BasicString.LongIndexOf(in item, index, count);
    public readonly long LongLastIndexOf(in byte item) => BasicString.LongLastIndexOf(in item);
    public readonly long LongLastIndexOf(in byte item, long index) => BasicString.LongLastIndexOf(in item, index);
    public readonly long LongLastIndexOf(in byte item, long index, long count) => BasicString.LongLastIndexOf(in item, index, count);
    public long EnsureCapacity(long capacity) => BasicString.EnsureCapacity(capacity);
    public long TrimExcess() => BasicString.TrimExcess();
    public void Resize(long newSize) => BasicString.Resize(newSize);
    public void Resize(long newSize, in byte defaultValue) => BasicString.Resize(newSize, in defaultValue);
    public void ResizeUndefined(long newSize) => BasicString.ResizeUndefined(newSize);
    public long SetCapacity(long newCapacity) => BasicString.SetCapacity(newCapacity);
    public readonly int CompareTo(object? obj) => BasicString.CompareTo(obj);
    public readonly int CompareTo(IStdBasicString<byte>? other) => BasicString.CompareTo(other);
    public readonly string Decode(Encoding encoding) => BasicString.Decode(encoding);
    
    [Obsolete($"Use {nameof(AsSpan)} instead.")]
    public readonly ReadOnlySpan<byte> Slice(int start) => AsSpan(start);
    
    [Obsolete($"Use {nameof(AsSpan)} instead.")]
    public readonly ReadOnlySpan<byte> Slice(int start, int length) => AsSpan(start, length);

    [Obsolete($"Use {nameof(ToArray)} or {nameof(AsSpan)} instead.")]
    public readonly byte[] GetBytes() => ToArray();
}
