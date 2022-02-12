using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonJournalResult
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x288)]
public unsafe struct AddonJournalResult
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public AtkImageNode* AtkImageNode220;
    [FieldOffset(0x228)] public AtkImageNode* AtkImageNode228;
    [FieldOffset(0x230)] public AtkImageNode* AtkImageNode230;
    [FieldOffset(0x238)] public AtkComponentGuildLeveCard* AtkComponentGuildLeveCard238;
    [FieldOffset(0x240)] public AtkComponentButton* CompleteButton;
    [FieldOffset(0x248)] public AtkComponentButton* DeclineButton;
    [FieldOffset(0x250)] public AtkTextNode* AtkTextNode250;
    [FieldOffset(0x258)] public AtkTextNode* AtkTextNode258;
    [FieldOffset(0x260)] public AtkImageNode* AtkImageNode260;
    [FieldOffset(0x268)] public AtkComponentJournalCanvas* AtkComponentJournalCanvas268;
}