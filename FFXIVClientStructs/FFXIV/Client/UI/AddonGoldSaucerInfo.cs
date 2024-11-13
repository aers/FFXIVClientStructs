using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGoldSaucerInfo
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GoldSaucerInfo")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x328)]
public unsafe partial struct AddonGoldSaucerInfo {
    [FieldOffset(0x238)] public int SelectedCategory;
    [FieldOffset(0x23C)] public int SelectedSubCategory;

    [FieldOffset(0x248)] public AtkAddonControl AddonControl;

    [FieldOffset(0x2B8), FixedSizeArray] internal FixedSizeArray6<Pointer<AtkComponentRadioButton>> _categoryRadioButtons; // General/Chocobo/CardList/CardDecks/Verminion/Mahjong

    [FieldOffset(0x2E8), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentRadioButton>> _chocoboRadioButtons; // Parameters/Pedigree/Appearance

    [FieldOffset(0x300)] public AtkCollisionNode* ContentsSection;
    [FieldOffset(0x310)] public AtkResNode* ChocoboPetInfo;
    [FieldOffset(0x318)] public AtkNineGridNode* ChocoboPetExpBar;
    [FieldOffset(0x320)] public int ChocoboPetExpBarWidth;
}
