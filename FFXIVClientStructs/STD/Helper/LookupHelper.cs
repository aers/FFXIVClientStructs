using FFXIVClientStructs.STD.ContainerInterface;
using JetBrains.Annotations;

namespace FFXIVClientStructs.STD.Helper;

internal static partial class LookupHelper<T, TOwner>
    where T : unmanaged
    where TOwner : IStdRandomMutable<T> {

    public static void Reverse(ref TOwner owner) => Reverse(ref owner, 0, owner.LongCount);
    public static void Reverse(ref TOwner owner, long index, long count) {
        CheckRangeArguments(in owner, index, count);
        var l = index;
        var r = count - 1;
        for (; l < r; l++, r--)
            StdOps<T>.Swap(ref owner[l], ref owner[r]);
    }

    public static T[] ToArray(ref readonly TOwner owner) => ToArray(in owner, 0, owner.LongCount);
    public static T[] ToArray(ref readonly TOwner owner, long index) => ToArray(in owner, index, owner.LongCount - index);
    public static T[] ToArray(ref readonly TOwner owner, long index, long count) {
        CheckRangeArguments(in owner, index, count);
        var a = new T[count];
        var i = 0L;
        for (; i < count; index++, i++)
            a[i] = owner[index];
        return a;
    }

    public static long LongFindIndex(ref readonly TOwner owner, Predicate<T> match) => LongFindIndex(in owner, 0, owner.LongCount, match);
    public static long LongFindIndex(ref readonly TOwner owner, long startIndex, Predicate<T> match) => LongFindIndex(in owner, startIndex, owner.LongCount - startIndex, match);
    public static long LongFindIndex(ref readonly TOwner owner, long startIndex, long count, Predicate<T> match) {
        CheckRangeArguments(in owner, startIndex, count);

        var end = startIndex + count;
        for (var i = startIndex; i < end; i++, startIndex++) {
            if (match(owner[i]))
                return startIndex;
        }

        return -1;
    }
    
    public static long LongFindLastIndex(ref readonly TOwner owner, Predicate<T> match) => LongFindLastIndex(in owner, owner.LongCount - 1, owner.LongCount, match);
    public static long LongFindLastIndex(ref readonly TOwner owner, long startIndex, Predicate<T> match) => LongFindLastIndex(in owner, startIndex, startIndex + 1, match);
    public static long LongFindLastIndex(ref readonly TOwner owner, long startIndex, long count, Predicate<T> match) {
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
    
    public static long LongIndexOf(ref readonly TOwner owner, in T item) => LongIndexOf(in owner, item, 0, owner.LongCount);
    public static long LongIndexOf(ref readonly TOwner owner, in T item, long index) => LongIndexOf(in owner, item, index, owner.LongCount - index);
    public static long LongIndexOf(ref readonly TOwner owner, in T item, long index, long count) {
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
    
    public static long LongIndexOf(ref readonly TOwner owner, ReadOnlySpan<T> subsequence) => LongIndexOf(in owner, subsequence, 0, owner.LongCount);
    public static long LongIndexOf(ref readonly TOwner owner, ReadOnlySpan<T> subsequence, long index) => LongIndexOf(in owner, subsequence, index, owner.LongCount - index);
    public static unsafe long LongIndexOf(ref readonly TOwner owner, ReadOnlySpan<T> subsequence, long index, long count) {
        fixed (T* p = subsequence)
            return LongIndexOf(in owner, p, subsequence.Length, index, count);
    }

    public static unsafe long LongIndexOf(ref readonly TOwner owner, T* subsequence, nint subsequenceLength) => LongIndexOf(in owner, subsequence, subsequenceLength, 0, owner.LongCount);
    public static unsafe long LongIndexOf(ref readonly TOwner owner, T* subsequence, nint subsequenceLength, long index) => LongIndexOf(in owner, subsequence, subsequenceLength, index, owner.LongCount - index);
    public static unsafe long LongIndexOf(ref readonly TOwner owner, T* subsequence, nint subsequenceLength, long index, long count) {
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
    
    public static long LongLastIndexOf(ref readonly TOwner owner, in T item) => LongLastIndexOf(in owner, item, owner.LongCount - 1, owner.LongCount);
    public static long LongLastIndexOf(ref readonly TOwner owner, in T item, long index) => LongLastIndexOf(in owner, item, index, index + 1);
    public static long LongLastIndexOf(ref readonly TOwner owner, in T item, long index, long count) {
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
    
    public static long LongLastIndexOf(ref readonly TOwner owner, ReadOnlySpan<T> subsequence) => LongLastIndexOf(in owner, subsequence, owner.LongCount - 1, owner.LongCount);
    public static long LongLastIndexOf(ref readonly TOwner owner, ReadOnlySpan<T> subsequence, long index) => LongLastIndexOf(in owner, subsequence, index, index + 1);
    public static unsafe long LongLastIndexOf(ref readonly TOwner owner, ReadOnlySpan<T> subsequence, long index, long count) {
        fixed (T* p = subsequence)
            return LongLastIndexOf(in owner, p, subsequence.Length, index, count);
    }

    public static unsafe long LongLastIndexOf(ref readonly TOwner owner, T* subsequence, nint subsequenceLength) => LongLastIndexOf(in owner, subsequence, subsequenceLength, owner.LongCount - 1, owner.LongCount);
    public static unsafe long LongLastIndexOf(ref readonly TOwner owner, T* subsequence, nint subsequenceLength, long index) => LongLastIndexOf(in owner, subsequence, subsequenceLength, index, index + 1);
    public static unsafe long LongLastIndexOf(ref readonly TOwner owner, T* subsequence, nint subsequenceLength, long index, long count) {
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
    private static void CheckRangeArguments(ref readonly TOwner owner, long index, long count) {
        if (index < 0 || index > owner.LongCount)
            throw new ArgumentOutOfRangeException(nameof(index), index, null);
        if (count < 0 || count > owner.LongCount - index)
            throw new ArgumentOutOfRangeException(nameof(count), count, null);
    }
}
