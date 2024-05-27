namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop, Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct AtkUldComponentDataScrollBar {
    [FieldOffset(0x0C)] public fixed uint Nodes[4];
    [FieldOffset(0x1C)] public ushort Margin;
    [FieldOffset(0x1E)] public byte Vertical;
}
