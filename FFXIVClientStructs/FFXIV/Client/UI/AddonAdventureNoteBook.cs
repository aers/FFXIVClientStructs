using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonAdventureNoteBook
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("AdventureNoteBook")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x640)]
public unsafe partial struct AddonAdventureNoteBook {
    [FieldOffset(0x580)] public TabController TabController;
}
