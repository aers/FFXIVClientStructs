using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.STD.Helper;

/// <summary>
/// Static interface for <see cref="IMemorySpace"/>.
/// </summary>
[SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
public unsafe interface IStaticMemorySpace {
    /// <summary>
    /// Allocates aligned memory.
    /// </summary>
    /// <param name="size">The size of allocation in bytes.</param>
    /// <param name="alignment">The required alignment in bytes.</param>
    /// <returns>0 if failed; otherwise, pointer to the newly allocated memory.</returns>
    public abstract static void* Allocate(nuint size, nuint alignment);

    public abstract class Default : IStaticMemorySpace {
        private Default() => throw new InvalidOperationException();

        public static void* Allocate(UIntPtr size, UIntPtr alignment) =>
            IMemorySpace.GetDefaultSpace()->Malloc(size, alignment);
    }
}
