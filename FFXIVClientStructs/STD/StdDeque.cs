using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using FFXIVClientStructs.STD.ContainerInterface;
using FFXIVClientStructs.STD.Helper;
using JetBrains.Annotations;

namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential, Size = 0x28)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public unsafe struct StdDeque<T>
    : IStdRandomElementModifiable<T>
        , IStaticNativeObjectOperation<StdDeque<T>>
    where T : unmanaged {
    private static readonly int BlockSize = sizeof(T) <= 1 ? 16 :
        sizeof(T) <= 2 ? 8 :
        sizeof(T) <= 4 ? 4 :
        sizeof(T) <= 8 ? 2 :
        1;

    // TODO: set values accordingly after implementing IList<T>
    public static bool HasDefault => throw new NotImplementedException(); // StdOps<T>.HasDefault
    public static bool IsDisposable => true;
    public static bool IsCopiable => throw new NotImplementedException(); // StdOps<T>.IsCopiable
    public static bool IsMovable => true;

    public void* ContainerBase; // iterator base nonsense
    public T** Map; // pointer to array of pointers (size MapSize) to arrays of T (size BlockSize)
    public ulong MapSize; // size of map
    public ulong MyOff; // offset of current first element
    public ulong MySize; // current length

    /// <inheritdoc cref="IStdRandomMutable{T}.Count"/>
    public readonly int Count => checked((int)MySize);

    /// <inheritdoc cref="IStdRandomMutable{T}.LongCount"/>
    public readonly long LongCount => (long)MySize;

    /// <inheritdoc/>
    public readonly void* RepresentativePointer => Map;

    /// <inheritdoc cref="IStdRandomElementModifiable{T}.this[long]" />
    public readonly ref T this[long index] {
        get {
            var actualIndex = MyOff + (ulong)CheckedIndex(index < 0 ? LongCount - ~index : index);
            var block = (actualIndex / (ulong)BlockSize) & (MapSize - 1);
            var offset = actualIndex % (ulong)BlockSize;
            return ref Map[block][offset];
        }
    }

    /// <inheritdoc cref="IStdRandomElementModifiable{T}.this[int]" />
    public readonly ref T this[int index] => ref this[(long)index];

    /// <inheritdoc cref="IStdRandomElementModifiable{T}.this[Index]" />
    public readonly ref T this[Index index] => ref this[index.IsFromEnd ? LongCount - index.Value : index.Value];

    public static int Compare(in StdDeque<T> left, in StdDeque<T> right) {
        var lv = 0;
        var lt = left.LongCount;
        var rv = 0;
        var rt = right.LongCount;
        while (lv < lt && rv < rt) {
            var cmp = StdOps<T>.Compare(left[lt], right[rt]);
            if (cmp != 0)
                return cmp;
            lv++;
            rv++;
        }

        return left.LongCount.CompareTo(right.LongCount);
    }

    public static bool ContentEquals(in StdDeque<T> left, in StdDeque<T> right) {
        if (left.LongCount != right.LongCount)
            return false;

        for (long i = 0, count = left.LongCount; i < count; i++) {
            if (!StdOps<T>.ContentEquals(left[i], right[i]))
                return false;
        }

        return true;
    }

    public static void ConstructDefaultInPlace(out StdDeque<T> item) => throw new NotImplementedException();

    public static void StaticDispose(ref StdDeque<T> item) { }

    public static void ConstructCopyInPlace(in StdDeque<T> source, out StdDeque<T> target) => throw new NotImplementedException();

    public static void ConstructMoveInPlace(ref StdDeque<T> source, out StdDeque<T> target) => (target, source) = (source, default);

    public static void Swap(ref StdDeque<T> item1, ref StdDeque<T> item2) => (item1, item2) = (item2, item1);

    [Obsolete("Use indexer")]
    public readonly T Get(ulong index) => this[(long)index];

    /// <inheritdoc/>
    public readonly long BinarySearch(in T item) => LookupHelper<T, StdDeque<T>>.BinarySearch(in this, 0, LongCount, item, null);

    /// <inheritdoc/>
    public readonly long BinarySearch(in T item, IComparer<T>? comparer) => LookupHelper<T, StdDeque<T>>.BinarySearch(in this, 0, LongCount, item, comparer);

    /// <inheritdoc/>
    public readonly long BinarySearch(long index, long count, in T item, IComparer<T>? comparer) => LookupHelper<T, StdDeque<T>>.BinarySearch(in this, index, count, item, comparer);

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
        foreach (ref var v in this)
            array[i++] = v;
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
    public void Reverse() => MutateHelper<T, StdDeque<T>>.DefaultReverse(ref this);

    /// <inheritdoc/>
    public void Reverse(long index, long count) => MutateHelper<T, StdDeque<T>>.DefaultReverse(ref this, index, count);

    /// <inheritdoc/>
    public void Sort() => MutateHelper<T, StdDeque<T>>.Sort(ref this, 0, LongCount);

    /// <inheritdoc/>
    public void Sort(long index, long count) => MutateHelper<T, StdDeque<T>>.Sort(ref this, index, CheckedRangeCount(index, count));

    /// <inheritdoc/>
    public void Sort(IComparer<T>? comparer) => MutateHelper<T, StdDeque<T>>.Sort(ref this, 0, LongCount, comparer);

    /// <inheritdoc/>
    public void Sort(long index, long count, IComparer<T>? comparer) => MutateHelper<T, StdDeque<T>>.Sort(ref this, index, CheckedRangeCount(index, count), comparer);

    /// <inheritdoc/>
    public void Sort(Comparison<T> comparison) => Sort(0, LongCount, comparison);

    /// <inheritdoc/>
    public void Sort(long index, long count, Comparison<T> comparison) => MutateHelper<T, StdDeque<T>>.Sort(ref this, index, CheckedRangeCount(index, count), comparison);

    /// <inheritdoc/>
    public readonly T[] ToArray() => LookupHelper<T, StdDeque<T>>.DefaultToArray(in this);

    /// <inheritdoc/>
    public readonly T[] ToArray(long index) => LookupHelper<T, StdDeque<T>>.DefaultToArray(in this, index);

    /// <inheritdoc/>
    public readonly T[] ToArray(long index, long count) => LookupHelper<T, StdDeque<T>>.DefaultToArray(in this, index, count);

    /// <inheritdoc/>
    public readonly long LongFindIndex(Predicate<T> match) => LookupHelper<T, StdDeque<T>>.DefaultLongFindIndex(in this, match);

    /// <inheritdoc/>
    public readonly long LongFindIndex(long startIndex, Predicate<T> match) => LookupHelper<T, StdDeque<T>>.DefaultLongFindIndex(in this, startIndex, match);

    /// <inheritdoc/>
    public readonly long LongFindIndex(long startIndex, long count, Predicate<T> match) => LookupHelper<T, StdDeque<T>>.DefaultLongFindIndex(in this, startIndex, count, match);

    /// <inheritdoc/>
    public readonly long LongFindLastIndex(Predicate<T> match) => LookupHelper<T, StdDeque<T>>.DefaultLongFindLastIndex(in this, match);

    /// <inheritdoc/>
    public readonly long LongFindLastIndex(long startIndex, Predicate<T> match) => LookupHelper<T, StdDeque<T>>.DefaultLongFindLastIndex(in this, startIndex, match);

    /// <inheritdoc/>
    public readonly long LongFindLastIndex(long startIndex, long count, Predicate<T> match) => LookupHelper<T, StdDeque<T>>.DefaultLongFindLastIndex(in this, startIndex, count, match);

    /// <inheritdoc/>
    public readonly long LongIndexOf(in T item) => LookupHelper<T, StdDeque<T>>.DefaultLongIndexOf(in this, item);

    /// <inheritdoc/>
    public readonly long LongIndexOf(in T item, long index) => LookupHelper<T, StdDeque<T>>.DefaultLongIndexOf(in this, item, index);

    /// <inheritdoc/>
    public readonly long LongIndexOf(in T item, long index, long count) => LookupHelper<T, StdDeque<T>>.DefaultLongIndexOf(in this, item, index, count);

    /// <inheritdoc/>
    public readonly long LongIndexOf(ReadOnlySpan<T> subsequence) => LookupHelper<T, StdDeque<T>>.DefaultLongIndexOf(in this, subsequence);

    /// <inheritdoc/>
    public readonly long LongIndexOf(ReadOnlySpan<T> subsequence, long index) => LookupHelper<T, StdDeque<T>>.DefaultLongIndexOf(in this, subsequence, index);

    /// <inheritdoc/>
    public readonly long LongIndexOf(ReadOnlySpan<T> subsequence, long index, long count) => LookupHelper<T, StdDeque<T>>.DefaultLongIndexOf(in this, subsequence, index, count);

    /// <inheritdoc/>
    public readonly long LongIndexOf(T* subsequence, nint subsequenceLength) => LookupHelper<T, StdDeque<T>>.DefaultLongIndexOf(in this, subsequence, subsequenceLength, 0, LongCount);

    /// <inheritdoc/>
    public readonly long LongIndexOf(T* subsequence, nint subsequenceLength, long index) => LookupHelper<T, StdDeque<T>>.DefaultLongIndexOf(in this, subsequence, subsequenceLength, index, LongCount - index);

    /// <inheritdoc/>
    public readonly long LongIndexOf(T* subsequence, nint subsequenceLength, long index, long count) => LookupHelper<T, StdDeque<T>>.DefaultLongIndexOf(in this, subsequence, subsequenceLength, index, count);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(in T item) => LookupHelper<T, StdDeque<T>>.DefaultLongLastIndexOf(in this, item);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(in T item, long index) => LookupHelper<T, StdDeque<T>>.DefaultLongLastIndexOf(in this, item, index);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(in T item, long index, long count) => LookupHelper<T, StdDeque<T>>.DefaultLongLastIndexOf(in this, item, index, count);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(ReadOnlySpan<T> subsequence) => LookupHelper<T, StdDeque<T>>.DefaultLongLastIndexOf(in this, subsequence);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(ReadOnlySpan<T> subsequence, long index) => LookupHelper<T, StdDeque<T>>.DefaultLongLastIndexOf(in this, subsequence, index);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(ReadOnlySpan<T> subsequence, long index, long count) => LookupHelper<T, StdDeque<T>>.DefaultLongLastIndexOf(in this, subsequence, index, count);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(T* subsequence, nint subsequenceLength) => LookupHelper<T, StdDeque<T>>.DefaultLongLastIndexOf(in this, subsequence, subsequenceLength);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(T* subsequence, nint subsequenceLength, long index) => LookupHelper<T, StdDeque<T>>.DefaultLongLastIndexOf(in this, subsequence, subsequenceLength, index);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(T* subsequence, nint subsequenceLength, long index, long count) => LookupHelper<T, StdDeque<T>>.DefaultLongLastIndexOf(in this, subsequence, subsequenceLength, index, count);

    /// <inheritdoc/>
    public int CompareTo(object? obj) => obj switch {
        null => 1,
        IStdRandomMutable<T> random => random.CompareTo(random),
        _ => throw new ArgumentException(null, nameof(obj)),
    };

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is StdDeque<T> d && Equals(d);

    /// <inheritdoc/>
    public readonly bool Equals(IStdRandomElementReadable<T>? other) => other is StdDeque<T> d && Equals(d);

    /// <inheritdoc cref="object.Equals(object?)"/>
    public readonly bool Equals(in StdDeque<T> other) => Map == other.Map;

    /// <inheritdoc cref="IEnumerable{T}.GetEnumerator"/>
    public readonly Enumerator GetEnumerator() => new((StdDeque<T>*)Unsafe.AsPointer(ref Unsafe.AsRef(in this)));

    /// <inheritdoc cref="IEnumerable{T}.GetEnumerator"/>
    readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

    /// <inheritdoc cref="IEnumerable.GetEnumerator"/>
    readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine((nint)Map, MapSize, MyOff, MySize);

    [AssertionMethod]
    private readonly long CheckedIndex(long index) {
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index), index, null);
        if (index >= LongCount)
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

    public struct Enumerator : IEnumerable<T>, IEnumerator<T> {
        private readonly StdDeque<T>* _owner;
        private long _offset;

        public Enumerator(StdDeque<T>* owner) {
            _owner = owner;
            _offset = -1;
        }

        public readonly ref T Current => ref (*_owner)[_offset];

        readonly T IEnumerator<T>.Current => Current;
        readonly object IEnumerator.Current => Current;

        public bool MoveNext() {
            if (_offset >= _owner->Count - 1)
                return false;
            _offset++;
            return true;
        }

        public void Reset() => _offset = -1;

        public void Dispose() {
        }

        public readonly Enumerator GetEnumerator() => new(_owner);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
