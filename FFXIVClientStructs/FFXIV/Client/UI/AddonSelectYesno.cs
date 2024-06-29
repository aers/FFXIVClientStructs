using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSelectYesNo
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("SelectYesNo")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2E0)]
public unsafe partial struct AddonSelectYesno {
    [FieldOffset(0x230)] public AtkTextNode* PromptText;
    [FieldOffset(0x238)] public AtkComponentButton* YesButton;
    [FieldOffset(0x240)] public AtkComponentButton* NoButton;
    [FieldOffset(0x248)] public AtkComponentButton* AtkComponentButton238;
    [FieldOffset(0x250)] public AtkResNode* AtkResNode240;
    [FieldOffset(0x258)] public AtkResNode* AtkResNode248;
    [FieldOffset(0x268)] public AtkResNode* AtkResNode258;
    [FieldOffset(0x270)] public AtkComponentButton* AtkComponentButton260; // repeat 228
    [FieldOffset(0x278)] public AtkComponentButton* AtkComponentButton268; // repeat 230
    [FieldOffset(0x280)] public AtkComponentButton* AtkComponentButton270; // repeat 238
    [FieldOffset(0x288)] public AtkComponentHoldButton* AtkComponentHoldButton278;
    [FieldOffset(0x290)] public AtkComponentHoldButton* AtkComponentHoldButton280;
    [FieldOffset(0x298)] public AtkComponentHoldButton* AtkComponentHoldButton288;
    [FieldOffset(0x2A0)] public AtkComponentCheckBox* ConfirmCheckBox;
    [FieldOffset(0x2A8)] public AtkTextNode* AtkTextNode298;
    [FieldOffset(0x2B0)] public AtkComponentBase* AtkComponentBase2A0;
}
