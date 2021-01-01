using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Component.GUI.ULD
{
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
        BottomRight = 0x8,

        Font0 = 0x00, // Standard font, Supports 0xE0## characters
        Font1 = 0x10, // Used on title screen menu
        Font2 = 0x20, // Item Level. 0123456789.%!+-   Non supported characters are replaced with '-'
        Font3 = 0x30, // 
        Font4 = 0x40, // Used for job names
        Font5 = 0x50, // Damage Values. Numeric and ! only. Non supported characters are not drawn.
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public unsafe struct ULDWidgetInfo
    {
        [FieldOffset(0x0)] public ULDObjectInfo ObjectInfo;
        [FieldOffset(0x10)] public uint AlignmentType;
        [FieldOffset(0x14)] public float X;
        [FieldOffset(0x18)] public float Y;
    }
}
