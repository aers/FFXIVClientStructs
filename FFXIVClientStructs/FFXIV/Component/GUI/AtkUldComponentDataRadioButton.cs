namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop, Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x24)]
public unsafe partial struct AtkUldComponentDataRadioButton {
    [FieldOffset(0x0C), FixedSizeArray] internal FixedSizeArray4<uint> _nodes;
    [FieldOffset(0x1C)] public uint TextId;
    [FieldOffset(0x20)] public uint GroupId;
}
