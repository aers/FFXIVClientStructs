namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop, Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1C)]
public unsafe partial struct AtkUldComponentDataCheckBox {
    [FieldOffset(0x0C)] public fixed uint Nodes[3];
    [FieldOffset(0x18)] public uint TextId;
}
