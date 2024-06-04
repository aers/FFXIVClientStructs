using FFXIVClientStructs.FFXIV.Client.Network;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[GenerateInterop]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 8B F9 48 89 01 48 81 C1 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8F", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x848)]
public unsafe partial struct LobbyUIClient {
    [FieldOffset(0x10)] public NetworkModuleProxy* NetworkModuleProxy;
    //[FieldOffset(0x18)] public ?* NetworConfig; // contains hosts and ports

    [FieldOffset(0x30)] public StdVector<LobbyDataCenterWorldEntry> CurrentDataCenterWorlds;

    [FieldOffset(0x48)] public LobbySubscriptionInfo* SubscriptionInfo;
}

[StructLayout(LayoutKind.Explicit, Size = 0x54)]
public unsafe struct LobbyDataCenterWorldEntry {
    [FieldOffset(0)] public ushort Id; // RowId in World sheet
    [FieldOffset(0x2)] public ushort Index;

    [FieldOffset(0x14), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name; // size unknown
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
