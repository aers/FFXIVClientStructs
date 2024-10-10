using FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
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

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 0B 0F B6 90")]
    public partial PublicContentDirector* GetPublicContentDirector();

    /// <summary>
    /// When EventHandlerSelector is active, this function is used to select specific event handler to interact with.
    /// </summary>
    /// <param name="index">Index of the option in EventHandlerSelector singleton.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 44 89 A7 ?? ?? ?? ?? 44 38 A7")]
    public partial void InteractWithHandlerFromSelector(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 1B 66 83 78 ?? ??")]
    public partial EventHandler* GetEventHandlerById(uint id);
    public EventHandler* GetEventHandlerById(ushort id) => GetEventHandlerById((uint)(id | 0x10000));

    [MemberFunction("40 53 57 41 56 48 83 EC 70 48 8B 02")]
    public partial bool CheckInteractRange(GameObject* source, GameObject* target, byte interactionType, bool logErrorsToUser);

    [MemberFunction("E8 ?? ?? ?? ?? 41 0F B7 4E ?? 3B C8")]
    public static partial uint GetCurrentContentId();

    [MemberFunction("E8 ?? ?? ?? ?? 41 38 46 66")]
    public static partial ContentType GetCurrentContentType();

    [MemberFunction("E8 ?? ?? ?? ?? 66 89 45 82")]
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
