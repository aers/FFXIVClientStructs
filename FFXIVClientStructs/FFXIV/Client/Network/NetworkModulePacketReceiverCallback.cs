namespace FFXIVClientStructs.FFXIV.Client.Network;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct NetworkModulePacketReceiverCallback
{
    [FieldOffset(0)] public void* vtbl;
}