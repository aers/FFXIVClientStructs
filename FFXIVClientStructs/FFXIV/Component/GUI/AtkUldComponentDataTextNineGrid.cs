namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct AtkUldComponentDataTextNineGrid {
    [FieldOffset(0x0C), FixedSizeArray] internal FixedSizeArray2<uint> _nodes;
    [FieldOffset(0x14)] public uint TextId;
}
