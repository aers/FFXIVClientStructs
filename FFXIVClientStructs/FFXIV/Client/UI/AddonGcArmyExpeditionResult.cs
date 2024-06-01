using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("GcArmyExpeditionReport")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x228)]
public unsafe partial struct AddonGcArmyExpeditionResult {
    [FieldOffset(0x220)] public AtkComponentButton* CompleteButton;
}
