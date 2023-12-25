using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.STD;

internal static class StdHelpers {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool DefaultEquals<T>(in T v1, in T v2) where T : unmanaged =>
        EqualityComparer<T>.Default.Equals(v1, v2);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int DefaultCompare<T>(in T v1, in T v2) where T : unmanaged =>
        Comparer<T>.Default.Compare(v1, v2);
}
