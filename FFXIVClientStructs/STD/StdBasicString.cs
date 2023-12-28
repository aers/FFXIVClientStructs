using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.STD.ContainerInterface;
using FFXIVClientStructs.STD.Helper;
using JetBrains.Annotations;
using static FFXIVClientStructs.STD.Helper.StdImplHelpers;

namespace FFXIVClientStructs.STD;

/// <summary>
/// A <see cref="List{T}"/>-like view for <see href="https://en.cppreference.com/w/cpp/string/basic_string">std::basic_string</see>.
/// </summary>
/// <typeparam name="T">The type of element.</typeparam>
/// <typeparam name="TEncoding">The encoding.</typeparam>
/// <typeparam name="TMemorySpace">The specifier for <see cref="IMemorySpace"/>, for vectors with different preferred memory space.</typeparam>
/// <remarks>The object must be pinned on use, if the instance of this struct itself is allocated in heap.</remarks>
[StructLayout(LayoutKind.Sequential, Size = 0x20)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public unsafe struct StdBasicString<T, TEncoding, TMemorySpace>
    : IStdBasicString<T>
        , IComparable<StdBasicString<T, TEncoding, TMemorySpace>>
        , IStaticNativeObjectOperation<StdBasicString<T, TEncoding, TMemorySpace>>
    where T : unmanaged, IBinaryNumber<T>
    where TEncoding : IStaticEncoding
    where TMemorySpace : IStaticMemorySpace {

    // See:
    // https://github.com/microsoft/STL/blob/a8888806c6960f1687590ffd4244794c753aa819/stl/inc/xstring#L2202
    private const int BufByteSize = 16;
    private static readonly int BufSize = BufByteSize / sizeof(T);
    private static readonly int SmallStringCapacity = BufByteSize / sizeof(T) - 1;

    public fixed byte BufferBytes[BufByteSize];
    public ulong ULongLength;
    public ulong ULongCapacity;

    public static bool HasDefault => true;
    public static bool IsDisposable => true;
    public static bool IsCopiable => true;
    public static bool IsMovable => true;

    /// <inheritdoc/>
    public readonly void* RepresentativePointer => First;

    /// <summary>
    /// The pointer to the first element of the string. <c>null</c> if empty.
    /// </summary>
    public readonly T* First => IsLargeMode
        ? *(T**)Unsafe.AsPointer(ref Unsafe.AsRef(in BufferBytes[0]))
        : (T*)Unsafe.AsPointer(ref Unsafe.AsRef(in BufferBytes[0]));

    /// <summary>
    /// The pointer to next of the last element of the string. <c>null</c> if empty.
    /// </summary>
    public readonly T* Last => First + ULongLength;

    /// <summary>
    /// The pointer to the end of the memory allocation. <c>null</c> if empty.
    /// </summary>
    public readonly T* End => First + ULongCapacity;

    /// <inheritdoc cref="IStdRandomAccessible{T}.Count"/>
    public int Count {
        readonly get => checked((int)ULongLength);
        set => Resize(value);
    }

    /// <inheritdoc/>
    public long LongCount {
        readonly get => unchecked((long)ULongLength);
        set => Resize(value);
    }

    /// <inheritdoc/>
    public int Capacity {
        readonly get => checked((int)LongCapacity);
        set => SetCapacity(value);
    }

    /// <inheritdoc/>
    public long LongCapacity {
        readonly get => IsLargeMode ? unchecked((long)ULongCapacity) : BufSize;
        set => SetCapacity(value);
    }

    private readonly bool IsLargeMode => ULongCapacity > (ulong)SmallStringCapacity;

    /// <inheritdoc/>
    public readonly ref T this[long index] => ref First[CheckedIndex(index)];

    public static bool operator ==(in StdBasicString<T, TEncoding, TMemorySpace> l, in StdBasicString<T, TEncoding, TMemorySpace> r) => l.Equals(r);

    public static bool operator !=(in StdBasicString<T, TEncoding, TMemorySpace> l, in StdBasicString<T, TEncoding, TMemorySpace> r) => !l.Equals(r);

    public static implicit operator Span<T>(in StdBasicString<T, TEncoding, TMemorySpace> value)
        => value.AsSpan();

    public static implicit operator ReadOnlySpan<T>(in StdBasicString<T, TEncoding, TMemorySpace> value)
        => value.AsSpan();

    /// <inheritdoc/>
    public static int Compare(in StdBasicString<T, TEncoding, TMemorySpace> left, in StdBasicString<T, TEncoding, TMemorySpace> right) => left.CompareTo(right);

    /// <inheritdoc/>
    public static bool ContentEquals(in StdBasicString<T, TEncoding, TMemorySpace> left, in StdBasicString<T, TEncoding, TMemorySpace> right) => left.Equals(right);

    /// <inheritdoc/>
    public static void ConstructDefaultInPlace(out StdBasicString<T, TEncoding, TMemorySpace> item) => item = default;

    /// <inheritdoc/>
    public static void StaticDispose(ref StdBasicString<T, TEncoding, TMemorySpace> item) => item.Dispose();

    /// <inheritdoc/>
    public static void ConstructCopyInPlace(in StdBasicString<T, TEncoding, TMemorySpace> source, out StdBasicString<T, TEncoding, TMemorySpace> target) {
        target = default;
        var len = source.LongCount;
        target.EnsureCapacity(len);
        target.ULongLength = source.ULongLength;
        Buffer.MemoryCopy(source.First, target.First, sizeof(T) * (len + 1), sizeof(T) * (len + 1));
    }

    /// <inheritdoc/>
    public static void ConstructMoveInPlace(ref StdBasicString<T, TEncoding, TMemorySpace> source, out StdBasicString<T, TEncoding, TMemorySpace> target) => (target, source) = (source, default);

    /// <inheritdoc/>
    public static void Swap(ref StdBasicString<T, TEncoding, TMemorySpace> item1, ref StdBasicString<T, TEncoding, TMemorySpace> item2) => (item1, item2) = (item2, item1);

    /// <inheritdoc/>
    public readonly Span<T> AsSpan() => new(First, Count);

    /// <inheritdoc/>
    public readonly Span<T> AsSpan(long index) => new(
        First + index,
        checked((int)CheckedRangeCount(index, LongCount - index)));

    /// <inheritdoc/>
    public readonly Span<T> AsSpan(long index, int count) => new(
        First + index,
        checked((int)CheckedRangeCount(index, count)));

    /// <inheritdoc/>
    public void AddCopy(in T item) {
        EnsureCapacity(LongCount + 1);
        First[ULongLength++] = item;
        First[ULongLength] = default;
    }

    /// <inheritdoc/>
    public void AddMove(ref T item) => AddCopy(in item);

    /// <inheritdoc/>
    public void AddRangeCopy(IEnumerable<T> collection) => InsertRangeCopy(LongCount, collection);

    /// <inheritdoc/>
    public void AddSpanCopy(ReadOnlySpan<T> span) => InsertSpanCopy(LongCount, span);

    /// <inheritdoc/>
    public void AddSpanMove(Span<T> span) => InsertSpanMove(LongCount, span);

    /// <inheritdoc/>
    public void AddString(ReadOnlySpan<char> str) => InsertString(LongCount, str);

    /// <inheritdoc/>
    public readonly long BinarySearch(in T item) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.BinarySearch(in this, 0, LongCount, item, null);
    
    /// <inheritdoc/>
    public readonly long BinarySearch(in T item, IComparer<T>? comparer) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.BinarySearch(in this, 0, LongCount, item, comparer);
    
    /// <inheritdoc/>
    public readonly long BinarySearch(long index, long count, in T item, IComparer<T>? comparer) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.BinarySearch(in this, index, count, item, comparer);

    /// <inheritdoc cref="IComparable{T}.CompareTo"/>
    public readonly int CompareTo(in StdBasicString<T, TEncoding, TMemorySpace> other) {
        var lv = First;
        var lt = lv + LongCount;
        var rv = other.First;
        var rt = rv + other.LongCount;
        while (lv < lt && rv < rt) {
            var cmp = Comparer<T>.Default.Compare(*lv, *rv);
            if (cmp != 0)
                return cmp;
            lv++;
            rv++;
        }

        return LongCount.CompareTo(other.LongCount);
    }

    /// <inheritdoc/>
    readonly int IComparable<StdBasicString<T, TEncoding, TMemorySpace>>.CompareTo(StdBasicString<T, TEncoding, TMemorySpace> other) => CompareTo(other);

    /// <inheritdoc/>
    public readonly int CompareTo(object? obj) => obj switch {
        null => 1,
        StdBasicString<T, TEncoding, TMemorySpace> s => CompareTo(s),
        IStdBasicString<T> s => CompareTo(s),
        _ => throw new ArgumentException(null, nameof(obj)),
    };

    /// <inheritdoc cref="IStdRandomAccessible{T}.Clear"/>
    public void Clear() => ResizeUndefined(0);

    /// <inheritdoc/>
    public readonly bool Contains(in T item) => LongIndexOf(item) != -1;

    /// <inheritdoc/>
    public readonly bool Contains(T* subsequence, nint length) => LongIndexOf(subsequence, length) != -1;

    /// <inheritdoc/>
    public readonly bool Contains(ReadOnlySpan<T> subsequence) => LongIndexOf(subsequence) != -1;

    /// <inheritdoc/>
    public readonly void CopyTo(T[] array, int arrayIndex) {
        if (arrayIndex < 0 || arrayIndex > array.Length)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, null);
        if (array.Length - arrayIndex < LongCount)
            throw new ArgumentException(null, nameof(array));

        var i = (long)arrayIndex;
        for (var p = First; p < Last; p++)
            array[i++] = *p;
    }

    /// <inheritdoc/>
    public readonly bool ContainsString(ReadOnlySpan<char> str) => LongIndexOfString(str) != -1;

    /// <inheritdoc/>
    public void Dispose() {
        Clear();
        SetCapacity(0);
    }

    /// <inheritdoc/>
    public readonly override bool Equals(object? obj) => obj is StdBasicString<T, TEncoding, TMemorySpace> sbs && Equals(sbs);

    /// <inheritdoc/>
    public readonly bool Equals(IStdRandomAccessible<T>? obj) => obj is StdBasicString<T, TEncoding, TMemorySpace> sbs && Equals(sbs);

    /// <inheritdoc cref="Equals(object?)"/>
    public readonly bool Equals(in StdBasicString<T, TEncoding, TMemorySpace> other) {
        if (LongCount != other.LongCount)
            return false;
        var buf1 = First;
        var buf2 = other.First;
        for (var i = 0L; i < LongCount; i++) {
            if (*buf1++ != *buf2++)
                return false;
        }

        return true;
    }

    /// <inheritdoc/>
    public readonly bool Exists(Predicate<T> match) => LongFindIndex(match) != -1;

    /// <inheritdoc/>
    public readonly T? Find(Predicate<T> match) {
        var index = LongFindIndex(match);
        return index == -1 ? default(T?) : First[index];
    }

    /// <inheritdoc/>
    public readonly int FindIndex(Predicate<T> match) => checked((int)LongFindIndex(match));

    /// <inheritdoc/>
    public readonly int FindIndex(int startIndex, Predicate<T> match) => checked((int)LongFindIndex(startIndex, match));

    /// <inheritdoc/>
    public readonly int FindIndex(int startIndex, int count, Predicate<T> match) => checked((int)LongFindIndex(startIndex, count, match));

    /// <inheritdoc/>
    public readonly int FindLastIndex(Predicate<T> match) => checked((int)LongFindLastIndex(match));

    /// <inheritdoc/>
    public readonly int FindLastIndex(int startIndex, Predicate<T> match) => checked((int)LongFindLastIndex(startIndex, match));

    /// <inheritdoc/>
    public readonly int FindLastIndex(int startIndex, int count, Predicate<T> match) => checked((int)LongFindLastIndex(startIndex, count, match));

    /// <inheritdoc/>
    public readonly void ForEach(Action<T> action) {
        var i = ULongLength;
        for (var p = First; i > 0; p++, i--)
            action(*p);
    }

    /// <summary>
    /// Gets an enumerator for this string.
    /// </summary>
    /// <returns>The enumerator returning references to items.</returns>
    public readonly UnmanagedArrayEnumerator<T> GetEnumerator() => new(First, Last);

    /// <inheritdoc cref="IEnumerable{T}.GetEnumerator"/>
    readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
    
    /// <inheritdoc cref="IEnumerable.GetEnumerator"/>
    readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <inheritdoc/>
    public override int GetHashCode() {
        var hc = new HashCode();
        foreach (var span in new ChunkedSpanEnumerator<byte>((byte*)First, (nuint)(LongCount * sizeof(T))))
            hc.AddBytes(span);
        return hc.ToHashCode();
    }

    /// <inheritdoc/>
    public readonly int IndexOf(in T item) => checked((int)LongIndexOf(item));

    /// <inheritdoc/>
    public readonly int IndexOf(in T item, int index) => checked((int)LongIndexOf(item, index));

    /// <inheritdoc/>
    public readonly int IndexOf(in T item, int index, int count) => checked((int)LongIndexOf(item, index, count));

    /// <inheritdoc/>
    public readonly int IndexOf(ReadOnlySpan<T> item) => checked((int)LongIndexOf(item));

    /// <inheritdoc/>
    public readonly int IndexOf(ReadOnlySpan<T> item, int index) => checked((int)LongIndexOf(item, index));

    /// <inheritdoc/>
    public readonly int IndexOf(ReadOnlySpan<T> item, int index, int count) => checked((int)LongIndexOf(item, index, count));

    /// <inheritdoc/>
    public readonly int IndexOfString(ReadOnlySpan<char> str) =>
        IndexOfString(str, 0, Count);

    /// <inheritdoc/>
    public readonly int IndexOfString(ReadOnlySpan<char> str, int index) =>
        IndexOfString(str, index, Count - index);

    /// <inheritdoc/>
    public readonly int IndexOfString(ReadOnlySpan<char> str, int index, int count) =>
        checked((int)LongIndexOfString(str, index, count));

    /// <inheritdoc/>
    public void InsertCopy(long index, in T item) {
        if (index < 0 || index > LongCount)
            throw new ArgumentOutOfRangeException(nameof(index), index, null);

        EnsureCapacity(LongCount + 1);
        SpliceHole(index, 1);
        ULongLength++;
        First[index] = item;
        First[ULongLength] = default;
    }

    /// <inheritdoc/>
    public void InsertMove(long index, ref T item) => InsertCopy(index, item);

    /// <inheritdoc/>
    public void InsertRangeCopy(long index, IEnumerable<T> collection) {
        var prevCount = LongCount;
        if (index < 0 || index > prevCount)
            throw new ArgumentOutOfRangeException(nameof(index), index, null);

        switch (collection) {
            case IStdVector<T> isv when isv.RepresentativePointer == RepresentativePointer:
                // We're inserting this vector into itself.
                EnsureCapacity(checked(prevCount * 2));
                CopyInside(index, index + prevCount, prevCount - index);
                CopyInside(0, index, prevCount);
                ULongLength += (ulong)prevCount;
                break;
            case List<T> list:
                InsertSpanCopy(index, CollectionsMarshal.AsSpan(list));
                break;
            case T[] array:
                InsertSpanCopy(index, array.AsSpan());
                break;
            case var _ when TryGetCountFromEnumerable(collection, out var count):
                EnsureCapacity(prevCount + count);
                SpliceHole(index, count);
                using (var enu = collection.GetEnumerator()) {
                    var p = First + index;
                    while (count-- > 0 && enu.MoveNext()) {
                        *p++ = enu.Current;
                        ULongLength++;
                    }
                }
                break;
            default:
                foreach (var item in collection)
                    InsertCopy(index++, item);
                break;
        }

        First[ULongLength] = default;
    }

    /// <inheritdoc/>
    public void InsertSpanCopy(long index, ReadOnlySpan<T> span) {
        var prevCount = LongCount;
        if (index < 0 || index > prevCount)
            throw new ArgumentOutOfRangeException(nameof(index), index, null);

        EnsureCapacity(prevCount + span.Length);
        SpliceHole(index, span.Length);
        ULongLength += (ulong)span.Length;
        span.CopyTo(new Span<T>(First + index, span.Length));
        First[ULongLength] = default;
    }

    /// <inheritdoc/>
    public void InsertSpanMove(long index, Span<T> span) => InsertSpanCopy(index, span);

    /// <inheritdoc/>
    public void InsertString(long index, ReadOnlySpan<char> str) {
        var encoding = TEncoding.Encoding;
        var sizeofT = sizeof(T);
        var nb = encoding.GetByteCount(str);
        if (nb % sizeofT != 0)
            throw new InvalidOperationException("Number of bytes required is not aligned to the data type.");
        nb /= sizeofT;

        EnsureCapacity(LongCapacity + nb);
        SpliceHole(index, nb);
        ULongLength += (ulong)nb;
        encoding.GetBytes(str, new Span<byte>(First + index, nb * sizeofT));
        First[ULongLength] = default;
    }

    /// <inheritdoc/>
    public readonly int LastIndexOf(in T item) => checked((int)LongLastIndexOf(item));

    /// <inheritdoc/>
    public readonly int LastIndexOf(in T item, int index) => checked((int)LongLastIndexOf(item, index));

    /// <inheritdoc/>
    public readonly int LastIndexOf(in T item, int index, int count) => checked((int)LongLastIndexOf(item, index, count));

    /// <inheritdoc/>
    public readonly int LastIndexOf(ReadOnlySpan<T> subsequence) => checked((int)LongLastIndexOf(subsequence));

    /// <inheritdoc/>
    public readonly int LastIndexOf(ReadOnlySpan<T> subsequence, int index) => checked((int)LongLastIndexOf(subsequence, index));

    /// <inheritdoc/>
    public readonly int LastIndexOf(ReadOnlySpan<T> subsequence, int index, int count) =>
        checked((int)LongLastIndexOf(subsequence, index, count));

    /// <inheritdoc/>
    public readonly int LastIndexOfString(ReadOnlySpan<char> str) => LastIndexOfString(str, Count - 1, Count);

    /// <inheritdoc/>
    public readonly int LastIndexOfString(ReadOnlySpan<char> str, int index) =>
        LastIndexOfString(str, index, Count - index);

    /// <inheritdoc/>
    public readonly int LastIndexOfString(ReadOnlySpan<char> str, int index, int count) =>
        checked((int)LongLastIndexOfString(str, index, count));

    /// <inheritdoc/>
    public bool Remove(in T item) {
        var i = LongIndexOf(item);
        if (i == -1)
            return false;

        RemoveAt(i);
        First[ULongLength] = default;
        return true;
    }

    /// <inheritdoc/>
    public long RemoveAll(Predicate<T> match) {
        long removed = 0;
        long index = -1;
        while (true) {
            index = LongFindIndex(index + 1, match);
            if (index == -1)
                break;
            removed++;
            RemoveAt(index);
            index--;
        }

        First[ULongLength] = default;
        return removed;
    }

    /// <inheritdoc/>
    public void RemoveAt(long index) {
        _ = CheckedIndex(index);
        ULongLength--;
        CopyInside(index + 1, index, LongCount - index);
        First[ULongLength] = default;
    }

    /// <inheritdoc/>
    public void RemoveRange(long index, long count) {
        _ = CheckedRangeCount(index, count);
        ULongLength -= (ulong)count;
        CopyInside(index + count, index, LongCount - index);
        First[ULongLength] = default;
    }

    /// <inheritdoc/>
    public void Reverse() => Reverse(0, LongCount);

    /// <inheritdoc/>
    public void Reverse(long index, long count) {
        _ = CheckedRangeCount(index, count);
        var first = First;
        var l = first + index;
        var r = first + count - 1;
        for (; l < r; l++, r--) {
            var t = *l;
            *l = *r;
            *r = t;
        }
    }

    /// <inheritdoc/>
    public void Sort() => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.Sort(ref this, 0, LongCount);

    /// <inheritdoc/>
    public void Sort(long index, long count) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.Sort(ref this, index, CheckedRangeCount(index, count));

    /// <inheritdoc/>
    public void Sort(IComparer<T>? comparer) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.Sort(ref this, 0, LongCount, comparer);

    /// <inheritdoc/>
    public void Sort(long index, long count, IComparer<T>? comparer) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.Sort(ref this, index, CheckedRangeCount(index, count), comparer);

    /// <inheritdoc/>
    public void Sort(Comparison<T> comparison) => Sort(0, LongCount, comparison);

    /// <inheritdoc/>
    public void Sort(long index, long count, Comparison<T> comparison) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.Sort(ref this, index, CheckedRangeCount(index, count), comparison);

    /// <inheritdoc/>
    public readonly T[] ToArray() => ToArray(0, LongCount);

    /// <inheritdoc/>
    public readonly T[] ToArray(long index) => ToArray(index, LongCount - index);

    /// <inheritdoc/>
    public readonly T[] ToArray(long index, long count) {
        _ = CheckedRangeCount(index, count);
        if (count == 0)
            return Array.Empty<T>();

        var res = new T[count];
        fixed (T* p = res)
            Buffer.MemoryCopy(First + index, p, count * sizeof(T), count * sizeof(T));
        return res;
    }

    public override string ToString() => TEncoding.Encoding.GetString((byte*)First, checked((int)(LongCount * sizeof(T))));

    /// <inheritdoc/>
    public readonly long LongFindIndex(Predicate<T> match) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongFindIndex(in this, match);

    /// <inheritdoc/>
    public readonly long LongFindIndex(long startIndex, Predicate<T> match) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongFindIndex(in this, startIndex, match);

    /// <inheritdoc/>
    public readonly long LongFindIndex(long startIndex, long count, Predicate<T> match) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongFindIndex(in this, startIndex, count, match);

    /// <inheritdoc/>
    public readonly long LongFindLastIndex(Predicate<T> match) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongFindLastIndex(in this, match);

    /// <inheritdoc/>
    public readonly long LongFindLastIndex(long startIndex, Predicate<T> match) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongFindLastIndex(in this, startIndex, match);

    /// <inheritdoc/>
    public readonly long LongFindLastIndex(long startIndex, long count, Predicate<T> match) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongFindLastIndex(in this, startIndex, count, match);

    /// <inheritdoc/>
    public readonly long LongIndexOf(in T item) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongIndexOf(in this, item);

    /// <inheritdoc/>
    public readonly long LongIndexOf(in T item, long index) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongIndexOf(in this, item, index);

    /// <inheritdoc/>
    public readonly long LongIndexOf(in T item, long index, long count) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongIndexOf(in this, item, index, count);

    /// <inheritdoc/>
    public readonly long LongIndexOf(ReadOnlySpan<T> subsequence) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongIndexOf(in this, subsequence);

    /// <inheritdoc/>
    public readonly long LongIndexOf(ReadOnlySpan<T> subsequence, long index) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongIndexOf(in this, subsequence, index);

    /// <inheritdoc/>
    public readonly long LongIndexOf(ReadOnlySpan<T> subsequence, long index, long count) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongIndexOf(in this, subsequence, index, count);

    /// <inheritdoc/>
    public readonly long LongIndexOf(T* subsequence, nint subsequenceLength) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongIndexOf(in this, subsequence, subsequenceLength, 0, LongCount);

    /// <inheritdoc/>
    public readonly long LongIndexOf(T* subsequence, nint subsequenceLength, long index) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongIndexOf(in this, subsequence, subsequenceLength, index, LongCount - index);

    /// <inheritdoc/>
    public readonly long LongIndexOf(T* subsequence, nint subsequenceLength, long index, long count) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongIndexOf(in this, subsequence, subsequenceLength, index, count);

    /// <inheritdoc/>
    public readonly long LongIndexOfString(ReadOnlySpan<char> str) =>
        LongIndexOfString(str, 0, LongCount);

    /// <inheritdoc/>
    public readonly long LongIndexOfString(ReadOnlySpan<char> str, long index) =>
        LongIndexOfString(str, index, LongCount - index);

    /// <inheritdoc/>
    public readonly long LongIndexOfString(ReadOnlySpan<char> str, long index, long count) {
        var encoding = TEncoding.Encoding;
        var byteCount = encoding.GetByteCount(str);
        var bytes = byteCount < 1024 ? stackalloc byte[byteCount] : new byte[byteCount];
        encoding.GetBytes(str, bytes);
        fixed (void* p = bytes)
            return LongIndexOf((T*)p, byteCount / sizeof(T), index, count);
    }

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(in T item) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongLastIndexOf(in this, item);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(in T item, long index) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongLastIndexOf(in this, item, index);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(in T item, long index, long count) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongLastIndexOf(in this, item, index, count);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(ReadOnlySpan<T> subsequence) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongLastIndexOf(in this, subsequence);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(ReadOnlySpan<T> subsequence, long index) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongLastIndexOf(in this, subsequence, index);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(ReadOnlySpan<T> subsequence, long index, long count) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongLastIndexOf(in this, subsequence, index, count);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(T* subsequence, nint subsequenceLength) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongLastIndexOf(in this, subsequence, subsequenceLength);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(T* subsequence, nint subsequenceLength, long index) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongLastIndexOf(in this, subsequence, subsequenceLength, index);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(T* subsequence, nint subsequenceLength, long index, long count) => LookupHelper<T, StdBasicString<T, TEncoding, TMemorySpace>>.LongLastIndexOf(in this, subsequence, subsequenceLength, index, count);

    /// <inheritdoc/>
    public readonly long LongLastIndexOfString(ReadOnlySpan<char> str) =>
        LongLastIndexOfString(str, LongCount - 1, LongCount);

    /// <inheritdoc/>
    public readonly long LongLastIndexOfString(ReadOnlySpan<char> str, long index) =>
        LongLastIndexOfString(str, index, index + 1);

    /// <inheritdoc/>
    public readonly long LongLastIndexOfString(ReadOnlySpan<char> str, long index, long count) {
        var encoding = TEncoding.Encoding;
        var byteCount = encoding.GetByteCount(str);
        var bytes = byteCount < 1024 ? stackalloc byte[byteCount] : new byte[byteCount];
        encoding.GetBytes(str, bytes);
        fixed (void* p = bytes)
            return LongLastIndexOf((T*)p, byteCount / sizeof(T), index, count);
    }

    /// <inheritdoc/>
    public long EnsureCapacity(long capacity) {
        if (capacity <= LongCapacity)
            return capacity;

        capacity = Math.Max(capacity, LongCount * 2);
        SetCapacity(capacity);
        return capacity;
    }

    /// <inheritdoc/>
    public long TrimExcess() => SetCapacity(LongCount);

    /// <inheritdoc/>
    public void Resize(long newSize) {
        var prevCount = LongCount;
        ResizeUndefined(newSize);

        if (newSize <= prevCount)
            return;

        ZeroMemory(First + prevCount, (nuint)(newSize - prevCount));
    }

    /// <inheritdoc/>
    public void Resize(long newSize, in T defaultValue) {
        var prevCount = LongCount;
        ResizeUndefined(newSize);

        if (newSize <= prevCount)
            return;

        FillMemory(First + prevCount, (nuint)(newSize - prevCount), defaultValue);
    }

    /// <inheritdoc/>
    public long SetCapacity(long newCapacity) {
        var count = LongCount;
        var prevCapacity = LongCapacity;
        if (newCapacity < count || count < 0)
            throw new ArgumentOutOfRangeException(nameof(newCapacity), newCapacity, null);

        if (newCapacity == prevCapacity)
            return prevCapacity;

        var oldPtr = First;
        if (newCapacity <= BufSize) {
            if (!IsLargeMode)
                return BufSize;
            var data = new ReadOnlySpan<T>(oldPtr, BufSize);
            ULongCapacity = (ulong)SmallStringCapacity;
            fixed (byte* p = BufferBytes)
                data.CopyTo(new Span<T>(p, BufSize));
            Debug.Assert(count < BufSize, "count < BufSize");
            BufferBytes[count] = 0;
            IMemorySpace.Free(oldPtr, (nuint)((prevCapacity + 1) * sizeof(T)));
            return BufSize;
        }

        var newAlloc = (T*)TMemorySpace.Allocate(checked((nuint)((newCapacity + 1) * sizeof(T))), 16);
        if (newAlloc == null)
            throw new OutOfMemoryException();

        if (count != 0)
            Unsafe.CopyBlock(newAlloc, oldPtr, (uint)(count * sizeof(T)));

        // Ensure null termination
        newAlloc[count] = default;

        if (IsLargeMode)
            IMemorySpace.Free(oldPtr, (nuint)((prevCapacity + 1) * sizeof(T)));

        ULongCapacity = (ulong)newCapacity;
        *(T**)Unsafe.AsPointer(ref BufferBytes[0]) = newAlloc;
        return newCapacity;
    }

    private void ResizeUndefined(long newSize) {
        EnsureCapacity(newSize);
        ULongLength = (ulong)newSize;
        First[newSize] = default;
    }

    [AssertionMethod]
    private readonly long CheckedIndex(long index) {
        if (index < 0 || index >= LongCount)
            throw new ArgumentOutOfRangeException(nameof(index), index, null);
        return index;
    }

    [AssertionMethod]
    private readonly long CheckedRangeCount(long index, long count) {
        if (index < 0 || index > LongCount)
            throw new ArgumentOutOfRangeException(nameof(index), index, null);
        if (count < 0 || count > LongCount - index)
            throw new ArgumentOutOfRangeException(nameof(count), count, null);
        return count;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private readonly void CopyInside(long fromIndex, long toIndex, long count) =>
        Buffer.MemoryCopy(First + fromIndex, First + toIndex, count * sizeof(T), count * sizeof(T));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private readonly void SpliceHole(long index, long count) =>
        CopyInside(index, index + count, LongCount - index);
}
