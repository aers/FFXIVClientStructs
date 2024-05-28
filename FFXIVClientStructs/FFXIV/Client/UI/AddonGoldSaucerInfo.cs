using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("GoldSaucerInfo")]
[GenerateInterop, Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x310)]
public unsafe partial struct AddonGoldSaucerInfo {
    [FieldOffset(0x220)] public int SelectedCategory;
    [FieldOffset(0x224)] public int SelectedSubCategory;

    [FieldOffset(0x230)] public AtkAddonControl AddonControl;

    [FieldOffset(0x2A0), FixedSizeArray] internal FixedSizeArray6<Pointer<AtkComponentRadioButton>> _categoryRadioButtons; // General/Chocobo/CardList/CardDecks/Verminion/Mahjong

    [FieldOffset(0x2D0), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentRadioButton>> _chocoboRadioButtons; // Parameters/Pedigree/Appearance

    [FieldOffset(0x2E8)] public AtkCollisionNode* ContentsSection;
    [FieldOffset(0x2F8)] public AtkResNode* ChocoboPetInfo;
    [FieldOffset(0x300)] public AtkNineGridNode* ChocoboPetExpBar;
    [FieldOffset(0x308)] public int ChocoboPetExpBarWidth;
}
