using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonItemDetailCompare
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("ItemDetailCompare")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x3F0)]
public partial struct AddonItemDetailCompare {
    [FieldOffset(0x238)] public Glamour SelectedItem;
    [FieldOffset(0x310)] public Glamour EquippedItem;
    [FieldOffset(0x3E8)] public short ArrowYOffset;

    [StructLayout(LayoutKind.Explicit, Size = 0xD8)]
    public struct Glamour {
        [FieldOffset(0x0)] public Utf8String ItemName;
        [FieldOffset(0x68)] public Utf8String GlamourName;
        [FieldOffset(0xD0)] public bool ShowGlamour;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x15D0)]
    public struct AtkValuesArray {
        [FieldOffset(0x0000)] public Item SelectedItem;
        [FieldOffset(0x0560)] public Item SelectedItemOtherQuality;
        [FieldOffset(0x0AC0)] public Item EquippedItem;
        [FieldOffset(0x1020)] public Item LeftRing;
        [FieldOffset(0x1580)] public AtkValue SlotName;
        [FieldOffset(0x1590)] public AtkValue QualityToggleHelpText;
        [FieldOffset(0x15A0)] public AtkValue ShowRingSlotToggle;
        [FieldOffset(0x15B0)] public AtkValue RingSlotState;
        [FieldOffset(0x15C0)] public AtkValue CtrlHeld;

        [StructLayout(LayoutKind.Explicit, Size = 0x560)]
        public struct Item {
            [FieldOffset(0x000)] public AtkValue IconId;
            [FieldOffset(0x010)] public AtkValue DyeColor1;
            [FieldOffset(0x020)] public AtkValue DyeColor2;
            [FieldOffset(0x030)] public AtkValue EquippableStateTimelineId;
            [FieldOffset(0x040)] public AtkValue RequiredLevelColor;
            [FieldOffset(0x050), FixedSizeArray] internal FixedSizeArray3<AtkValue> _mainStatDeltaColorTimelineId;
            [FieldOffset(0x080)] public AtkValue BonusStatCount;
            [FieldOffset(0x090)] public AtkValue GreenBonusItemCount;
            [FieldOffset(0x0A0)] public AtkValue BlueMateriaSlotCount;
            [FieldOffset(0x0B0), FixedSizeArray] internal FixedSizeArray5<AtkValue> _materiaGrades;
            [FieldOffset(0x100)] public AtkValue OvercappingMateriaIndexes; // bitfield
            [FieldOffset(0x110)] public AtkValue RepairJobIconId;
            [FieldOffset(0x120)] private AtkValue Unk18;
            [FieldOffset(0x130)] public AtkValue ConditionPercentage;
            [FieldOffset(0x140)] public AtkValue SpiritbondPercentage;
            [FieldOffset(0x150)] public AtkValue Flags;
            [FieldOffset(0x160)] public AtkValue ItemName;
            [FieldOffset(0x170)] public AtkValue GlamName;
            [FieldOffset(0x180)] public AtkValue EquipSlot;
            [FieldOffset(0x190)] public AtkValue InventoryCount;
            [FieldOffset(0x1A0)] public AtkValue ItemLevel;
            [FieldOffset(0x1B0)] public AtkValue EquippableBy;
            [FieldOffset(0x1C0)] public AtkValue EquipLevel;
            [FieldOffset(0x1D0)] public AtkValue ItemSeries;
            [FieldOffset(0x1E0), FixedSizeArray] internal FixedSizeArray3<AtkValue> _primaryStatNames;
            [FieldOffset(0x210), FixedSizeArray] internal FixedSizeArray3<AtkValue> _primaryStatValues;
            [FieldOffset(0x240), FixedSizeArray] internal FixedSizeArray3<AtkValue> _primaryStatDeltas;
            [FieldOffset(0x270)] public AtkValue BonusesLabel;
            [FieldOffset(0x280), FixedSizeArray] internal FixedSizeArray8<AtkValue> _bonusStats;
            [FieldOffset(0x300), FixedSizeArray] internal FixedSizeArray8<AtkValue> _greenBonusItems;
            [FieldOffset(0x380)] private AtkValue Unk56;
            [FieldOffset(0x390), FixedSizeArray] internal FixedSizeArray5<AtkValue> _materiaNames;
            [FieldOffset(0x3E0), FixedSizeArray] internal FixedSizeArray5<AtkValue> _materiaValues;
            [FieldOffset(0x430)] public AtkValue RequirementsHeader;
            [FieldOffset(0x440), FixedSizeArray] internal FixedSizeArray4<AtkValue> _requirementValues;
            [FieldOffset(0x480)] public AtkValue ConditionPercentageString;
            [FieldOffset(0x490)] public AtkValue SpiritbondOrCollectabilityHeader;
            [FieldOffset(0x4A0)] public AtkValue SpiritbondOrCollectabilityValueString;
            [FieldOffset(0x4B0)] private AtkValue Unk75;
            [FieldOffset(0x4C0)] private AtkValue Unk76;
            [FieldOffset(0x4D0)] private AtkValue Unk77;
            [FieldOffset(0x4E0)] private AtkValue Unk78;
            [FieldOffset(0x4F0)] public AtkValue ExtractProjectDesynthString;
            [FieldOffset(0x500)] public AtkValue DyeColors;
            [FieldOffset(0x510)] public AtkValue Marketability;
            [FieldOffset(0x520)] public AtkValue CrafterName;
            [FieldOffset(0x530)] public AtkValue SellPrice;
            [FieldOffset(0x540)] public AtkValue RequiredJobLabel;
            [FieldOffset(0x550)] public AtkValue RequiredJob;
        }
    }
}
