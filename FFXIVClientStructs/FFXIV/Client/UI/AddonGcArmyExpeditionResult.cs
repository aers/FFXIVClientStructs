using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("GcArmyExpeditionReport")]
[StructLayout(LayoutKind.Explicit, Size = 0x228)]
public unsafe struct AddonGcArmyExpeditionResult {
    [FieldOffset(0x00)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x220)] public AtkComponentButton* CompleteButton;
}
