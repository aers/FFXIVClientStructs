using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("GSInfoCardList")]
[GenerateInterop, Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x540)]
public unsafe partial struct AddonGSInfoCardList {
    [FieldOffset(0x298)] public TabController TabController;

    [FieldOffset(0x348)] public AtkResNode* PageSelection;

    [FieldOffset(0x350), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkComponentButton>> _pageButtons;

    [FieldOffset(0x398)] public AtkComponentButton* GotoFirstPageButton;
    [FieldOffset(0x3A0)] public AtkComponentButton* GotoLastPageButton;

    [FieldOffset(0x3B8), FixedSizeArray] internal FixedSizeArray30<Pointer<AtkComponentButton>> _cardButtons;

    [FieldOffset(0x4A8)] public AtkTextNode* TotalTextNode;
    [FieldOffset(0x4B0)] public AtkImageNode* SelectedButtonBorderImage;
    [FieldOffset(0x4B8)] public AtkComponentDropDownList* CardDisplayFilter;
    [FieldOffset(0x4D0)] public AtkTextNode* SelectedCardName;
    [FieldOffset(0x4D8)] public AtkTextNode* SelectedCardTribeName;
    [FieldOffset(0x4E0)] public AtkTextNode* SelectedCardDescription;
    [FieldOffset(0x4E8)] public AtkTextNode* PreviewedCardNumber;
    [FieldOffset(0x4F0)] public AtkTextNode* SelectedCardNumber;
    [FieldOffset(0x4F8)] public AtkTextNode* SelectedCardAcquisitionName;
    [FieldOffset(0x500)] public AtkImageNode* SelectedCardAcquisitionIcon;

    [FieldOffset(0x508)] public GSInfoCardListFilterMode FilterMode;
    [FieldOffset(0x510)] public int SelectedPage;
    [FieldOffset(0x514)] public int SelectedCardIndex; // 0-30, does not account for page
}

public enum GSInfoCardListFilterMode {
    DisplayAllCards = 0xE,
    DisplayOwnedCards = 0x6,
    DisplayUnownedCards = 0x9,
}
