using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentList
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 1
[GenerateInterop(isInherited: true)]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1A8)]
public unsafe partial struct AtkComponentList : ICreatable {
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
    [FieldOffset(0x193)] public bool IsUpdatePending;

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 9F ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 07 0F 57 C0")]
    public partial void Ctor();
    
    [VirtualFunction(25)]
    public partial AtkComponentListItemRenderer* GetItemRenderer(int index);

    [VirtualFunction(26)]
    public partial void SetItemDisabledState(int index, bool disabled);

    [VirtualFunction(27)]
    public partial bool GetItemDisabledState(int index);

    [VirtualFunction(28)]
    public partial void SetItemHighlightedState(int index, bool highlighted, bool triggerUpdate = true);

    [VirtualFunction(29)]
    public partial bool GetItemHighlightedState(int index);

    [VirtualFunction(31)]
    public partial void SelectItem(int index, bool dispatchEvent = false);

    [VirtualFunction(32)]
    public partial void DeselectItem();

    [VirtualFunction(36)]
    public partial int GetItemCount();

    [MemberFunction("E8 ?? ?? ?? ?? 41 80 FF 04")]
    public partial void SetItemCount(int value);

    /// <remarks> Used by <see cref="AtkComponentDropDownList"/>. </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? FF C5 48 8D 5B 70"), GenerateStringOverloads]
    public partial void SetItemLabel(int index, byte* text);

    /// <remarks> Used by <see cref="AtkComponentDropDownList"/>. </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 97 ?? ?? ?? ?? 89 5C 24 28")]
    public partial byte* GetItemLabel(int index);

    [MemberFunction("83 FA FF 0F 8E ?? ?? ?? ?? 53")]
    public partial void DispatchItemEvent(int index, AtkEventType eventType);

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct ListItem {
        /// <remarks> Used by <see cref="AtkComponentDropDownList"/>. </remarks>
        [FieldOffset(0)] public byte* Label;
        [FieldOffset(0x8)] public AtkComponentListItemRenderer* AtkComponentListItemRenderer;

        [FieldOffset(0x14)] public bool IsHighlighted;
        [FieldOffset(0x15)] public bool IsDisabled;
    }
}
