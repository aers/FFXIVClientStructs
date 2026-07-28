using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonInputNumeric
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("InputNumeric")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x258)]
public unsafe partial struct AddonInputNumeric {
    [FieldOffset(0x238)] public AtkComponentButton* OkButton;
    [FieldOffset(0x240)] public AtkComponentButton* CancelButton;
    [FieldOffset(0x248)] public AtkTextNode* PromptText;
    [FieldOffset(0x250)] public AtkComponentNumericInput* NumericInput;
}
