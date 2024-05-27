using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct ResidentResourceManager {
    [FieldOffset(0x14)]
    public uint ResourceCount;

    [FieldOffset(0x18)]
    public ResourceHandle** ResourceList;

    public readonly ReadOnlySpan<Pointer<ResourceHandle>> ResourceSpan
        => new(ResourceList, (int)ResourceCount);

    [StaticAddress("0F 44 FE 48 8B 0D ?? ?? ?? ?? 48 85 C9 74 05", 6, isPointer: true)]
    public static partial ResidentResourceManager* Instance();
}
