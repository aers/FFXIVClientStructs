using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMateriaRetrieveDialog
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("MateriaRetrieveDialog")]
[StructLayout(LayoutKind.Explicit, Size = 0x220)]
public struct AddonMateriaRetrieveDialog {
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
}
