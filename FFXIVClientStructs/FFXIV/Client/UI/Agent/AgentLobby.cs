using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Network;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.GUI;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// ctor "E8 ?? ?? ?? ?? EB 03 48 8B C5 45 33 C9 48 89 47 20"
[Agent(AgentId.Lobby)]
[VTableAddress("48 8D 05 ?? ?? ?? ?? 48 89 71 18 48 89 01", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x1DF8)]
public unsafe partial struct AgentLobby {
    [FieldOffset(0)] public AgentInterface AgentInterface;

    [FieldOffset(0x40)] public LobbyData LobbyData; // for lack of a better name
    [FieldOffset(0xA00)] public UIModule* UIModule;
    [FieldOffset(0xA08)] internal nint TitleScreenMoviePtr;

    [FieldOffset(0xA30)] public uint AccountExpansion;
    [FieldOffset(0xA34)] public bool ShowFreeTrialLogo;

    [FieldOffset(0xA38)] public uint TitleScreenExpansion;
    [FieldOffset(0xA3C)] public bool ShowOriginalLogo; // pre-relaunch

    [FieldOffset(0xA40)] public ExcelSheet* ErrorSheet;
    [FieldOffset(0xA48)] public ExcelSheet* LobbySheet;
    [FieldOffset(0xA50)] public NetworkModuleProxy* NetworkModuleProxy;
    [FieldOffset(0xA58)] public StdDeque<TextParameter> LobbyTextParameters;
    [FixedSizeArray<Utf8String>(13)]
    [FieldOffset(0xA80)] public fixed byte Utf8StringsData[0x68 * 13];

    [FieldOffset(0x10E0)] public sbyte ServiceAccountIndex;
    [Obsolete("Renamed to HoveredCharacterIndex")]
    [FieldOffset(0x10E1)] public sbyte SelectedCharacterIndex;
    [FieldOffset(0x10E1)] public sbyte HoveredCharacterIndex; // index in CharaSelectCharacterList
    [FieldOffset(0x10E8)] public ulong HoveredCharacterContentId;
    [FieldOffset(0x10F0)] public byte DataCenter;

    [FieldOffset(0x10F2)] public short WorldIndex; // index in CurrentDataCenterWorlds
    [FieldOffset(0x10F4)] public ushort WorldId;

    [FieldOffset(0x10F8)] public uint DialogAddonId;
    [FieldOffset(0x10FC)] public uint DialogAddonId2;
    [FieldOffset(0x1100)] public uint LobbyScreenTextAddonId;

    [Obsolete("Invalid type: this field is a byte, not a bool. Use LobbyUpdateStage.")] // used for a switch in AgentLobby_Update
    [FieldOffset(0x1104)] public bool RequestedDataReady;
    [FieldOffset(0x1104)] public byte LobbyUpdateStage;

    [FieldOffset(0x1107)] public byte LobbyUIStage;

    [FieldOffset(0x1110)] public uint IdleTime;

    [FieldOffset(0x1138)] public ulong SelectedCharacterContentId;
    [FieldOffset(0x1140)] public bool IsLoggedIn;

    [FieldOffset(0x1228)] public bool TemporaryLocked; // "Please wait and try logging in later."

    [FieldOffset(0x1240)] public long RequestContentId;
    [FieldOffset(0x1248)] public byte RequestCharaterIndex;
    [FieldOffset(0x1DA4)] public bool HasShownCharacterNotFound; // "The character you last logged out with in this play environment could not be found on the current data center."

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 41 8B D6")]
    public readonly partial void UpdateLobbyUIStage();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 07 C6 86 ?? ?? ?? ?? ?? 48 8B 8C 24")]
    public readonly partial void UpdateCharaSelectDisplay(sbyte index, bool a2);

    [MemberFunction("E8 ?? ?? ?? ?? EB 4A 84 C0")]
    public readonly partial void OpenLoginWaitDialog(int position);
}

[StructLayout(LayoutKind.Explicit, Size = 0x9C0)]
public unsafe partial struct LobbyData {
    [FieldOffset(0)] public AgentLobby* AgentLobby;
    [FieldOffset(0x8)] public LobbyUIClient LobbyUIClient;

    [FieldOffset(0x858)] public StdVector<Pointer<CharaSelectCharacterEntry>> CharaSelectEntries;

    [FieldOffset(0x878)] public ulong ContentId;
    [FieldOffset(0x880)] public Utf8String HomeWorldName;
    [FieldOffset(0x8E8)] public Utf8String HomeWorldName2;
    [FieldOffset(0x950)] public Utf8String CurrentWorldName;

    [FieldOffset(0x9BC)] public ushort CurrentWorldId;
    [FieldOffset(0x9BE)] public ushort HomeWorldId;

    [MemberFunction("40 53 56 41 57 48 83 EC 20 33 DB")]
    public partial CharaSelectCharacterEntry* GetCharacterEntryFromServer(byte index, long contentId);

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 2C 48 8D 48 2C")]
    public partial CharaSelectCharacterEntry* GetCharacterEntryByIndex(int a2, int worldIndex, int characterMappingIndex);
}

[VTableAddress("48 8D 05 ?? ?? ?? ?? 48 8B F9 48 89 01 48 81 C1 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8F", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x848)]
public unsafe partial struct LobbyUIClient {
    [FieldOffset(0x00), Obsolete("Use LobbyUIClient.StaticAddressPointers.VTable")] public void** vtbl;
    [FieldOffset(0x10)] public NetworkModuleProxy* NetworkModuleProxy;
    //[FieldOffset(0x18)] public ?* NetworConfig; // contains hosts and ports

    [FieldOffset(0x30)] public StdVector<LobbyDataCenterWorldEntry> CurrentDataCenterWorlds;

    [FieldOffset(0x48)] public LobbySubscriptionInfo* SubscriptionInfo;
}

[StructLayout(LayoutKind.Explicit, Size = 0x54)]
public unsafe struct LobbyDataCenterWorldEntry {
    [FieldOffset(0)] public ushort Id; // RowId in World sheet
    [FieldOffset(0x2)] public ushort Index;

    [FieldOffset(0x14)] public fixed byte Name[32]; // size unknown
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)] // size unknown
public unsafe struct LobbySubscriptionInfo // name probably totally wrong
{
    [FieldOffset(0x8)] public uint Flags;

    [FieldOffset(0x2D)] public byte VeteranRewardRank;

    [FieldOffset(0x30)] public uint TotalDaysSubscribed;
    [FieldOffset(0x34)] public uint DaysRemaining;
    [FieldOffset(0x38)] public uint DaysUntilNextVeteranRank;
}

[StructLayout(LayoutKind.Explicit, Size = 0x6F8)]
public unsafe partial struct CharaSelectCharacterEntry {
    [FieldOffset(0x8)] public ulong ContentId;
    [FieldOffset(0x10)] public byte Index;
    [FieldOffset(0x11)] public CharaSelectCharacterEntryLoginFlags LoginFlags;

    [FieldOffset(0x18)] public ushort CurrentWorldId;
    [FieldOffset(0x1A)] public ushort HomeWorldId;

    [FieldOffset(0x2C)] public fixed byte Name[32];
    [FieldOffset(0x4C)] public fixed byte CurrentWorldName[32];
    [FieldOffset(0x6C)] public fixed byte HomeWorldName[32];
    [FieldOffset(0x8C)] public fixed byte RawJson[1024];

    [FieldOffset(0x4A0)] public StdVector<Pointer<CharaSelectRetainerInfo>> RetainerInfo;

    [FieldOffset(0x4C0)] public CharaSelectCharacterInfo CharacterInfo; // x2?

    [MemberFunction("0F B6 41 ?? 84 05 ?? ?? ?? ?? 0F 94 C0")]
    public partial bool IsNotLocked();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 0F 48 8B CB")]
    public partial bool IsInDifferentRegion();
}

// see "E8 ?? ?? ?? ?? 44 0F B6 43 ?? 8D 57 7E"
public enum CharaSelectCharacterEntryLoginFlags : byte {
    None = 0,
    Locked = 1, // Lobby#64: "You cannot select this character with your current account."
    NameChangeRequired = 2, // Lobby#26: "A name change is required to log in with this character."
    [Obsolete("Renamed to MissingExVersionForLogin")]
    ExpansionMissing = 4,
    MissingExVersionForLogin = 4, // Lobby#68: "To log in with this character you must first install <ExVersion>."
    MissingExVersionForCharacterEdit = 8, // Lobby#69: "To edit this character's race, sex, or appearance you must first install <ExVersion>."
    DCTraveling = 16,// Lobby#1175: "This character is currently visiting the <value> data center."
    Unk32 = 32, // unsure. sidebar should change to Lobby#1153 "TRAVELED TO" and might print LogMessage#5800 "Unable to execute command. Character is currently visiting the <string(lstr1)> data center."
}

[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe struct CharaSelectRetainerInfo {
    [FieldOffset(0)] public ulong RetainerId;
    [FieldOffset(0x8)] public ulong OwnerContentId;
    [FieldOffset(0x10)] public ushort Index; // guessed
    [FieldOffset(0x12)] public CharaSelectRetainerInfoLoginFlags LoginFlags;

    [FieldOffset(0x18)] public fixed byte Name[32];
}

public enum CharaSelectRetainerInfoLoginFlags : ushort {
    None = 0,

    NameChangeRequired = 4 // Lobby#66: "Please change your retainer's name after retrieving your character's data./To log in with this character you must first change your retainer's name."
}

[StructLayout(LayoutKind.Explicit, Size = 0x1E2)]
public unsafe struct CharaSelectCharacterInfo {
    [FieldOffset(0x8)] public fixed byte Name[32];
    [FieldOffset(0x28)] public byte CurrentClassJobId;

    [FieldOffset(0x2A)] public fixed ushort ClassJobLevelArray[30];
    [FieldOffset(0x66)] public byte Race;
    [FieldOffset(0x67)] public byte Tribe;
    [FieldOffset(0x68)] public byte Sex;
    [FieldOffset(0x69)] public byte BirthMonth;
    [FieldOffset(0x6A)] public byte BirthDay;
    [FieldOffset(0x6B)] public byte GuardianDeity;
    [FieldOffset(0x6C)] public byte FirstClass;

    // [FieldOffset(0x6E)] public ushort ZoneId;
    [FieldOffset(0x70)] public ushort TerritoryType;
    [FieldOffset(0x72)] public ushort ContentFinderCondition;
    [FieldOffset(0x74)] public CustomizeData CustomizeData;

    [FieldOffset(0x90)] public WeaponModelId MainHandModel;
    [FieldOffset(0x98)] public WeaponModelId OffHandModel;
    [FieldOffset(0xA0)] public EquipmentModelId Head;
    [FieldOffset(0xA4)] public EquipmentModelId Body;
    [FieldOffset(0xA8)] public EquipmentModelId Hands;
    [FieldOffset(0xAC)] public EquipmentModelId Legs;
    [FieldOffset(0xB0)] public EquipmentModelId Feet;
    [FieldOffset(0xB4)] public EquipmentModelId Ears;
    [FieldOffset(0xB8)] public EquipmentModelId Neck;
    [FieldOffset(0xBC)] public EquipmentModelId Wrists;
    [FieldOffset(0xC0)] public EquipmentModelId RingRight;
    [FieldOffset(0xC4)] public EquipmentModelId RingLeft;
    [FieldOffset(0xC8)] public uint MainHandItemId;
    [FieldOffset(0xCC)] public uint OffHandItemId;
    [FieldOffset(0xD0)] public uint SoulstoneItemId;
    // [FieldOffset(0xD4)] public uint RemakeFlag;
    [FieldOffset(0xD8)] public CharaSelectCharacterConfigFlags ConfigFlags;
    [FieldOffset(0xDA)] public byte VoiceId;
    // [FieldOffset(0xDB)] public fixed byte WorldName[32]; // always empty?

    // [FieldOffset(0x100)] public ulong LoginStatus;
    // [FieldOffset(0x108)] public byte IsOutTerritory;
}

[Flags]
public enum CharaSelectCharacterConfigFlags : ushort {
    None = 0,
    HideHead = 0x01,
    HideWeapon = 0x02,
    HideLegacyMark = 0x04,
    // ? = 0x08,
    StoreNewItemsInArmouryChest = 0x10,
    StoreCraftedItemsInInventory = 0x20,
    CloseVisor = 0x40
    // ? = 0x80
}

[StructLayout(LayoutKind.Explicit, Size = 40 * 0x10)]
public unsafe partial struct CharaSelectCharacterList {
    [StaticAddress("4C 8D 3D ?? ?? ?? ?? 48 8B DA", 3)]
    public static partial CharaSelectCharacterList* Instance();

    [StaticAddress("48 89 2D ?? ?? ?? ?? 48 8B 6C 24", 3, true)]
    public static partial Character* GetCurrentCharacter();

    [MemberFunction("E8 ?? ?? ?? ?? 66 44 89 B6")]
    public static partial void CleanupCharacters();

    [FixedSizeArray<CharaSelectCharacterMapping>(40)]
    [FieldOffset(0)] public fixed byte CharacterMapping[40 * 0x10];
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct CharaSelectCharacterMapping {
    [FieldOffset(0)] public ulong ContentId;
    [FieldOffset(8)] public short ClientObjectIndex; // index in ClientObjectManager
}
