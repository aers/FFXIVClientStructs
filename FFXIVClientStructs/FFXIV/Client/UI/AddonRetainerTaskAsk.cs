using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerTaskAsk
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RetainerTaskAsk")]
[StructLayout(LayoutKind.Explicit, Size = 0x2B8)]
[VTableAddress("48 8d 05 ?? ?? ?? ?? 48 89 03 48 8d 83 50 02 00 00 48 89 93 20 02 00 00", 3)]
public unsafe partial struct AddonRetainerTaskAsk {
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x2A8)] public AtkComponentButton* AssignButton;
    [FieldOffset(0x2B0)] public AtkComponentButton* ReturnButton;

    [VirtualFunction(48), Obsolete("Use AtkUnitBase.OnSetup")]
    public partial void OnSetup(uint a2, AtkValue* atkValues);
}
