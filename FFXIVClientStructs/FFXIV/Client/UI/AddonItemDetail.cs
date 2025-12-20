using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonItemDetail
//   Client::UI::AddonItemDetailBase
//     Component::GUI::AtkUnitBase
//       Component::GUI::AtkEventListener
[Addon("ItemDetail")]
[GenerateInterop]
[Inherits<AddonItemDetailBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x7C0)]
public unsafe partial struct AddonItemDetail {
    [FieldOffset(0x240)] public Utf8String ItemName;
    [FieldOffset(0x2A8)] public Utf8String GlamourItemName;
    /// <remarks> Set to <see langword="true"/> when <see cref="ItemName"/> is displayed, or to <see langword="false"/> when <see cref="GlamourItemName"/> is shown. </remarks>
    [FieldOffset(0x310)] public bool DisplayingItemName;

    /// <summary> Cast/Recast, Defense, Magic Defense </summary>
    [FieldOffset(0x318)] public AtkResNode* HeaderStatsGroup;
    [FieldOffset(0x320)] public AtkComponentNode* MagicDefenseComponentNode;
    [FieldOffset(0x328)] public AtkComponentNode* DefenseComponentNode;
    [FieldOffset(0x330)] public AtkComponentNode* CastComponentNode;
    [FieldOffset(0x338)] public AtkTextNode* MagicDefenseTitle;
    [FieldOffset(0x340)] public AtkTextNode* DefenseTitle;
    [FieldOffset(0x348)] public AtkTextNode* CastTitle;
    [FieldOffset(0x350)] public AtkTextNode* MagicDefenseValue;
    [FieldOffset(0x358)] public AtkTextNode* DefenseValue;
    [FieldOffset(0x360)] public AtkTextNode* CastValue;
    [FieldOffset(0x368)] public AtkTextNode* MagicDefenseDifference;
    [FieldOffset(0x370)] public AtkTextNode* DefenseDifference;
    [FieldOffset(0x378)] public AtkTextNode* CastDifference;
    [FieldOffset(0x380)] public AtkResNode* ControlHints;
    [FieldOffset(0x388)] public AtkComponentTextNineGrid* ControlHintsTextNineGrid;

    [FieldOffset(0x398)] private AtkResNode* RootNodeAgain;
    [FieldOffset(0x3A0)] private AtkCollisionNode* Unk3A0;
    [FieldOffset(0x3A8)] private AtkCollisionNode* Unk3A8;
    [FieldOffset(0x3B0)] public AtkResNode* HeaderGroup;
    [FieldOffset(0x3B8)] public AtkTextNode* ItemNameText;
    [FieldOffset(0x3C0)] public AtkTextNode* CategoryText;
    [FieldOffset(0x3C8)] private AtkComponentIcon* ItemIcon;
    [FieldOffset(0x3D0)] public AtkTextNode* UniqueText;
    [FieldOffset(0x3D8)] public AtkTextNode* BindingText;
    [FieldOffset(0x3E0)] public AtkTextNode* UntradableText;
    [FieldOffset(0x3E8)] public AtkTextNode* QuantityText;
    [FieldOffset(0x3F0)] public AtkResNode* HeaderIconsGroup;
    [FieldOffset(0x3F8)] public AtkResNode* FcCrestIconGroup;
    [FieldOffset(0x400)] public AtkResNode* GlamourDresserIconGroup;
    [FieldOffset(0x408)] public AtkResNode* ArmoireIconGroup;
    [FieldOffset(0x410)] public AtkResNode* CollectedImageGroup;
    [FieldOffset(0x418)] public AtkResNode* MarketableGroup;
    [FieldOffset(0x420)] public AtkTextNode* MarketableText;
    [FieldOffset(0x428)] public AtkResNode* DescriptionGroup;
    [FieldOffset(0x430)] public AtkTextNode* DescriptionText;
    [FieldOffset(0x438)] public AtkTextNode* CrafterNameText;
    [FieldOffset(0x440)] public AtkResNode* ShopSellingPriceGroup;
    [FieldOffset(0x448)] public AtkTextNode* ShopSellingPriceText;
    [FieldOffset(0x450)] public AtkTextNode* CooldownText;
    [FieldOffset(0x458)] public AtkResNode* EffectsGroup;
    [FieldOffset(0x460)] public AtkTextNode* EffectsTitle;
    [FieldOffset(0x468)] public AtkTextNode* EffectsDescription;
    // nodes for Proof of Covering. didn't check in-depth
    [FieldOffset(0x470)] public AtkResNode* FledglingGroup;
    [FieldOffset(0x478)] public AtkTextNode* FledglingTitle;
    [FieldOffset(0x480)] public AtkResNode* AdoptionDateGroup;
    [FieldOffset(0x488)] public AtkTextNode* AdoptionDateLabel;
    [FieldOffset(0x490)] public AtkTextNode* AdoptionDateValue;
    [FieldOffset(0x498)] private AtkResNode* Unk498;
    [FieldOffset(0x4A0)] private AtkTextNode* Unk4A0;
    [FieldOffset(0x4A8)] private AtkTextNode* Unk4A8;
    /// <summary> Spiritbond and Condition bars, FC Crest icon </summary>
    [FieldOffset(0x4B0)] public AtkResNode* SpiritbondConditionCrestGroup;
    [FieldOffset(0x4B8)] public AtkResNode* SpiritbondGroup;
    [FieldOffset(0x4C0)] public AtkImageNode* SpiritbondImage;
    [FieldOffset(0x4C8)] public AtkResNode* ConditionGroup;
    [FieldOffset(0x4D0)] public AtkImageNode* ConditionImage;
    /// <summary> ItemLevel, ClassJobCategory, Level </summary>
    [FieldOffset(0x4D8)] public AtkResNode* EquipRestrictionGroup;
    [FieldOffset(0x4E0)] public AtkTextNode* ItemLevelText;
    [FieldOffset(0x4E8)] public AtkComponentNode* ClassJobCategoryGroup;
    [FieldOffset(0x4F0)] public AtkTextNode* ClassJobCategoryText;
    [FieldOffset(0x4F8)] public AtkComponentNode* LevelGroup;
    [FieldOffset(0x500)] public AtkTextNode* LevelText;
    [FieldOffset(0x508)] private AtkComponentNode* Unk508Group; // third line?
    [FieldOffset(0x510)] private AtkTextNode* Unk510Text;
    [FieldOffset(0x518)] public AtkResNode* CraftingAndRepairsGroup;
    [FieldOffset(0x520)] public AtkImageNode* CraftingAndRepairsIcon;
    [FieldOffset(0x528)] public AtkTextNode* CraftingAndRepairsTitle;
    [FieldOffset(0x530)] public AtkResNode* ConditionLine;
    [FieldOffset(0x538)] public AtkTextNode* ConditionValue;
    [FieldOffset(0x540)] public AtkResNode* SpiritbondLine;
    [FieldOffset(0x548)] public AtkTextNode* SpiritbondLabel;
    [FieldOffset(0x550)] public AtkTextNode* SpiritbondValue;
    [FieldOffset(0x558)] public AtkResNode* RepairLine;
    [FieldOffset(0x560)] public AtkTextNode* RepairValue;
    [FieldOffset(0x568)] public AtkResNode* MaterialsLine;
    [FieldOffset(0x570)] public AtkTextNode* MaterialsValue;
    [FieldOffset(0x578)] public AtkResNode* QuickRepairsLine;
    [FieldOffset(0x580)] public AtkTextNode* QuickRepairsValue;
    [FieldOffset(0x588)] public AtkResNode* AffixMateriaLine;
    [FieldOffset(0x590)] public AtkTextNode* AffixMateriaValue;
    /// <summary> Extractable / Projectable / Desynthesizable </summary>
    [FieldOffset(0x598)] public AtkTextNode* MaterializeText;

    [FieldOffset(0x5A8)] public AtkResNode* MateriaGroup;
    [FieldOffset(0x5B0)] public AtkTextNode* MateriaTitle;
    [FieldOffset(0x5B8), FixedSizeArray] internal FixedSizeArray5<MateriaEntry> _materiaLines;

    [FieldOffset(0x6B0)] public AtkResNode* BonusesGroup;
    [FieldOffset(0x6B8)] public AtkTextNode* BonusesTitle;
    [FieldOffset(0x6C0), FixedSizeArray] internal FixedSizeArray4<BonusEntry> _bonuses;
    // [FieldOffset(0x720), FixedSizeArray] internal FixedSizeArray6<same size as BonusEntry> _unk; // not sure what this is, but it's set in the same function as Bonuses
    // remove these when array is known:
    [FieldOffset(0x720)] private AtkComponentNode* Unk720;
    [FieldOffset(0x728)] private AtkTextNode* Unk728;
    [FieldOffset(0x730)] private AtkTextNode* Unk730;
    [FieldOffset(0x738)] private AtkComponentNode* Unk738;
    [FieldOffset(0x740)] private AtkTextNode* Unk740;
    [FieldOffset(0x748)] private AtkTextNode* Unk748;
    [FieldOffset(0x750)] private AtkComponentNode* Unk750;
    [FieldOffset(0x758)] private AtkTextNode* Unk758;
    [FieldOffset(0x760)] private AtkTextNode* Unk760;
    [FieldOffset(0x768)] private AtkComponentNode* Unk768;
    [FieldOffset(0x770)] private AtkTextNode* Unk770;
    [FieldOffset(0x778)] private AtkTextNode* Unk778;
    [FieldOffset(0x780)] private AtkComponentNode* Unk780;
    [FieldOffset(0x788)] private AtkTextNode* Unk788;
    [FieldOffset(0x790)] private AtkTextNode* Unk790;
    [FieldOffset(0x798)] private AtkComponentNode* Unk798;
    [FieldOffset(0x7A0)] private AtkTextNode* Unk7A0;
    [FieldOffset(0x7A8)] private AtkTextNode* Unk7A8;
    [FieldOffset(0x7B4)] public short OffsetX;
    [FieldOffset(0x7B6)] public short OffsetY;

    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 45 ?? 83 F8 ?? 77 ?? ?? ?? ?? 48 8B CF")]
    public partial void UpdateGroupPositions(NumberArrayData* numberArray, StringArrayData* stringArray);

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public struct MateriaEntry {
        [FieldOffset(0x00)] public AtkComponentBase* Group;
        [FieldOffset(0x08)] public AtkImageNode* SlotImage;
        [FieldOffset(0x10)] public AtkImageNode* SlotBorderImage;
        [FieldOffset(0x18)] public AtkResNode* TextGroup;
        [FieldOffset(0x20)] public AtkTextNode* Label;
        [FieldOffset(0x28)] public AtkTextNode* Value;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct BonusEntry {
        [FieldOffset(0x00)] public AtkComponentNode* LineComponentNode;
        [FieldOffset(0x08)] public AtkTextNode* LeftText;
        [FieldOffset(0x10)] public AtkTextNode* RightText;
    }
}
