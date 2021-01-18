using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
    // Component::GUI::AtkComponentList
    //   Component::GUI::AtkComponentBase
    //     Component::GUI::AtkEventListener

    // size = 0x1A8
    // common CreateAtkComponent function 8B FA 33 DB E8 ? ? ? ? 
    // type 1
    [StructLayout(LayoutKind.Explicit, Size = 0x1A8)]
    public unsafe struct AtkComponentList
    {
        [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;
        [FieldOffset(0xC0)] public AtkComponentListItemRenderer* FirstAtkComponentListItemRenderer;
        [FieldOffset(0xC8)] public AtkComponentScrollBar* AtkComponentScrollBarC8;
        [FieldOffset(0xF0)] public ListItem* ItemRendererList;
        [FieldOffset(0x118)] public int ListLength;

        [StructLayout(LayoutKind.Explicit, Size = 0x18)]
        public unsafe struct ListItem
        {
            [FieldOffset(0x8)] public AtkComponentListItemRenderer* AtkComponentListItemRenderer;
        }
    }
}
