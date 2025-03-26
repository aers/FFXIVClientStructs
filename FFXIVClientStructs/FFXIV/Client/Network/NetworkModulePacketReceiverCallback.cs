namespace FFXIVClientStructs.FFXIV.Client.Network;

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct NetworkModulePacketReceiverCallback {
    [FieldOffset(0x08)] public PacketDispatcher PacketDispatcher;
    [FieldOffset(0x18)] public NetworkModuleProxy* NetworkModuleProxy;
}
