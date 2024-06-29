using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonDtr
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_DTR")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x378)]
public unsafe partial struct AddonDtr {
    [FieldOffset(0x230)] public Utf8String TimeModeTooltip; // Example: "Eorzea Time/Local Time"
    [FieldOffset(0x298)] public Utf8String NetworkInfoTooltip;
    [FieldOffset(0x308)] public AtkTextNode* TimeText;
    [FieldOffset(0x310)] public AtkResNode* NetworkStrengthContainer;
    [FieldOffset(0x318)] public AtkImageNode* NetworkStrengthImage;
    [FieldOffset(0x320)] public AtkResNode* MailContainer;
    [FieldOffset(0x328)] public AtkImageNode* MailImage;
    [FieldOffset(0x330)] public AtkTextNode* MailText;
    [FieldOffset(0x338)] public AtkResNode* DutyRecorderContainer;
    [FieldOffset(0x340)] public AtkResNode* AlarmsContainer;
    [FieldOffset(0x348)] public AtkResNode* WalkModeContainer;
    [FieldOffset(0x350)] public AtkResNode* WorldInfoContainer;
    [FieldOffset(0x358)] public AtkTextNode* WorldText;
    [FieldOffset(0x360)] public AtkImageNode* WorldVisitImage; // Displays home icon if in home world
    [FieldOffset(0x368)] public AtkCollisionNode* CollisionNode;

    // [FieldOffset(0x370)] public int unknown; // Some kind of pre-calculated size, might only update when one of the containers needs to be shown.
}
