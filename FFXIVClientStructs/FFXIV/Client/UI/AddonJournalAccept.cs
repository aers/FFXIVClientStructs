using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonJournalAccept
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("JournalAccept")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2C8)]
public unsafe partial struct AddonJournalAccept {
    [FieldOffset(0x238)] public AtkTextNode* QuestTitleText;
    [FieldOffset(0x240)] private AtkResNode* Unk240;
    [FieldOffset(0x248)] private AtkTextNode* Unk248;
    [FieldOffset(0x250)] private AtkImageNode* Unk250;
    [FieldOffset(0x258)] private AtkImageNode* Unk258;
    [FieldOffset(0x260)] private AtkImageNode* Unk260;
    [FieldOffset(0x268)] public AtkComponentButton* AcceptButton;
    [FieldOffset(0x270)] public AtkComponentButton* DeclineButton;
    [FieldOffset(0x278)] private AtkResNode* Unk278;
    [FieldOffset(0x280)] private AtkTextNode* Unk280;
    [FieldOffset(0x288)] private AtkTextNode* Unk288;
    [FieldOffset(0x290)] public AtkComponentScrollBar* ScrollBar;
    [FieldOffset(0x298)] public AtkComponentJournalCanvas* JournalCanvas;
    [FieldOffset(0x2A0)] public AtkTextNode* JournalCanvasText;
    [FieldOffset(0x2A8)] private AtkResNode* Unk2A8;
    [FieldOffset(0x2B0)] private AtkTextNode* Unk2B0;
}
