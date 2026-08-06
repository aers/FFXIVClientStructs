using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSalvageAutoDialog
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("SalvageAutoDialog")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x248)]
public unsafe partial struct AddonSalvageAutoDialog {
    [FieldOffset(0x238)] public AtkComponentButton* EndDesynthesisButton;
    [FieldOffset(0x240)] private byte Unk240;
}
