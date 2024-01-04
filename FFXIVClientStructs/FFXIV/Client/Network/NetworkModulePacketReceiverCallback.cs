namespace FFXIVClientStructs.FFXIV.Client.Network;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct NetworkModulePacketReceiverCallback {
    [FieldOffset(0x00)] public void* vtbl;
    [FieldOffset(0x08)] public PacketDispatcher PacketDispatcher;
    [FieldOffset(0x18)] public NetworkModuleProxy* NetworkModuleProxy;
}
