using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGSInfoEditDeck
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GSInfoEditDeck")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xD90)]
public partial struct AddonGSInfoEditDeck {
    [FieldOffset(0x230)] public TabController TabController;
}
