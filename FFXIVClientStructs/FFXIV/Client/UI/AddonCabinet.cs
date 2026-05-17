using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonCabinet
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Cabinet")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x4B88)]
public unsafe partial struct AddonCabinet {
    // Count of populated slots = NumberArrayData[0x30][0]. Slots past that count are stale.
    [FieldOffset(0x238), FixedSizeArray] internal FixedSizeArray140<ItemSlot> _itemSlots;

    // Category names shown in the dropdown, populated from AtkValue args on setup.
    [FieldOffset(0x4838), FixedSizeArray] internal FixedSizeArray7<Utf8String> _categoryNames;

    [FieldOffset(0x4B10)] public AtkComponentList* ItemList;
    [FieldOffset(0x4B18)] public AtkResNode* TimelineNode;
    [FieldOffset(0x4B28)] public AtkComponentDropDownList* CategoryDropDown;
    [FieldOffset(0x4B58)] public AtkComponentButton* CloseButton;
    [FieldOffset(0x4B60)] public uint CategoryIndex;               // 0xFFFFFFFF until first render

    [StructLayout(LayoutKind.Explicit, Size = 0x80)]
    public struct ItemSlot {
        [FieldOffset(0x00)] public Utf8String Name;
        [FieldOffset(0x68)] public uint Unk68;                  // ItemCache.Unk74; fed to image node renderer
        [FieldOffset(0x6C)] public uint InventorySlotIndex;     // slot index within the found InventoryContainer
        [FieldOffset(0x70)] public uint InventoryContainerType; // InventoryType where the item is held/equipped
        [FieldOffset(0x74)] public uint ItemsArrayIndex;        // index into AgentCabinet.Items[]
        [FieldOffset(0x78)] public float ConditionNormalized;   // item condition as Condition / 30000f
    }
}
