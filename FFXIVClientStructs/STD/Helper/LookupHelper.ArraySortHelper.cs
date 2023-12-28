using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.STD.Helper;

internal static partial class LookupHelper<T, TOwner> {
    private const long IntrosortSizeThreshold = 64;
    
    internal static void Sort(ref TOwner owner, long offset, long length) =>
        IntrospectiveSort(ref owner, offset, length, Comparer<T>.Default.Compare);

    internal static void Sort(ref TOwner owner, long offset, long length, IComparer<T>? comparer) =>
        IntrospectiveSort(ref owner, offset, length, (comparer ?? Comparer<T>.Default).Compare);

    internal static void Sort(ref TOwner owner, long offset, long length, Comparison<T> comparer) =>
        IntrospectiveSort(ref owner, offset, length, comparer);

    internal static long BinarySearch(ref readonly TOwner owner, long index, long length, T value, IComparer<T>? comparer) {
        comparer ??= Comparer<T>.Default;
        return InternalBinarySearch(in owner, index, length, value, comparer);
    }

    private static long InternalBinarySearch(ref readonly TOwner owner, long index, long length, T value, IComparer<T> comparer) {
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
}

