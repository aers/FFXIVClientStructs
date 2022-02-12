using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonItemInspectionResult
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x2F8)]
public struct AddonItemInspectionResult
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
}