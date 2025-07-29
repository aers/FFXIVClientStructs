using FFXIVClientStructs.FFXIV.Client.Graphics;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[Inherits<AtkUldComponentDataInputBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x7C)]
public unsafe partial struct AtkUldComponentDataTextInput {
    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray16<uint> _nodes;
    [FieldOffset(0x50)] public ByteColor CandidateColor;
    [FieldOffset(0x54)] public ByteColor IMEColor;
    [FieldOffset(0x58)] public uint MaxWidth;
    [FieldOffset(0x5C)] public uint MaxLine;
    [FieldOffset(0x60)] public uint MaxByte;
    [FieldOffset(0x64)] public uint MaxChar;
    [FieldOffset(0x68)] public ushort CharSet;
    [FieldOffset(0x6A)] public TextInputFlags1 Flags1;
    [FieldOffset(0x6B)] public TextInputFlags2 Flags2;
    [FieldOffset(0x6C), FixedSizeArray] internal FixedSizeArray16<byte> _charSetExtras;
}

[Flags]
public enum TextInputFlags1 : byte {
    Capitalize = 0x1,
    Mask = 0x2,
    EnableDictionary = 0x4,
    EnableHistory = 0x8,
    EnableIME = 0x10,
    EscapeClears = 0x20,
    AllowUpperCase = 0x40,
    AllowLowerCase = 0x80
}

[Flags]
public enum TextInputFlags2 : byte {
    AllowNumberInput = 0x1,
    AllowSymbolInput = 0x2,
    WordWrap = 0x4,
    MultiLine = 0x8,
    AutoMaxWidth = 0x10
}
