using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonXBMMonsterBookDetail
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("XBMMonsterBookDetail")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x3C0)]
public unsafe partial struct AddonXBMMonsterBookDetail {
    [FieldOffset(0x238)] public AtkTextNode* EntryNumberText;
    [FieldOffset(0x240)] public AtkTextNode* EntryName;
    [FieldOffset(0x248)] public AtkImageNode* EntryImage;
    [FieldOffset(0x250)] private AtkComponentNode* Unk250;
    [FieldOffset(0x258)] public AtkTextNode* EntryClassification;
    [FieldOffset(0x260)] public AtkTextNode* EntryBorrowActionName;
    [FieldOffset(0x268)] public AtkComponentIcon* EntryBorrowComponentIcon;
    [FieldOffset(0x270)] public AtkTextNode* EntryAutoAttackType;
    [FieldOffset(0x278)] public StdVector<Pointer<AtkComponentBase>> EntryBeastActionsComponents;
    [FieldOffset(0x290)] public AtkTextNode* EntryAreaLocation;
    [FieldOffset(0x298)] public AtkTextNode* EntryDescription;
    [FieldOffset(0x2A0)] public AtkTextNode* EntryHabitat;
    [FieldOffset(0x2A8)] public AtkTextNode* EntryHPCount;
    [FieldOffset(0x2B0)] public AtkTextNode* EntryExpCount;
    [FieldOffset(0x2B8)] public AtkComponentGaugeBar* EntryExpGaugeBar;
    [FieldOffset(0x2C0)] public AtkTextNode* EntrySatietyCount;
    [FieldOffset(0x2C8)] public AtkTextNode* EntryStrengthHeader;
    [FieldOffset(0x2D0)] public AtkTextNode* EntryStrengthCount;
    [FieldOffset(0x2D8)] public AtkTextNode* EntryPhysicalResistanceHeader;
    [FieldOffset(0x2E0)] public AtkTextNode* EntryPhysicalResistanceCount;
    [FieldOffset(0x2E8)] public AtkTextNode* EntryConstitutionHeader;
    [FieldOffset(0x2F0)] public AtkTextNode* EntryConstitutionCount;
    [FieldOffset(0x2F8)] public AtkTextNode* EntryIngelligenceHeader;
    [FieldOffset(0x300)] public AtkTextNode* EntryIngelligenceCount;
    [FieldOffset(0x308)] public AtkTextNode* EntryMagicalResistanceHeader;
    [FieldOffset(0x310)] public AtkTextNode* EntryMagicalResistanceCount;
    [FieldOffset(0x318)] public StdVector<Pointer<AtkComponentButton>> EntryEquipedItemsSlots;

}
