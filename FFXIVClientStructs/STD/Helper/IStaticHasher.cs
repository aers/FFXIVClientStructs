using System.Diagnostics.CodeAnalysis;

namespace FFXIVClientStructs.STD.Helper;

/// <summary>
/// hash functor primary template (handles enums, integrals, and pointers)
/// </summary>
[SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
public interface IStaticHasher<T> where T : unmanaged {
    abstract static ulong Hash(in T value);
}
