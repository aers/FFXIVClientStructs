namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct AtkUldComponentDataScrollBar {
    // [0] ThumbButton
    // [1] ArrowUpButton
    // [2] ArrowDownButton
    // [3] TrackButton
    [FieldOffset(0x0C), FixedSizeArray] internal FixedSizeArray4<uint> _nodes;
    [FieldOffset(0x1C)] public ushort Margin;
    [FieldOffset(0x1E)] public byte Vertical;
}
