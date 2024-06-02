using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSelectOk
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("SelectOk")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2A8)]
public unsafe partial struct AddonSelectOk {
    [FieldOffset(0x220)] public AtkTextNode* PromptText;
    [FieldOffset(0x228)] public AtkComponentButton* OkButton;
}
