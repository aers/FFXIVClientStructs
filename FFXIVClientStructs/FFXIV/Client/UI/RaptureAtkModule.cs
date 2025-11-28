using FFXIVClientStructs.FFXIV.Client.Game.Character;
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
[StructLayout(LayoutKind.Explicit, Size = 0x29EB0)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 8F ?? ?? ?? ?? 48 89 07", 3)]
public unsafe partial struct RaptureAtkModule {
    public static RaptureAtkModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetRaptureAtkModule();
    }

    [FieldOffset(0x82C0)] public GameUIScene UIScene;
    [FieldOffset(0x82C0), Obsolete($"Renamed to {nameof(UIScene)}")] public ushort UiMode; // 0 = In Lobby, 1 = In Game
    [FieldOffset(0x82C2)] public GameUIMode UIMode;
    [FieldOffset(0x82C2), Obsolete($"Renamed to {nameof(UIMode)}")] public ushort UISetupStage; // unsure

    [FieldOffset(0x8358)] internal Utf8String Unk8358;
    [FieldOffset(0x83C0), FixedSizeArray] internal FixedSizeArray6<Utf8String> _unkArray;
    [FieldOffset(0x8630)] public Utf8String ItalicOn; // <italic(1)>
    [FieldOffset(0x8698)] public Utf8String ItalicOff; // <italic(0)>
    [FieldOffset(0x8700)] public Utf8String BoldOn; // <bold(1)>
    [FieldOffset(0x8768)] public Utf8String BoldOff; // <bold(0)>

    [FieldOffset(0x8817)] public AgentUpdateFlags AgentUpdateFlag; // reset happens in RaptureAtkModule_OnUpdate
    [FieldOffset(0x8818), FixedSizeArray] internal FixedSizeArray931<AddonFactoryInfo> _addonFactories;
    [FieldOffset(0x11990)] public StdVector<Utf8String> AddonNames;
    [FieldOffset(0x119A8)] public AddonConfig* AddonConfigPtr;

    // [FieldOffset(0x119B8)] public ProhibitModule ProhibitModule;
    [FieldOffset(0x11A50)] public int AudioClientRpcTagSize;

    [FieldOffset(0x11A58)] public char* AudioClientRpcTag;
    [FieldOffset(0x11A60)] public UIModule* UIModulePtr;
    [FieldOffset(0x11A68)] public RaptureLogModule* RaptureLogModulePtr;
    [FieldOffset(0x11A70)] public AgentModule AgentModule;
    [FieldOffset(0x129C0)] public RaptureHotbarModule* RaptureHotbarModulePtr;
    [FieldOffset(0x129C8)] public RaptureAtkUnitManager RaptureAtkUnitManager;
    [FieldOffset(0x1C6E0)] public RaptureAtkColorDataManager RaptureAtkColorDataManager;

    [FieldOffset(0x1C960)] public int NameplateInfoCount;
    [FieldOffset(0x1C968), FixedSizeArray] internal FixedSizeArray50<NamePlateInfo> _namePlateInfoEntries;

    [FieldOffset(0x23DE0), FixedSizeArray] internal FixedSizeArray18<CrystalCache> _crystalItemCache;
    [FieldOffset(0x24890)] public ItemCache* KeyItemCache; // ptr to 120 entries
    [FieldOffset(0x24898)] public ItemCache* EquippedItemCache; // ptr to 14 entries
    [FieldOffset(0x248A0), FixedSizeArray] internal FixedSizeArray160<ItemCache> _inventoryItemCache; // only 140 slots are processed, unused?
    [FieldOffset(0x29DA0)] public uint InventoryItemCacheSlotCount;
    [FieldOffset(0x29DA4)] public uint GilCap;

    [FieldOffset(0x29DE8)] public uint LocalPlayerClassJobId;
    [FieldOffset(0x29DEC)] public uint LocalPlayerLevel;

    [FieldOffset(0x29DF5)] public bool QuickGatheringEnabled;

    [FieldOffset(0x29E60)] internal ExcelSheet* AddonParamSheet;
    [FieldOffset(0x29E68)] public AtkTexture CharaViewDefaultBackgroundTexture; // "ui/common/CharacterBg.tex" (or _hr1 variant)

    [FieldOffset(0x29E84)] public uint LoginSummonCompanionId;
    [FieldOffset(0x29E88)] public float LoginSummonCompanionCountdown;
    /// <remarks> Only for Region 5 </remarks>
    [FieldOffset(0x29E8C)] public float HourTimer;
    /// <remarks> Only for Region 5 </remarks>
    [FieldOffset(0x29E90)] public int HoursPlayed;

    [FieldOffset(0x29EA8)] internal nint ShellCommands; // only 1 function to open links?

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 0F BF 81 ?? ?? ?? ?? 8B FA")]
    public partial bool ChangeUiMode(uint uiMode);

    [MemberFunction("E8 ?? ?? ?? ?? 0F BE 4E 30")]
    public partial bool IncRefNumberArrayData(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 44 89 76 30")]
    public partial bool DecRefNumberArrayData(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F ?? 44 88 77")]
    public partial bool IncRefStringArrayData(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 6B 28")]
    public partial bool DecRefStringArrayData(int index);

    [MemberFunction("4C 89 4C 24 ?? 44 89 44 24 ?? 53 55 56 57 41 57")]
    public partial ushort OpenAddon(uint addonNameId, uint valueCount, AtkValue* values, AtkModuleInterface.AtkEventInterface* eventInterface, ulong eventKind, ushort parentAddonId, int depthLayer);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 40 4C 8B F2 41 8B E9"), GenerateStringOverloads]
    public partial ushort OpenAddonByAgent(CStringPointer addonName, AtkUnitBase* addon, int valueCount, AtkValue* values, AgentInterface* agent, ulong eventKind, ushort parentAddonId);

    [MemberFunction("48 85 D2 0F 84 ?? ?? ?? ?? 4C 8B DC 49 89 6B ?? 56"), GenerateStringOverloads]
    public partial void ShowTextGimmickHint(CStringPointer text, TextGimmickHintStyle style, int duration);

    [MemberFunction("40 56 41 56 41 57 48 81 EC A0 00 00 00")]
    public partial byte IsDawnSupported(uint contentFinderCondition); // return & 1 = dawnstory, & 2 = dawn

    [MemberFunction("E8 ?? ?? ?? ?? C6 46 ?? 00 E9 ?? ?? ?? ?? 49 8B 46")]
    public partial void OpenDawn(uint contentFinderCondition);

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 45 33 C9 49 8D 56 ?? 41 B0 01")]
    public partial void OpenDawnStory(uint contentFinderCondition);

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 9B ?? ?? ?? ?? 48 8B CE")]
    public partial void OpenSatisfactionSupply(nint a2, uint satisfactionNPC, bool a4);

    /// <remarks>
    /// 0 = success <br/>
    /// -1 = fail
    /// </remarks>
    [MemberFunction("40 53 55 57 41 56 48 81 EC ?? ?? ?? ?? 48 8B 84 24")]
    public partial int UpdateBattleCharaNameplates(NamePlateInfo* namePlateInfo, NumberArrayData* numArray, StringArrayData* stringArray, BattleChara* battleChara, int numArrayIndex, int stringArrayIndex);

    /// <remarks>
    /// 0 = success <br/>
    /// -1 = fail
    /// </remarks>
    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 4C 89 44 24 ?? 57 41 54 41 55 41 56 41 57 48 83 EC 20 48 8B 7C 24")]
    public partial int UpdateNpcNameplates(NamePlateInfo* namePlateInfo, NumberArrayData* numArray, StringArrayData* stringArray, GameObject* gameObject, int numArrayIndex, int stringArrayIndex);

    public void OpenSatisfactionSupply(uint satisfactionNPC) => OpenSatisfactionSupply(nint.Zero, satisfactionNPC, true);

    [VirtualFunction(39)]
    public partial void SetUiVisibility(bool uiVisible);

    [VirtualFunction(58)]
    public partial void Update(float delta);

    [VirtualFunction(63), GenerateStringOverloads]
    public partial bool OpenMapWithMapLink(CStringPointer mapLink);

    // CallbackHandlerFunctions[24]
    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 55 41 56 41 57 48 8B EC 48 83 EC 40 4C 8B F1")]
    public partial AtkValue* HandleItemMove(AtkValue* returnValue, AtkValue* values, uint valueCount);

    public bool IsUiVisible {
        get => !RaptureAtkUnitManager.AtkUnitManager.Flags.HasFlag(AtkUnitManagerFlags.UiHidden);
        set => SetUiVisibility(value);
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x250)]
    public struct NamePlateInfo {
        [FieldOffset(0x00)] public GameObjectId ObjectId;
        [FieldOffset(0x20)] public uint Level;
        [FieldOffset(0x24)] public uint ClassJobId;
        [FieldOffset(0x2C)] public uint Icon;
        [FieldOffset(0x30)] public Utf8String Name;
        [FieldOffset(0xA0)] public Utf8String FcName;
        [FieldOffset(0x108)] public Utf8String Title;
        [FieldOffset(0x170)] public Utf8String DisplayTitle;
        [FieldOffset(0x1D8)] public Utf8String LevelText;
        [FieldOffset(0x248)] public int Flags;
        [FieldOffset(0x24C)] public bool IsPrefix;
        [FieldOffset(0x24D)] public bool IsDirty;

        public bool IsPrefixTitle => IsPrefix;
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
    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public partial struct InventoryCache;

    // Client::UI::RaptureAtkModule::CrystalCache
    [GenerateInterop, Inherits<ItemCache>]
    [StructLayout(LayoutKind.Explicit, Size = 0x98)]
    public partial struct CrystalCache;

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct AddonFactoryInfo {
        // Create(RaptureAtkModule* thisPtr, byte* addonName, uint numValues, AtkValue* values)
        [FieldOffset(0)] public delegate* unmanaged<RaptureAtkModule*, byte*, uint, AtkValue*, nint> Create;
    }

    [Flags]
    public enum AgentUpdateFlags : byte {
        None = 0,

        /// <remarks> Set when an inventory has been updated. </remarks>
        InventoryUpdate = 1 << 0,

        /// <remarks> Set when a hotbar slot has been executed, or a Gearset or Macro has been changed. </remarks>
        ActionBarUpdate = 1 << 1,

        /// <remarks> Set when the RetainerMarket inventory has been updated. </remarks>
        RetainerMarketInventoryUpdate = 1 << 2,
        [Obsolete("Renamed to RetainerMarketInventoryUpdate")] RetainerUpdate = 1 << 2,

        /// <remarks> Unknown use case. </remarks>
        NameplateUpdate = 1 << 3,

        /// <remarks> Set when the player unlocked collectibles, contents or systems. </remarks>
        UnlocksUpdate = 1 << 4,

        /// <remarks> Set when <see cref="AgentHUD.SetMainCommandEnabledState"/> was called. </remarks>
        MainCommandEnabledStateUpdate = 1 << 5,

        /// <remarks> Set when any housing inventory has been updated. </remarks>
        HousingInventoryUpdate = 1 << 6,

        /// <remarks> Set when any content inventory has been updated. </remarks>
        ContentInventoryUpdate = 1 << 7,
    }

    public enum TextGimmickHintStyle : byte {
        Warning = 0,
        Info = 1,
    }
}

public enum GameUIScene : ushort {
    LobbyMain = 0,
    GameMain = 1,
}

public enum GameUIMode : ushort {
    Normal = 0,
    ChocoboRace = 1,
    Lovm = 2, // Lord of Verminion
    PvPSpectator = 3,
    ContentsReplay = 4,
    Emj = 5, // Doman Mahjong
    EmjSolo = 6,
    RideShooting = 7,
    TripleTriad = 8,
}
