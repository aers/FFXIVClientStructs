namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop, Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct AtkUldComponentDataTreeList {
    [FieldOffset(0x0C)] public fixed uint Nodes[5];
    [FieldOffset(0x20)] public byte Wrap;
    [FieldOffset(0x21)] public byte Orientation;
    [FieldOffset(0x22)] public ushort RowNum;
    [FieldOffset(0x24)] public ushort ColNum;
}
