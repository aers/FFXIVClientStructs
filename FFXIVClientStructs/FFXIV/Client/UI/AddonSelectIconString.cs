using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSelectIconString
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[GenerateInterop, Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2A8)]
public partial struct AddonSelectIconString {
    [FieldOffset(0x238)] public PopupMenuDerive PopupMenu;

    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public struct PopupMenuDerive {
        [FieldOffset(0x0)] public PopupMenu PopupMenu;
    }
}
