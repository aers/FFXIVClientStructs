using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.STD.StdHelpers;

public class DefaultMemorySpaceStatic : IMemorySpaceStatic {
    private DefaultMemorySpaceStatic() => throw new InvalidOperationException();

    public static unsafe delegate* unmanaged[Stdcall]<IMemorySpace*> GetSpace => IMemorySpace.MemberFunctionPointers.GetDefaultSpace;
}