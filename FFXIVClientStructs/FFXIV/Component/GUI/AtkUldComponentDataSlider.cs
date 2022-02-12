namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x34)]
public unsafe struct AtkUldComponentDataSlider
{
    [FieldOffset(0x00)] public AtkUldComponentDataBase Base;
    [FieldOffset(0x0C)] public fixed uint Nodes[4];
    [FieldOffset(0x1C)] public int Min;
    [FieldOffset(0x20)] public int Max;
    [FieldOffset(0x24)] public int Step;
    [FieldOffset(0x28)] public int OfffsetL;
    [FieldOffset(0x2C)] public int OffsetR;
    [FieldOffset(0x30)] public byte Vertical;
}