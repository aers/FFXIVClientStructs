using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// ctor "E8 ?? ?? ?? ?? EB 03 48 8B C5 45 33 C9 48 89 47 20"
[Agent(AgentId.Lobby)]
[VTableAddress("48 8D 05 ?? ?? ?? ?? 48 89 71 18 48 89 01", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x1DD0)]
public unsafe partial struct AgentLobby {
    public static AgentLobby* Instance()
        => (AgentLobby*)AgentModule.Instance()->GetAgentByInternalId(AgentId.Lobby);

    [FieldOffset(0)] public AgentInterface AgentInterface;

    [FieldOffset(0x40)] public LobbyData LobbyData; // for lack of a better name
    [FieldOffset(0xA00)] public UIModule* UIModule;

    [FieldOffset(0xA40)] public ExcelSheet* ErrorSheet;
    [FieldOffset(0xA48)] public ExcelSheet* LobbySheet;
    //[FieldOffset(0xA50)] public NetworkModuleProxy* NetworkModuleProxy;

    [FieldOffset(0x10E0)] public sbyte ServiceAccountIndex;
    [FieldOffset(0x10E1)] public sbyte SelectedCharacterIndex; // index in CharaSelectCharacterList
    [Obsolete("Renamed to SelectedCharacterContentId", true)]
    [FieldOffset(0x10E8)] public ulong SelectedCharacterId;
    [FieldOffset(0x10E8)] public ulong SelectedCharacterContentId;
    [FieldOffset(0x10F0)] public byte DataCenter;

    [FieldOffset(0x10F2)] public short WorldIndex; // index in CurrentDataCenterWorlds
    [FieldOffset(0x10F4)] public ushort WorldId;

    [FieldOffset(0x1110)] public uint IdleTime;

    [FieldOffset(0x1228)] public bool TemporaryLocked; // "Please wait and try logging in later."

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 07 C6 87 ?? ?? ?? ?? ?? 48 8B 4C 24")]
    public readonly partial void UpdateCharaSelectDisplay(sbyte index, bool a2);

    [MemberFunction("E8 ?? ?? ?? ?? EB 4A 84 C0")]
    public readonly partial void OpenLoginWaitDialog(int position);
}

[StructLayout(LayoutKind.Explicit, Size = 0x9C0)]
public unsafe partial struct LobbyData {
    [FieldOffset(0)] public AgentLobby* AgentLobby;
    [FieldOffset(0x8)] public LobbyUIClient LobbyUIClient;

    [FieldOffset(0x858)] public StdVector<Pointer<CharaSelectCharacterEntry>> CharaSelectEntries;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 48 08 49 89 8C 24")]
    public partial CharaSelectCharacterEntry* GetCharacterEntryByIndex(int a2, int worldIndex, int characterMappingIndex);
}

[VTableAddress("48 8D 05 ?? ?? ?? ?? 48 8B F9 48 89 01 48 81 C1 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8F", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x848)]
public unsafe partial struct LobbyUIClient {
    //[FieldOffset(0x10)] public NetworkModuleProxy* NetworkModuleProxy;
    //[FieldOffset(0x18)] public ?* SomeNetworkConfig; // contains hosts and ports

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
}

[StructLayout(LayoutKind.Explicit, Size = 0x6F8)]
public unsafe struct CharaSelectCharacterEntry {
    [FieldOffset(0x8)] public ulong ContentId;

    [FieldOffset(0x11)] public CharaSelectCharacterEntryLoginFlags LoginFlags;

    [FieldOffset(0x18)] public ushort CurrentWorldId;
    [FieldOffset(0x1A)] public ushort HomeWorldId;

    [FieldOffset(0x2C)] public fixed byte Name[32];
    [FieldOffset(0x4C)] public fixed byte CurrentWorldName[32];
    [FieldOffset(0x6C)] public fixed byte HomeWorldName[32];
    [FieldOffset(0x8C)] public fixed byte RawJson[1024];

    [FieldOffset(0x4A0)] public StdVector<Pointer<CharaSelectRetainerInfo>> RetainerInfo;

    [FieldOffset(0x4C0)] public CharaSelectCharacterInfo CharacterInfo; // x2?
}

public enum CharaSelectCharacterEntryLoginFlags : byte {
    None = 0,
    Locked = 1, // Lobby#64: "You cannot select this character with your current account."
    NameChangeRequired = 2, // Lobby#26: "A name change is required to log in with this character."
    ExpansionMissing = 4, // Lobby#68: "To log in with this character you must first install <ExVersion>."

    DCTraveling = 16, // Lobby#1175: "This character is currently visiting the <value> data center."
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

    NameChangeRequired = 4, // Lobby#66: "Please change your retainer's name after retrieving your character's data./To log in with this character you must first change your retainer's name."
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
    CloseVisor = 0x40,
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
