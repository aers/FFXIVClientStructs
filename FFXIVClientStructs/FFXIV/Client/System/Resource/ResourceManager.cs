using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource;

// Client::System::Resource::ResourceManager
// ctor "E8 ?? ?? ?? ?? 48 89 05 ?? ?? ?? ?? 48 8B 08"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1728)]
public unsafe partial struct ResourceManager {
    [FieldOffset(0x8)] public ResourceGraph* ResourceGraph;

    [StaticAddress("48 89 05 ?? ?? ?? ?? 48 8B 08", 3, isPointer: true)]
    public static partial ResourceManager* Instance();
    
    [MemberFunction("44 8B 12 4D 8B D8 41 0F B7 C2 49 C1 EA 18")]
    public partial ResourceHandle* FindResourceHandle(ResourceCategory* category, uint* type, uint* hash);

    [MemberFunction("E8 ?? ?? 00 00 48 8D 8F ?? ?? 00 00 48 89 87 ?? ?? 00 00"), GenerateStringOverloads]
    public partial ResourceHandle* GetResourceSync(ResourceCategory* category, uint* type, uint* hash, byte* path, void* unknown);

    [MemberFunction("E8 ?? ?? ?? 00 48 8B D8 EB ?? F0 FF 83 ?? ?? 00 00"), GenerateStringOverloads]
    public partial ResourceHandle* GetResourceAsync(ResourceCategory* category, uint* type, uint* hash, byte* path, void* unknown, bool isUnknown);
}

public enum ResourceCategory {
    Common = 0,
    BgCommon = 1,
    Bg = 2,
    Cut = 3,
    Chara = 4,
    Shader = 5,
    Ui = 6,
    Sound = 7,
    Vfx = 8,
    UiScript = 9,
    Exd = 10,
    GameScript = 11,
    Music = 12,
    SqpackTest = 18,
    Debug = 19,
    MaxCount = 20
}
