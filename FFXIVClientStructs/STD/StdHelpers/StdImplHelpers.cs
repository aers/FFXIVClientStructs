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
        switch (enumerable)
        {
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
}
