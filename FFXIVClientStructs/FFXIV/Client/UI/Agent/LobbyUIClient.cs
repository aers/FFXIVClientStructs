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
