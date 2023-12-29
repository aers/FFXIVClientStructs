using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using FFXIVClientStructs.STD.ContainerInterface;
using JetBrains.Annotations;

namespace FFXIVClientStructs.STD.Helper;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
internal static class MutateHelper<T, TOwner>
    where T : unmanaged
    where TOwner : IStdRandomElementModifiable<T> {
    private const long IntrosortSizeThreshold = 64;

    public static void DefaultReverse(ref TOwner owner) => DefaultReverse(ref owner, 0, owner.LongCount);
    public static void DefaultReverse(ref TOwner owner, long index, long count) {
        CheckRangeArguments(in owner, index, count);
        var l = index;
        var r = count - 1;
        for (; l < r; l++, r--)
            StdOps<T>.Swap(ref owner[l], ref owner[r]);
    }

    internal static void Sort(ref TOwner owner, long offset, long length) =>
        IntrospectiveSort(ref owner, offset, length, Comparer<T>.Default.Compare);

    internal static void Sort(ref TOwner owner, long offset, long length, IComparer<T>? comparer) =>
        IntrospectiveSort(ref owner, offset, length, (comparer ?? Comparer<T>.Default).Compare);

    internal static void Sort(ref TOwner owner, long offset, long length, Comparison<T> comparer) =>
        IntrospectiveSort(ref owner, offset, length, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void SwapIfGreater(ref TOwner owner, Comparison<T> comparer, long offset, long i, long j) {
        Debug.Assert(i != j);

        ref var e1 = ref owner[offset + i];
        ref var e2 = ref owner[offset + j];
        if (comparer(e1, e2) > 0)
            StdOps<T>.Swap(ref e1, ref e2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void Swap(ref TOwner owner, long offset, long i, long j) {
        Debug.Assert(i != j);
        StdOps<T>.Swap(ref owner[offset + i], ref owner[offset + j]);
    }

    private static void IntrospectiveSort(ref TOwner owner, long offset, long length, Comparison<T> comparer) {
        Debug.Assert(comparer != null);

        if (length > 1) {
            IntroSort(ref owner, offset, length, 2 * (BitOperations.Log2((ulong)length) + 1), comparer);
        }
    }

    private static void IntroSort(ref TOwner owner, long offset, long length, long depthLimit, Comparison<T> comparer) {
        Debug.Assert(length != 0);
        Debug.Assert(depthLimit >= 0);
        Debug.Assert(comparer != null);

        var partitionSize = length;
        while (partitionSize > 1) {
            if (partitionSize <= IntrosortSizeThreshold) {

                if (partitionSize == 2) {
                    SwapIfGreater(ref owner, comparer, offset, 0, 1);
                    return;
                }

                if (partitionSize == 3) {
                    SwapIfGreater(ref owner, comparer, offset, 0, 1);
                    SwapIfGreater(ref owner, comparer, offset, 0, 2);
                    SwapIfGreater(ref owner, comparer, offset, 1, 2);
                    return;
                }

                InsertionSort(ref owner, offset, partitionSize, comparer);
                return;
            }

            if (depthLimit == 0) {
                HeapSort(ref owner, offset, partitionSize, comparer);
                return;
            }
            depthLimit--;

            var p = PickPivotAndPartition(ref owner, offset, partitionSize, comparer);

            // Note we've already partitioned around the pivot and do not have to move the pivot again.
            IntroSort(ref owner, p + 1, partitionSize - p - 1, depthLimit, comparer);
            partitionSize = p;
        }
    }

    private static long PickPivotAndPartition(ref TOwner owner, long offset, long length, Comparison<T> comparer) {
        Debug.Assert(length >= IntrosortSizeThreshold);
        Debug.Assert(comparer != null);

        var hi = length - 1;

        // Compute median-of-three.  But also partition them, since we've done the comparison.
        var middle = hi >> 1;

        // Sort lo, mid and hi appropriately, then pick mid as the pivot.
        SwapIfGreater(ref owner, comparer, offset, 0, middle); // swap the low with the mid point
        SwapIfGreater(ref owner, comparer, offset, 0, hi); // swap the low with the high
        SwapIfGreater(ref owner, comparer, offset, middle, hi); // swap the middle with the high

        Swap(ref owner, offset, middle, hi - 1);
        ref var pivot = ref owner[offset + hi - 1];

        long left = 0, right = hi - 1; // We already partitioned lo and hi and put the pivot in hi - 1.  And we pre-increment & decrement below.

        while (left < right) {
            while (comparer(owner[offset + ++left], pivot) < 0) _ = 0;
            while (comparer(pivot, owner[offset + --right]) < 0) _ = 0;

            if (left >= right)
                break;

            Swap(ref owner, offset, left, right);
        }

        // Put pivot in the right location.
        if (left != hi - 1) {
            Swap(ref owner, offset, left, hi - 1);
        }
        return left;
    }

    private static void HeapSort(ref TOwner owner, long offset, long length, Comparison<T> comparer) {
        Debug.Assert(comparer != null);
        Debug.Assert(length != 0);

        var n = length;
        for (var i = n >> 1; i >= 1; i--) {
            DownHeap(ref owner, offset, i, n, comparer);
        }

        for (var i = n; i > 1; i--) {
            Swap(ref owner, offset, 0, i - 1);
            DownHeap(ref owner, offset, 1, i - 1, comparer);
        }
    }

    private static void DownHeap(ref TOwner owner, long offset, long i, long n, Comparison<T> comparer) {
        Debug.Assert(comparer != null);

        while (i <= n >> 1) {
            var child = 2 * i;
            if (child < n && comparer(owner[offset + child - 1], owner[offset + child]) < 0) {
                child++;
            }

            if (!(comparer(owner[offset + i - 1], owner[offset + child - 1]) < 0))
                break;

            Swap(ref owner, offset, i - 1, child - 1);
            i = child;
        }
    }

    private static void InsertionSort(ref TOwner owner, long offset, long length, Comparison<T> comparer) {
        for (long i = 0; i < length - 1; i++) {
            var j = i;
            while (j >= 0 && comparer(owner[offset + j + 1], owner[offset + j]) < 0) {
                Swap(ref owner, offset, j + 1, j);
                j--;
            }
        }
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
