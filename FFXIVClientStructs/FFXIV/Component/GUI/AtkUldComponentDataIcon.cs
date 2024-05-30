namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop, Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2C)]
public unsafe partial struct AtkUldComponentDataIcon {
    [FieldOffset(0x0C), FixedSizeArray] internal FixedSizeArray8<uint> _nodes;
}
