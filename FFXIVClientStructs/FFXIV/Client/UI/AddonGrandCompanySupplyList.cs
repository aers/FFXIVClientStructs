using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGrandCompanySupplyList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GrandCompanySupplyList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x308)]
public unsafe partial struct AddonGrandCompanySupplyList {
    [FieldOffset(0x290)] public AtkComponentList* SupplyProvisioningList;
    [FieldOffset(0x298)] public AtkComponentList* ExpertDeliveryList;

    [FieldOffset(0x2B0)] public AtkComponentRadioButton* SupplyRadioButton;
    [FieldOffset(0x2B8)] public AtkComponentRadioButton* ProvisioningRadioButton;
    [FieldOffset(0x2C0)] public AtkComponentRadioButton* ExpertDeliveryRadioButton;

    [FieldOffset(0x2D0)] public AtkTextNode* NextMissionAllowanceTextNode;
    [FieldOffset(0x2D8)] public AtkTextNode* ListEmptyTextNode;

    [FieldOffset(0x2A0)] public AtkComponentDropDownList* SortByDropdown;
    [FieldOffset(0x2A8)] public AtkComponentDropDownList* FilterDropdown;

    [FieldOffset(0x2E0)] public AtkTextNode* SealCountTextNode; // Contains "54,121/90,000" text
    [FieldOffset(0x2E8)] public AtkImageNode* SealIconNode;

    [FieldOffset(0x2F8)] public int SelectedTab;
    [FieldOffset(0x2FC)] public int SelectedSortBy;
    [FieldOffset(0x300)] public int SelectedFilter;
}
