using FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;
using FFXIVClientStructs.FFXIV.Client.Game.MassivePcContent;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Common.Lua;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::EventFramework
// ctor "E8 ?? ?? ?? ?? 48 89 05 ?? ?? ?? ?? 48 83 C4 28 E9"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x44A0)]
public unsafe partial struct EventFramework {
    [StaticAddress("4C 39 2D ?? ?? ?? ?? 74 14", 3, isPointer: true)]
    public static partial EventFramework* Instance();

    [FieldOffset(0x00)] public EventHandlerModule EventHandlerModule;
    [FieldOffset(0xC0)] public DirectorModule DirectorModule;
    [FieldOffset(0x160)] public LuaActorModule LuaActorModule;
    [FieldOffset(0x1B0)] public EventSceneModule EventSceneModule;
    // 7.1: something new
    [FieldOffset(0x3BF8)] public int LoadState; //0=Exd, 1=EventHandler, 2=Director, 3=LuaActor, 4=EventScene, 5=Idle?, 6=Ready?

    [FieldOffset(0x3C00)] public LuaState* LuaState;
    [FieldOffset(0x3C08)] public LuaThread LuaThread;

    [FieldOffset(0x3C60)] public EventState EventState1;
    [FieldOffset(0x3CC0)] public EventState EventState2;

    [FieldOffset(0x42B8)] public DailyQuestMap DailyQuests;

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 0E 66 83 B8")]
    public partial ContentDirector* GetContentDirector();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 98")]
    public partial InstanceContentDirector* GetInstanceContentDirector();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D0 48 85 C0 74 ?? 80 B8")]
    public partial PublicContentDirector* GetPublicContentDirector();

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 F6 74 ?? 48 81 C6")]
    public partial MassivePcContentDirector* GetMassivePcContentDirector();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F 10 48 8B F0 48 8B 11 FF 52 40")]
    public static partial PublicContentDirector* GetPublicContentDirectorByType(PublicContentDirectorType publicContentDirectorType);

    /// <summary>
    /// When EventHandlerSelector is active, this function is used to select specific event handler to interact with.
    /// </summary>
    /// <param name="index">Index of the option in EventHandlerSelector singleton.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 89 AF ?? ?? ?? ?? 80 BF")]
    public partial void InteractWithHandlerFromSelector(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 1B 66 83 78 ?? ??")]
    public partial EventHandler* GetEventHandlerById(uint id);
    public EventHandler* GetEventHandlerById(ushort id) => GetEventHandlerById((uint)(id | 0x10000));

    [MemberFunction("40 53 57 41 56 48 83 EC 70 48 8B 02")]
    public partial bool CheckInteractRange(GameObject* source, GameObject* target, byte interactionType, bool logErrorsToUser);

    [MemberFunction("48 89 5C 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC ?? 48 8B D9 48 89 6C 24")]
    public partial void SetTerritoryTypeId(ushort territoryType);

    [MemberFunction("E8 ?? ?? ?? ?? EB 27 48 8B 01")]
    public partial void MaterializeItem(EventId eventID, InventoryType inventoryType, short inventorySlot, int extraParam = 0);

    public void MaterializeItem(InventoryItem* itemSlot, MaterializeEntryId entryId) {
        MaterializeItem(new EventId { ContentId = EventHandlerContent.Materialize, EntryId = (ushort)entryId }, itemSlot->Container, itemSlot->Slot, 0);
    }

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 46 ?? 49 BF")]
    public partial void GetEventMapMarkers(ushort territoryId, StdVector<MapMarkerData>* markerVector);

    [MemberFunction("E8 ?? ?? ?? ?? 41 0F B7 4E ?? 3B C8")]
    public static partial uint GetCurrentContentId();

    [MemberFunction("E8 ?? ?? ?? ?? 41 38 46 66")]
    public static partial ContentType GetCurrentContentType();

    [MemberFunction("E8 ?? ?? ?? ?? 66 89 45 82")]
    public static partial ushort GetContentFinderCondition(ContentType contentType, uint contentId);

    [MemberFunction("48 83 EC 28 48 8B 05 ?? ?? ?? ?? 48 85 C0 74 2C")]
    public static partial bool CanLeaveCurrentContent();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 43 ?? 41 B2")]
    public static partial void LeaveCurrentContent(bool forced = false);

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
