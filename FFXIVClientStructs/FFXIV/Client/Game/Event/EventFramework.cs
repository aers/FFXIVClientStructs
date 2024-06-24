using FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;
using FFXIVClientStructs.FFXIV.Common.Lua;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::EventFramework
// ctor "E8 ?? ?? ?? ?? 48 89 05 ?? ?? ?? ?? 48 83 C4 28 E9"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3C10)]
public unsafe partial struct EventFramework {
    [FieldOffset(0x00)] public EventHandlerModule EventHandlerModule;
    [FieldOffset(0xC0)] public DirectorModule DirectorModule;
    [FieldOffset(0x160)] public LuaActorModule LuaActorModule;
    [FieldOffset(0x1B0)] public EventSceneModule EventSceneModule;
    [FieldOffset(0x3370)] public int LoadState; //0=Exd, 1=EventHandler, 2=Director, 3=LuaActor, 4=EventScene, 5=Idle?, 6=Ready?

    [FieldOffset(0x3378)] public LuaState* LuaState;
    [FieldOffset(0x3380)] public LuaThread LuaThread;

    [FieldOffset(0x33D8)] public EventState EventState1;
    [FieldOffset(0x3438)] public EventState EventState2;

    [StaticAddress("48 8B 35 ?? ?? ?? ?? 0F B6 EA 4C 8B F1", 3, isPointer: true)]
    public static partial EventFramework* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 0D 0F B6 CB")]
    public partial ContentDirector* GetContentDirector();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 98")]
    public partial InstanceContentDirector* GetInstanceContentDirector();

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 19 83 B8 ?? ?? ?? ?? ??")]
    public partial PublicContentDirector* GetPublicContentDirector();

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 1B 66 83 78 ?? ??")]
    public partial EventHandler* GetEventHandlerById(uint id);
    public EventHandler* GetEventHandlerById(ushort id) => GetEventHandlerById((uint)(id | 0x10000));

    [MemberFunction("E8 ?? ?? ?? ?? 8B D8 3B 86")]
    public static partial uint GetCurrentContentId();

    [MemberFunction("E8 ?? ?? ?? ?? 41 38 44 24")]
    public static partial ContentType GetCurrentContentType();

    [MemberFunction("E8 ?? ?? ?? ?? 3B C7 75 53")]
    public static partial ushort GetContentFinderCondition(ContentType contentType, uint contentId);

    [MemberFunction("48 83 EC 28 48 8B 05 ?? ?? ?? ?? 48 85 C0 74 2C")]
    public static partial bool CanLeaveCurrentContent();

    private T* GetInstanceContentDirector<T>(InstanceContentType instanceContentType) where T : unmanaged {
        var instanceDirector = GetInstanceContentDirector();
        if (instanceDirector == null || instanceDirector->InstanceContentType != instanceContentType)
            return null;
        return (T*)instanceDirector;
    }

    public InstanceContentDeepDungeon* GetInstanceContentDeepDungeon()
        => GetInstanceContentDirector<InstanceContentDeepDungeon>(InstanceContentType.DeepDungeon);

    public InstanceContentOceanFishing* GetInstanceContentOceanFishing()
        => GetInstanceContentDirector<InstanceContentOceanFishing>(InstanceContentType.OceanFishing);

    public CraftEventHandler* GetCraftEventHandler()
        => (CraftEventHandler*)GetEventHandlerById(0xA0001);
}

public enum ContentType : byte {
    None, // used for raids
    Instance,
    Party, // SkyIsland - used in early phases of the Diadem
    Public,
    GoldSaucer
}
