namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop, Inherits<AtkUldComponentDataInputBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x3C)]
public unsafe partial struct AtkUldComponentDataNumericInput {
    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray5<uint> _nodes;
    [FieldOffset(0x24)] public int Value;
    [FieldOffset(0x28)] public int Min;
    [FieldOffset(0x2C)] public int Max;
    [FieldOffset(0x30)] public int Add;
    [FieldOffset(0x34)] public uint EndLetterId;
    [FieldOffset(0x38)] public byte Comma;
}
