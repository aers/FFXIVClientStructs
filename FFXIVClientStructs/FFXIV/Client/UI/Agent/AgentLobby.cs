using FFXIVClientStructs.FFXIV.Application.Network;
using FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;
using FFXIVClientStructs.FFXIV.Client.Network;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentLobby
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
// ctor "E8 ?? ?? ?? ?? EB 03 48 8B C5 45 33 C9 48 89 47 20"
[Agent(AgentId.Lobby)]
[GenerateInterop]
[Inherits<AgentInterface>, Inherits<LogoutCallbackInterface>(0x30)]
[StructLayout(LayoutKind.Explicit, Size = 0x1E68)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 69 ?? 48 89 01 4C 8B E1", 3)]
public unsafe partial struct AgentLobby {
    [FieldOffset(0x40)] public LobbyData LobbyData; // for lack of a better name

    [FieldOffset(0xA20)] public ExcelSheet* ErrorSheet;
    [FieldOffset(0xA28)] public ExcelSheet* LobbySheet;
    [FieldOffset(0xA30)] public NetworkModuleProxy* NetworkModuleProxy;
    [FieldOffset(0xA38)] public StdDeque<TextParameter> LobbyTextParameters;
    [FieldOffset(0xA60), FixedSizeArray] internal FixedSizeArray4<Utf8String> _tempUtf8Strings;
    [FieldOffset(0xC00)] public StdVector<Utf8String> VersionStrings;
    [FieldOffset(0xC18)] public Utf8String DisplayedVersionString;

    [FieldOffset(0xC98), FixedSizeArray] internal FixedSizeArray8<Utf8String> _unkUtf8Strings;

    [FieldOffset(0x1110)] public sbyte ServiceAccountIndex;

    [FieldOffset(0x1118)] public ulong HoveredCharacterContentId;
    [FieldOffset(0x1120)] public byte DataCenter;

    [FieldOffset(0x1122)] public short WorldIndex; // index in CurrentDataCenterWorlds
    [FieldOffset(0x1124)] public ushort WorldId;

    [FieldOffset(0x1128)] public uint DialogAddonId;
    [FieldOffset(0x112C)] public uint DialogAddonId2;
    [FieldOffset(0x1130)] public uint LobbyScreenTextAddonId;
    [FieldOffset(0x1134)] public uint LogoAddonId;
    [FieldOffset(0x1138)] public uint TitleDCWorldMapAddonId;
    [FieldOffset(0x113C)] public uint TitleMovieSelectorAddonId;
    [FieldOffset(0x1140)] public uint TitleGameVersionAddonId;
    [FieldOffset(0x1144)] public uint TitleConnectAddonId;
    [FieldOffset(0x1148)] public uint CharaSelectAddonId;
    [FieldOffset(0x114C)] public uint CharaMakeDataImportAddonId;
    [FieldOffset(0x1150)] public uint LoadPreviouslySavedAppearanceDataDialogAddonId; // SelectYesno
    [FieldOffset(0x1154)] public uint LoadSavedCharacterCreationDataDialogAddonId; // SelectYesno
    [FieldOffset(0x1158)] public uint CreateNewCharacterDialogAddonId; // SelectYesno
    [FieldOffset(0x115C)] public uint LobbyWKTAddonId;

    [FieldOffset(0x1164)] public byte LobbyUpdateStage;

    [FieldOffset(0x1167)] public byte LobbyUIStage;

    [FieldOffset(0x1170)] public long IdleTime;

    [FieldOffset(0x1190)] public int QueuePosition;

    [FieldOffset(0x1195)] public sbyte HoveredCharacterIndex; // index in CharaSelectCharacterList

    [FieldOffset(0x1198)] public ulong SelectedCharacterContentId;

    [FieldOffset(0x11A0)] public bool IsLoggedIn; // set in ProcessPacketPlayerSetup, unset in LogoutCallbackInterface_OnLogout
    [FieldOffset(0x11A1)] public bool IsLoggedIntoZone; // set in ZoneLoginCallbackInterface_OnZoneLogin

    [FieldOffset(0x11A3)] public bool LogoutShouldCloseGame;

    [FieldOffset(0x12A0)] public bool TemporaryLocked; // "Please wait and try logging in later."

    [FieldOffset(0x12B8)] public ulong RequestContentId;

    [FieldOffset(0x1E14)] public bool HasShownCharacterNotFound; // "The character you last logged out with in this play environment could not be found on the current data center."

    [FieldOffset(0x12D8)] public LogoutCallbackInterface.LogoutParams LogoutParams;

    // TODO: everything below here is wrong

    // title movie stuff is seemingly no longer part of AgentLobby
    [FieldOffset(0xA30), Obsolete("Not updated. Expect invalid data.")] public uint AccountExpansion;
    [FieldOffset(0xA34), Obsolete("Not updated. Expect invalid data.")] public bool ShowFreeTrialLogo;
    [FieldOffset(0xA38), Obsolete("Not updated. Expect invalid data.")] public uint TitleScreenExpansion;
    [FieldOffset(0xA3C), Obsolete("Not updated. Expect invalid data.")] public bool ShowOriginalLogo; // pre-relaunch

    [FieldOffset(0x1248), Obsolete("Not updated. Expect invalid data.")] public byte RequestCharaterIndex;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 8E ?? ?? ?? ?? 41 8B D5")]
    public partial void UpdateLobbyUIStage();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 07 C6 86 ?? ?? ?? ?? ?? 48 8B 8C 24")]
    public partial void UpdateCharaSelectDisplay(sbyte index, bool a2);

    [MemberFunction("E8 ?? ?? ?? ?? C6 87 ?? ?? ?? ?? ?? 66 C7 87 ?? ?? ?? ?? ?? ??")]
    public partial void OpenLoginWaitDialog(int position);

    [MemberFunction("40 56 41 56 41 57 48 83 EC 40 80 B9")]
    public partial void HandleLogout(bool isExiting, byte a3); // a3 is some kind of frame-based countdown for the lobby
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x9E0)]
public unsafe partial struct LobbyData {
    [FieldOffset(0)] public AgentLobby* AgentLobby;
    [FieldOffset(0x8)] public LobbyUIClient LobbyUIClient;

    [FieldOffset(0x878)] public StdVector<Pointer<CharaSelectCharacterEntry>> CharaSelectEntries;

    [FieldOffset(0x898)] public ulong ContentId;
    [FieldOffset(0x8A0)] public Utf8String HomeWorldName;
    [FieldOffset(0x908)] public Utf8String HomeWorldName2;
    [FieldOffset(0x970)] public Utf8String CurrentWorldName;

    [FieldOffset(0x9DC)] public ushort CurrentWorldId;
    [FieldOffset(0x9DE)] public ushort HomeWorldId;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 19 C6 87 ?? ?? ?? ?? ??")]
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

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 56 48 8B CB")]
    public partial bool IsInDifferentRegion();
}

// see "E8 ?? ?? ?? ?? 44 0F B6 43 ?? 8D 57 7E"
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
