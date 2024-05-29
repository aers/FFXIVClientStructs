namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop, Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct AtkUldComponentDataHoldButton {
    [FieldOffset(0x0C), FixedSizeArray] internal FixedSizeArray4<uint> _nodes;
    [FieldOffset(0x1C)] public uint TextId;
}
