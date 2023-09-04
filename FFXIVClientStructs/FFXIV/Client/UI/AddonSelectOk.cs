using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSelectOk
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("SelectOk")]
[StructLayout(LayoutKind.Explicit, Size = 0x2A8)]
public unsafe struct AddonSelectOk {
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public AtkTextNode* PromptText;
    [FieldOffset(0x228)] public AtkComponentButton* OkButton;
}
