using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonLovmResult
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("LovmResult")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x240)]
public unsafe partial struct AddonLovmResult {
    [FieldOffset(0x238)] private AtkTextNode* Unk238;
}
