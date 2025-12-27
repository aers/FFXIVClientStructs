namespace FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;

[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct VfxResourceHandle {
    [FieldOffset(0), CExporterUnion("Value")] public ulong Value;
    [FieldOffset(0), CExporterUnion("Value")] public uint Id;
    [FieldOffset(4), CExporterUnion("Value")] public uint Index;
}
