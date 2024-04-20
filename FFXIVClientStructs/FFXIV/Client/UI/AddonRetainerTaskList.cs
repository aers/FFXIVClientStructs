using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerTaskList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RetainerTaskList")]
[StructLayout(LayoutKind.Explicit, Size = 0x238)]
[VTableAddress("48 8d 05 ?? ?? ?? ?? 48 89 03 33 c0 80 8b 88 01 00 00 20 48 89 83 20 02 00 00 48 89 83 28 02 00 00 88", 3)]
public unsafe partial struct AddonRetainerTaskList {
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;

    [VirtualFunction(48), Obsolete("Use AtkUnitBase.OnSetup")]
    public partial void OnSetup(uint a2, AtkValue* atkValues);
}
