namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct AtkArrayData
{
    [FieldOffset(0x0)] public void* vtbl;
    [FieldOffset(0x8)] public int Size;
    [FieldOffset(0x1C)] public byte Unk1C;
    [FieldOffset(0x1D)] public byte Unk1D;
    [FieldOffset(0x1E)] public byte HasModifiedData;
    [FieldOffset(0x1F)] public byte Unk1F; // initialized to -1
}