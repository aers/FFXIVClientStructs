using FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;
using FFXIVClientStructs.FFXIV.Client.Game.MassivePcContent;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Common.Lua;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::EventFramework
// ctor "E8 ?? ?? ?? ?? 48 89 05 ?? ?? ?? ?? 48 83 C4 28 E9"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x4500)]
public unsafe partial struct EventFramework {
    [StaticAddress("48 8B 05 ?? ?? ?? ?? 48 85 C0 74 ?? 83 B8 ?? ?? ?? ?? ?? 7C", 3, isPointer: true)]
    public static partial EventFramework* Instance();

    [FieldOffset(0x00)] public EventHandlerModule EventHandlerModule;
    [FieldOffset(0xC0)] public DirectorModule DirectorModule;
    [FieldOffset(0x160)] public LuaActorModule LuaActorModule;
    [FieldOffset(0x1B0)] public EventSceneModule EventSceneModule;
    // 7.1: something new
    [FieldOffset(0x3BF8)] public int LoadState; //0=Exd, 1=EventHandler, 2=Director, 3=LuaActor, 4=EventScene, 5=Idle?, 6=Ready?

    [FieldOffset(0x3C20)] public LuaState* LuaState;
    [FieldOffset(0x3C28)] public LuaThread LuaThread;

    [FieldOffset(0x3C80)] public EventState EventState1;
    [FieldOffset(0x3CE0)] public EventState EventState2;
    // Written by ProcessEventPlay
    [FieldOffset(0x3D10)] public GameObjectId SceneGameObjectId;
    [FieldOffset(0x3D18)] public short Scene;
    [FieldOffset(0x3D20)] public ushort SceneFlags;
    [FieldOffset(0x3D28), FixedSizeArray] internal FixedSizeArray255<uint> _sceneData;
    [FieldOffset(0x4124)] public byte SceneDataCount;

    [FieldOffset(0x42D8)] public DailyQuestMap DailyQuests;

    [MemberFunction("E8 ?? ?? ?? ?? 33 D2 48 8B D8 48 85 C0 0F 84")]
    public partial ContentDirector* GetContentDirector();

    [MemberFunction("E8 ?? ?? ?? ?? 41 8B 5E 18 48 8B F8")]
    public partial InstanceContentDirector* GetInstanceContentDirector();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D0 48 85 C0 74 ?? 80 B8")]
    public partial PublicContentDirector* GetPublicContentDirector();

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 DB 74 ?? 48 8D 83")]
    public partial MassivePcContentDirector* GetMassivePcContentDirector();

    [MemberFunction("40 53 48 83 EC 20 48 83 3D ?? ?? ?? ?? ?? 8B D9 74 1D")]
    public static partial PublicContentDirector* GetPublicContentDirectorByType(PublicContentDirectorType publicContentDirectorType);

    /// <summary>
    /// When EventHandlerSelector is active, this function is used to select specific event handler to interact with.
    /// </summary>
    /// <param name="index">Index of the option in EventHandlerSelector singleton.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 89 AE ?? ?? ?? ?? 80 BE")]
    public partial void InteractWithHandlerFromSelector(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 65 ?? 4C 8B F8")]
    public partial EventHandler* GetEventHandlerById(uint id);
    public EventHandler* GetEventHandlerById(ushort id) => GetEventHandlerById((uint)(id | 0x10000));

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 ?? 80 4B ?? ?? 48 8B CB")]
    public partial bool CheckInteractRange(GameObject* source, GameObject* target, byte interactionType, bool logErrorsToUser);

    [MemberFunction("48 89 5C 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC ?? 48 8B D9 48 89 6C 24")]
    public partial void SetTerritoryTypeId(ushort territoryType);

    [MemberFunction("E8 ?? ?? ?? ?? 83 7E 20 00 48 8B 7C 24")]
    public partial void MaterializeItem(EventId eventID, InventoryType inventoryType, short inventorySlot, int extraParam = 0);

    public void MaterializeItem(InventoryItem* itemSlot, MaterializeEntryId entryId) {
        MaterializeItem(new EventId { ContentId = EventHandlerContent.Materialize, EntryId = (ushort)entryId }, itemSlot->Container, itemSlot->Slot, 0);
    }

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 46 ?? 49 BF")]
    public partial void GetEventMapMarkers(ushort territoryId, StdVector<MapMarkerData>* markerVector);

    [MemberFunction("E8 ?? ?? ?? ?? 8B D8 3B 85")]
    public static partial uint GetCurrentContentId();

    [MemberFunction("E8 ?? ?? ?? ?? 38 46 ?? 75")]
    public static partial ContentType GetCurrentContentType();

    [MemberFunction("E8 ?? ?? ?? ?? 8B D8 EB ?? 0F B7 DF")]
    public static partial ushort GetContentFinderCondition(ContentType contentType, uint contentId);

    [MemberFunction("48 83 EC 28 48 8B 05 ?? ?? ?? ?? 48 85 C0 74 2C")]
    public static partial bool CanLeaveCurrentContent();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 43 ?? 41 B2")]
    public static partial void LeaveCurrentContent(bool forced = false);

    // For ObjectKind.ReactionEventObject (12)
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 48 8B FA 48 8B D9 E8 ?? ?? ?? ?? 4C 8D 83")]
    public partial void InteractWithReactionEventObject(GameObject* obj);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 8B 81 ?? ?? ?? ?? 41 0F B7 F1")]
    public partial void ProcessEventPlay(GameObject* gameObject, EventId eventId, short scene, ulong sceneFlags, uint* sceneData, byte sceneDataCount);

    [MemberFunction("E8 ?? ?? ?? ?? EB 07 48 8D 9F ?? ?? ?? ??")]
    public partial void ProcessInitializeScene(GameObject* gameObject, EventId eventId, short scene, ulong sceneFlags, uint* sceneData, byte sceneDataCount);

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
