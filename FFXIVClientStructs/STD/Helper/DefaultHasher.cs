using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.STD.Helper;

public abstract class DefaultHasher<T> : IStaticHasher<T> where T : unmanaged {
    public static unsafe ulong Hash(in T value) {
        const ulong fnvOffsetBasis = 14695981039346656037ul;
        const ulong fnvPrime = 1099511628211ul;
        var hash = fnvOffsetBasis;
        var bytes = (byte*)Unsafe.AsPointer(ref Unsafe.AsRef(in value));
        for (var i = 0; i < sizeof(T); i++) {
            hash ^= bytes[i];
            hash *= fnvPrime;
        }

        return hash;
    }
}
