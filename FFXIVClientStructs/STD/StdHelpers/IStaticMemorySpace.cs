using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.STD.StdHelpers;

/// <summary>
/// Static interface for <see cref="IMemorySpace"/>.
/// </summary>
public unsafe interface IStaticMemorySpace {
    /// <summary>
    /// Allocates aligned memory.
    /// </summary>
    /// <param name="size">The size of allocation in bytes.</param>
    /// <param name="alignment">The required alignment in bytes.</param>
    /// <returns>0 if failed; otherwise, pointer to the newly allocated memory.</returns>
    public abstract static void* Allocate(nuint size, nuint alignment);
}
