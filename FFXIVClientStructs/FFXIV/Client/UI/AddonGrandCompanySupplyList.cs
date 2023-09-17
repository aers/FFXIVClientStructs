using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("GrandCompanySupplyList")]
[StructLayout(LayoutKind.Explicit, Size = 0x760)]
public unsafe struct AddonGrandCompanySupplyList {
    [FieldOffset(0x00)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x280)] public AtkComponentList* SupplyProvisioningList;
    [FieldOffset(0x288)] public AtkComponentList* ExpertDeliveryList;

    [FieldOffset(0x2A0)] public AtkComponentRadioButton* SupplyRadioButton;
    [FieldOffset(0x2A8)] public AtkComponentRadioButton* ProvisioningRadioButton;
    [FieldOffset(0x2B0)] public AtkComponentRadioButton* ExpertDeliveryRadioButton;

    [FieldOffset(0x2C0)] public AtkTextNode* NextMissionAllowanceTextNode;
    [FieldOffset(0x2C8)] public AtkTextNode* ListEmptyTextNode;

    [FieldOffset(0x290)] public AtkComponentDropDownList* SortByDropdown;
    [FieldOffset(0x298)] public AtkComponentDropDownList* FilterDropdown;

    [FieldOffset(0x2D0)] public AtkTextNode* SealCountTextNode; // Contains "54,121/90,000" text
    [FieldOffset(0x2D8)] public AtkImageNode* SealIconNode;

    [FieldOffset(0x2E8)] public int SelectedTab;
    [FieldOffset(0x2EC)] public int SelectedSortBy;
    [FieldOffset(0x2F0)] public int SelectedFilter;

}
