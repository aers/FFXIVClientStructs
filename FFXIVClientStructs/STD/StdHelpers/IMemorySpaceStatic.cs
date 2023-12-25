using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.STD.StdHelpers;

public unsafe interface IMemorySpaceStatic {
    public abstract static delegate* unmanaged[Stdcall]<IMemorySpace*> GetSpace { get; }
}