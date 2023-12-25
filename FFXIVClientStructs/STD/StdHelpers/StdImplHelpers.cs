using System.Collections;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace FFXIVClientStructs.STD.StdHelpers;

public static class StdImplHelpers {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool DefaultEquals<T>(in T v1, in T v2) where T : unmanaged =>
        EqualityComparer<T>.Default.Equals(v1, v2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int DefaultCompare<T>(in T v1, in T v2) where T : unmanaged =>
        Comparer<T>.Default.Compare(v1, v2);

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
        while (size > 0) {
            var chunk = (int)Math.Min(0x10000000, size);
            new Span<T>(p, chunk).Clear();
            size -= (nuint)chunk;
            p += chunk;
        }
    }

    internal static unsafe void FillMemory<T>(T* p, nuint size, in T value) where T : unmanaged {
        while (size > 0) {
            var chunk = (int)Math.Min(0x10000000, size);
            new Span<T>(p, chunk).Fill(value);
            size -= (nuint)chunk;
            p += chunk;
        }
    }
}
