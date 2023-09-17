using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("GoldSaucerInfo")]
[StructLayout(LayoutKind.Explicit, Size = 0x310)]
public unsafe partial struct AddonGoldSaucerInfo {
    [FieldOffset(0x00)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x220)] public int SelectedCategory;
    [FieldOffset(0x224)] public int SelectedSubCategory;

    [FixedSizeArray<Pointer<AtkComponentRadioButton>>(6)]
    [FieldOffset(0x2A0)] public fixed byte CategoryRadioButtons[0x8 * 6]; // General/Chocobo/CardList/CardDecks/Verminion/Mahjong


    [FixedSizeArray<Pointer<AtkComponentRadioButton>>(3)]
    [FieldOffset(0x2D0)] public fixed byte ChocoboRadioButtons[0x8 * 3]; // Parameters/Pedigree/Appearance

    [FieldOffset(0x2E8)] public AtkCollisionNode* ContentsSection;
    [FieldOffset(0x2F8)] public AtkResNode* ChocoboPetInfo;
    [FieldOffset(0x300)] public AtkNineGridNode* ChocoboPetExpBar;
    [FieldOffset(0x308)] public int ChocoboPetExpBarWidth;
}
