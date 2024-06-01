using System.Collections;
using FFXIVClientStructs.STD.ContainerInterface;
using FFXIVClientStructs.STD.Helper;

namespace FFXIVClientStructs.STD;

/// <summary>
/// A <see cref="StdBasicString{T,TEncoding,TMemorySpace}"/> using
/// <see cref="IStaticMemorySpace.Default"/>, <see cref="IStaticEncoding.System"/> and <see cref="byte"/>.<br />
/// Encoding contained within is assumed to be the system default encoding.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct StdString
    : IStdBasicString<byte>
        , IStaticNativeObjectOperation<StdString> {
    [FieldOffset(0x0), CExportIgnore] public StdBasicString<byte, IStaticEncoding.System, IStaticMemorySpace.Default> BasicString;
    [FieldOffset(0x0), CExporterUnion("Buffer")] public byte* BufferPtr;
    [FieldOffset(0x0), CExporterUnion("Buffer")] public fixed byte Buffer[16];
    /// <summary>
    /// This string's length, as a <see cref="ulong"/>.
    /// </summary>
    [FieldOffset(0x10)] public ulong Length;
    [FieldOffset(0x18)] public ulong Capacity;

    public static bool HasDefault => StdBasicString<char, IStaticEncoding.System, IStaticMemorySpace.Default>.HasDefault;
    public static bool IsDisposable => StdBasicString<char, IStaticEncoding.System, IStaticMemorySpace.Default>.IsDisposable;
    public static bool IsCopiable => StdBasicString<char, IStaticEncoding.System, IStaticMemorySpace.Default>.IsCopiable;
    public static bool IsMovable => StdBasicString<char, IStaticEncoding.System, IStaticMemorySpace.Default>.IsMovable;

    public long LongCapacity {
        readonly get => BasicString.LongCapacity;
        set => BasicString.LongCapacity = value;
    }
    public long LongCount {
        readonly get => BasicString.LongCount;
        set => BasicString.LongCount = value;
    }
    int IStdVector<byte>.Capacity {
        readonly get => BasicString.Capacity;
        set => BasicString.Capacity = value;
    }
    public void* RepresentativePointer => BasicString.RepresentativePointer;
    public int Count {
        readonly get => BasicString.Count;
        set => BasicString.Count = value;
    }
    public readonly ref byte this[long index] => ref BasicString[index];
    public readonly ref byte this[int index] => ref BasicString[index];
    public readonly ref byte this[Index index] => ref BasicString[index];

    public static implicit operator Span<byte>(in StdString value) => value.AsSpan();
    public static implicit operator ReadOnlySpan<byte>(in StdString value) => value.AsSpan();
    public static implicit operator StdSpan<byte>(in StdString value) => value.AsStdSpan();

    public static int Compare(in StdString left, in StdString right) => StdBasicString<byte, IStaticEncoding.System, IStaticMemorySpace.Default>.Compare(left.BasicString, right.BasicString);
    public static bool ContentEquals(in StdString left, in StdString right) => StdBasicString<byte, IStaticEncoding.System, IStaticMemorySpace.Default>.ContentEquals(left.BasicString, right.BasicString);
    public static void ConstructDefaultInPlace(out StdString item) {
        item = default;
        StdBasicString<byte, IStaticEncoding.System, IStaticMemorySpace.Default>.ConstructDefaultInPlace(out item.BasicString);
    }
    public static void StaticDispose(ref StdString item) => StdBasicString<byte, IStaticEncoding.System, IStaticMemorySpace.Default>.StaticDispose(ref item.BasicString);
    public static void ConstructCopyInPlace(in StdString source, out StdString target) {
        target = default;
        StdBasicString<byte, IStaticEncoding.System, IStaticMemorySpace.Default>.ConstructCopyInPlace(in source.BasicString, out target.BasicString);
    }
    public static void ConstructMoveInPlace(ref StdString source, out StdString target) {
        target = default;
        StdBasicString<byte, IStaticEncoding.System, IStaticMemorySpace.Default>.ConstructMoveInPlace(ref source.BasicString, out target.BasicString);
    }
    public static void Swap(ref StdString item1, ref StdString item2) => StdBasicString<byte, IStaticEncoding.System, IStaticMemorySpace.Default>.Swap(ref item1.BasicString, ref item2.BasicString);

    public readonly Span<byte> AsSpan() => BasicString.AsSpan();
    public readonly Span<byte> AsSpan(long index) => BasicString.AsSpan(index);
    public readonly Span<byte> AsSpan(long index, int count) => BasicString.AsSpan(index, count);
    public readonly StdSpan<byte> AsStdSpan() => BasicString.AsStdSpan();
    public readonly StdSpan<byte> AsStdSpan(long index) => BasicString.AsStdSpan(index);
    public readonly StdSpan<byte> AsStdSpan(long index, long count) => BasicString.AsStdSpan(index, count);
    public void AddCopy(in byte item) => BasicString.AddCopy(in item);
    public void AddMove(ref byte item) => BasicString.AddMove(ref item);
    public void AddRangeCopy(IEnumerable<byte> collection) => BasicString.AddRangeCopy(collection);
    public void AddSpanCopy(ReadOnlySpan<byte> span) => BasicString.AddSpanCopy(span);
    public void AddSpanMove(Span<byte> span) => BasicString.AddSpanMove(span);
    public void AddString(ReadOnlySpan<char> str) => BasicString.AddString(str);
    public readonly long BinarySearch(in byte item) => BasicString.BinarySearch(in item);
    public readonly long BinarySearch(in byte item, IComparer<byte>? comparer) => BasicString.BinarySearch(in item, comparer);
    public readonly long BinarySearch(long index, long count, in byte item, IComparer<byte>? comparer) => BasicString.BinarySearch(index, count, in item, comparer);
    public void Clear() => BasicString.Clear();
    public readonly int CompareTo(object? obj) => obj switch { null => 1, StdString s => BasicString.CompareTo(s.BasicString), _ => BasicString.CompareTo(obj) };
    public readonly int CompareTo(IStdRandomElementReadable<byte>? other) => BasicString.CompareTo(other);
    public readonly bool Contains(in byte item) => BasicString.Contains(in item);
    public readonly bool Contains(byte* subsequence, IntPtr length) => BasicString.Contains(subsequence, length);
    public readonly bool Contains(ReadOnlySpan<byte> subsequence) => BasicString.Contains(subsequence);
    public readonly bool ContainsString(ReadOnlySpan<char> str) => BasicString.ContainsString(str);
    public readonly void CopyTo(byte[] array, int arrayIndex) => BasicString.CopyTo(array, arrayIndex);
    public void Dispose() => BasicString.Dispose();
    public readonly override bool Equals(object? obj) => obj is StdString s && Equals(s);
    public readonly bool Equals(IStdRandomElementReadable<byte>? other) => other is StdString s && Equals(s);
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
    public readonly UnmanagedArrayEnumerator<byte> GetEnumerator() => BasicString.GetEnumerator();
    readonly IEnumerator<byte> IEnumerable<byte>.GetEnumerator() => GetEnumerator();
    readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public readonly override int GetHashCode() => BasicString.GetHashCode();
    public readonly override string ToString() => BasicString.ToString();
    public readonly int IndexOf(in byte item) => BasicString.IndexOf(in item);
    public readonly int IndexOf(in byte item, int index) => BasicString.IndexOf(in item, index);
    public readonly int IndexOf(in byte item, int index, int count) => BasicString.IndexOf(in item, index, count);
    public readonly int IndexOf(ReadOnlySpan<byte> subsequence) => BasicString.IndexOf(subsequence);
    public readonly int IndexOf(ReadOnlySpan<byte> subsequence, int index) => BasicString.IndexOf(subsequence, index);
    public readonly int IndexOf(ReadOnlySpan<byte> subsequence, int index, int count) => BasicString.IndexOf(subsequence, index, count);
    public readonly int IndexOfString(ReadOnlySpan<char> str) => BasicString.IndexOfString(str);
    public readonly int IndexOfString(ReadOnlySpan<char> str, int index) => BasicString.IndexOfString(str, index);
    public readonly int IndexOfString(ReadOnlySpan<char> str, int index, int count) => BasicString.IndexOfString(str, index, count);
    public void InsertCopy(long index, in byte item) => BasicString.InsertCopy(index, in item);
    public void InsertMove(long index, ref byte item) => BasicString.InsertMove(index, ref item);
    public void InsertRangeCopy(long index, IEnumerable<byte> collection) => BasicString.InsertRangeCopy(index, collection);
    public void InsertSpanCopy(long index, ReadOnlySpan<byte> span) => BasicString.InsertSpanCopy(index, span);
    public void InsertSpanMove(long index, Span<byte> span) => BasicString.InsertSpanMove(index, span);
    public void InsertString(long index, ReadOnlySpan<char> str) => BasicString.InsertString(index, str);
    public readonly int LastIndexOf(in byte item) => BasicString.LastIndexOf(in item);
    public readonly int LastIndexOf(in byte item, int index) => BasicString.LastIndexOf(in item, index);
    public readonly int LastIndexOf(in byte item, int index, int count) => BasicString.LastIndexOf(in item, index, count);
    public readonly int LastIndexOf(ReadOnlySpan<byte> subsequence) => BasicString.LastIndexOf(subsequence);
    public readonly int LastIndexOf(ReadOnlySpan<byte> subsequence, int index) => BasicString.LastIndexOf(subsequence, index);
    public readonly int LastIndexOf(ReadOnlySpan<byte> subsequence, int index, int count) => BasicString.LastIndexOf(subsequence, index, count);
    public readonly int LastIndexOfString(ReadOnlySpan<char> str) => BasicString.LastIndexOfString(str);
    public readonly int LastIndexOfString(ReadOnlySpan<char> str, int index) => BasicString.LastIndexOfString(str, index);
    public readonly int LastIndexOfString(ReadOnlySpan<char> str, int index, int count) => BasicString.LastIndexOfString(str, index, count);
    public readonly long LongIndexOfString(ReadOnlySpan<char> str) => BasicString.LongIndexOfString(str);
    public readonly long LongIndexOfString(ReadOnlySpan<char> str, long index) => BasicString.LongIndexOfString(str, index);
    public readonly long LongIndexOfString(ReadOnlySpan<char> str, long index, long count) => BasicString.LongIndexOfString(str, index, count);
    public readonly long LongFindIndex(Predicate<byte> match) => BasicString.LongFindIndex(match);
    public readonly long LongFindIndex(long startIndex, Predicate<byte> match) => BasicString.LongFindIndex(startIndex, match);
    public readonly long LongFindIndex(long startIndex, long count, Predicate<byte> match) => BasicString.LongFindIndex(startIndex, count, match);
    public readonly long LongFindLastIndex(Predicate<byte> match) => BasicString.LongFindLastIndex(match);
    public readonly long LongFindLastIndex(long startIndex, Predicate<byte> match) => BasicString.LongFindLastIndex(startIndex, match);
    public readonly long LongFindLastIndex(long startIndex, long count, Predicate<byte> match) => BasicString.LongFindLastIndex(startIndex, count, match);
    public readonly long LongIndexOf(in byte item) => BasicString.LongIndexOf(in item);
    public readonly long LongIndexOf(in byte item, long index) => BasicString.LongIndexOf(in item, index);
    public readonly long LongIndexOf(in byte item, long index, long count) => BasicString.LongIndexOf(in item, index, count);
    public readonly long LongIndexOf(ReadOnlySpan<byte> subsequence) => BasicString.LongIndexOf(subsequence);
    public readonly long LongIndexOf(ReadOnlySpan<byte> subsequence, long index) => BasicString.LongIndexOf(subsequence, index);
    public readonly long LongIndexOf(ReadOnlySpan<byte> subsequence, long index, long count) => BasicString.LongIndexOf(subsequence, index, count);
    public readonly long LongIndexOf(byte* subsequence, IntPtr subsequenceLength) => BasicString.LongIndexOf(subsequence, subsequenceLength);
    public readonly long LongIndexOf(byte* subsequence, IntPtr subsequenceLength, long index) => BasicString.LongIndexOf(subsequence, subsequenceLength, index);
    public readonly long LongIndexOf(byte* subsequence, IntPtr subsequenceLength, long index, long count) => BasicString.LongIndexOf(subsequence, subsequenceLength, index, count);
    public readonly long LongLastIndexOf(in byte item) => BasicString.LongLastIndexOf(in item);
    public readonly long LongLastIndexOf(in byte item, long index) => BasicString.LongLastIndexOf(in item, index);
    public readonly long LongLastIndexOf(in byte item, long index, long count) => BasicString.LongLastIndexOf(in item, index, count);
    public readonly long LongLastIndexOf(ReadOnlySpan<byte> subsequence) => BasicString.LongLastIndexOf(subsequence);
    public readonly long LongLastIndexOf(ReadOnlySpan<byte> subsequence, long index) => BasicString.LongLastIndexOf(subsequence, index);
    public readonly long LongLastIndexOf(ReadOnlySpan<byte> subsequence, long index, long count) => BasicString.LongLastIndexOf(subsequence, index, count);
    public readonly long LongLastIndexOf(byte* subsequence, IntPtr subsequenceLength) => BasicString.LongLastIndexOf(subsequence, subsequenceLength);
    public readonly long LongLastIndexOf(byte* subsequence, IntPtr subsequenceLength, long index) => BasicString.LongLastIndexOf(subsequence, subsequenceLength, index);
    public readonly long LongLastIndexOf(byte* subsequence, IntPtr subsequenceLength, long index, long count) => BasicString.LongLastIndexOf(subsequence, subsequenceLength, index, count);
    public readonly long LongLastIndexOfString(ReadOnlySpan<char> str) => BasicString.LongLastIndexOfString(str);
    public readonly long LongLastIndexOfString(ReadOnlySpan<char> str, long index) => BasicString.LongLastIndexOfString(str, index);
    public readonly long LongLastIndexOfString(ReadOnlySpan<char> str, long index, long count) => BasicString.LongLastIndexOfString(str, index, count);
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
    public long EnsureCapacity(long capacity) => BasicString.EnsureCapacity(capacity);
    public long TrimExcess() => BasicString.TrimExcess();
    public void Resize(long newSize) => BasicString.Resize(newSize);
    public void Resize(long newSize, in byte defaultValue) => BasicString.Resize(newSize, in defaultValue);
    public long SetCapacity(long newCapacity) => BasicString.SetCapacity(newCapacity);

    [Obsolete($"Use {nameof(AsSpan)} instead.")]
    public readonly ReadOnlySpan<byte> Slice(int start) => AsSpan(start);

    [Obsolete($"Use {nameof(AsSpan)} instead.")]
    public readonly ReadOnlySpan<byte> Slice(int start, int length) => AsSpan(start, length);

    [Obsolete($"Use {nameof(ToArray)} or {nameof(AsSpan)} instead.")]
    public readonly byte[] GetBytes() => ToArray();
}
