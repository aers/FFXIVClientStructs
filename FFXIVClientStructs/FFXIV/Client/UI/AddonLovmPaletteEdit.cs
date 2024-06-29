using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonLovmPaletteEdit
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("LovmPaletteEdit")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xA20)]
public partial struct AddonLovmPaletteEdit {
    [FieldOffset(0x850)] public TabController TabController;
}
