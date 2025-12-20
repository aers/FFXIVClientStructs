using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSelectString
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("SelectString")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 8B CB ?? ?? ?? E8 ?? ?? ?? ?? 33 C9 48 89 83 ?? ?? ?? ?? 48 89 8B ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? B8", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x2C0)]
public unsafe partial struct AddonSelectString {
    [FieldOffset(0x238)] public PopupMenuDerive PopupMenu;

    [GenerateInterop]
    [Inherits<PopupMenu>]
    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct PopupMenuDerive;
}
