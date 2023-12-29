using System.Runtime.CompilerServices;
using FFXIVClientStructs.STD.ContainerInterface;
using JetBrains.Annotations;

namespace FFXIVClientStructs.STD.Helper;

internal static class LookupHelper<T, TOwner>
    where T : unmanaged
    where TOwner : IStdRandomElementModifiable<T> {

    internal static long BinarySearch(ref readonly TOwner owner, long index, long length, T value, IComparer<T>? comparer) {
        comparer ??= Comparer<T>.Default;
        var lo = index;
        var hi = index + length - 1;
        while (lo <= hi) {
            var i = lo + ((hi - lo) >> 1);
            var order = comparer.Compare(owner[i], value);

            if (order == 0) return i;
            if (order < 0) {
                lo = i + 1;
            } else {
                hi = i - 1;
            }
        }

        return ~lo;
    }

    public static T[] DefaultToArray(ref readonly TOwner owner) => DefaultToArray(in owner, 0, owner.LongCount);
    public static T[] DefaultToArray(ref readonly TOwner owner, long index) => DefaultToArray(in owner, index, owner.LongCount - index);
    public static T[] DefaultToArray(ref readonly TOwner owner, long index, long count) {
        CheckRangeArguments(in owner, index, count);
        var a = new T[count];
        var i = 0L;
        for (; i < count; index++, i++)
            a[i] = owner[index];
        return a;
    }

    public static long DefaultLongFindIndex(ref readonly TOwner owner, Predicate<T> match) => DefaultLongFindIndex(in owner, 0, owner.LongCount, match);
    public static long DefaultLongFindIndex(ref readonly TOwner owner, long startIndex, Predicate<T> match) => DefaultLongFindIndex(in owner, startIndex, owner.LongCount - startIndex, match);
    public static long DefaultLongFindIndex(ref readonly TOwner owner, long startIndex, long count, Predicate<T> match) {
        CheckRangeArguments(in owner, startIndex, count);

        var end = startIndex + count;
        for (var i = startIndex; i < end; i++, startIndex++) {
            if (match(owner[i]))
                return startIndex;
        }

        return -1;
    }

    public static long DefaultLongFindLastIndex(ref readonly TOwner owner, Predicate<T> match) => DefaultLongFindLastIndex(in owner, owner.LongCount - 1, owner.LongCount, match);
    public static long DefaultLongFindLastIndex(ref readonly TOwner owner, long startIndex, Predicate<T> match) => DefaultLongFindLastIndex(in owner, startIndex, startIndex + 1, match);
    public static long DefaultLongFindLastIndex(ref readonly TOwner owner, long startIndex, long count, Predicate<T> match) {
        if (owner.LongCount == 0) {
            if (startIndex != -1)
                throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, null);
        } else {
            if (startIndex < -1 || startIndex >= owner.LongCount)
                throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, null);
        }

        if (count < 0 || startIndex > owner.LongCount - count)
            throw new ArgumentOutOfRangeException(nameof(count), count, null);

        var end = startIndex - count;
        for (var i = startIndex; i >= end; i--, startIndex--) {
            if (match(owner[i]))
                return startIndex;
        }

        return -1;
    }

    public static long DefaultLongIndexOf(ref readonly TOwner owner, in T item) => DefaultLongIndexOf(in owner, item, 0, owner.LongCount);
    public static long DefaultLongIndexOf(ref readonly TOwner owner, in T item, long index) => DefaultLongIndexOf(in owner, item, index, owner.LongCount - index);
    public static long DefaultLongIndexOf(ref readonly TOwner owner, in T item, long index, long count) {
        if (index < 0 || index > owner.LongCount)
            throw new ArgumentOutOfRangeException(nameof(index), index, null);

        if (count < 0 || index > owner.LongCount - count)
            throw new ArgumentOutOfRangeException(nameof(count), count, null);

        var end = index + count;
        for (var i = index; i < end; i++, index++) {
            if (StdOps<T>.ContentEquals(owner[i], item))
                return index;
        }

        return -1;
    }

    public static long DefaultLongIndexOf(ref readonly TOwner owner, ReadOnlySpan<T> subsequence) => DefaultLongIndexOf(in owner, subsequence, 0, owner.LongCount);
    public static long DefaultLongIndexOf(ref readonly TOwner owner, ReadOnlySpan<T> subsequence, long index) => DefaultLongIndexOf(in owner, subsequence, index, owner.LongCount - index);
    public static unsafe long DefaultLongIndexOf(ref readonly TOwner owner, ReadOnlySpan<T> subsequence, long index, long count) {
        fixed (T* p = subsequence)
            return DefaultLongIndexOf(in owner, p, subsequence.Length, index, count);
    }

    public static unsafe long DefaultLongIndexOf(ref readonly TOwner owner, T* subsequence, nint subsequenceLength) => DefaultLongIndexOf(in owner, subsequence, subsequenceLength, 0, owner.LongCount);
    public static unsafe long DefaultLongIndexOf(ref readonly TOwner owner, T* subsequence, nint subsequenceLength, long index) => DefaultLongIndexOf(in owner, subsequence, subsequenceLength, index, owner.LongCount - index);
    public static unsafe long DefaultLongIndexOf(ref readonly TOwner owner, T* subsequence, nint subsequenceLength, long index, long count) {
        CheckRangeArguments(in owner, index, count);
        if (subsequenceLength < 0)
            throw new ArgumentOutOfRangeException(nameof(subsequenceLength), subsequenceLength, null);
        if (subsequenceLength == 0)
            return index;
        if (count < subsequenceLength)
            return -1;

        var testIndex = index;
        var testEnd = testIndex + count - subsequenceLength + 1;
        for (; testIndex < testEnd; ++testIndex) {
            if (!StdOps<T>.ContentEquals(*subsequence, owner[testIndex]))
                continue;
            var s = subsequence + 1;
            var t = testIndex + 1;
            nint i = 1;
            while (i < subsequenceLength && StdOps<T>.ContentEquals(*s++, owner[t++]))
                i++;
            if (i == subsequenceLength)
                return testIndex;
        }

        return -1;
    }

    public static long DefaultLongLastIndexOf(ref readonly TOwner owner, in T item) => DefaultLongLastIndexOf(in owner, item, owner.LongCount - 1, owner.LongCount);
    public static long DefaultLongLastIndexOf(ref readonly TOwner owner, in T item, long index) => DefaultLongLastIndexOf(in owner, item, index, index + 1);
    public static long DefaultLongLastIndexOf(ref readonly TOwner owner, in T item, long index, long count) {
        if (owner.LongCount == 0) {
            if (index != -1)
                throw new ArgumentOutOfRangeException(nameof(index), index, null);
        } else {
            if (index < -1 || index >= owner.LongCount)
                throw new ArgumentOutOfRangeException(nameof(index), index, null);
        }

        if (count < 0 || index - count + 1 < 0)
            throw new ArgumentOutOfRangeException(nameof(count), count, null);

        var end = index - count + 1;
        for (var i = index; i >= end; i--) {
            if (StdOps<T>.ContentEquals(item, owner[i]))
                return i;
        }

        return -1;
    }

    public static long DefaultLongLastIndexOf(ref readonly TOwner owner, ReadOnlySpan<T> subsequence) => DefaultLongLastIndexOf(in owner, subsequence, owner.LongCount - 1, owner.LongCount);
    public static long DefaultLongLastIndexOf(ref readonly TOwner owner, ReadOnlySpan<T> subsequence, long index) => DefaultLongLastIndexOf(in owner, subsequence, index, index + 1);
    public static unsafe long DefaultLongLastIndexOf(ref readonly TOwner owner, ReadOnlySpan<T> subsequence, long index, long count) {
        fixed (T* p = subsequence)
            return DefaultLongLastIndexOf(in owner, p, subsequence.Length, index, count);
    }

    public static unsafe long DefaultLongLastIndexOf(ref readonly TOwner owner, T* subsequence, nint subsequenceLength) => DefaultLongLastIndexOf(in owner, subsequence, subsequenceLength, owner.LongCount - 1, owner.LongCount);
    public static unsafe long DefaultLongLastIndexOf(ref readonly TOwner owner, T* subsequence, nint subsequenceLength, long index) => DefaultLongLastIndexOf(in owner, subsequence, subsequenceLength, index, index + 1);
    public static unsafe long DefaultLongLastIndexOf(ref readonly TOwner owner, T* subsequence, nint subsequenceLength, long index, long count) {
        if (owner.LongCount == 0) {
            if (index != -1)
                throw new ArgumentOutOfRangeException(nameof(index), index, null);
        } else {
            if (index < -1 || index >= owner.LongCount)
                throw new ArgumentOutOfRangeException(nameof(index), index, null);
        }

        if (count < 0 || index - count + subsequenceLength < 0)
            throw new ArgumentOutOfRangeException(nameof(count), count, null);

        if (subsequenceLength < 0)
            throw new ArgumentOutOfRangeException(nameof(subsequenceLength), subsequenceLength, null);
        if (subsequenceLength == 0)
            return index;
        if (count < subsequenceLength)
            return -1;

        var testIndex = index - subsequenceLength + 1;
        var testEnd = index - count + 1;
        for (; testIndex >= testEnd; --testIndex) {
            if (!StdOps<T>.ContentEquals(*subsequence, owner[testIndex]))
                continue;
            var s = subsequence + 1;
            var t = testIndex + 1;
            nint i = 1;
            while (i < subsequenceLength && StdOps<T>.ContentEquals(*s++, owner[t++]))
                i++;
            if (i == subsequenceLength)
                return testIndex;
        }

        return -1;
    }

    [AssertionMethod]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void CheckRangeArguments(ref readonly TOwner owner, long index, long count) {
        if (index < 0 || index > owner.LongCount)
            throw new ArgumentOutOfRangeException(nameof(index), index, null);
        if (count < 0 || count > owner.LongCount - index)
            throw new ArgumentOutOfRangeException(nameof(count), count, null);
    }
}
