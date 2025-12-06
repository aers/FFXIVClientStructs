using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonItemDetailCompare
//   Client::UI::AddonItemDetailBase
//     Component::GUI::AtkUnitBase
//       Component::GUI::AtkEventListener
[Addon("ItemDetailCompare")]
[GenerateInterop]
[Inherits<AtkUnitBase>] // TODO: inherit from AddonItemDetailBase
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
    public partial struct AtkValuesArray {
        [FieldOffset(ComparedItem.StructSize * 0)] public ComparedItem SelectedItem;
        [FieldOffset(ComparedItem.StructSize * 1)] public ComparedItem SelectedItemOtherQuality;
        [FieldOffset(ComparedItem.StructSize * 2)] public ComparedItem EquippedItem;
        [FieldOffset(ComparedItem.StructSize * 3)] public ComparedItem LeftRing;
        [FieldOffset(ComparedItem.StructSize * 4 + AtkValue.StructSize * 0)] public AtkValue SlotName;
        [FieldOffset(ComparedItem.StructSize * 4 + AtkValue.StructSize * 1)] public AtkValue QualityToggleHelpText;
        [FieldOffset(ComparedItem.StructSize * 4 + AtkValue.StructSize * 2)] public AtkValue ShowRingSlotToggle;
        [FieldOffset(ComparedItem.StructSize * 4 + AtkValue.StructSize * 3)] public AtkValue RingSlotState;
        [FieldOffset(ComparedItem.StructSize * 4 + AtkValue.StructSize * 4)] public AtkValue CtrlHeld;

        [GenerateInterop]
        [StructLayout(LayoutKind.Explicit, Size = 0x560)]
        public partial struct ComparedItem {
            [FieldOffset(AtkValue.StructSize * 0)] public AtkValue IconId;
            [FieldOffset(AtkValue.StructSize * 1)] public AtkValue DyeColor1;
            [FieldOffset(AtkValue.StructSize * 2)] public AtkValue DyeColor2;
            [FieldOffset(AtkValue.StructSize * 3)] public AtkValue EquippableStateTimelineId;
            [FieldOffset(AtkValue.StructSize * 4)] public AtkValue RequiredLevelColor;
            [FieldOffset(AtkValue.StructSize * 5), FixedSizeArray] internal FixedSizeArray3<AtkValue> _mainStatDeltaColorTimelineId;
            [FieldOffset(AtkValue.StructSize * 8)] public AtkValue BonusStatCount;
            [FieldOffset(AtkValue.StructSize * 9)] public AtkValue GreenBonusItemCount;
            [FieldOffset(AtkValue.StructSize * 10)] public AtkValue BlueMateriaSlotCount;
            [FieldOffset(AtkValue.StructSize * 11), FixedSizeArray] internal FixedSizeArray5<AtkValue> _materiaGrades;
            /// <remark>
            ///  Bitfield of booleans, where bit index maps to materia slot index
            /// </remark>
            [FieldOffset(AtkValue.StructSize * 16)] public AtkValue OvercappingMateriaIndexes;
            [FieldOffset(AtkValue.StructSize * 17)] public AtkValue RepairJobIconId;
            [FieldOffset(AtkValue.StructSize * 18)] private AtkValue Unk18;
            [FieldOffset(AtkValue.StructSize * 19)] public AtkValue ConditionPercentage;
            [FieldOffset(AtkValue.StructSize * 20)] public AtkValue SpiritbondPercentage;
            [FieldOffset(AtkValue.StructSize * 21)] public AtkValue Flags;
            [FieldOffset(AtkValue.StructSize * 22)] public AtkValue ItemName;
            [FieldOffset(AtkValue.StructSize * 23)] public AtkValue GlamName;
            [FieldOffset(AtkValue.StructSize * 24)] public AtkValue EquipSlot;
            [FieldOffset(AtkValue.StructSize * 25)] public AtkValue InventoryCount;
            [FieldOffset(AtkValue.StructSize * 26)] public AtkValue ItemLevel;
            [FieldOffset(AtkValue.StructSize * 27)] public AtkValue EquippableBy;
            [FieldOffset(AtkValue.StructSize * 28)] public AtkValue EquipLevel;
            [FieldOffset(AtkValue.StructSize * 29)] public AtkValue ItemSeries;
            [FieldOffset(AtkValue.StructSize * 30), FixedSizeArray] internal FixedSizeArray3<AtkValue> _primaryStatNames;
            [FieldOffset(AtkValue.StructSize * 33), FixedSizeArray] internal FixedSizeArray3<AtkValue> _primaryStatValues;
            [FieldOffset(AtkValue.StructSize * 36), FixedSizeArray] internal FixedSizeArray3<AtkValue> _primaryStatDeltas;
            [FieldOffset(AtkValue.StructSize * 39)] public AtkValue BonusesLabel;
            [FieldOffset(AtkValue.StructSize * 40), FixedSizeArray] internal FixedSizeArray8<AtkValue> _bonusStats;
            [FieldOffset(AtkValue.StructSize * 48), FixedSizeArray] internal FixedSizeArray8<AtkValue> _greenBonusItems;
            [FieldOffset(AtkValue.StructSize * 56)] private AtkValue Unk56;
            [FieldOffset(AtkValue.StructSize * 57), FixedSizeArray] internal FixedSizeArray5<AtkValue> _materiaNames;
            [FieldOffset(AtkValue.StructSize * 62), FixedSizeArray] internal FixedSizeArray5<AtkValue> _materiaValues;
            [FieldOffset(AtkValue.StructSize * 67)] public AtkValue RequirementsHeader;
            [FieldOffset(AtkValue.StructSize * 68), FixedSizeArray] internal FixedSizeArray4<AtkValue> _requirementValues;
            [FieldOffset(AtkValue.StructSize * 72)] public AtkValue ConditionPercentageString;
            [FieldOffset(AtkValue.StructSize * 73)] public AtkValue SpiritbondOrCollectabilityHeader;
            [FieldOffset(AtkValue.StructSize * 74)] public AtkValue SpiritbondOrCollectabilityValueString;
            [FieldOffset(AtkValue.StructSize * 75)] private AtkValue Unk75;
            [FieldOffset(AtkValue.StructSize * 76)] private AtkValue Unk76;
            [FieldOffset(AtkValue.StructSize * 77)] private AtkValue Unk77;
            [FieldOffset(AtkValue.StructSize * 78)] private AtkValue Unk78;
            [FieldOffset(AtkValue.StructSize * 79)] public AtkValue ExtractProjectDesynthString;
            [FieldOffset(AtkValue.StructSize * 80)] public AtkValue DyeColors;
            [FieldOffset(AtkValue.StructSize * 81)] public AtkValue Marketability;
            [FieldOffset(AtkValue.StructSize * 82)] public AtkValue CrafterName;
            [FieldOffset(AtkValue.StructSize * 83)] public AtkValue SellPrice;
            [FieldOffset(AtkValue.StructSize * 84)] public AtkValue RequiredJobLabel;
            [FieldOffset(AtkValue.StructSize * 85)] public AtkValue RequiredJob;
        }
    }
}
