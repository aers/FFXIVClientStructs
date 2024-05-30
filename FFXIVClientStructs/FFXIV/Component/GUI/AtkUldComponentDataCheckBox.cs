namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop, Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1C)]
public unsafe partial struct AtkUldComponentDataCheckBox {
    [FieldOffset(0x0C), FixedSizeArray] internal FixedSizeArray3<uint> _nodes;
    [FieldOffset(0x18)] public uint TextId;
}
