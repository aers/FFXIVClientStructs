using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Common.Configuration.ConfigBase;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::RaptureAtkModule
//   Component::GUI::AtkModule
//     Component::GUI::AtkModuleInterface
//   Common::Configuration::ConfigBase::ChangeEventInterface
[GenerateInterop]
[Inherits<AtkModule>, Inherits<ChangeEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x29720)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 8F ?? ?? ?? ?? 48 89 07", 3)]
public unsafe partial struct RaptureAtkModule {
    public static RaptureAtkModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetRaptureAtkModule();
    }

    [FieldOffset(0x82C0)] public ushort UiMode; // 0 = In Lobby, 1 = In Game
    [FieldOffset(0x82C2)] public ushort UISetupStage; // unsure

    [FieldOffset(0x8338)] internal Utf8String Unk8338;
    [FieldOffset(0x83A0), FixedSizeArray] internal FixedSizeArray6<Utf8String> _unkArray;
    [FieldOffset(0x8610)] public Utf8String ItalicOn; // <italic(1)>
    [FieldOffset(0x8678)] public Utf8String ItalicOff; // <italic(0)>
    [FieldOffset(0x86E0)] public Utf8String BoldOn; // <bold(1)>
    [FieldOffset(0x8748)] public Utf8String BoldOff; // <bold(0)>

    [FieldOffset(0x87F7)] public AgentUpdateFlags AgentUpdateFlag; // reset happens in RaptureAtkModule_OnUpdate
    [FieldOffset(0x87F8)] internal fixed byte AddonAllocators[0x28 * 889];
    [FieldOffset(0x112E0)] public StdVector<Utf8String> AddonNames;
    [FieldOffset(0x112F8)] public AddonConfig* AddonConfigPtr;

    [FieldOffset(0x113B0)] public UIModule* UIModulePtr;
    [FieldOffset(0x113B8)] public RaptureLogModule* RaptureLogModulePtr;
    [FieldOffset(0x113C0)] public AgentModule AgentModule;
    [FieldOffset(0x12210)] public RaptureHotbarModule* RaptureHotbarModulePtr;
    [FieldOffset(0x12218)] public RaptureAtkUnitManager RaptureAtkUnitManager;
    [FieldOffset(0x1BF30)] public RaptureAtkColorDataManager RaptureAtkColorDataManager;

    [FieldOffset(0x1C1B0)] public int NameplateInfoCount;
    [FieldOffset(0x1C1B8), FixedSizeArray] internal FixedSizeArray50<NamePlateInfo> _namePlateInfoEntries;

    [FieldOffset(0x23630), FixedSizeArray] internal FixedSizeArray18<CrystalCache> _crystalItemCache;
    [FieldOffset(0x240E0)] public ItemCache* KeyItemCache; // ptr to 120 entries
    [FieldOffset(0x240E8)] public ItemCache* EquippedItemCache; // ptr to 14 entries
    [FieldOffset(0x240F0), FixedSizeArray] internal FixedSizeArray160<InventoryCache> _inventoryItemCache; // see "E8 ?? ?? ?? ?? 48 8B 07 8D 55 05", only 140 slots are processed, unused?
    [FieldOffset(0x295F0)] public uint InventoryItemCacheSlotCount;
    [FieldOffset(0x295F4)] public uint GilCap;

    [FieldOffset(0x29638)] public uint LocalPlayerClassJobId;
    [FieldOffset(0x2963C)] public uint LocalPlayerLevel;

    [FieldOffset(0x29645)] public bool QuickGatheringEnabled;

    [FieldOffset(0x296D0)] internal ExcelSheet* AddonParamSheet;
    [FieldOffset(0x296D8)] public AtkTexture CharaViewDefaultBackgroundTexture; // "ui/common/CharacterBg.tex" (or _hr1 variant)

    [FieldOffset(0x296F4)] public uint LoginSummonCompanionId;
    [FieldOffset(0x296F8)] public float LoginSummonCompanionCountdown;
    /// <remarks> Only for Region 5 </remarks>
    [FieldOffset(0x296FC)] public float HourTimer;
    /// <remarks> Only for Region 5 </remarks>
    [FieldOffset(0x29700)] public int HoursPlayed;

    [FieldOffset(0x29718)] internal nint ShellCommands; // only 1 function to open links?

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 9F ?? ?? ?? ?? 48 89 5F 58")]
    public partial bool ChangeUiMode(uint uiMode);

    [MemberFunction("E8 ?? ?? ?? ?? 0F BE 4E 30")]
    public partial bool IncRefNumberArrayData(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 44 89 76 30")]
    public partial bool DecRefNumberArrayData(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 ED 41 8B 47 44")]
    public partial bool IncRefStringArrayData(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 6B 28")]
    public partial bool DecRefStringArrayData(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 66 89 46 50")]
    public partial ushort OpenAddon(uint addonNameId, uint valueCount, AtkValue* values, AgentInterface* parentAgent, ulong unk, ushort parentAddonId, int unk2);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 40 4C 8B F2 41 8B E9")]
    public partial ushort OpenAddonByAgent(byte* addonName, AtkUnitBase* addon, int valueCount, AtkValue* values, AgentInterface* agent, nint a7, ushort parentAddonId);

    [MemberFunction("48 ?? ?? 0F 84 ?? ?? ?? ?? 4C ?? ?? 49 89 5B ?? 49 89 73"), GenerateStringOverloads]
    public partial void ShowTextGimmickHint(byte* text, TextGimmickHintStyle style, int duration);

    [VirtualFunction(39)]
    public partial void SetUiVisibility(bool uiVisible);

    [VirtualFunction(58)]
    public partial void Update(float delta);

    [VirtualFunction(63), GenerateStringOverloads]
    public partial bool OpenMapWithMapLink(byte* mapLink);

    public bool IsUiVisible {
        get => !RaptureAtkUnitManager.AtkUnitManager.Flags.HasFlag(AtkUnitManagerFlags.UiHidden);
        set => SetUiVisibility(value);
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x250)]
    public struct NamePlateInfo {
        [FieldOffset(0x00)] public GameObjectId ObjectId;
        [FieldOffset(0x30)] public Utf8String Name;
        [FieldOffset(0xA0)] public Utf8String FcName;
        [FieldOffset(0x108)] public Utf8String Title;
        [FieldOffset(0x170)] public Utf8String DisplayTitle;
        [FieldOffset(0x1D8)] public Utf8String LevelText;
        [FieldOffset(0x248)] public int Flags;
        [FieldOffset(0x24C)] public bool IsDirty;

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

    public enum TextGimmickHintStyle : byte {
        Warning = 0,
        Info = 1,
    }
}
