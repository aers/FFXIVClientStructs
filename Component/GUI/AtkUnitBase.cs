using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Component.GUI
{    public enum AlignmentType
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
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public unsafe struct WidgetInfo
    {
        [FieldOffset(0x4)] public int NodeCount;
        [FieldOffset(0x8)] public AtkResNode** NodeList;
        [FieldOffset(0x10)] public uint AlignmentType;
        [FieldOffset(0x14)] public float X;
        [FieldOffset(0x18)] public float Y;
    }

    // this is passed to functions as its own struct, they lea AtkUnitBase+0x28
    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public unsafe struct AddonData
    {
        [FieldOffset(0x10)] public WidgetInfo* Widgets; // this is an array with size WidgetCount
        [FieldOffset(0x24)] public ushort WidgetCount;
        [FieldOffset(0x28)] public void* UldResourceHandle; // only exists during loading, pointer is released immediately afterwards
        [FieldOffset(0x48)] public void* AtkResourceRendererManager;
        [FieldOffset(0x86)] public byte Flags1; // bit 0x10 is set if byte 5 in a widget is set
        [FieldOffset(0x89)] public byte LoadedState;
    }

    // Component::GUI::AtkUnitBase
    //   Component::GUI::AtkEventListener

    // base class for all AddonXXX classes (visible UI objects)

    // size = 0x220
    // ctor E8 ? ? ? ? 83 8B ? ? ? ? ? 33 C0 

    [StructLayout(LayoutKind.Explicit, Size = 0x220)]
    public unsafe struct AtkUnitBase
    {
        [FieldOffset(0x0)] public AtkEventListener AtkEventListener;
        [FieldOffset(0x8)] public fixed byte Name[0x20];
        [FieldOffset(0x28)] public AddonData AddonData;
        [FieldOffset(0xC8)] public AtkResNode* RootNode;
        [FieldOffset(0x1AC)] public float Scale;
        [FieldOffset(0x182)] public byte Flags;
        [FieldOffset(0x1BC)] public short X;
        [FieldOffset(0x1BE)] public short Y;
        [FieldOffset(0x1D5)] public byte Alpha;
    }
}
