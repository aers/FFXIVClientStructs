using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::ResidentResourceManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct ResidentResourceManager {
    [StaticAddress("0F 44 FE 48 8B 0D ?? ?? ?? ?? 48 85 C9 74 05", 6, isPointer: true)]
    public static partial ResidentResourceManager* Instance();

    [FieldOffset(0x14)]
    public uint ResourceCount;

    [FieldOffset(0x18)]
    public ResourceHandle** ResourceList;

    public ReadOnlySpan<Pointer<ResourceHandle>> ResourceSpan
        => new(ResourceList, (int)ResourceCount);
}
