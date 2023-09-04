namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct AtkUldComponentDataHoldButton {
    [FieldOffset(0x00)] public AtkUldComponentDataBase Base;
    [FieldOffset(0x0C)] public fixed uint Nodes[4];
    [FieldOffset(0x1C)] public uint TextId;
}
