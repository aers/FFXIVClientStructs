using FFXIVClientStructs.FFXIV.Client.Network;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common;

namespace FFXIVClientStructs.FFXIV.Application.Network;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xC50)]
public unsafe partial struct NetworkModule {
    [FieldOffset(0x028)] public byte LobbyCount;
    [FieldOffset(0x02C), FixedSizeArray] internal FixedSizeArray14<uint> _lobbyPorts;
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
    [FieldOffset(0xA00)] private Utf8String UnkA00;

    [FieldOffset(0xAA1)] public bool WinSockInitialized;
    [FieldOffset(0xAA8)] public NetworkModulePacketReceiverCallback* PacketReceiverCallback;

    [FieldOffset(0xAD0)] private TimePoint UnkTimeAD0;
    [FieldOffset(0xB28)] private TimePoint UnkTimeB28;
    [FieldOffset(0xB54)] public int CurrentDeviceTime; //Timestamp
    [FieldOffset(0xB58)] public int CurrentDeviceTimeMillis; //Milliseconds for CurrentDeviceTime

    [FieldOffset(0xB68)] private TimePoint UnkTimeB68;
    [FieldOffset(0xB88)] private TimePoint UnkTimeB88;
    [FieldOffset(0xBB0)] private TimePoint UnkTimeBB0;
    [FieldOffset(0xBC8)] private uint UnkTimeBB0_UpdateFrequency;

    [FieldOffset(0xBD0)] private TimePoint UnkTimeBD0;
    [FieldOffset(0xBE8)] private TimePoint UnkTimeBE8;
    [FieldOffset(0xC06)] public short CurrentInstance;

    [FieldOffset(0xC10)] public int KeepAliveZone;
    [FieldOffset(0xC14)] public int KeepAliveIntervalZone;
    [FieldOffset(0xC18)] public int KeepAliveChat;
    [FieldOffset(0xC1C)] public int KeepAliveIntervalChat;
    [FieldOffset(0xC20)] private TimePoint UnkTimeC20;

    [FieldOffset(0xC38)] public bool IsInCrossWorldDuty;
}
