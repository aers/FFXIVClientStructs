namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x1C)]
public unsafe struct AtkUldComponentDataCheckBox {
    [FieldOffset(0x00)] public AtkUldComponentDataBase Base;
    [FieldOffset(0x0C)] public fixed uint Nodes[3];
    [FieldOffset(0x18)] public uint TextId;
}
