using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Component.GUI
{
    // probably a more generic type they use in multiple places
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe struct NodeList
    {
        [FieldOffset(0x4)] public int Count;
        [FieldOffset(0x8)] public AtkResNode** List;
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
        [FieldOffset(0x38)] public NodeList* ChildNodes;
        [FieldOffset(0xC8)] public AtkResNode* RootNode;
        [FieldOffset(0x1AC)] public float Scale;
        [FieldOffset(0x182)] public byte Flags;
        [FieldOffset(0x1BC)] public short X;
        [FieldOffset(0x1BE)] public short Y;
        [FieldOffset(0x1D5)] public byte Alpha;
    }
}
