using FFXIVClientStructs.FFXIV.Application.Network.LobbyClient;
using FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;
using FFXIVClientStructs.FFXIV.Client.Network;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::LobbyUIClient
//   Application::Network::LobbyClient::LobbyRequestCallback
[GenerateInterop]
[Inherits<LobbyRequestCallback>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? ?? ?? ?? 48 8B F9 48 89 71 ?? 48 89 71 ?? 48 89 71 ?? 48 89 71 ?? 48 89 71", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x8C8)]
public unsafe partial struct LobbyUIClient {
    [FieldOffset(0x08)] public LobbyData* LobbyData;
    [FieldOffset(0x10)] public NetworkModuleProxy* NetworkModuleProxy;
    //[FieldOffset(0x18)] public ?* NetworConfig; // contains hosts and ports

    [FieldOffset(0x30)] public StdVector<LobbyDataCenterWorldEntry> CurrentDataCenterWorlds;

    [FieldOffset(0x48)] public LobbySubscriptionInfo* SubscriptionInfo;

    [FieldOffset(0xF8)] public StdVector<LobbyUIClientCharacterEntry> CurrentDataCenterCharacters;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x54)]
public unsafe partial struct LobbyDataCenterWorldEntry {
    [FieldOffset(0)] public ushort Id; // RowId in World sheet
    [FieldOffset(0x2)] public ushort Index;

    [FieldOffset(0x14), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name; // size unknown
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)] // size unknown
public struct LobbySubscriptionInfo // name probably totally wrong
{
    [FieldOffset(0x8)] public uint Flags;

    [FieldOffset(0x2D)] public byte VeteranRewardRank;

    [FieldOffset(0x30)] public uint TotalDaysSubscribed;
    [FieldOffset(0x34)] public uint DaysRemaining;
    [FieldOffset(0x38)] public uint DaysUntilNextVeteranRank;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x758)]
public unsafe partial struct LobbyUIClientCharacterEntry {
    [FieldOffset(0x08)] public ulong ContentId;
    [FieldOffset(0x10)] public byte Index;
    [FieldOffset(0x11)] public CharaSelectCharacterEntryLoginFlags LoginFlags;

    [FieldOffset(0x18)] public ushort CurrentWorldId;
    [FieldOffset(0x1A)] public ushort HomeWorldId;

    [FieldOffset(0x2C), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;
    [FieldOffset(0x4C), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _currentWorldName;
    [FieldOffset(0x6C), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _homeWorldName;
    [FieldOffset(0x8C), FixedSizeArray(isString: true)] internal FixedSizeArray1024<byte> _rawJson;

    [FieldOffset(0x4C0)] public ClientSelectData ClientSelectData;
    [FieldOffset(0x600)] public ClientSelectData ClientSelectData2;

    [FieldOffset(0x740)] public ulong ContentIdMirror;
    [FieldOffset(0x748)] public byte Flag;
    [FieldOffset(0x74C)] private int Unk74C;
    [FieldOffset(0x750)] public byte DeletedFlag;
}
