using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonJournalDetail
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x2F8)]
public unsafe struct AddonJournalDetail
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x230)] public AtkComponentScrollBar* AtkComponentScrollBar230;
    [FieldOffset(0x238)] public AtkComponentGuildLeveCard* AtkComponentGuildLeveCard238;
    [FieldOffset(0x240)] public AtkTextNode* AtkTextNode240;
    [FieldOffset(0x248)] public AtkTextNode* AtkTextNode248;
    [FieldOffset(0x250)] public AtkImageNode* AtkImageNode250;
    [FieldOffset(0x258)] public AtkImageNode* AtkImageNode258;
    [FieldOffset(0x260)] public AtkImageNode* AtkImageNode260;
    [FieldOffset(0x268)] public AtkResNode* AtkResNode268;
    [FieldOffset(0x270)] public AtkTextNode* AtkTextNode270;
    [FieldOffset(0x278)] public AtkResNode* AtkResNode278;
    [FieldOffset(0x280)] public AtkComponentButton* AcceptButton;
    [FieldOffset(0x288)] public AtkComponentButton* DeclineButton;
    [FieldOffset(0x290)] public AtkComponentButton* AtkComponentButton290;
    [FieldOffset(0x298)] public AtkResNode* AtkResNode298;
    [FieldOffset(0x2A0)] public AtkImageNode* AtkImageNode2A0;
    [FieldOffset(0x2A8)] public AtkTextNode* AtkTextNode2A8;
    [FieldOffset(0x2B0)] public AtkTextNode* AtkTextNode2B0;
    [FieldOffset(0x2B8)] public AtkTextNode* AtkTextNode2B8;
    [FieldOffset(0x2C0)] public AtkTextNode* AtkTextNode2C0;
    [FieldOffset(0x2C8)] public AtkComponentButton* AtkComponentButton2C8;
    [FieldOffset(0x2D0)] public AtkComponentJournalCanvas* AtkComponentJournalCanvas2D0;
}