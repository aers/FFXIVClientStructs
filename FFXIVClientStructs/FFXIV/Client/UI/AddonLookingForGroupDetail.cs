using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonLookingForGroupDetail
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("LookingForGroupDetail")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x400)]
public unsafe partial struct AddonLookingForGroupDetail {
    [FieldOffset(0x260)] public AtkComponentButton* JoinPartyButton;

    [FieldOffset(0x268), FixedSizeArray] internal FixedSizeArray6<Pointer<AtkComponentButton>> _joinAllianceButtons;

    [FieldOffset(0x298)] public AtkComponentButton* SendTellButton;
    [FieldOffset(0x2A0)] public AtkComponentButton* AllianceBackButton; // Not visible in 8-man parties
    [FieldOffset(0x2A8)] public AtkComponentButton* BackButton;
    [FieldOffset(0x2D0)] public AtkComponentButton* RelayPartyFinderInfoButton;

    [FieldOffset(0x2D8)] public AtkImageNode* LookingForGroupImageNode;
    [FieldOffset(0x2E0)] public AtkImageNode* CategoryImageNode;

    [FieldOffset(0x2E8)] public AtkTextNode* PartyLeaderTextNode;
    [FieldOffset(0x2F8)] public AtkTextNode* TimeRemainingTextNode;
    [FieldOffset(0x300)] public AtkTextNode* DutyNameTextNode;
    [FieldOffset(0x2F0)] public AtkTextNode* LocationTextNode;
    [FieldOffset(0x308)] public AtkTextNode* ItemLevelTextNode;
    [FieldOffset(0x310)] public AtkTextNode* StatusTextNode;
    [FieldOffset(0x318)] public AtkTextNode* DescriptionTextNode;

    [FieldOffset(0x320)] public Utf8String DescriptionString;
    [FieldOffset(0x388)] public Utf8String CategoriesString; // Duty Complete, Loot, One Player Per Job
}
