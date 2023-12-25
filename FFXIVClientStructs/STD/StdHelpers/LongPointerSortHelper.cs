using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.STD.StdHelpers;

/// <summary>
/// Taken from ArraySortHelper.
/// </summary>
/// <typeparam name="T">The element type.</typeparam>
/// <typeparam name="TOperation">The operations.</typeparam>
internal static unsafe class LongPointerSortHelper<T, TOperation>
    where T : unmanaged
    where TOperation : INativeObjectOperationStatic<T> {
    private const long IntrosortSizeThreshold = 64;

    internal static void Sort(T* data, long dataLength) =>
        IntrospectiveSort(data, dataLength, Comparer<T>.Default.Compare);

    internal static void Sort(T* data, long dataLength, IComparer<T>? comparer) =>
        IntrospectiveSort(data, dataLength, (comparer ?? Comparer<T>.Default).Compare);

    internal static void Sort(T* data, long dataLength, Comparison<T> comparer) =>
        IntrospectiveSort(data, dataLength, comparer);

    internal static long BinarySearch(T* data, long index, long length, T value, IComparer<T>? comparer) {
        comparer ??= Comparer<T>.Default;
        return InternalBinarySearch(data, index, length, value, comparer);
    }

    private static long InternalBinarySearch(T* data, long index, long length, T value, IComparer<T> comparer) {
        var lo = index;
        var hi = index + length - 1;
        while (lo <= hi) {
            var i = lo + ((hi - lo) >> 1);
            long order = comparer.Compare(data[i], value);

            if (order == 0) return i;
            if (order < 0) {
                lo = i + 1;
            } else {
                hi = i - 1;
            }
        }

        return ~lo;
    }

    private static void SwapIfGreater(T* data, Comparison<T> comparer, long i, long j) {
        Debug.Assert(i != j);

        if (comparer(data[i], data[j]) > 0)
            TOperation.Swap(ref data[i], ref data[j]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void Swap(T* a, long i, long j) {
        Debug.Assert(i != j);
        TOperation.Swap(ref a[i], ref a[j]);
    }

    private static void IntrospectiveSort(T* data, long dataLength, Comparison<T> comparer) {
        Debug.Assert(comparer != null);

        if (dataLength > 1) {
            IntroSort(data, dataLength, 2 * (BitOperations.Log2((uint)dataLength) + 1), comparer);
        }
    }

    private static void IntroSort(T* data, long dataLength, long depthLimit, Comparison<T> comparer) {
        Debug.Assert(dataLength != 0);
        Debug.Assert(depthLimit >= 0);
        Debug.Assert(comparer != null);

        var partitionSize = dataLength;
        while (partitionSize > 1) {
            if (partitionSize <= IntrosortSizeThreshold) {

                if (partitionSize == 2) {
                    SwapIfGreater(data, comparer, 0, 1);
                    return;
                }

                if (partitionSize == 3) {
                    SwapIfGreater(data, comparer, 0, 1);
                    SwapIfGreater(data, comparer, 0, 2);
                    SwapIfGreater(data, comparer, 1, 2);
                    return;
                }

                InsertionSort(data, partitionSize, comparer);
                return;
            }

            if (depthLimit == 0) {
                HeapSort(data, partitionSize, comparer);
                return;
            }
            depthLimit--;

            var p = PickPivotAndPartition(data, partitionSize, comparer);

            // Note we've already partitioned around the pivot and do not have to move the pivot again.
            IntroSort(data + p + 1, partitionSize - p - 1, depthLimit, comparer);
            partitionSize = p;
        }
    }

    private static long PickPivotAndPartition(T* data, long dataLength, Comparison<T> comparer) {
        Debug.Assert(dataLength >= IntrosortSizeThreshold);
        Debug.Assert(comparer != null);

        var hi = dataLength - 1;

        // Compute median-of-three.  But also partition them, since we've done the comparison.
        var middle = hi >> 1;

        // Sort lo, mid and hi appropriately, then pick mid as the pivot.
        SwapIfGreater(data, comparer, 0, middle); // swap the low with the mid point
        SwapIfGreater(data, comparer, 0, hi); // swap the low with the high
        SwapIfGreater(data, comparer, middle, hi); // swap the middle with the high

        var pivot = data[middle];
        Swap(data, middle, hi - 1);
        long left = 0, right = hi - 1; // We already partitioned lo and hi and put the pivot in hi - 1.  And we pre-increment & decrement below.

        while (left < right) {
            while (comparer(data[++left], pivot) < 0) _ = 0;
            while (comparer(pivot, data[--right]) < 0) _ = 0;

            if (left >= right)
                break;

            Swap(data, left, right);
        }

        // Put pivot in the right location.
        if (left != hi - 1) {
            Swap(data, left, hi - 1);
        }
        return left;
    }

    private static void HeapSort(T* data, long dataLength, Comparison<T> comparer) {
        Debug.Assert(comparer != null);
        Debug.Assert(dataLength != 0);

        var n = dataLength;
        for (var i = n >> 1; i >= 1; i--) {
            DownHeap(data, i, n, comparer);
        }

        for (var i = n; i > 1; i--) {
            Swap(data, 0, i - 1);
            DownHeap(data, 1, i - 1, comparer);
        }
    }

    private static void DownHeap(T* data, long i, long n, Comparison<T> comparer) {
        Debug.Assert(comparer != null);

        while (i <= n >> 1) {
            var child = 2 * i;
            if (child < n && comparer(data[child - 1], data[child]) < 0) {
                child++;
            }

            if (!(comparer(data[i - 1], data[child - 1]) < 0))
                break;

            Swap(data, i - 1, child - 1);
            i = child;
        }
    }

    private static void InsertionSort(T* data, long dataLength, Comparison<T> comparer) {
        for (long i = 0; i < dataLength - 1; i++) {
            var j = i;
            while (j >= 0 && comparer(data[j + 1], data[j]) < 0) {
                Swap(data, j + 1, j);
                j--;
            }
        }
    }
}
