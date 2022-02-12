namespace FFXIVClientStructs.FFXIV.Component.GUI;

public enum AlignmentType
{
    TopLeft = 0x0,
    Top = 0x1,
    TopRight = 0x2,
    Left = 0x3,
    Center = 0x4,
    Right = 0x5,
    BottomLeft = 0x6,
    Bottom = 0x7,
    BottomRight = 0x8
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct AtkUldWidgetInfo
{
    [FieldOffset(0x0)] public AtkUldObjectInfo ObjectInfo;
    [FieldOffset(0x10)] public uint AlignmentType;
    [FieldOffset(0x14)] public float X;
    [FieldOffset(0x18)] public float Y;
}