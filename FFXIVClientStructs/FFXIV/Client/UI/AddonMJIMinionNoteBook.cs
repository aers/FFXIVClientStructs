using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMJIMinionNoteBook
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("MJIMinionNoteBook")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x640)]
public partial struct AddonMJIMinionNoteBook {
    [FieldOffset(0x2B0)] public TabController TabController;
}
