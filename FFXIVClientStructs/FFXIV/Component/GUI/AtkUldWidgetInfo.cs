namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[Inherits<AtkUldObjectInfo>]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public partial struct AtkUldWidgetInfo {
    [FieldOffset(0x10)] public AtkWidgetAlignment WidgetAlignment;
    [FieldOffset(0x10), Obsolete("Use WidgetAlignment.AlignmentType", true)] public uint AlignmentType;
    [FieldOffset(0x14), Obsolete("Use WidgetAlignment.X", true)] public float X;
    [FieldOffset(0x18), Obsolete("Use WidgetAlignment.Y", true)] public float Y;
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
