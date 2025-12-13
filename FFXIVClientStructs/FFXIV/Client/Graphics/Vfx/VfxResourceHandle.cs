namespace FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;

[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct VfxResourceHandle {
    [FieldOffset(0)] public ulong Value;

    [FieldOffset(0)] public uint Id;
    [FieldOffset(4)] public uint Index;
}
