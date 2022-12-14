namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentList
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener

// size = 0x1A8
// common CreateAtkComponent function 8B FA 33 DB E8 ?? ?? ?? ?? 
// type 1
[StructLayout(LayoutKind.Explicit, Size = 0x1A8)]
public unsafe struct AtkComponentList
{
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;
    [FieldOffset(0xC0)] public AtkComponentListItemRenderer* FirstAtkComponentListItemRenderer;
    [FieldOffset(0xC8)] public AtkComponentScrollBar* AtkComponentScrollBarC8;
    [FieldOffset(0xF0)] public ListItem* ItemRendererList;
    [FieldOffset(0x118)] public int ListLength;
    [FieldOffset(0x12C)] public int SelectedItemIndex; // 0-N, -1 when none.
    [FieldOffset(0x130)] public int HeldItemIndex; // 0-N, -1 when none. While mouse is held down.

    [FieldOffset(0x134)] public int HoveredItemIndex; // 0-N, -1 when none. While mouse is hovering.

    // [FieldOffset(0x138)] public int SelectedItemIndex2; // Goes negative sometimes... strange.
    [FieldOffset(0x148)] public AtkCollisionNode* HoveredItemCollisionNode;
    [FieldOffset(0x150)] public int HoveredItemIndex2; // Repeat?
    [FieldOffset(0x158)] public int HoveredItemIndex3; // Repeat?

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct ListItem
    {
        [FieldOffset(0x8)] public AtkComponentListItemRenderer* AtkComponentListItemRenderer;
    }
}