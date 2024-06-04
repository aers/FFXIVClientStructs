using FFXIVClientStructs.FFXIV.Client.Network;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Application.Network;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xBD8)]
public unsafe partial struct NetworkModule {
    [FieldOffset(0x028)] public byte LobbyCount;
    [FieldOffset(0x02C), FixedSizeArray] internal FixedSizeArray13<uint> _lobbyPorts;
    [FieldOffset(0x068), FixedSizeArray] internal FixedSizeArray14<Utf8String> _lobbyHosts;
    [FieldOffset(0x61C)] public short OperatingSystemTypeAndVersion; //Most likely this is an enum
    [FieldOffset(0x620)] public uint SaveDataBankPort;
    [FieldOffset(0x628)] public Utf8String SaveDataBankHost; //Config Saves
    [FieldOffset(0x690)] public uint SaveDataBankMode;
    [FieldOffset(0x694)] public uint DktWebPort;
    [FieldOffset(0x698)] public Utf8String DktWebHost; //DC Travel
    [FieldOffset(0x700)] public uint ActiveLobbyPort;
    [FieldOffset(0x708)] public Utf8String ActiveLobbyHost;
    [FieldOffset(0x770)] public uint AlternateLobbyPort;
    [FieldOffset(0x778)] public Utf8String AlternateLobbyHost;
    [FieldOffset(0x7E0)] public uint LobbyRetryCount;
    [FieldOffset(0x7E4)] public uint LobbyRetryInterval;
    [FieldOffset(0x7E8)] public uint LobbyPing;
    [FieldOffset(0x7EC)] public uint FrontPort;
    [FieldOffset(0x7F0)] public Utf8String FrontHost;
    [FieldOffset(0x858)] public Utf8String FrontProtocol;
    [FieldOffset(0x8C0)] public bool UseCfgFrontend;
    [FieldOffset(0x8C8)] public Utf8String Ticket;
    [FieldOffset(0x930)] public Utf8String World;
    [FieldOffset(0x998)] public Utf8String ZoneName;

    [FieldOffset(0xA39)] public bool WinSockInitialized;
    [FieldOffset(0xA40)] public NetworkModulePacketReceiverCallback* PacketReceiverCallback;

    [FieldOffset(0xAE4)] public int CurrentDeviceTime; //Timestamp
    [FieldOffset(0xAE8)] public int CurrentDeviceTimeMillis; //Milliseconds for A74

    [FieldOffset(0xB9E)] public short CurrentInstance;

    [FieldOffset(0xBA8)] public int KeepAliveZone;
    [FieldOffset(0xBAC)] public int KeepAliveIntervalZone;
    [FieldOffset(0xBB0)] public int KeepAliveChat;
    [FieldOffset(0xBB4)] public int KeepAliveIntervalChat;

    [FieldOffset(0xBD0)] public bool IsInCrossWorldDuty;
}
