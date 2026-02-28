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
public unsafe partial struct AtkComponentList : ICreatable<AtkComponentList> {
    [FieldOffset(0xC0)] public AtkComponentListItemRenderer* FirstAtkComponentListItemRenderer;
    [FieldOffset(0xC8)] public AtkComponentScrollBar* ScrollBarComponent;
    [FieldOffset(0xD0)] public AtkCollisionNode* CollisionNode;
    [FieldOffset(0xD8)] public AtkComponentBase* BottomFadeComponent; // ComponentBase that has a image node
    [FieldOffset(0xE0)] public AtkComponentBase* TopFadeComponent; // ComponentBase that has a image node
    [FieldOffset(0xE8)] public ListComponentCallBackInterface* CallBackInterface;
    [FieldOffset(0xF0)] public ListItem* ItemRendererList;
    [FieldOffset(0xF8)] public int AllocatedItemRendererListLength;
    // 4 bytes nothing?
    [FieldOffset(0x100)] public CategoryItem* CategoryItemRendererList;
    [FieldOffset(0x108)] public AtkDragDropInterface* DragDropInterface;
    [FieldOffset(0x110)] public AtkComponentListItemRenderer* DraggingListItemRenderer;
    [FieldOffset(0x118)] public CStringPointer* ItemLabels; // when set with SetItemLabels, GetItemLabel will use strings from this array
    [FieldOffset(0x120)] public int ListLength;
    [FieldOffset(0x124)] public int PendingFirstVisibleItemIndex; // PendingScrollPosition / ItemHeight, applied next Update
    [FieldOffset(0x128)] public int FirstVisibleItemIndex;
    [FieldOffset(0x12C)] public int ScrollOffset; // PendingScrollPosition % ItemHeight or ItemWidth depending on IsVerticalScroll
    [FieldOffset(0x130)] public int ScrollMaxIndex; // the item index at which the scrollbar is at 100%
    [FieldOffset(0x134)] public int SelectedItemIndex; // 0-N, -1 when none.
    [FieldOffset(0x138)] public int HeldItemIndex; // 0-N, -1 when none. While mouse is held down.
    [FieldOffset(0x13C)] public int HoveredItemIndex; // 0-N, -1 when none. While mouse is hovering.
    [FieldOffset(0x140)] private int Unk140ItemIndex;
    [FieldOffset(0x144)] private int Unk144ItemIndex; // set when dialog is opened?
    [FieldOffset(0x148)] public int DragDropItemIndex;
    // 4 bytes nothing?
    [FieldOffset(0x150)] public AtkCollisionNode* HoveredItemCollisionNode;
    [FieldOffset(0x158)] public int HoveredItemIndex2; // Repeat?
    [FieldOffset(0x15C)] private int Unk15C;
    [FieldOffset(0x160)] public int HoveredItemIndex3; // Repeat?
    [FieldOffset(0x164)] public DragDropType DragDropType;
    [FieldOffset(0x168)] public short VisibleRowCount;
    [FieldOffset(0x16A)] public short RowStepX;
    [FieldOffset(0x16C)] public short RowStepY;
    [FieldOffset(0x16E)] public short ColumnCount;
    [FieldOffset(0x170)] public short ColumnStepX;
    [FieldOffset(0x172)] public short ColumnStepY;
    [FieldOffset(0x174)] public short NumVisibleColumns;
    [FieldOffset(0x176)] public short NumVisibleRows;
    [FieldOffset(0x178)] public short NumVisibleItems; // NumVisibleColumns * NumVisibleRows
    [FieldOffset(0x17A)] private short Unk17A;
    [FieldOffset(0x17C)] private short Unk17C;
    [FieldOffset(0x17E)] private short Unk17E;
    [FieldOffset(0x180)] private short Unk180;
    [FieldOffset(0x182)] public short ListWidth; // width of the ComponentNode
    [FieldOffset(0x184)] public short ListHeight; // height of the ComponentNode
    [FieldOffset(0x186)] public short ItemWidth;
    [FieldOffset(0x188)] public short ItemHeight;
    [FieldOffset(0x18A)] public short BaseScrollOffset;
    [FieldOffset(0x18C)] public byte NumCategoryRenderers;
    [FieldOffset(0x18D)] public byte Wrap; // name from Lumina
    [FieldOffset(0x18E)] private byte Unk18E;
    [FieldOffset(0x18F)] public byte MoveInputId;
    [FieldOffset(0x190)] private byte Unk190InputId;
    [FieldOffset(0x191)] public bool IsVerticalScroll;
    [FieldOffset(0x192)] private byte Unk192;
    [FieldOffset(0x193)] public bool IsScrollBarEnabled;
    [FieldOffset(0x194)] public bool IsScrollSnappingEnabled;
    [FieldOffset(0x195)] public bool IsScrollBarVisible;
    [FieldOffset(0x196)] public bool IsDroppingDisabled;
    [FieldOffset(0x197)] public bool IsItemInteractionEnabled; // scrolling still works, just not hovering/clicking on items
    [FieldOffset(0x198)] private byte Unk198;
    [FieldOffset(0x199)] private bool Unk199; // required for IsAutoResizeHeightEnabled, but seems to have something to do with focus?
    [FieldOffset(0x19A)] private bool IsAutoResizeHeightEnabled; // resizes the OwnerNode based on elements in the list
    [FieldOffset(0x19B)] public bool IsUpdatePending;
    [FieldOffset(0x19C)] public bool IsScrollRefreshPending;
    [FieldOffset(0x19D)] private bool Unk19D;
    [FieldOffset(0x19E)] public bool IsItemClickEnabled; // needed to finish drag drop
    [FieldOffset(0x19F)] private bool Unk19F; // something used in AddonFreeCompanyCrestColor, enables ModifierFlag.Unk8?
    [FieldOffset(0x1A0)] public bool IsInputTopBottomEnabled; // InputId.TOP / InputId.BOTTOM
    [FieldOffset(0x1A1)] public bool IsInputMenuOptionEnabled; // InputId.MENU_OPTION
    [FieldOffset(0x1A2)] private bool Unk1A2; // something with input handling DragDrop insert
    [FieldOffset(0x1A3)] private bool Unk1A3; // overrides DrawOrderIndex with one from RaptureAtkUnitManager
    [FieldOffset(0x1A4)] private bool Unk1A4; // disables handling of AtkEventType.Unk79
    [FieldOffset(0x1A5)] private bool Unk1A5; // deselect on InputId.PAD_CANCEL + more
    [FieldOffset(0x1A6)] private bool Unk1A6; // something with selection logic?
    [FieldOffset(0x1A7)] private byte Unk1A7; // select on cancel?
    [FieldOffset(0x1A8)] public bool IsCursorNavigationCrossList; // see AddonEmote where it continues the repeat on another list if enabled
    [FieldOffset(0x1A9)] private bool Unk1A9;
    [FieldOffset(0x1AA)] private bool Unk1AA; // PlaySoundEffect(3) on InputId.CANCEL when CursorNavigationInfo.Unk08 == 1 and Unk140ItemIndex >= 0
    [FieldOffset(0x1AB)] private bool Unk1AB; // something with inputs
    [FieldOffset(0x1AC)] private bool Unk1AC; // something with inputs
    [FieldOffset(0x1AD)] private byte Unk1AD; // flags for dragdrop
    // 2 bytes nothing?

    [FieldOffset(0xC8), Obsolete("Renamed to ScrollBarComponent")] public AtkComponentScrollBar* AtkComponentScrollBarC8;
    [FieldOffset(0x193), Obsolete("Renamed to IsScrollBarEnabled")] public bool ScrollbarEnabled;

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 9F ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 07 0F 57 C0")]
    public partial AtkComponentList* Ctor();

    [VirtualFunction(23)]
    public partial void ScrollToItem(short index);

    [VirtualFunction(24)]
    public partial void CenterScrollOnItem(short index);

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

    /// <remarks> For lists with 1 column only?! </remarks>
    [VirtualFunction(30)]
    public partial bool IsItemVisible(int index, bool checkPartial = true);

    [VirtualFunction(31)]
    public partial void SelectItem(int index, bool dispatchEvent = false);

    [VirtualFunction(32)]
    public partial void DeselectItem();

    [VirtualFunction(36)]
    public partial int GetItemCount();

    [VirtualFunction(38)]
    public partial void RecalculateVisibleItems(bool a2);

    /// <remarks> Updates every ListItemRenderers postition, visibility, ListItemIndex etc. </remarks>
    [VirtualFunction(40)]
    public partial void UpdateListItems();

    [VirtualFunction(44)]
    public partial bool DispatchEvent(AtkEventType eventType, AtkEvent* atkEvent, AtkEventData* atkEventData, uint selectedIndex, bool handled);

    /// <remarks> rendererNodeId is the node id of the ListItemRenderer to use. if 0, it uses FirstAtkComponentListItemRenderer </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 8B D3 85 ED")]
    public partial void SetupRenderer(AtkComponentListItemPopulator* populator, ColumnNodeInfo* columns, int columnCount, uint rendererNodeId = 0); // TODO: columnCount is of size byte and not int

    [Obsolete("Use GetComponentItemRendererById")]
    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B C8 48 85 DB")]
    public partial AtkComponentListItemRenderer* GetItemRendererByNodeId(uint nodeId);

    [MemberFunction("E8 ?? ?? ?? ?? 41 80 FF 04")]
    public partial void SetItemCount(int value); // TODO: value is of size short and not int. passed the value of SetItemLabels

    [MemberFunction("E8 ?? ?? ?? ?? 85 FF 79 ?? 44 39 75"), GenerateStringOverloads]
    public partial void SetItemLabel(int index, CStringPointer text);

    [MemberFunction("E8 ?? ?? ?? ?? FF C6 48 83 C5 ?? 41 3B F6")]
    public partial void SetItemIcon(int index, uint iconId);

    /// <remarks> Used by <see cref="AtkComponentDropDownList"/>. </remarks>
    [MemberFunction("3B 91 ?? ?? ?? ?? 7C 03 33 C0 C3 4C 8B 81")]
    public partial CStringPointer GetItemLabel(int index);

    // TODO: rename this to something more distinct from SetItemLabel?!?
    [MemberFunction("E8 ?? ?? ?? ?? 33 ED E9")]
    public partial void SetItemLabels(short count, CStringPointer* labels, bool deselectCurrent = true);

    [MemberFunction("83 FA FF 0F 8E ?? ?? ?? ?? 53")]
    public partial void DispatchItemEvent(int index, AtkEventType eventType);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ?? 66 0F 6F 05")]
    public partial void ToggleScrollSnapping(bool enabled);

    /// <remarks> iconId is unused </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 41 81 4C 24 ?? ?? ?? ?? ?? 41 C6 44 24 ?? ?? 33 D2")]
    public partial void SetDragDropPayloadData(uint iconId, int int2, int int1);

    [MemberFunction("E8 ?? ?? ?? ?? 44 39 64 24 ?? 74 ?? 48 8B 83")]
    public partial void CancelDragDrop();

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 45 8B CE 89 7C 24")]
    public partial bool HandleMouseDown(AtkEvent* atkEvent, AtkEventData.AtkMouseData* data);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 41 83 FE ?? 0F 85 ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 40 38 B0")]
    public partial bool HandleMouseUp(AtkEvent* atkEvent, AtkEventData.AtkMouseData* data, int eventParam, int itemIndex);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 4C 8B C5 48 8B D6 48 8B CB")]
    public partial bool HandleMouseWheel(AtkEvent* atkEvent, AtkEventData.AtkMouseData* data);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 81 4E")]
    public partial bool HandleInput(AtkEventData.AtkInputData* data, uint itemIndex, AtkEvent* atkEvent, AtkComponentListItemRenderer* itemRenderer); // itemIndex from +0x140

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5C 24 ?? 48 8B 6C 24 ?? 48 8B 74 24 ?? 48 83 C4 ?? 41 5F 41 5E 5F C3 66 90")]
    public partial bool HandleFocusStart(AtkEvent* atkEvent, AtkEventData.AtkFocusData* data);

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 4C 8B C5 48 8B D7")]
    public partial bool HandleFocusStop(AtkEvent* atkEvent, AtkEventData.AtkFocusData* data);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? ?? ?? ?? 8B D7 48 8B CB FF 90")]
    public partial bool HandleButtonPress(AtkEvent* atkEvent, AtkEventData.AtkInputData* data, int itemIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 44 24 ?? 83 FB")]
    public partial void PopulateAtkListItemData(AtkEventData.AtkListItemData* dst, AtkEventData.AtkMouseData* src, uint selectedIndex, AtkEventType eventType);

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct ListItem {
        /// <remarks> Used by <see cref="AtkComponentDropDownList"/>. </remarks>
        [FieldOffset(0)] public CStringPointer Label;
        [FieldOffset(0x8)] public AtkComponentListItemRenderer* AtkComponentListItemRenderer;
        [FieldOffset(0x10)] public uint IconId;
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
