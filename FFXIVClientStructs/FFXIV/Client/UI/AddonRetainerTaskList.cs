using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerTaskList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public struct AddonRetainerTaskList
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
}
