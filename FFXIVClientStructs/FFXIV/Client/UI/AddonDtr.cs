using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI; 

[Addon("_DTR")]
[StructLayout(LayoutKind.Explicit, Size = 0x368)]
public unsafe partial struct AddonDtr {
    [FieldOffset(0x00)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x2F8)] public AtkTextNode* TimeText;
    [FieldOffset(0x300)] public AtkResNode* NetworkStrengthContainer;
    [FieldOffset(0x308)] public AtkImageNode* NetworkStrengthImage;
    [FieldOffset(0x310)] public AtkResNode* MailContainer;
    [FieldOffset(0x318)] public AtkImageNode* MailImage;
    [FieldOffset(0x320)] public AtkTextNode* MailText;
    [FieldOffset(0x328)] public AtkResNode* DutyRecorderContainer;
    [FieldOffset(0x330)] public AtkResNode* AlarmsContainer;
    [FieldOffset(0x338)] public AtkResNode* WalkModeContainer;
    [FieldOffset(0x340)] public AtkResNode* WorldInfoContainer;
    [FieldOffset(0x348)] public AtkTextNode* WorldText;
    [FieldOffset(0x350)] public AtkImageNode* WorldVisitImage; // Displays homeicon if in homeworld
    [FieldOffset(0x358)] public AtkCollisionNode* CollisionNode;
}
