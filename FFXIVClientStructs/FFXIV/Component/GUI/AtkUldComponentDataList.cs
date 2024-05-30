namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop, Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct AtkUldComponentDataList {
    [FieldOffset(0x0C), FixedSizeArray] internal FixedSizeArray5<uint> _nodes;
    [FieldOffset(0x20)] public byte Wrap;
    [FieldOffset(0x21)] public byte Orientation;
    [FieldOffset(0x22)] public ushort RowNum;
    [FieldOffset(0x24)] public ushort ColNum;
}
