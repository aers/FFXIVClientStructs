using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGathering
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Gathering")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x358)]
public unsafe partial struct AddonGathering {
    [FieldOffset(0x238)] public AtkResNode* UnkResNode230;
    [FieldOffset(0x240), Obsolete("Use GatheredItemComponentCheckbox[0]")] public AtkComponentCheckBox* GatheredItemComponentCheckBox1;
    [FieldOffset(0x248), Obsolete("Use GatheredItemComponentCheckbox[1]")] public AtkComponentCheckBox* GatheredItemComponentCheckBox2;
    [FieldOffset(0x250), Obsolete("Use GatheredItemComponentCheckbox[2]")] public AtkComponentCheckBox* GatheredItemComponentCheckBox3;
    [FieldOffset(0x258), Obsolete("Use GatheredItemComponentCheckbox[3]")] public AtkComponentCheckBox* GatheredItemComponentCheckBox4;
    [FieldOffset(0x260), Obsolete("Use GatheredItemComponentCheckbox[4]")] public AtkComponentCheckBox* GatheredItemComponentCheckBox5;
    [FieldOffset(0x268), Obsolete("Use GatheredItemComponentCheckbox[5]")] public AtkComponentCheckBox* GatheredItemComponentCheckBox6;
    [FieldOffset(0x270), Obsolete("Use GatheredItemComponentCheckbox[6]")] public AtkComponentCheckBox* GatheredItemComponentCheckBox7;
    [FieldOffset(0x278), Obsolete("Use GatheredItemComponentCheckbox[7]")] public AtkComponentCheckBox* GatheredItemComponentCheckBox8;
    [FieldOffset(0x240), FixedSizeArray] internal FixedSizeArray8<Pointer<AtkComponentCheckBox>> _gatheredItemComponentCheckbox;
    [FieldOffset(0x280)] public AtkComponentGaugeBar* IntegrityGaugeBar;
    [FieldOffset(0x288)] public AtkResNode* UnkResNode280;
    [FieldOffset(0x290)] public AtkTextNode* IntegrityLeftover;
    [FieldOffset(0x298)] public AtkResNode* UnkResNode290;
    [FieldOffset(0x2A0)] public AtkTextNode* IntegrityTotal;
    [FieldOffset(0x2A8)] public AtkResNode* UnkResNode2A0;
    [FieldOffset(0x2B0)] public AtkTextNode* InventoryQuantityTextNode;
    [FieldOffset(0x2B8)] public AtkResNode* UnkResNode2B0;
    [FieldOffset(0x2C0)] public AtkComponentCheckBox* QuickGatheringComponentCheckBox;
    [FieldOffset(0x2C8)] public AtkResNode* UnkResNode2C0;

    [FieldOffset(0x2F0), FixedSizeArray] internal FixedSizeArray8<uint> _itemFlags;
    [FieldOffset(0x310), FixedSizeArray] internal FixedSizeArray8<uint> _itemIds;

    [FieldOffset(0x338)] public bool TooltipActive;
    [FieldOffset(0x339)] public bool ItemListHovered;

    [FieldOffset(0x33D)] public byte GatherStatus; // 1 = UI Open, 2 = Quick Gathering

    // [FieldOffset(0x348)] public AddonMainCross* AddonMainCross;
}
