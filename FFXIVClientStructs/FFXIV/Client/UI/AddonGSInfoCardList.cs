using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGSInfoCardList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GSInfoCardList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x550)]
public unsafe partial struct AddonGSInfoCardList {
    [FieldOffset(0x2A8)] public TabController TabController;

    [FieldOffset(0x358)] public AtkResNode* PageSelection;

    [FieldOffset(0x360), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkComponentButton>> _pageButtons;

    [FieldOffset(0x3A8)] public AtkComponentButton* GotoFirstPageButton;
    [FieldOffset(0x3B0)] public AtkComponentButton* GotoLastPageButton;

    [FieldOffset(0x3C8), FixedSizeArray] internal FixedSizeArray30<Pointer<AtkComponentButton>> _cardButtons;

    [FieldOffset(0x4B8)] public AtkTextNode* TotalTextNode;
    [FieldOffset(0x4C0)] public AtkImageNode* SelectedButtonBorderImage;
    [FieldOffset(0x4C8)] public AtkComponentDropDownList* CardDisplayFilter;
    [FieldOffset(0x4E0)] public AtkTextNode* SelectedCardName;
    [FieldOffset(0x4E8)] public AtkTextNode* SelectedCardTribeName;
    [FieldOffset(0x4F0)] public AtkTextNode* SelectedCardDescription;
    [FieldOffset(0x4F8)] public AtkTextNode* PreviewedCardNumber;
    [FieldOffset(0x500)] public AtkTextNode* SelectedCardNumber;
    [FieldOffset(0x508)] public AtkTextNode* SelectedCardAcquisitionName;
    [FieldOffset(0x510)] public AtkImageNode* SelectedCardAcquisitionIcon;

    [FieldOffset(0x518)] public GSInfoCardListFilterMode FilterMode;
    [FieldOffset(0x520)] public int SelectedPage;
    [FieldOffset(0x524)] public int SelectedCardIndex; // 0-30, does not account for page
}

public enum GSInfoCardListFilterMode {
    DisplayAllCards = 0xE,
    DisplayOwnedCards = 0x6,
    DisplayUnownedCards = 0x9,
}
