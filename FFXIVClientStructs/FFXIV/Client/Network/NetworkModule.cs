using System.ComponentModel.DataAnnotations;
using FFXIVClientStructs.FFXIV.Application.Network;
using FFXIVClientStructs.FFXIV.Client.System.String;
using Unknown = nint;

namespace FFXIVClientStructs.FFXIV.Client.Network;

[StructLayout(LayoutKind.Explicit, Size = 0xB60)]
public unsafe partial struct NetworkModule {
    [FieldOffset(0x028)] public int LobbyCount;
    [FixedSizeArray<uint>(0xC)] [FieldOffset(0x02C)]
    public fixed byte LobbyPorts[0xC * 0x4];
    [FixedSizeArray<Utf8String>(0xC)] [FieldOffset(0x060)]
    public fixed byte LobbyHosts[0xC * 0x68];

    [FieldOffset(0x5AC)] public int OperatingSystemTypeAndVersion; //Most likely this is an enum
    [FieldOffset(0x5B0)] public uint SaveDataBankPort;
    [FieldOffset(0x5B8)] public Utf8String SaveDataBankHost; //Config Saves
    [FieldOffset(0x620)] public uint SaveDataBankMode;
    [FieldOffset(0x624)] public uint DktWebPort;
    [FieldOffset(0x628)] public Utf8String DktWebHost; //DC Travel
    [FieldOffset(0x690)] public uint ActiveLobbyPort;
    [FieldOffset(0x698)] public Utf8String ActiveLobbyHost;
    [FieldOffset(0x700)] public uint AlternateLobbyPort;
    [FieldOffset(0x708)] public Utf8String AlternateLobbyHost;
    [FieldOffset(0x770)] public uint LobbyRetryCount;
    [FieldOffset(0x774)] public uint LobbyRetryInterval;
    [FieldOffset(0x778)] public uint LobbyPing;
    [FieldOffset(0x77C)] public uint FrontPort;
    [FieldOffset(0x780)] public Utf8String FrontHost;
    [FieldOffset(0x7E8)] public Utf8String FrontProtocol;
    [FieldOffset(0x850)] public bool UseCfgFrontend;
    [FieldOffset(0x858)] public Utf8String Ticket;
    [FieldOffset(0x8C0)] public Utf8String World;
    [FieldOffset(0x928)] public Utf8String ZoneName;

    [FieldOffset(0x9C9)] public bool WinSockInitialized;
    [FieldOffset(0x9D0)] public NetworkModulePacketReceiverCallback* PacketReceiverCallback;


    [FieldOffset(0xB26)] public short CurrentInstance;

    [FieldOffset(0xB30)] public int KeepAliveZone;
    [FieldOffset(0xB34)] public int KeepAliveIntervalZone;
    [FieldOffset(0xB38)] public int KeepAliveChat;
    [FieldOffset(0xB3C)] public int KeepAliveIntervalChat;

    [FieldOffset(0xB58)] public bool IsInCrossWorldDuty;
}
