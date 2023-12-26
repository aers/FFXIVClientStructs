using System.Collections;
using JetBrains.Annotations;

namespace FFXIVClientStructs.STD.StdHelpers;

public static class StdImplHelpers {
    // [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // internal static bool DefaultEquals<T>(in T v1, in T v2) =>
    //     EqualityComparer<T>.Default.Equals(v1, v2);
    //
    // [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // internal static int DefaultCompare<T>(in T v1, in T v2) =>
    //     Comparer<T>.Default.Compare(v1, v2);

    internal static bool TryGetCountFromEnumerable<T>([NoEnumeration] IEnumerable<T>? enumerable, out int count) {
        switch (enumerable) {
            case null:
                count = 0;
                return true;
            case ICollection c:
                count = c.Count;
                return true;
            case ICollection<T> c:
                count = c.Count;
                return true;
            case IReadOnlyCollection<T> c:
                count = c.Count;
                return true;
            default:
                count = 0;
                return false;
        }
    }

    internal static unsafe void ZeroMemory<T>(T* p, nuint size) where T : unmanaged {
        foreach (var span in new ChunkedSpanEnumerator<T>(p, size))
            span.Clear();
    }

    internal static unsafe void FillMemory<T>(T* p, nuint size, in T value) where T : unmanaged {
        foreach (var span in new ChunkedSpanEnumerator<T>(p, size))
            span.Fill(value);
    }

    internal unsafe struct ChunkedSpanEnumerator<T>
        where T : unmanaged {
        private const int ChunkSize = 0x10000000;
        private readonly T* _ptr;
        private readonly nuint _count;
        private nuint _offset = unchecked((nuint)0 - ChunkSize);

        public ChunkedSpanEnumerator(T* ptr, nuint count) {
            _ptr = ptr;
            _count = count;
        }

        public Span<T> Current =>
            _offset >= _count
                ? throw new InvalidOperationException()
                : new(
                    _ptr + _offset,
                    (int)Math.Min(ChunkSize, (ulong)(_count - _offset)));

        public bool MoveNext() {
            var next = unchecked(_offset + ChunkSize);
            if (next >= _count - 1 || _count == 0)
                return false;

            _offset = next;
            return true;
        }

        public ChunkedSpanEnumerator<T> GetEnumerator() => this;
    }
}
