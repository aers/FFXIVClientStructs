using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("LookingForGroupDetail")]
[StructLayout(LayoutKind.Explicit, Size = 0x3E8)]
public unsafe partial struct AddonLookingForGroupDetail {
    [FieldOffset(0x00)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x248)] public AtkComponentButton* JoinPartyButton;

    [FixedSizeArray<Pointer<AtkComponentButton>>(6)]
    [FieldOffset(0x250)] public fixed byte JoinAllianceButtons[0x8 * 6];

    [FieldOffset(0x280)] public AtkComponentButton* SendTellButton;
    [FieldOffset(0x288)] public AtkComponentButton* AllianceBackButton; // Not visible in 8-man parties
    [FieldOffset(0x290)] public AtkComponentButton* BackButton;
    [FieldOffset(0x2B8)] public AtkComponentButton* RelayPartyFinderInfoButton;

    [FieldOffset(0x2C0)] public AtkImageNode* LookingForGroupImageNode;
    [FieldOffset(0x2C8)] public AtkImageNode* CategoryImageNode;

    [FieldOffset(0x2D0)] public AtkTextNode* PartyLeaderTextNode;
    [FieldOffset(0x2E0)] public AtkTextNode* TimeRemainingTextNode;
    [FieldOffset(0x2E8)] public AtkTextNode* DutyNameTextNode;
    [FieldOffset(0x2D8)] public AtkTextNode* LocationTextNode;
    [FieldOffset(0x2F0)] public AtkTextNode* ItemLevelTextNode;
    [FieldOffset(0x2F8)] public AtkTextNode* StatusTextNode;
    [FieldOffset(0x300)] public AtkTextNode* DescriptionTextNode;

    [FieldOffset(0x308)] public Utf8String DescriptionString;
    [FieldOffset(0x370)] public Utf8String CategoriesString; // Duty Complete, Loot, One Player Per Job
}
