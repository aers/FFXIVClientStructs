namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop, Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct AtkUldComponentDataPortrait {
    [FieldOffset(0x0C), FixedSizeArray] internal FixedSizeArray3<uint> _nodes;
}
