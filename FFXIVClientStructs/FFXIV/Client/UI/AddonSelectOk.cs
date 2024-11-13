using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSelectOk
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("SelectOk")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2C0)]
public unsafe partial struct AddonSelectOk {
    [FieldOffset(0x238)] public AtkTextNode* PromptText;
    [FieldOffset(0x240)] public AtkComponentButton* OkButton;
}
