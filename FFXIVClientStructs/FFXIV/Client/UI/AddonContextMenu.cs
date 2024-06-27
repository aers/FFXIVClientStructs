using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonContextMenu
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("ContextMenu")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 8B CB 48 89 03 E8 ?? ?? ?? ?? 80 8B ?? ?? ?? ?? ?? 33 C9 48 89 83 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 8B C3", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
public partial struct AddonContextMenu {
    [VirtualFunction(72)]
    public partial bool OnMenuSelected(int selectedIdx, byte a3);
}
