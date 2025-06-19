using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentList
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08"
// type 1
[GenerateInterop(isInherited: true)]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1B0)]
public unsafe partial struct AtkComponentList : ICreatable {
    [FieldOffset(0xC0)] public AtkComponentListItemRenderer* FirstAtkComponentListItemRenderer;
    [FieldOffset(0xC8)] public AtkComponentScrollBar* AtkComponentScrollBarC8;
    [FieldOffset(0xD0)] public AtkCollisionNode* CollisionNode;
    [FieldOffset(0xD8)] public AtkComponentBase* BottomFadeComponent; // ComponentBase that has a image node
    [FieldOffset(0xE0)] public AtkComponentBase* TopFadeComponent; // ComponentBase that has a image node
    [FieldOffset(0xF0)] public ListItem* ItemRendererList;
    [FieldOffset(0x100)] public CategoryItem* CategoryItemRendererList;
    [FieldOffset(0x120)] public int ListLength;
    [FieldOffset(0x134)] public int SelectedItemIndex; // 0-N, -1 when none.
    [FieldOffset(0x138)] public int HeldItemIndex; // 0-N, -1 when none. While mouse is held down.

    [FieldOffset(0x13C)] public int HoveredItemIndex; // 0-N, -1 when none. While mouse is hovering.

    // [FieldOffset(0x140)] public int SelectedItemIndex2; // Goes negative sometimes... strange.
    [FieldOffset(0x150)] public AtkCollisionNode* HoveredItemCollisionNode;
    [FieldOffset(0x158)] public int HoveredItemIndex2; // Repeat?
    [FieldOffset(0x160)] public int HoveredItemIndex3; // Repeat?
    [FieldOffset(0x18C)] public byte NumCategoryRenderers;
    [FieldOffset(0x19B)] public bool IsUpdatePending;

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

    // rendererNodeId is the node id of the ListItemRenderer to use. if 0, it uses FirstAtkComponentListItemRenderer
    [MemberFunction("E8 ?? ?? ?? ?? 83 FE 47")]
    public partial void SetupRenderer(AtkComponentListItemPopulator* populator, ColumnNodeInfo* columns, int columnCount, uint rendererNodeId = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B C8 48 85 DB")]
    public partial AtkComponentListItemRenderer* GetItemRendererByNodeId(uint nodeId);

    [MemberFunction("E8 ?? ?? ?? ?? 41 80 FF 04")]
    public partial void SetItemCount(int value);

    /// <remarks> Used by <see cref="AtkComponentDropDownList"/>. </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? FF C5 48 8D 5B 70"), GenerateStringOverloads]
    public partial void SetItemLabel(int index, CStringPointer text);

    /// <remarks> Used by <see cref="AtkComponentDropDownList"/>. </remarks>
    [MemberFunction("3B 91 ?? ?? ?? ?? 7C 03 33 C0 C3 4C 8B 81")]
    public partial CStringPointer GetItemLabel(int index);

    [MemberFunction("83 FA FF 0F 8E ?? ?? ?? ?? 53")]
    public partial void DispatchItemEvent(int index, AtkEventType eventType);

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct ListItem {
        /// <remarks> Used by <see cref="AtkComponentDropDownList"/>. </remarks>
        [FieldOffset(0)] public CStringPointer Label;
        [FieldOffset(0x8)] public AtkComponentListItemRenderer* AtkComponentListItemRenderer;

        [FieldOffset(0x14)] public bool IsHighlighted;
        [FieldOffset(0x15)] public bool IsDisabled;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct CategoryItem {
        [FieldOffset(0)] public AtkComponentListItemRenderer* AtkComponentListItemRenderer;
        [FieldOffset(0x8)] public AtkComponentNode* NodeList;
        [FieldOffset(0x10)] public ushort NodeCount;
        [FieldOffset(0x12)] public ushort NodeId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct ColumnNodeInfo {
        [FieldOffset(0x00)] public uint NodeId;
        [FieldOffset(0x04)] public uint ParentNodeId; // if AtkResNode is not set, this is used
        [FieldOffset(0x08)] public AtkResNode* AtkResNode;
    }
}
