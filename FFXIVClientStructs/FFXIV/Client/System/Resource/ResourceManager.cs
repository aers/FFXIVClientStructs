using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource;

// Client::System::Resource::ResourceManager
// ctor "E8 ?? ?? ?? ?? 48 89 05 ?? ?? ?? ?? 48 8B 08"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1728)]
public unsafe partial struct ResourceManager {
    [StaticAddress("48 89 05 ?? ?? ?? ?? 48 8B 08", 3, isPointer: true)]
    public static partial ResourceManager* Instance();

    [FieldOffset(0x8)] public ResourceGraph* ResourceGraph;

    [Obsolete("Use ResourceGraph->FindResourceHandle() instead")]
    public ResourceHandle* FindResourceHandle(ResourceCategory* category, uint* type, uint* hash) => ResourceGraph->FindResourceHandle(category, type, hash);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B C8 8B C3 F0 0F C0 81"), GenerateStringOverloads]
    public partial ResourceHandle* GetResourceSync(ResourceCategory* category, uint* type, uint* hash, CStringPointer path, void* unknown, void* unkDebugPtr, uint unkDebugInt); // TODO: first arg is `ResourceHandleType*` sent to ResourceHandle.ctor a2 and renamed to `resourceHandleType`

    [MemberFunction("E8 ?? ?? ?? 00 48 8B D8 EB ?? F0 FF 83 ?? ?? 00 00"), GenerateStringOverloads]
    public partial ResourceHandle* GetResourceAsync(ResourceCategory* category, uint* type, uint* hash, CStringPointer path, void* unknown, bool isUnknown, void* unkDebugPtr, uint unkDebugInt);// TODO: first arg is `ResourceHandleType*` sent to ResourceHandle.ctor a2 and renamed to `resourceHandleType`
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
