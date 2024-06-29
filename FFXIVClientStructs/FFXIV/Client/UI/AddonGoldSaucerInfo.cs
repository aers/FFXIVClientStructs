using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGoldSaucerInfo
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GoldSaucerInfo")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x320)]
public unsafe partial struct AddonGoldSaucerInfo {
    [FieldOffset(0x230)] public int SelectedCategory;
    [FieldOffset(0x234)] public int SelectedSubCategory;

    [FieldOffset(0x240)] public AtkAddonControl AddonControl;

    [FieldOffset(0x2B0), FixedSizeArray] internal FixedSizeArray6<Pointer<AtkComponentRadioButton>> _categoryRadioButtons; // General/Chocobo/CardList/CardDecks/Verminion/Mahjong

    [FieldOffset(0x2E0), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentRadioButton>> _chocoboRadioButtons; // Parameters/Pedigree/Appearance

    [FieldOffset(0x2F8)] public AtkCollisionNode* ContentsSection;
    [FieldOffset(0x308)] public AtkResNode* ChocoboPetInfo;
    [FieldOffset(0x310)] public AtkNineGridNode* ChocoboPetExpBar;
    [FieldOffset(0x318)] public int ChocoboPetExpBarWidth;
}
