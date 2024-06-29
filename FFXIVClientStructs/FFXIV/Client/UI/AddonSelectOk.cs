using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSelectOk
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("SelectOk")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2B8)]
public unsafe partial struct AddonSelectOk {
    [FieldOffset(0x230)] public AtkTextNode* PromptText;
    [FieldOffset(0x238)] public AtkComponentButton* OkButton;
}
