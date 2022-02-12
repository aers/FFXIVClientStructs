using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonItemInspectionList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x1230)]
public struct AddonItemInspectionList
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
}