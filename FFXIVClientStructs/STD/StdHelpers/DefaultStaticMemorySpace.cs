using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.STD.StdHelpers;

public class DefaultStaticMemorySpace : IStaticMemorySpace {
    private DefaultStaticMemorySpace() => throw new InvalidOperationException();

    public static unsafe void* Allocate(UIntPtr size, UIntPtr alignment) =>
        IMemorySpace.GetDefaultSpace()->Malloc(size, alignment);
}
