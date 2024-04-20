using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RetainerList")]
[StructLayout(LayoutKind.Explicit, Size = 0x260)]
[VTableAddress("48 8d 05 ?? ?? ?? ?? 48 89 03 33 c0 48 89 83 20 02 00 00 48 89 83 28 02 00 00 48 89 83 30 02 00 00 48 89 83 38 02 00 00 48 89 83 40 02 00 00 48 89 83 48 02 00 00 48 89 83 50 02 00 00 80 8b 8b 01 00 00 08", 3)]
public unsafe partial struct AddonRetainerList {
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;

    [VirtualFunction(48), Obsolete("Use AtkUnitBase.OnSetup")]
    public partial void OnSetup(uint a2, AtkValue* atkValues);
}
