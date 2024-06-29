using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonOrnamentNoteBook
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x550)]
public partial struct AddonOrnamentNoteBook {
    [FieldOffset(0x2A0)] public TabController TabController;
}
