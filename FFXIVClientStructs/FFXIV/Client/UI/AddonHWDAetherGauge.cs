using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonHWDAetherGauge
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("HWDAetherGauge")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x270)]
public unsafe partial struct AddonHWDAetherGauge {
    [FieldOffset(0x238), FixedSizeArray] internal FixedSizeArray5<Pointer<AtkComponentGaugeBar>> _gauges;
    [FieldOffset(0x268)] public int MaxGaugeValue;
}
