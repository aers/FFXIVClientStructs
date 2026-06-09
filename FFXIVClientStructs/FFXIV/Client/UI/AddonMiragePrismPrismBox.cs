using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMiragePrismPrismBox
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("MiragePrismPrismBox")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1440)]
public unsafe partial struct AddonMiragePrismPrismBox {
    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public struct ItemSlot {
        [FieldOffset(0x00)] public AtkComponentButton* Button;
        [FieldOffset(0x08)] public AtkImageNode* SlotIcon;
        [FieldOffset(0x10)] public AtkResNode* Dye1Res;
        [FieldOffset(0x18)] public AtkImageNode* Dye1Image;
        [FieldOffset(0x20)] public AtkResNode* Dye2Res;
        [FieldOffset(0x28)] public AtkImageNode* Dye2Image;
        [FieldOffset(0x30)] public AtkResNode* SlotRes;
        [FieldOffset(0x38)] public AtkResNode* OutfitGlamour;
        [FieldOffset(0x40)] public AtkResNode* OutfitItemAmountRes;
        [FieldOffset(0x48)] public AtkTextNode* OutfitItemAmountResText;
    }

    [FieldOffset(0x238), FixedSizeArray] internal FixedSizeArray50<ItemSlot> _itemSlots;

    [FieldOffset(0x11E8)] public AtkComponentButton* PrevButton;
    [FieldOffset(0x11F0)] public AtkComponentButton* NextButton;
    [FieldOffset(0x11F8)] public AtkComponentButton* EditGlamourPlatesButton;

    [FieldOffset(0x1200)] private AtkResNode* Unk1200;
    [FieldOffset(0x1208)] private AtkTextNode* Unk1208;
    [FieldOffset(0x1210)] public AtkTextNode* UsedSlotsText;
    [FieldOffset(0x1218)] public AtkTextNode* CategoryLabelText;
    [FieldOffset(0x1220)] public AtkImageNode* CategoryIcon;
    [FieldOffset(0x1228)] public AtkComponentWindow* WindowComponent;
    [FieldOffset(0x1230)] public AtkResNode* SlotsContentNode;

    [FieldOffset(0x1238)] public AtkComponentDropDownList* JobDropdown;

    [FieldOffset(0x1240)] public AtkResNode* FilterNode;
    [FieldOffset(0x1248)] public AtkComponentBase* FilterButton;
    [FieldOffset(0x1250)] public AtkComponentTextInput* SearchInput;
    [FieldOffset(0x1258)] public AtkResNode* SearchBar;

    [FieldOffset(0x1260)] public AtkComponentDropDownList* OrderDropdown;

    [FieldOffset(0x1268)] public AtkComponentButton* GuideButton;

    [FieldOffset(0x1270), FixedSizeArray] internal FixedSizeArray13<Pointer<AtkComponentRadioButton>> _slotTabs;

    [FieldOffset(0x12D8)] private uint Unk12D8;
    [FieldOffset(0x12DC)] public uint SelectedTabIndex;

    [FieldOffset(0x12E0), FixedSizeArray] internal FixedSizeArray35<CStringPointer> _jobLabels;

    [FieldOffset(0x13F8), FixedSizeArray] internal FixedSizeArray35<byte> _jobIds;

    [FieldOffset(0x1420), FixedSizeArray] internal FixedSizeArray2<CStringPointer> _orderLabels;
}
