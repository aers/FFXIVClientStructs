using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerTaskResult
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x258)]
public unsafe struct AddonRetainerTaskResult
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x240)] public AtkComponentButton* ReassignButton;
    [FieldOffset(0x248)] public AtkComponentButton* ConfirmButton;
}