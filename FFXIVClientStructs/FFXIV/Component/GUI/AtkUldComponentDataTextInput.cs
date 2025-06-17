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
    [FieldOffset(0x6A)] public byte Flags1; // TODO: use TextInputFlags1
    [FieldOffset(0x6B)] public byte Flags2; // TODO: use TextInputFlags2
    [FieldOffset(0x6C), FixedSizeArray] internal FixedSizeArray16<byte> _charSetExtras;
}

public enum TextInputFlags1 { // TODO: set underlying type to byte, additionally add [Flags] attribute
    Capitalize = 0x1,
    Mask = 0x2,
    EnableDictionary = 0x4,
    EnableHistory = 0x8,
    EnableIME = 0x10,
    EscapeClears = 0x20,
    AllowUpperCase = 0x40,
    AllowLowerCase = 0x80
}

public enum TextInputFlags2 { // TODO: set underlying type to byte, additionally add [Flags] attribute
    AllowNumberInput = 0x1,
    AllowSymbolInput = 0x2,
    WordWrap = 0x4,
    MultiLine = 0x8,
    AutoMaxWidth = 0x10
}
