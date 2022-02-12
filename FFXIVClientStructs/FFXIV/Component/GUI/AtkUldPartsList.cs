namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct AtkUldPartsList
{
    [FieldOffset(0x0)] public uint Id;
    [FieldOffset(0x4)] public uint PartCount;
    [FieldOffset(0x8)] public AtkUldPart* Parts; // array with size PartCount
}