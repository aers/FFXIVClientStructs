using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using FFXIVClientStructs.STD.ContainerInterface;
using FFXIVClientStructs.STD.Helper;
using JetBrains.Annotations;

namespace FFXIVClientStructs.STD;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public unsafe struct StdSpan<T>
    : IStdRandomElementModifiable<T>
    where T : unmanaged {
    private readonly T* _begin;
    private readonly nint _count;

    public StdSpan(ref T firstPinnedObject, nint count) {
        _begin = (T*)Unsafe.AsPointer(ref firstPinnedObject);
        _count = count;
        if (_count == 0)
            _begin = null;
        else if (_count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), count, null);
    }

    public StdSpan(T* begin, nint count) {
        _begin = begin;
        _count = count;
        if (_count == 0)
            _begin = null;
        else if (_count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), count, null);
    }

    public StdSpan(T* begin, long count) : this(begin, (nint)count) { }

    public StdSpan(Span<T> span) {
        if (span.IsEmpty)
            return;
        _begin = (T*)Unsafe.AsPointer(ref Unsafe.AsRef(in span[0]));
        _count = span.Length;
    }

    /// <inheritdoc cref="IStdRandomMutable{T}.Count"/>
    public readonly int Count => checked((int)_count);

    /// <summary>
    /// Gets a value indicating whether this <see cref="StdSpan{T}"/> is empty.
    /// </summary>
    /// <value><c>true</c> if this span is empty.</value>
    public readonly bool IsEmpty => _count == 0;

    /// <inheritdoc cref="IStdRandomMutable{T}.LongCount"/>
    public readonly long LongCount => _count;

    /// <inheritdoc/>
    public readonly void* RepresentativePointer => _begin;

    /// <inheritdoc cref="IStdRandomElementModifiable{T}.this[long]" />
    public readonly ref T this[long index] => ref _begin[CheckedIndex(index < 0 ? _count - ~index : index)];

    /// <inheritdoc cref="IStdRandomElementModifiable{T}.this[int]" />
    public readonly ref T this[int index] => ref this[(long)index];

    /// <inheritdoc cref="IStdRandomElementModifiable{T}.this[Index]" />
    public readonly ref T this[Index index] => ref this[index.IsFromEnd ? LongCount - index.Value : index.Value];

    /// <summary>
    /// Gets a slice of this <see cref="StdSpan{T}"/> for the given range.
    /// </summary>
    /// <param name="range">The range.</param>
    public readonly StdSpan<T> this[Range range] => this[
        range.Start.IsFromEnd ? ~range.Start.Value : range.Start.Value,
        range.End.IsFromEnd ? ~range.End.Value : range.End.Value];

    /// <summary>
    /// Gets a slice of this <see cref="StdSpan{T}"/> for the given range.
    /// </summary>
    /// <param name="start">The starting index. Negative numbers will be counted from the end of this span after inverting.</param>
    /// <param name="end">The ending index. Negative numbers will be counted from the end of this span after inverting.</param>
    public readonly StdSpan<T> this[long start, long end] {
        get {
            if (start < 0)
                start = _count - ~start;

            if (end < 0)
                end = _count - ~end;

            if (end > _count || start > end)
                throw new ArgumentOutOfRangeException(nameof(end), end, null);

            return new StdSpan<T>(_begin + start, end - start);
        }
    }

    public static bool operator ==(StdSpan<T> left, StdSpan<T> right) => left.Equals(right);

    public static bool operator !=(StdSpan<T> left, StdSpan<T> right) => !left.Equals(right);

    public static implicit operator Span<T>(StdSpan<T> s) => s.AsSpan();

    public static implicit operator ReadOnlySpan<T>(StdSpan<T> s) => s.AsSpan();

    public static implicit operator StdSpanReadOnly<T>(StdSpan<T> s) => new(s._begin, s._count);

    public static explicit operator StdSpan<T>(Span<T> s) => new(s);

    /// <summary>
    /// Gets the <see cref="Span{T}"/> view of this <see cref="StdSpan{T}"/>.
    /// </summary>
    /// <returns>The span.</returns>
    public readonly Span<T> AsSpan() => new(_begin, Count);

    /// <summary>
    /// Gets the <see cref="Span{T}"/> view of this <see cref="StdSpan{T}"/>.
    /// </summary>
    /// <param name="index">The starting index.</param>
    /// <returns>The span.</returns>
    public readonly Span<T> AsSpan(long index) => new(
        _begin + index,
        checked((int)CheckedRangeCount(index, LongCount - index)));

    /// <summary>
    /// Gets the <see cref="Span{T}"/> view of this <see cref="StdSpan{T}"/>.
    /// </summary>
    /// <param name="index">The starting index.</param>
    /// <param name="count">The number of items.</param>
    /// <returns>The span.</returns>
    public readonly Span<T> AsSpan(long index, int count) => new(
        _begin + index,
        checked((int)CheckedRangeCount(index, count)));

    /// <inheritdoc/>
    public readonly long BinarySearch(in T item) => LookupHelper<T, StdSpan<T>>.BinarySearch(in this, 0, LongCount, item, null);

    /// <inheritdoc/>
    public readonly long BinarySearch(in T item, IComparer<T>? comparer) => LookupHelper<T, StdSpan<T>>.BinarySearch(in this, 0, LongCount, item, comparer);

    /// <inheritdoc/>
    public readonly long BinarySearch(long index, long count, in T item, IComparer<T>? comparer) => LookupHelper<T, StdSpan<T>>.BinarySearch(in this, index, count, item, comparer);

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
        var end = _begin + _count;
        for (var p = _begin; p < end; p++)
            array[i++] = *p;
    }

    /// <inheritdoc/>
    public readonly bool Exists(Predicate<T> match) => LongFindIndex(match) != -1;

    /// <inheritdoc/>
    public readonly T? Find(Predicate<T> match) {
        var index = LongFindIndex(match);
        return index == -1 ? default(T?) : this[index];
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
        foreach (ref var v in this)
            action(v);
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
    public readonly int LastIndexOf(ReadOnlySpan<T> subsequence, int index, int count) => checked((int)LongLastIndexOf(subsequence, index, count));

    /// <inheritdoc/>
    public void Reverse() => MutateHelper<T, StdSpan<T>>.DefaultReverse(ref this);

    /// <inheritdoc/>
    public void Reverse(long index, long count) => MutateHelper<T, StdSpan<T>>.DefaultReverse(ref this, index, count);

    /// <summary>
    /// Forms a slice out of the current span that begins at a specified index.
    /// </summary>
    /// <param name="start">The index at which to begin the slice.</param>
    /// <returns>A span that consists of all elements of the current span from <paramref name="start"/> to the end of the span.</returns>
    public StdSpan<T> Slice(long start) => new(_begin + start, CheckedRangeCount(start, _count - start));
    
    /// <summary>
    /// Forms a slice out of the current span starting at a specified index for a specified length.
    /// </summary>
    /// <param name="start">The index at which to begin this slice.</param>
    /// <param name="length">The desired length for the slice.</param>
    /// <returns>A span that consists of <paramref name="length"/> elements from the current span starting at <paramref name="start"/>.</returns>
    public StdSpan<T> Slice(long start, long length) => new(_begin + start, CheckedRangeCount(start, length));

    /// <inheritdoc/>
    public void Sort() => MutateHelper<T, StdSpan<T>>.Sort(ref this, 0, LongCount);

    /// <inheritdoc/>
    public void Sort(long index, long count) => MutateHelper<T, StdSpan<T>>.Sort(ref this, index, CheckedRangeCount(index, count));

    /// <inheritdoc/>
    public void Sort(IComparer<T>? comparer) => MutateHelper<T, StdSpan<T>>.Sort(ref this, 0, LongCount, comparer);

    /// <inheritdoc/>
    public void Sort(long index, long count, IComparer<T>? comparer) => MutateHelper<T, StdSpan<T>>.Sort(ref this, index, CheckedRangeCount(index, count), comparer);

    /// <inheritdoc/>
    public void Sort(Comparison<T> comparison) => Sort(0, LongCount, comparison);

    /// <inheritdoc/>
    public void Sort(long index, long count, Comparison<T> comparison) => MutateHelper<T, StdSpan<T>>.Sort(ref this, index, CheckedRangeCount(index, count), comparison);

    /// <inheritdoc/>
    public readonly T[] ToArray() => LookupHelper<T, StdSpan<T>>.DefaultToArray(in this);

    /// <inheritdoc/>
    public readonly T[] ToArray(long index) => LookupHelper<T, StdSpan<T>>.DefaultToArray(in this, index);

    /// <inheritdoc/>
    public readonly T[] ToArray(long index, long count) => LookupHelper<T, StdSpan<T>>.DefaultToArray(in this, index, count);

    /// <inheritdoc/>
    public readonly long LongFindIndex(Predicate<T> match) => LookupHelper<T, StdSpan<T>>.DefaultLongFindIndex(in this, match);

    /// <inheritdoc/>
    public readonly long LongFindIndex(long startIndex, Predicate<T> match) => LookupHelper<T, StdSpan<T>>.DefaultLongFindIndex(in this, startIndex, match);

    /// <inheritdoc/>
    public readonly long LongFindIndex(long startIndex, long count, Predicate<T> match) => LookupHelper<T, StdSpan<T>>.DefaultLongFindIndex(in this, startIndex, count, match);

    /// <inheritdoc/>
    public readonly long LongFindLastIndex(Predicate<T> match) => LookupHelper<T, StdSpan<T>>.DefaultLongFindLastIndex(in this, match);

    /// <inheritdoc/>
    public readonly long LongFindLastIndex(long startIndex, Predicate<T> match) => LookupHelper<T, StdSpan<T>>.DefaultLongFindLastIndex(in this, startIndex, match);

    /// <inheritdoc/>
    public readonly long LongFindLastIndex(long startIndex, long count, Predicate<T> match) => LookupHelper<T, StdSpan<T>>.DefaultLongFindLastIndex(in this, startIndex, count, match);

    /// <inheritdoc/>
    public readonly long LongIndexOf(in T item) => LookupHelper<T, StdSpan<T>>.DefaultLongIndexOf(in this, item);

    /// <inheritdoc/>
    public readonly long LongIndexOf(in T item, long index) => LookupHelper<T, StdSpan<T>>.DefaultLongIndexOf(in this, item, index);

    /// <inheritdoc/>
    public readonly long LongIndexOf(in T item, long index, long count) => LookupHelper<T, StdSpan<T>>.DefaultLongIndexOf(in this, item, index, count);

    /// <inheritdoc/>
    public readonly long LongIndexOf(ReadOnlySpan<T> subsequence) => LookupHelper<T, StdSpan<T>>.DefaultLongIndexOf(in this, subsequence);

    /// <inheritdoc/>
    public readonly long LongIndexOf(ReadOnlySpan<T> subsequence, long index) => LookupHelper<T, StdSpan<T>>.DefaultLongIndexOf(in this, subsequence, index);

    /// <inheritdoc/>
    public readonly long LongIndexOf(ReadOnlySpan<T> subsequence, long index, long count) => LookupHelper<T, StdSpan<T>>.DefaultLongIndexOf(in this, subsequence, index, count);

    /// <inheritdoc/>
    public readonly long LongIndexOf(T* subsequence, nint subsequenceLength) => LookupHelper<T, StdSpan<T>>.DefaultLongIndexOf(in this, subsequence, subsequenceLength, 0, LongCount);

    /// <inheritdoc/>
    public readonly long LongIndexOf(T* subsequence, nint subsequenceLength, long index) => LookupHelper<T, StdSpan<T>>.DefaultLongIndexOf(in this, subsequence, subsequenceLength, index, LongCount - index);

    /// <inheritdoc/>
    public readonly long LongIndexOf(T* subsequence, nint subsequenceLength, long index, long count) => LookupHelper<T, StdSpan<T>>.DefaultLongIndexOf(in this, subsequence, subsequenceLength, index, count);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(in T item) => LookupHelper<T, StdSpan<T>>.DefaultLongLastIndexOf(in this, item);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(in T item, long index) => LookupHelper<T, StdSpan<T>>.DefaultLongLastIndexOf(in this, item, index);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(in T item, long index, long count) => LookupHelper<T, StdSpan<T>>.DefaultLongLastIndexOf(in this, item, index, count);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(ReadOnlySpan<T> subsequence) => LookupHelper<T, StdSpan<T>>.DefaultLongLastIndexOf(in this, subsequence);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(ReadOnlySpan<T> subsequence, long index) => LookupHelper<T, StdSpan<T>>.DefaultLongLastIndexOf(in this, subsequence, index);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(ReadOnlySpan<T> subsequence, long index, long count) => LookupHelper<T, StdSpan<T>>.DefaultLongLastIndexOf(in this, subsequence, index, count);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(T* subsequence, nint subsequenceLength) => LookupHelper<T, StdSpan<T>>.DefaultLongLastIndexOf(in this, subsequence, subsequenceLength);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(T* subsequence, nint subsequenceLength, long index) => LookupHelper<T, StdSpan<T>>.DefaultLongLastIndexOf(in this, subsequence, subsequenceLength, index);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(T* subsequence, nint subsequenceLength, long index, long count) => LookupHelper<T, StdSpan<T>>.DefaultLongLastIndexOf(in this, subsequence, subsequenceLength, index, count);

    /// <inheritdoc/>
    public int CompareTo(object? obj) => obj switch {
        null => 1,
        IStdRandomMutable<T> random => random.CompareTo(random),
        _ => throw new ArgumentException(null, nameof(obj)),
    };

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is StdSpan<T> d && Equals(d);

    /// <inheritdoc/>
    public readonly bool Equals(IStdRandomElementReadable<T>? other) => other is StdSpan<T> d && Equals(d);

    /// <inheritdoc cref="object.Equals(object?)"/>
    public readonly bool Equals(in StdSpan<T> other) => _begin == other._begin && _count == other._count;

    /// <inheritdoc cref="IEnumerable{T}.GetEnumerator"/>
    public readonly UnmanagedArrayEnumerator<T> GetEnumerator() => new(_begin, _begin + _count);

    /// <inheritdoc cref="IEnumerable{T}.GetEnumerator"/>
    readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

    /// <inheritdoc cref="IEnumerable.GetEnumerator"/>
    readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine((nint)_begin, _count);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [AssertionMethod]
    private readonly long CheckedIndex(long index) {
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index), index, null);
        if (index >= LongCount)
            throw new ArgumentOutOfRangeException(nameof(index), index, null);
        return index;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [AssertionMethod]
    private readonly long CheckedRangeCount(long index, long count) {
        if (index < 0 || index > LongCount)
            throw new ArgumentOutOfRangeException(nameof(index), index, null);
        if (count < 0 || count > LongCount - index)
            throw new ArgumentOutOfRangeException(nameof(count), count, null);
        return count;
    }
}
