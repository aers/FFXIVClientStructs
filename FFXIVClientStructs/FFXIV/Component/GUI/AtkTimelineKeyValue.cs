using FFXIVClientStructs.FFXIV.Client.Graphics;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x08), CExporterStructUnion]
public struct AtkTimelineKeyValue {
    [FieldOffset(0x00)] public StdPair<float, float> Float2;
    [FieldOffset(0x00)] public float Float;
    [FieldOffset(0x00)] public byte Byte;
    [FieldOffset(0x00)] public AtkTimelineNodeTint NodeTint; // Alpha values are ignored
    [FieldOffset(0x00)] public ushort UShort;
    [FieldOffset(0x00)] public ByteColor RGB; // Alpha values are ignored
    [FieldOffset(0x00)] public AtkTimelineLabel Label;
    [FieldOffset(0x00)] public short Short;
}
