namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[Inherits<AtkUldObjectInfo>]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public partial struct AtkUldWidgetInfo {
    [FieldOffset(0x10)] public AtkWidgetAlignment WidgetAlignment;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct AtkWidgetAlignment {
    [FieldOffset(0x00)] public AlignmentType AlignmentType;
    [FieldOffset(0x04)] public float X;
    [FieldOffset(0x08)] public float Y;
}

public enum AlignmentType {
    TopLeft,
    Top,
    TopRight,
    Left,
    Center,
    Right,
    BottomLeft,
    Bottom,
    BottomRight
}
