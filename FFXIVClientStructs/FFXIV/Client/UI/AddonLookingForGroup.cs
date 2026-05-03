using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonLookingForGroup
//   Client::UI::AddonLookingForGroupBase
//     Component::GUI::AtkUnitBase
//       Component::GUI::AtkEventListener
[Addon("LookingForGroup")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x65C0)]
public unsafe partial struct AddonLookingForGroup {
    [FieldOffset(0x6358)] public AtkComponentList* StandardViewList;
    [FieldOffset(0x6360)] public AtkComponentList* CompactViewList;
    [FieldOffset(0x63D0)] public AtkComponentDropDownList* SortDirectionDropDown;
    [FieldOffset(0x63D8)] public AtkComponentButton* RecruitMembersButton;
    [FieldOffset(0x63E0)] public AtkComponentButton* AdvancedSearchButton;
    [FieldOffset(0x63E8)] public AtkComponentButton* RefreshResultsButton;
    [FieldOffset(0x63F8)] public AtkComponentButton* RecruiterSearchButton;
    [FieldOffset(0x6400)] public AtkComponentButton* NextPageButton;
    [FieldOffset(0x6408)] public AtkComponentButton* PreviousPageButton;
    [FieldOffset(0x6410)] public AtkComponentButton* FilterSettingsButton;
    [FieldOffset(0x6418)] public AtkComponentButton* DisplaySettingsButton;
    [FieldOffset(0x6420)] public AtkComponentButton* ListDisplayModeButton;
    [FieldOffset(0x6428)] public AtkTextNode* CurrentPageTextNode;

    [FieldOffset(0x6430), FixedSizeArray] internal FixedSizeArray17<Pointer<AtkComponentRadioButton>> _categoryButtons;
    [FieldOffset(0x64B8), FixedSizeArray] internal FixedSizeArray17<Pointer<AtkTextNode>> _categoryCountTextNodes;
    [FieldOffset(0x6540), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentRadioButton>> _worldSelectButtons;

    [FieldOffset(0x6558)] public AtkTextNode* ResultsCountTextNode;
}
