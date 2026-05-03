using FFXIVClientStructs.FFXIV.Application.Network;
using FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;
using FFXIVClientStructs.FFXIV.Client.Network;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.GUI;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentLobby
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
//   Component::GUI::AtkMessageBoxManager::AtkMessageBoxEvent
//   Application::Network::LogoutCallbackInterface
//   Application::Network::ZoneLoginCallbackInterface
[Agent(AgentId.Lobby)]
[GenerateInterop]
[Inherits<AgentInterface>, Inherits<AtkMessageBoxManager.AtkMessageBoxEvent>, Inherits<LogoutCallbackInterface>, Inherits<ZoneLoginCallbackInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x2370)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? C6 41 ?? ?? 48 89 01 33 ED", 3)]
public unsafe partial struct AgentLobby {
    [FieldOffset(0x40)] public LobbyData LobbyData; // for lack of a better name

    [FieldOffset(0xA80)] public ExcelSheet* ErrorSheet;
    [FieldOffset(0xA88)] public ExcelSheet* LobbySheet;
    [FieldOffset(0xA90)] public NetworkModuleProxy* NetworkModuleProxy;
    [FieldOffset(0xA98)] public StdDeque<TextParameter> LobbyTextParameters;
    [FieldOffset(0xAC0), FixedSizeArray] internal FixedSizeArray4<Utf8String> _tempUtf8Strings;
    [FieldOffset(0xC60)] public Utf8String ConnectingToDatacenterString;
    [FieldOffset(0xCC8)] public StdVector<Utf8String> VersionStrings;
    [FieldOffset(0xCE0)] public Utf8String DisplayedVersionString;

    [FieldOffset(0xD60), FixedSizeArray] internal FixedSizeArray8<Utf8String> _unkUtf8Strings;

    [FieldOffset(0x11D8)] public sbyte ServiceAccountIndex;
    [FieldOffset(0x11D9)] public byte SelectedCharacterIndex;

    [FieldOffset(0x11E0)] public ulong HoveredCharacterContentId;
    [FieldOffset(0x11E8)] public byte DataCenter;

    [FieldOffset(0x11EA)] public short WorldIndex; // index in CurrentDataCenterWorlds
    [FieldOffset(0x11EC)] public ushort WorldId;

    [FieldOffset(0x11F0)] public uint DialogAddonId;
    [FieldOffset(0x11F4)] public uint DialogAddonId2;
    [FieldOffset(0x11F8)] public uint LobbyScreenTextAddonId;
    [FieldOffset(0x11FC)] public uint LogoAddonId;
    [FieldOffset(0x1200)] public uint TitleDCWorldMapAddonId;
    [FieldOffset(0x1204)] public uint TitleMovieSelectorAddonId;
    [FieldOffset(0x1208)] public uint TitleGameVersionAddonId;
    [FieldOffset(0x120C)] public uint TitleConnectAddonId;
    [FieldOffset(0x1210)] public uint CharaSelectAddonId;
    [FieldOffset(0x1214)] public uint CharaMakeDataImportAddonId;
    [FieldOffset(0x1218)] public uint LoadPreviouslySavedAppearanceDataDialogAddonId; // SelectYesno
    [FieldOffset(0x121C)] public uint LoadSavedCharacterCreationDataDialogAddonId; // SelectYesno
    [FieldOffset(0x1220)] public uint CreateNewCharacterDialogAddonId; // SelectYesno
    [FieldOffset(0x1224)] public uint LobbyWKTAddonId;

    [FieldOffset(0x1234)] public byte LobbyUpdateStage;

    [FieldOffset(0x1237)] public byte LobbyUIStage;

    [FieldOffset(0x1240)] public long IdleTime;

    [FieldOffset(0x1250)] public long QueueTimeSinceLastUpdate;
    [FieldOffset(0x1260)] public int QueuePosition;

    [FieldOffset(0x1265)] public sbyte HoveredCharacterIndex; // index in CharaSelectCharacterList

    [FieldOffset(0x1268)] public ulong SelectedCharacterContentId;

    [FieldOffset(0x1270)] public bool IsLoggedIn; // set in ProcessPacketPlayerSetup, unset in LogoutCallbackInterface_OnLogout
    [FieldOffset(0x1271)] public bool IsLoggedIntoZone; // set in ZoneLoginCallbackInterface_OnZoneLogin (+0x38)

    [FieldOffset(0x1273)] public bool LogoutShouldCloseGame;

    [FieldOffset(0x1370)] public bool TemporaryLocked; // "Please wait and try logging in later."

    [FieldOffset(0x1388)] public ulong RequestContentId;

    [FieldOffset(0x13A8)] public LogoutCallbackInterface.LogoutParams LogoutParams;

    [FieldOffset(0x2314)] public bool HasShownCharacterNotFound; // "The character you last logged out with in this play environment could not be found on the current data center."

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 8E ?? ?? ?? ?? 41 8B D5")]
    public partial void UpdateLobbyUIStage();

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 83 FB ?? 0F 8E ?? ?? ?? ?? 48 8D 4F")]
    public partial bool UpdateCharaSelectDisplay(sbyte index, bool a2);

    [MemberFunction("E8 ?? ?? ?? ?? C6 87 ?? ?? ?? ?? ?? 66 C7 87")]
    public partial void OpenLoginWaitDialog(int position);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4E 10 48 8B 01 FF 50 40 4C 8B BC 24")]
    public partial bool SendLoginRequestPacket(int characterEntryIdx);

    [MemberFunction("40 53 56 57 41 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 8B 99")]
    public partial void UpdateLoginPosition(int newPosition);

    [MemberFunction("40 56 41 56 41 57 48 83 EC 40 80 B9")]
    public partial void HandleLogout(bool isExiting, byte a3); // a3 is some kind of frame-based countdown for the lobby
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xA40)]
public unsafe partial struct LobbyData {
    [FieldOffset(0)] public AgentLobby* AgentLobby;
    [FieldOffset(0x8)] public LobbyUIClient LobbyUIClient;

    [FieldOffset(0x8D8)] public StdVector<Pointer<CharaSelectCharacterEntry>> CharaSelectEntries;

    [FieldOffset(0x8F8)] public ulong ContentId;
    [FieldOffset(0x900)] public Utf8String HomeWorldName;
    [FieldOffset(0x968)] public Utf8String HomeWorldName2;
    [FieldOffset(0x9D0)] public Utf8String CurrentWorldName;

    [FieldOffset(0xA3C)] public ushort CurrentWorldId;
    [FieldOffset(0xA3E)] public ushort HomeWorldId;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? C6 87 ?? ?? ?? ?? ?? B0 ?? 48 8B 5C 24")]
    public partial CharaSelectCharacterEntry* GetCharacterEntryFromServer(byte index, ulong contentId);

    [MemberFunction("40 53 48 83 EC 20 49 63 D9 E8 ?? ?? ?? ??")]
    public partial CharaSelectCharacterEntry* GetCharacterEntryByIndex(int a2, int worldIndex, int characterMappingIndex);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x6F8)]
public unsafe partial struct CharaSelectCharacterEntry {
    [FieldOffset(0x8)] public ulong ContentId;
    [FieldOffset(0x10)] public byte Index;
    [FieldOffset(0x11)] public CharaSelectCharacterEntryLoginFlags LoginFlags;

    [FieldOffset(0x18)] public ushort CurrentWorldId;
    [FieldOffset(0x1A)] public ushort HomeWorldId;

    [FieldOffset(0x2C), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;
    [FieldOffset(0x4C), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _currentWorldName;
    [FieldOffset(0x6C), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _homeWorldName;
    [FieldOffset(0x8C), FixedSizeArray(isString: true)] internal FixedSizeArray1024<byte> _rawJson;

    [FieldOffset(0x4A0)] public StdVector<Pointer<CharaSelectRetainerInfo>> RetainerInfo;

    [FieldOffset(0x4C0)] public ClientSelectData ClientSelectData;

    [MemberFunction("0F B6 41 ?? 84 05 ?? ?? ?? ?? 0F 94 C0")]
    public partial bool IsNotLocked();

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 74 24 ?? 84 C0 75 ?? 48 8B CE")]
    public partial bool IsInDifferentRegion();
}

public enum CharaSelectCharacterEntryLoginFlags : byte {
    None = 0,
    Locked = 1, // Lobby#64: "You cannot select this character with your current account."
    NameChangeRequired = 2, // Lobby#26: "A name change is required to log in with this character."
    MissingExVersionForLogin = 4, // Lobby#68: "To log in with this character you must first install <ExVersion>."
    MissingExVersionForCharacterEdit = 8, // Lobby#69: "To edit this character's race, sex, or appearance you must first install <ExVersion>."
    DCTraveling = 16,// Lobby#1175: "This character is currently visiting the <value> data center."
    Unk32 = 32, // unsure. sidebar should change to Lobby#1153 "TRAVELED TO" and might print LogMessage#5800 "Unable to execute command. Character is currently visiting the <string(lstr1)> data center."
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct CharaSelectRetainerInfo {
    [FieldOffset(0)] public ulong RetainerId;
    [FieldOffset(0x8)] public ulong OwnerContentId;
    [FieldOffset(0x10)] public ushort Index; // guessed
    [FieldOffset(0x12)] public CharaSelectRetainerInfoLoginFlags LoginFlags;

    [FieldOffset(0x18), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;
}

public enum CharaSelectRetainerInfoLoginFlags : ushort {
    None = 0,

    NameChangeRequired = 4 // Lobby#66: "Please change your retainer's name after retrieving your character's data./To log in with this character you must first change your retainer's name."
}
