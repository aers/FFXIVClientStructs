using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonLookingForGroup
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("LookingForGroupCondition")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x770)]
public unsafe partial struct LookingForGroupCondition {
    [FieldOffset(0x238)] public AtkComponentDropDownList* DutyCategoryDropDown;
    [FieldOffset(0x240)] public AtkComponentDropDownList* DutyDropDown;
    [FieldOffset(0x248)] public AtkComponentTextInput* CommentTextInput;
    [FieldOffset(0x250)] public AtkComponentNumericInput* PasswordNumericInput;
    [FieldOffset(0x258)] public AtkComponentCheckBox* UnselectClassesCheckbox;
    [FieldOffset(0x260)] public AtkComponentCheckBox* FormPrivatePartyCheckbox;
    [FieldOffset(0x268)] public AtkComponentCheckBox* LimitToWorldServerCheckbox;
    [FieldOffset(0x270)] public AtkComponentCheckBox* OnePlayerPerJobCheckbox;
    [FieldOffset(0x278)] public AtkComponentCheckBox* AvgItemLevelCheckbox;
    [FieldOffset(0x280)] public AtkComponentNumericInput* AvgItemLevelNumericInput;
    [FieldOffset(0x288)] public AtkComponentButton* RecruitMembersButton;
    [FieldOffset(0x290)] public AtkComponentButton* CancelButton;
    [FieldOffset(0x2A0)] public AtkComponentButton* ResetButton;
    [FieldOffset(0x2A8)] private AtkComponentCheckBox* RemoveSpectatorsCheckbox; // "Remove spectators from search.", checkbox seems to be hidden
    [FieldOffset(0x2B0), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentRadioButton>> _recruitmentType; // "Normal" "Alliance" "Custom Match"
    [FieldOffset(0x2C8), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentRadioButton>> _allianceSelection; // "A" "B" "C"
    [FieldOffset(0x2E0), FixedSizeArray] internal FixedSizeArray6<Pointer<AtkComponentRadioButton>> _pvpAllianceSelection;
    [FieldOffset(0x310)] public AtkComponentDropDownList* ObjectiveDropDown;
    [FieldOffset(0x318)] public AtkComponentCheckBox* BeginnersWelcomeCheckBox;
    [FieldOffset(0x320)] public AtkComponentCheckBox* RecordableCheckBox;
    [FieldOffset(0x328)] public AtkComponentDropDownList* CompletionStatusDropDown;
    [FieldOffset(0x330)] public AtkComponentCheckBox* CompletionStatusCheckBox;
    [FieldOffset(0x358)] public AtkComponentCheckBox* UnrestrictedPartyCheckBox;
    [FieldOffset(0x360)] public AtkComponentCheckBox* MinimumItemLevelCheckBox;
    [FieldOffset(0x368)] public AtkComponentCheckBox* SilenceEchoCheckbox;
    [FieldOffset(0x370)] public AtkComponentDropDownList* LootRulesDropDown;
    [FieldOffset(0x378), FixedSizeArray] internal FixedSizeArray4<Pointer<AtkComponentCheckBox>> _languages;
    [FieldOffset(0x398), FixedSizeArray] internal FixedSizeArray24<Pointer<AtkComponentButton>> _memberRoleButtons;
    [FieldOffset(0x458)] private AtkComponentButton* UnknownButton;
    // There are a bunch of additional AtkComponentBase* and AtkComponentButton* here, but I don't know what they are for.
    [FieldOffset(0x608)] public AtkComponentCheckBox* RemoveRoleRestrictionsCheckBox;
    [FieldOffset(0x610)] private AtkComponentButton* UnknownButton2;
}
