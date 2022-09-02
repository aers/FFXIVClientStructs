using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSelectYesNo
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x2D0)]
public unsafe struct AddonSelectYesno
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public AtkTextNode* PromptText;
    [FieldOffset(0x228)] public AtkComponentButton* YesButton;
    [FieldOffset(0x230)] public AtkComponentButton* NoButton;
    [FieldOffset(0x238)] public AtkComponentButton* AtkComponentButton238;
    [FieldOffset(0x240)] public AtkResNode* AtkResNode240;
    [FieldOffset(0x248)] public AtkResNode* AtkResNode248;
    [FieldOffset(0x258)] public AtkResNode* AtkResNode258;
    [FieldOffset(0x260)] public AtkComponentButton* AtkComponentButton260; // repeat 228
    [FieldOffset(0x268)] public AtkComponentButton* AtkComponentButton268; // repeat 230
    [FieldOffset(0x270)] public AtkComponentButton* AtkComponentButton270; // repeat 238
    [FieldOffset(0x278)] public AtkComponentHoldButton* AtkComponentHoldButton278;
    [FieldOffset(0x280)] public AtkComponentHoldButton* AtkComponentHoldButton280;
    [FieldOffset(0x288)] public AtkComponentHoldButton* AtkComponentHoldButton288;
    [FieldOffset(0x290)] public AtkComponentCheckBox* ConfirmCheckBox;
    [FieldOffset(0x298)] public AtkTextNode* AtkTextNode298;
    [FieldOffset(0x2A0)] public AtkComponentBase* AtkComponentBase2A0;
}