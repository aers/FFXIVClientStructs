using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonDifficultySelectYesNo
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("DifficultySelectYesNo")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x288)]
public unsafe partial struct AddonDifficultySelectYesNo {
    [FieldOffset(0x238)] public AtkTextNode* PromptText;
    [FieldOffset(0x240)] private AtkTextNode* Unk240;
    [FieldOffset(0x248)] private AtkTextNode* Unk248;
    [FieldOffset(0x250)] public AtkComponentButton* ProceedButton;
    [FieldOffset(0x258)] public AtkComponentButton* LeaveButton;
}
