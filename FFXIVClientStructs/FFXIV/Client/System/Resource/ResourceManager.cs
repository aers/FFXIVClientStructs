using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource;
// Client::System::Resource::ResourceManager
// no vtbl

// size = 0x1728
// ctor E8 ?? ?? ?? ?? 48 89 05 ?? ?? ?? ?? 48 8B 08
[StructLayout(LayoutKind.Explicit, Size = 0x1728)]
public unsafe partial struct ResourceManager
{
    [FieldOffset(0x8)] public ResourceGraph* ResourceGraph;

    [MemberFunction("44 8B 12 4D 8B D8 41 0F B7 C2 49 C1 EA 18")]
    public partial ResourceHandle* FindResourceHandle(ResourceCategory* category, uint* type, uint* hash);

    [MemberFunction("E8 ?? ?? 00 00 48 8D 8F ?? ?? 00 00 48 89 87 ?? ?? 00 00")]
    public partial ResourceHandle* GetResourceSync(ResourceCategory* category, uint* type, uint* hash, byte* path,
        void* unknown);

    [MemberFunction("E8 ?? ?? ?? 00 48 8B D8 EB ?? F0 FF 83 ?? ?? 00 00")]
    public partial ResourceHandle* GetResourceAsync(ResourceCategory* category, uint* type, uint* hash, byte* path,
        void* unknown, bool isUnknown);
}