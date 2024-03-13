using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerTaskResult
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RetainerTaskResult")]
[StructLayout(LayoutKind.Explicit, Size = 0x258)]
[VTableAddress("48 8d 05 ?? ?? ?? ?? 48 89 03 33 c0 80 8b 88 01 00 00 20 48 89 83 20 02 00 00 48 89 83 28 02 00 00 48 89 83 30 02 00 00 48 89 83 38 02 00 00 48 89 83 40 02 00 00 48 89 83 48 02 00 00 89 83 50 02 00 00", 3)]
public unsafe partial struct AddonRetainerTaskResult {
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x240)] public AtkComponentButton* ReassignButton;
    [FieldOffset(0x248)] public AtkComponentButton* ConfirmButton;

    [VirtualFunction(48), Obsolete("Use AtkUnitBase.OnSetup")]
    public partial void OnSetup(uint a2, AtkValue* atkValues);
}
