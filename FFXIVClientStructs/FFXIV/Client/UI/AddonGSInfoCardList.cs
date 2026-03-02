using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGSInfoCardList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GSInfoCardList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x560)]
public unsafe partial struct AddonGSInfoCardList {
    [FieldOffset(0xE0)] public AtkCollisionNode* SelectedCard;

    [FieldOffset(0x2A0)] public byte CardRarity; // 1..5
    [FieldOffset(0x2A1)] public CardType CardType;
    [FieldOffset(0x2A3)] public byte NumSideU;
    [FieldOffset(0x2A4)] public byte NumSideD;
    [FieldOffset(0x2A5)] public byte NumSideR;
    [FieldOffset(0x2A6)] public byte NumSideL;
    [FieldOffset(0x2A8)] public int CardIconId; // texture id for button (82100+) or 0 when missing

    [FieldOffset(0x2B0)] public TabController TabController;

    [FieldOffset(0x360)] public AtkResNode* PageSelection;

    [FieldOffset(0x368), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkComponentButton>> _pageButtons;

    [FieldOffset(0x3B0)] public AtkComponentButton* GotoFirstPageButton;
    [FieldOffset(0x3B8)] public AtkComponentButton* GotoLastPageButton;

    [FieldOffset(0x3D0), FixedSizeArray] internal FixedSizeArray30<Pointer<AtkComponentButton>> _cardButtons;

    [FieldOffset(0x4C0)] public AtkTextNode* TotalTextNode;
    [FieldOffset(0x4C8)] public AtkImageNode* SelectedButtonBorderImage;
    [FieldOffset(0x4D0)] public AtkComponentDropDownList* CardDisplayFilter;
    [FieldOffset(0x4E8)] public AtkTextNode* SelectedCardName;
    [FieldOffset(0x4F0)] public AtkTextNode* SelectedCardTribeName;
    [FieldOffset(0x4F8)] public AtkTextNode* SelectedCardDescription;
    [FieldOffset(0x500)] public AtkTextNode* PreviewedCardNumber;
    [FieldOffset(0x508)] public AtkTextNode* SelectedCardNumber;
    [FieldOffset(0x510)] public AtkTextNode* SelectedCardAcquisitionName;
    [FieldOffset(0x518)] public AtkImageNode* SelectedCardAcquisitionIcon;

    [FieldOffset(0x520)] public GSInfoCardListFilterMode FilterMode; // this isn't accurate
    [FieldOffset(0x528)] public int TotalPages;
    /// <remarks> 0-indexed </remarks>
    [FieldOffset(0x52C)] public int SelectedPage;
    [FieldOffset(0x534)] public byte CardIndex; // writable
}

public enum GSInfoCardListFilterMode {
    DisplayAllCards = 0xE,
    DisplayOwnedCards = 0x6,
    DisplayUnownedCards = 0x9,
}
