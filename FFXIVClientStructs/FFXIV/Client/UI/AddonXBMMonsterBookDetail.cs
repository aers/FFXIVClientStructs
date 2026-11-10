using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonXBMMonsterBookDetail
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("XBMMonsterBookDetail")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x398)]
public unsafe partial struct AddonXBMMonsterBookDetail {
    [FieldOffset(0x298)] public AtkTextNode* EntryNumberText;
    [FieldOffset(0x2A0)] public AtkTextNode* EntryName;
    [FieldOffset(0x2A8)] public AtkImageNode* EntryImage;
    [FieldOffset(0x2B0)] private AtkComponentNode* Unk250;
    [FieldOffset(0x2B8)] public AtkTextNode* EntryClassification;
    [FieldOffset(0x2C0)] public AtkTextNode* EntryBorrowActionName;
    [FieldOffset(0x2C8)] public AtkComponentIcon* EntryBorrowComponentIcon;
    [FieldOffset(0x2D0)] public AtkTextNode* EntryAutoAttackType;
    [FieldOffset(0x2D8)] public StdVector<Pointer<AtkComponentBase>> EntryBeastActionsComponents;
    [FieldOffset(0x2F0)] public AtkTextNode* EntryAreaLocation;
    [FieldOffset(0x2F8)] public AtkTextNode* EntryDescription;
    [FieldOffset(0x300)] public AtkTextNode* EntryHabitat;
    [FieldOffset(0x308)] public AtkTextNode* EntryHPCount;
    [FieldOffset(0x310)] public AtkTextNode* EntryExpCount;
    [FieldOffset(0x318)] public AtkComponentGaugeBar* EntryExpGaugeBar;
    [FieldOffset(0x320)] public AtkTextNode* EntrySatietyCount;
    [FieldOffset(0x328)] public AtkTextNode* EntryStrengthHeader;
    [FieldOffset(0x330)] public AtkTextNode* EntryStrengthCount;
    [FieldOffset(0x338)] public AtkTextNode* EntryPhysicalResistanceHeader;
    [FieldOffset(0x340)] public AtkTextNode* EntryPhysicalResistanceCount;
    [FieldOffset(0x348)] public AtkTextNode* EntryConstitutionHeader;
    [FieldOffset(0x350)] public AtkTextNode* EntryConstitutionCount;
    [FieldOffset(0x358)] public AtkTextNode* EntryIngelligenceHeader;
    [FieldOffset(0x360)] public AtkTextNode* EntryIngelligenceCount;
    [FieldOffset(0x368)] public AtkTextNode* EntryMagicalResistanceHeader;
    [FieldOffset(0x370)] public AtkTextNode* EntryMagicalResistanceCount;
    [FieldOffset(0x380)] public StdVector<Pointer<AtkComponentButton>> EntryEquipedItemsSlots;

}
