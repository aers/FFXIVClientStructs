using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::RaptureAtkModule
//   Component::GUI::AtkModule
//     Component::GUI::AtkModuleInterface
[GenerateInterop]
[Inherits<AtkModule>]
[StructLayout(LayoutKind.Explicit, Size = 0x28F98)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 8F ?? ?? ?? ?? 48 89 07", 3)]
public unsafe partial struct RaptureAtkModule {
    public static RaptureAtkModule* Instance() => UIModule.Instance()->GetRaptureAtkModule();

    [FieldOffset(0x82C0)] public ushort UiMode; // 0 = In Lobby, 1 = In Game

    [FieldOffset(0x8338)] internal Utf8String Unk8338;
    [FieldOffset(0x83A0), FixedSizeArray] internal FixedSizeArray6<Utf8String> _unkArray;
    [FieldOffset(0x8610)] public Utf8String ItalicOn; // <italic(1)>
    [FieldOffset(0x8678)] public Utf8String ItalicOff; // <italic(0)>
    [FieldOffset(0x86E0)] public Utf8String BoldOn; // <bold(1)>
    [FieldOffset(0x8748)] public Utf8String BoldOff; // <bold(0)>

    [FieldOffset(0x87F7)] public AgentUpdateFlags AgentUpdateFlag; // reset happens in RaptureAtkModule_OnUpdate
    [FieldOffset(0x87F8)] internal fixed byte AddonAllocators[0x28 * 853];
    [FieldOffset(0x10D40)] public StdVector<Utf8String> AddonNames;
    [FieldOffset(0x10D58)] public AddonConfig* AddonConfigPtr;

    [FieldOffset(0x10E10)] public UIModule* UIModulePtr;
    [FieldOffset(0x10E18)] public RaptureLogModule* RaptureLogModulePtr;
    [FieldOffset(0x10E20)] public AgentModule AgentModule;
    [FieldOffset(0x11C18)] public RaptureHotbarModule* RaptureHotbarModulePtr;
    [FieldOffset(0x11C20)] public RaptureAtkUnitManager RaptureAtkUnitManager;
    [FieldOffset(0x1B938)] public RaptureAtkColorDataManager RaptureAtkColorDataManager;

    [FieldOffset(0x1BBB8)] public int NameplateInfoCount;
    [FieldOffset(0x1BBC0), FixedSizeArray] internal FixedSizeArray50<NamePlateInfo> _namePlateInfoEntries;

    [FieldOffset(0x22EA8), FixedSizeArray] internal FixedSizeArray18<CrystalCache> _crystalItemCache;
    [FieldOffset(0x23958)] public ItemCache* KeyItemCache; // ptr to 120 entries
    [FieldOffset(0x23960)] public ItemCache* EquippedItemCache; // ptr to 14 entries
    [FieldOffset(0x23968), FixedSizeArray] internal FixedSizeArray160<InventoryCache> _inventoryItemCache; // see "E8 ?? ?? ?? ?? 48 8B 07 8D 55 05", only 140 slots are processed, unused?
    [FieldOffset(0x28E68)] public uint InventoryItemCacheSlotCount;
    [FieldOffset(0x28E6C)] public uint GilCap;

    [FieldOffset(0x28EB0)] public uint LocalPlayerClassJobId;
    [FieldOffset(0x28EB4)] public uint LocalPlayerLevel;

    [FieldOffset(0x28F48)] internal ExcelSheet* AddonParamSheet;
    [FieldOffset(0x28F50)] public AtkTexture CharaViewDefaultBackgroundTexture; // "ui/common/CharacterBg.tex" (or _hr1 variant)

    [FieldOffset(0x28F90)] internal nint ShellCommands; // only 1 function "48 83 EC 38 4C 8B C2 C7 44 24" to open links?

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 9E ?? ?? ?? ?? 48 89 5E 58")]
    public partial bool ChangeUiMode(uint uiMode);

    [MemberFunction("E8 ?? ?? ?? ?? 0F BE 4E 30")]
    public partial bool IncRefNumberArrayData(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 57 4C")]
    public partial bool DecRefNumberArrayData(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 ED 41 8B 47 44")]
    public partial bool IncRefStringArrayData(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 6B 28")]
    public partial bool DecRefStringArrayData(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 66 89 46 50")]
    public partial ushort OpenAddon(uint addonNameId, uint valueCount, AtkValue* values, AgentInterface* parentAgent, ulong unk, ushort parentAddonId, int unk2);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 40 4C 8B F2 41 8B E9")]
    public partial ushort OpenAddonByAgent(byte* addonName, AtkUnitBase* addon, int valueCount, AtkValue* values, AgentInterface* agent, nint a7, ushort parentAddonId);

    [VirtualFunction(39)]
    public partial void SetUiVisibility(bool uiVisible);

    [VirtualFunction(58)]
    public partial void Update(float delta);

    public bool IsUiVisible {
        get => !RaptureAtkUnitManager.AtkUnitManager.Flags.HasFlag(AtkUnitManagerFlags.UiHidden);
        set => SetUiVisibility(value);
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x248)]
    public struct NamePlateInfo {
        [FieldOffset(0x00)] public GameObjectId ObjectId;
        [FieldOffset(0x30)] public Utf8String Name;
        [FieldOffset(0x98)] public Utf8String FcName;
        [FieldOffset(0x100)] public Utf8String Title;
        [FieldOffset(0x168)] public Utf8String DisplayTitle;
        [FieldOffset(0x1D0)] public Utf8String LevelText;
        [FieldOffset(0x240)] public int Flags;
        [FieldOffset(0x244)] public bool IsDirty;

        public bool IsPrefixTitle => ((Flags >> (8 * 3)) & 0xFF) == 1;
    }

    // Client::UI::RaptureAtkModule::ItemCache
    [GenerateInterop(isInherited: true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x88)]
    public partial struct ItemCache {
        [FieldOffset(0x8)] public Utf8String Name;
        [FieldOffset(0x70)] public uint Id;
        [FieldOffset(0x74)] public uint IconId;
        [FieldOffset(0x78)] public uint StackSize;
        [FieldOffset(0x7C)] public byte EquipSlotCategory;
        [FieldOffset(0x7D)] public byte AdditionalData; // if FilterGroup == 15
        [FieldOffset(0x7E)] public byte LevelEquip;
        [FieldOffset(0x7F)] public byte SubStatCategory;
        [FieldOffset(0x80)] public short LevelItem;
    }

    // Client::UI::RaptureAtkModule::InventoryCache
    [GenerateInterop, Inherits<ItemCache>]
    [StructLayout(LayoutKind.Explicit, Size = 0x88)]
    public partial struct InventoryCache;

    // Client::UI::RaptureAtkModule::CrystalCache
    [GenerateInterop, Inherits<ItemCache>]
    [StructLayout(LayoutKind.Explicit, Size = 0x98)]
    public partial struct CrystalCache;

    [Flags]
    public enum AgentUpdateFlags : byte {
        None = 0x00,
        InventoryUpdate = 0x01,
        ActionBarUpdate = 0x02, // Triggered by using Actions, Inventories, Gearsets, Macros
        RetainerUpdate = 0x04,
        NameplateUpdate = 0x08,
        UnlocksUpdate = 0x10, // Triggered by Mounts, Minions, Orchestrion Rolls, Sightseeing Log, UnlockLinks...
        MainCommandEnabledStateUpdate = 0x20,
        HousingInventoryUpdate = 0x40,
    }
}
