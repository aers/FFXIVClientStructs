using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSelectIconString
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2C0)]
public partial struct AddonSelectIconString {
    [FieldOffset(0x250)] public PopupMenuDerive PopupMenu;

    [GenerateInterop]
    [Inherits<PopupMenu>]
    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public partial struct PopupMenuDerive;
}
