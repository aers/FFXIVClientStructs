using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGathering
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Gathering")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x350)]
public unsafe partial struct AddonGathering {
    [FieldOffset(0x230)] public AtkResNode* UnkResNode230;
    [FieldOffset(0x238)] public AtkComponentCheckBox* GatheredItemComponentCheckBox1;
    [FieldOffset(0x240)] public AtkComponentCheckBox* GatheredItemComponentCheckBox2;
    [FieldOffset(0x248)] public AtkComponentCheckBox* GatheredItemComponentCheckBox3;
    [FieldOffset(0x250)] public AtkComponentCheckBox* GatheredItemComponentCheckBox4;
    [FieldOffset(0x258)] public AtkComponentCheckBox* GatheredItemComponentCheckBox5;
    [FieldOffset(0x260)] public AtkComponentCheckBox* GatheredItemComponentCheckBox6;
    [FieldOffset(0x268)] public AtkComponentCheckBox* GatheredItemComponentCheckBox7;
    [FieldOffset(0x270)] public AtkComponentCheckBox* GatheredItemComponentCheckBox8;
    [FieldOffset(0x278)] public AtkComponentGaugeBar* IntegrityGaugeBar;
    [FieldOffset(0x280)] public AtkResNode* UnkResNode280;
    [FieldOffset(0x288)] public AtkTextNode* IntegrityLeftover;
    [FieldOffset(0x290)] public AtkResNode* UnkResNode290;
    [FieldOffset(0x298)] public AtkTextNode* IntegrityTotal;
    [FieldOffset(0x2A0)] public AtkResNode* UnkResNode2A0;
    [FieldOffset(0x2A8)] public AtkTextNode* InventoryQuantityTextNode;
    [FieldOffset(0x2B0)] public AtkResNode* UnkResNode2B0;
    [FieldOffset(0x2B8)] public AtkComponentCheckBox* QuickGatheringComponentCheckBox;
    [FieldOffset(0x2C0)] public AtkResNode* UnkResNode2C0;

    [FieldOffset(0x2E8), FixedSizeArray] internal FixedSizeArray8<uint> _itemFlags;
    [FieldOffset(0x308), FixedSizeArray] internal FixedSizeArray8<uint> _itemIds;

    [FieldOffset(0x330)] public bool TooltipActive;
    [FieldOffset(0x331)] public bool ItemListHovered;

    [FieldOffset(0x335)] public byte GatherStatus; // 1 = UI Open, 2 = Quick Gathering

    // [FieldOffset(0x340)] public AddonMainCross* AddonMainCross;
}
