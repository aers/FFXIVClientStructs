using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.STD.ContainerInterface;
using FFXIVClientStructs.STD.Helper;
using JetBrains.Annotations;
using static FFXIVClientStructs.STD.Helper.StdImplHelpers;

namespace FFXIVClientStructs.STD;

/// <summary>
/// A <see cref="List{T}"/>-like view for <see href="https://en.cppreference.com/w/cpp/container/vector">std::vector</see>.
/// </summary>
/// <typeparam name="T">The type of element.</typeparam>
/// <typeparam name="TMemorySpace">The specifier for <see cref="IMemorySpace"/>, for vectors with different preferred memory space.</typeparam>
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public unsafe struct StdVector<T, TMemorySpace>
    : IStdVector<T>
        , IStaticNativeObjectOperation<StdVector<T, TMemorySpace>>
    where T : unmanaged
    where TMemorySpace : IStaticMemorySpace {

    /// <summary>
    /// The pointer to the first element of the vector. <c>null</c> if empty.
    /// </summary>
    public T* First;

    /// <summary>
    /// The pointer to next of the last element of the vector. <c>null</c> if empty.
    /// </summary>
    public T* Last;

    /// <summary>
    /// The pointer to the end of the memory allocation. <c>null</c> if empty.
    /// </summary>
    public T* End;

    public static bool HasDefault => true;
    public static bool IsDisposable => true;
    public static bool IsCopyable => StdOps<T>.IsCopyable;
    public static bool IsMovable => true;

    /// <inheritdoc/>
    public readonly void* RepresentativePointer => First;

    /// <inheritdoc cref="IStdRandomMutable{T}.Count"/>
    public int Count {
        readonly get => checked((int)LongCount);
        set => Resize(value);
    }

    /// <inheritdoc cref="IStdRandomMutable{T}.LongCount"/>
    public long LongCount {
        readonly get => Last - First;
        set => Resize(value);
    }

    /// <inheritdoc cref="LongCapacity"/>
    public int Capacity {
        readonly get => checked((int)LongCapacity);
        set => SetCapacity(value);
    }

    /// <inheritdoc/>
    public long LongCapacity {
        readonly get => End - First;
        set => SetCapacity(value);
    }

    /// <inheritdoc cref="IStdRandomElementModifiable{T}.this[long]" />
    public readonly ref T this[long index] => ref First[CheckedIndex(index < 0 ? LongCount - ~index : index)];

    /// <inheritdoc cref="IStdRandomElementModifiable{T}.this[int]" />
    public readonly ref T this[int index] => ref this[(long)index];

    /// <inheritdoc cref="IStdRandomElementModifiable{T}.this[Index]" />
    public readonly ref T this[Index index] => ref this[index.IsFromEnd ? LongCount - index.Value : index.Value];

    public static implicit operator Span<T>(in StdVector<T, TMemorySpace> value)
        => value.AsSpan();

    public static implicit operator ReadOnlySpan<T>(in StdVector<T, TMemorySpace> value)
        => value.AsSpan();

    public static implicit operator StdSpan<T>(in StdVector<T, TMemorySpace> value)
        => value.AsStdSpan();

    /// <inheritdoc/>
    public static int Compare(in StdVector<T, TMemorySpace> left, in StdVector<T, TMemorySpace> right) {
        var lv = left.First;
        var lt = lv + left.LongCount;
        var rv = right.First;
        var rt = rv + right.LongCount;
        while (lv < lt && rv < rt) {
            var cmp = StdOps<T>.Compare(*lv, *rv);
            if (cmp != 0)
                return cmp;
            lv++;
            rv++;
        }

        return left.LongCount.CompareTo(right.LongCount);
    }

    /// <inheritdoc/>
    public static bool ContentEquals(in StdVector<T, TMemorySpace> left, in StdVector<T, TMemorySpace> right) {
        if (left.LongCount != right.LongCount)
            return false;
        var c = left.LongCount;
        var l = left.First;
        var r = right.First;
        for (; c > 0; c--) {
            if (!StdOps<T>.ContentEquals(*l++, *r++))
                return false;
        }

        return true;
    }

    /// <inheritdoc/>
    public static void ConstructDefaultInPlace(out StdVector<T, TMemorySpace> item) => item = default;

    /// <inheritdoc/>
    public static void StaticDispose(ref StdVector<T, TMemorySpace> item) => item.Dispose();

    /// <inheritdoc/>
    public static void ConstructCopyInPlace(in StdVector<T, TMemorySpace> source, out StdVector<T, TMemorySpace> target) {
        target = default;
        var len = source.LongCount;
        target.EnsureCapacity(len);
        target.Last = target.First + len;
        Buffer.MemoryCopy(source.First, target.First, sizeof(T) * len, sizeof(T) * len);
    }

    /// <inheritdoc/>
    public static void ConstructMoveInPlace(ref StdVector<T, TMemorySpace> source, out StdVector<T, TMemorySpace> target) => (target, source) = (source, default);

    /// <inheritdoc/>
    public static void Swap(ref StdVector<T, TMemorySpace> item1, ref StdVector<T, TMemorySpace> item2) => (item1, item2) = (item2, item1);

    /// <inheritdoc/>
    public void Dispose() {
        Resize(0);
        TrimExcess();
    }

    /// <inheritdoc/>
    public readonly int CompareTo(object? obj) => obj switch {
        StdVector<T, TMemorySpace> other => CompareTo(other),
        IStdRandomMutable<T> other => CompareTo(other),
        null => 1,
        _ => throw new ArgumentException(null, nameof(obj)),
    };

    /// <inheritdoc cref="IComparable{T}.CompareTo"/>
    public readonly int CompareTo(in StdVector<T, TMemorySpace> other) => Compare(this, other);

    /// <inheritdoc/>
    public readonly bool Equals(IStdRandomElementReadable<T>? other) =>
        other is StdVector<T, TMemorySpace> sv && ContentEquals(this, sv);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine((nint)First, (nint)Last, (nint)End);

    /// <inheritdoc/>
    public override string ToString() => $"{nameof(StdVector<T>)}<{typeof(T)}, {typeof(TMemorySpace)}, {typeof(StdOps<T>)}>({LongCount}/{LongCapacity})";

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
    public readonly StdSpan<T> AsStdSpan() => AsStdSpan(0, LongCount);

    /// <inheritdoc/>
    public readonly StdSpan<T> AsStdSpan(long index) => AsStdSpan(index, LongCount - index);

    /// <inheritdoc/>
    public readonly StdSpan<T> AsStdSpan(long index, long count) =>
      new(First + index, CheckedRangeCount(index, count));

    /// <inheritdoc/>
    public void AddCopy(in T item) {
        EnsureCapacity(LongCount + 1);
        StdOps<T>.ConstructCopyInPlace(in item, out *Last++);
    }

    /// <inheritdoc/>
    public void AddMove(ref T item) {
        EnsureCapacity(LongCount + 1);
        StdOps<T>.ConstructMoveInPlace(ref item, out *Last++);
    }

    /// <inheritdoc/>
    public void AddRangeCopy(IEnumerable<T> collection) => InsertRangeCopy(LongCount, collection);

    /// <inheritdoc/>
    public void AddSpanCopy(ReadOnlySpan<T> span) => InsertSpanCopy(LongCount, span);

    /// <inheritdoc/>
    public void AddSpanMove(Span<T> span) => InsertSpanMove(LongCount, span);

    /// <inheritdoc/>
    public readonly long BinarySearch(in T item) => BinarySearch(0, LongCount, item, null);

    /// <inheritdoc/>
    public readonly long BinarySearch(in T item, IComparer<T>? comparer) => BinarySearch(0, LongCount, item, comparer);

    /// <inheritdoc/>
    public readonly long BinarySearch(long index, long count, in T item, IComparer<T>? comparer) =>
        LookupHelper<T, StdVector<T, TMemorySpace>>.BinarySearch(
            ref Unsafe.AsRef(in this),
            index,
            CheckedRangeCount(index, count),
            item,
            comparer);

    /// <inheritdoc cref="IStdRandomMutable{T}.Clear"/>
    public void Clear() {
        if (!StdOps<T>.IsDisposable) {
            Last = First;
            return;
        }

        while (Last != First)
            StdOps<T>.StaticDispose(ref *--Last);
    }

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
        for (var p = First; p < Last; p++)
            action(*p);
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
    public void InsertCopy(long index, in T item) {
        if (index < 0 || index > LongCount)
            throw new ArgumentOutOfRangeException(nameof(index), index, null);
        if (!StdOps<T>.IsCopyable)
            throw new InvalidOperationException("Items are not copiable.");

        EnsureCapacity(LongCount + 1);
        SpliceHoleUnchecked(index, 1);
        Last++;
        StdOps<T>.ConstructCopyInPlace(in item, out First[index]);
    }

    /// <inheritdoc/>
    public void InsertMove(long index, ref T item) {
        if (index < 0 || index > LongCount)
            throw new ArgumentOutOfRangeException(nameof(index), index, null);
        if (!StdOps<T>.IsCopyable)
            throw new InvalidOperationException("Items are not copiable.");

        EnsureCapacity(LongCount + 1);
        SpliceHoleUnchecked(index, 1);
        Last++;
        StdOps<T>.ConstructMoveInPlace(ref item, out First[index]);
    }

    /// <inheritdoc/>
    public void InsertRangeCopy(long index, IEnumerable<T> collection) {
        var prevCount = LongCount;
        if (index < 0 || index > prevCount)
            throw new ArgumentOutOfRangeException(nameof(index), index, null);
        if (!StdOps<T>.IsCopyable)
            throw new InvalidOperationException("Items are not copiable.");

        switch (collection) {
            case IStdVector<T> isv when isv.RepresentativePointer == RepresentativePointer:
                // We're inserting this vector into itself.
                EnsureCapacity(checked(prevCount * 2));
                ConstructCopyInsideUnchecked(index, index + prevCount, prevCount - index);
                ConstructCopyInsideUnchecked(0, index, prevCount);
                Last += prevCount;
                break;
            case List<T> list:
                InsertSpanCopy(index, CollectionsMarshal.AsSpan(list));
                break;
            case T[] array:
                InsertSpanCopy(index, array.AsSpan());
                break;
            case var _ when TryGetCountFromEnumerable(collection, out var count):
                EnsureCapacity(prevCount + count);
                SpliceHoleUnchecked(index, count);
                using (var enu = collection.GetEnumerator()) {
                    var p = First + index;
                    while (count-- > 0 && enu.MoveNext()) {
                        *p++ = enu.Current;
                        Last++;
                    }
                }
                break;
            default:
                foreach (var item in collection)
                    InsertCopy(index++, item);
                break;
        }
    }

    /// <inheritdoc/>
    public void InsertSpanCopy(long index, ReadOnlySpan<T> span) {
        var prevCount = LongCount;
        if (index < 0 || index > prevCount)
            throw new ArgumentOutOfRangeException(nameof(index), index, null);
        if (!StdOps<T>.IsCopyable)
            throw new InvalidOperationException("Items are not copiable.");
        if (!StdOps<T>.IsMovable && index != LongCount)
            throw new InvalidOperationException("Items are not movable, and trying to insert in middle.");

        EnsureCapacity(prevCount + span.Length);
        SpliceHoleUnchecked(index, span.Length);
        Last += span.Length;
        var p = First + index;
        foreach (ref readonly var s in span)
            StdOps<T>.ConstructCopyInPlace(in s, out *p++);
    }

    /// <inheritdoc/>
    public void InsertSpanMove(long index, Span<T> span) {
        var prevCount = LongCount;
        if (index < 0 || index > prevCount)
            throw new ArgumentOutOfRangeException(nameof(index), index, null);
        if (!StdOps<T>.IsMovable)
            throw new InvalidOperationException("Items are not movable.");

        EnsureCapacity(prevCount + span.Length);
        SpliceHoleUnchecked(index, span.Length);
        Last += span.Length;
        var p = First + index;
        foreach (ref var s in span)
            StdOps<T>.ConstructMoveInPlace(ref s, out *p++);
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
    public readonly int LastIndexOf(ReadOnlySpan<T> subsequence, int index, int count) => checked((int)LongLastIndexOf(subsequence, index, count));

    /// <inheritdoc/>
    public bool Remove(in T item) {
        var i = LongIndexOf(item);
        if (i == -1)
            return false;

        RemoveAt(i);
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

        return removed;
    }

    /// <inheritdoc/>
    public void RemoveAt(long index) {
        _ = CheckedIndex(index);
        if (!StdOps<T>.IsMovable && index + 1 != LongCount)
            throw new InvalidOperationException("Cannot remove from middle when items are not movable");
        StdOps<T>.StaticDispose(ref First[index]);
        Last--;
        ConstructMoveInsideUnchecked(index + 1, index, LongCount - index);
    }

    /// <inheritdoc/>
    public void RemoveRange(long index, long count) {
        _ = CheckedRangeCount(index, count);
        if (!StdOps<T>.IsMovable && index + count != LongCount)
            throw new InvalidOperationException("Cannot remove from middle when items are not movable");
        if (StdOps<T>.IsDisposable) {
            var p = First + index;
            for (var remain = count; remain > 0; remain--)
                StdOps<T>.StaticDispose(ref *p);
        }

        Last -= count;
        ConstructMoveInsideUnchecked(index + count, index, LongCount - index);
    }

    /// <inheritdoc/>
    public void Reverse() => MutateHelper<T, StdVector<T, TMemorySpace>>.DefaultReverse(ref this);

    /// <inheritdoc/>
    public void Reverse(long index, long count) => MutateHelper<T, StdVector<T, TMemorySpace>>.DefaultReverse(ref this, index, count);

    /// <inheritdoc/>
    public void Sort() => MutateHelper<T, StdVector<T, TMemorySpace>>.Sort(ref this, 0, LongCount);

    /// <inheritdoc/>
    public void Sort(long index, long count) => MutateHelper<T, StdVector<T, TMemorySpace>>.Sort(ref this, index, CheckedRangeCount(index, count));

    /// <inheritdoc/>
    public void Sort(IComparer<T>? comparer) => MutateHelper<T, StdVector<T, TMemorySpace>>.Sort(ref this, 0, LongCount, comparer);

    /// <inheritdoc/>
    public void Sort(long index, long count, IComparer<T>? comparer) => MutateHelper<T, StdVector<T, TMemorySpace>>.Sort(ref this, index, CheckedRangeCount(index, count), comparer);

    /// <inheritdoc/>
    public void Sort(Comparison<T> comparison) => Sort(0, LongCount, comparison);

    /// <inheritdoc/>
    public void Sort(long index, long count, Comparison<T> comparison) => MutateHelper<T, StdVector<T, TMemorySpace>>.Sort(ref this, index, CheckedRangeCount(index, count), comparison);

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

    /// <inheritdoc/>
    public readonly long LongFindIndex(Predicate<T> match) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongFindIndex(in this, match);

    /// <inheritdoc/>
    public readonly long LongFindIndex(long startIndex, Predicate<T> match) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongFindIndex(in this, startIndex, match);

    /// <inheritdoc/>
    public readonly long LongFindIndex(long startIndex, long count, Predicate<T> match) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongFindIndex(in this, startIndex, count, match);

    /// <inheritdoc/>
    public readonly long LongFindLastIndex(Predicate<T> match) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongFindLastIndex(in this, match);

    /// <inheritdoc/>
    public readonly long LongFindLastIndex(long startIndex, Predicate<T> match) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongFindLastIndex(in this, startIndex, match);

    /// <inheritdoc/>
    public readonly long LongFindLastIndex(long startIndex, long count, Predicate<T> match) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongFindLastIndex(in this, startIndex, count, match);

    /// <inheritdoc/>
    public readonly long LongIndexOf(in T item) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongIndexOf(in this, item);

    /// <inheritdoc/>
    public readonly long LongIndexOf(in T item, long index) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongIndexOf(in this, item, index);

    /// <inheritdoc/>
    public readonly long LongIndexOf(in T item, long index, long count) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongIndexOf(in this, item, index, count);

    /// <inheritdoc/>
    public readonly long LongIndexOf(ReadOnlySpan<T> subsequence) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongIndexOf(in this, subsequence);

    /// <inheritdoc/>
    public readonly long LongIndexOf(ReadOnlySpan<T> subsequence, long index) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongIndexOf(in this, subsequence, index);

    /// <inheritdoc/>
    public readonly long LongIndexOf(ReadOnlySpan<T> subsequence, long index, long count) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongIndexOf(in this, subsequence, index, count);

    /// <inheritdoc/>
    public readonly long LongIndexOf(T* subsequence, nint subsequenceLength) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongIndexOf(in this, subsequence, subsequenceLength, 0, LongCount);

    /// <inheritdoc/>
    public readonly long LongIndexOf(T* subsequence, nint subsequenceLength, long index) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongIndexOf(in this, subsequence, subsequenceLength, index, LongCount - index);

    /// <inheritdoc/>
    public readonly long LongIndexOf(T* subsequence, nint subsequenceLength, long index, long count) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongIndexOf(in this, subsequence, subsequenceLength, index, count);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(in T item) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongLastIndexOf(in this, item);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(in T item, long index) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongLastIndexOf(in this, item, index);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(in T item, long index, long count) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongLastIndexOf(in this, item, index, count);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(ReadOnlySpan<T> subsequence) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongLastIndexOf(in this, subsequence);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(ReadOnlySpan<T> subsequence, long index) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongLastIndexOf(in this, subsequence, index);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(ReadOnlySpan<T> subsequence, long index, long count) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongLastIndexOf(in this, subsequence, index, count);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(T* subsequence, nint subsequenceLength) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongLastIndexOf(in this, subsequence, subsequenceLength);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(T* subsequence, nint subsequenceLength, long index) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongLastIndexOf(in this, subsequence, subsequenceLength, index);

    /// <inheritdoc/>
    public readonly long LongLastIndexOf(T* subsequence, nint subsequenceLength, long index, long count) => LookupHelper<T, StdVector<T, TMemorySpace>>.DefaultLongLastIndexOf(in this, subsequence, subsequenceLength, index, count);

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
        if (!StdOps<T>.HasDefault && prevCount < newSize)
            throw new InvalidOperationException("Type has no default value. Try specifying one.");

        ResizeUndefined(newSize);

        if (newSize <= prevCount)
            return;

        for (var i = prevCount; i < newSize; i++)
            StdOps<T>.ConstructDefaultInPlace(out First[i]);
    }

    /// <inheritdoc/>
    public void Resize(long newSize, in T defaultValue) {
        var prevCount = LongCount;
        if (!StdOps<T>.IsCopyable && prevCount < newSize)
            throw new InvalidOperationException("Elements are not copiable, and default value cannot be specified.");

        ResizeUndefined(newSize);

        if (newSize <= prevCount)
            return;

        for (var i = prevCount; i < newSize; i++)
            StdOps<T>.ConstructCopyInPlace(in defaultValue, out First[i]);
    }

    /// <inheritdoc/>
    public long SetCapacity(long newCapacity) {
        var count = LongCount;
        var prevCapacity = LongCapacity;
        if (newCapacity < count || count < 0)
            throw new ArgumentOutOfRangeException(nameof(newCapacity), newCapacity, null);
        if (newCapacity == prevCapacity)
            return prevCapacity;

        if (count != 0 && !StdOps<T>.IsMovable)
            throw new InvalidOperationException("Elements are not movable, and the vector is not empty.");

        var newAlloc =
            newCapacity == 0
                ? null
                : (T*)TMemorySpace.Allocate(checked((nuint)(newCapacity * sizeof(T))), 16);
        if (newAlloc == null && newCapacity > 0)
            throw new OutOfMemoryException();

        if (count != 0) {
            for (var i = 0L; i < count; i++) {
                StdOps<T>.ConstructMoveInPlace(ref First[i], out newAlloc![i]);
                StdOps<T>.StaticDispose(ref First[i]);
            }
        }

        if (First != null)
            IMemorySpace.Free(First, (nuint)(prevCapacity * sizeof(T)));

        First = newAlloc;
        End = First + newCapacity;
        Last = First + count;
        return newCapacity;
    }

    /// <summary>
    /// Gets an enumerator for this vector.
    /// </summary>
    /// <returns>The enumerator returning references to items.</returns>
    public readonly UnmanagedArrayEnumerator<T> GetEnumerator() => new(First, Last);

    /// <inheritdoc cref="IEnumerable{T}.GetEnumerator"/>
    readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

    /// <inheritdoc cref="IEnumerable.GetEnumerator"/>
    readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private void ResizeUndefined(long newSize) {
        var prevCount = LongCount;
        EnsureCapacity(newSize);
        Last = First + newSize;

        if (newSize >= prevCount || !StdOps<T>.IsDisposable)
            return;
        for (var i = newSize; i < prevCount; i++)
            StdOps<T>.StaticDispose(ref First[i]);
    }

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ConstructCopyInsideUnchecked(long fromIndex, long toIndex, long count) {
        if (fromIndex == toIndex || count <= 0)
            return;

        // Buffer.MemoryCopy(First + fromIndex, First + toIndex, count * sizeof(T), count * sizeof(T));
        if (fromIndex + count > toIndex && toIndex > fromIndex) {
            while (--count >= 0)
                StdOps<T>.ConstructCopyInPlace(First[fromIndex + count], out First[toIndex + count]);
        } else {
            for (var i = 0L; i < count; i++)
                StdOps<T>.ConstructCopyInPlace(First[fromIndex + i], out First[toIndex + i]);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ConstructMoveInsideUnchecked(long fromIndex, long toIndex, long count) {
        if (fromIndex == toIndex || count <= 0)
            return;

        // Buffer.MemoryCopy(First + fromIndex, First + toIndex, count * sizeof(T), count * sizeof(T));
        if (fromIndex + count > toIndex && toIndex > fromIndex) {
            while (--count >= 0)
                StdOps<T>.ConstructMoveInPlace(ref First[fromIndex + count], out First[toIndex + count]);
        } else {
            for (var i = 0L; i < count; i++)
                StdOps<T>.ConstructMoveInPlace(ref First[fromIndex + i], out First[toIndex + i]);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SpliceHoleUnchecked(long index, long count) => ConstructMoveInsideUnchecked(index, index + count, LongCount - index);
}
