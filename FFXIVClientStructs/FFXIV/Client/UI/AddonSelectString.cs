using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSelectString
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x2A8)]
public struct AddonSelectString
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public PopupMenuDerive PopupMenu;

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public struct PopupMenuDerive
    {
        [FieldOffset(0x0)] public PopupMenu PopupMenu;
    }
}