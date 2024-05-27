using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSelectString
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("SelectString")]
[GenerateInterop, Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2A8)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 8B F9 48 89 01 8B DA 48 81 C1 20 02 00 00 48 8D 05 ?? ?? ?? ?? 48 89 01 E8 ?? ?? ?? ?? 48 8B CF E8 ?? ?? ?? ?? F6 C3 01 74 0D BA A8 02 00 00", 3)]
public unsafe partial struct AddonSelectString {
    [FieldOffset(0x220)] public PopupMenuDerive PopupMenu;

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public struct PopupMenuDerive {
        [FieldOffset(0x0)] public PopupMenu PopupMenu;
    }
}
