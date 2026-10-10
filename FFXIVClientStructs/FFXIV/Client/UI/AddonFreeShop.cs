using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonFreeShop
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("FreeShop")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1000)]
public unsafe partial struct AddonFreeShop {
    [FieldOffset(0x238)] public AtkComponentList* ItemList;
    [FieldOffset(0x240)] public AtkComponentCheckBox* ShowNewItemsOnlyCheckbox;
    [FieldOffset(0x248)] public AtkComponentDropDownList* ClassJobDropdown;
    [FieldOffset(0x250)] public AtkComponentButton* CurrentClassJobButton;
    [FieldOffset(0x258)] public Utf8String NoItemsText;
    [FieldOffset(0x2C0), FixedSizeArray] internal FixedSizeArray61<Item> _items;
    /// <summary>Points into Items after applying the class/job and new-item filters.</summary>
    [FieldOffset(0xC48), FixedSizeArray] internal FixedSizeArray61<Pointer<Item>> _visibleItems;
    [FieldOffset(0xE30)] public uint ItemCount;
    [FieldOffset(0xE34)] public uint NewItemCount;
    [FieldOffset(0xE38)] public bool ShowNewItemsOnly;
    [FieldOffset(0xE40), FixedSizeArray] internal FixedSizeArray35<CStringPointer> _classJobNames;
    [FieldOffset(0xF58), FixedSizeArray] internal FixedSizeArray35<uint> _classJobIds;
    /// <remarks>0 selects all items. The dropdown entries use ClassJob row IDs.</remarks>
    [FieldOffset(0xFE4)] public uint SelectedClassJobId;
    [FieldOffset(0xFE8)] public uint ClassJobCount;
    /// <summary>Bits refer to dropdown entries</summary>
    [FieldOffset(0xFF0)] public ulong ClassJobMask;
    [FieldOffset(0xFF8)] public uint CurrentClassJobId;

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct Item {
        [FieldOffset(0x00)] public uint ItemId;
        [FieldOffset(0x04)] public uint IconId;
        [FieldOffset(0x08)] public CStringPointer Name;
        [FieldOffset(0x10)] public CStringPointer RequirementText;
        /// <summary>Index into <see cref="AgentFreeShop.Items"/>, preserved when the addon sorts its items.</summary>
        [FieldOffset(0x18)] public int Index;
        [FieldOffset(0x1C)] public uint ClassJobCategoryId;
        [FieldOffset(0x20)] public bool IsOwned;
        [FieldOffset(0x21)] public bool IsUnavailable;
        [FieldOffset(0x23)] public bool IsNew;
    }
}
