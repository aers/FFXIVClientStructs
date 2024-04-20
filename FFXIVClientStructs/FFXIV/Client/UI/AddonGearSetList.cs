using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("GearSetList")]
[StructLayout(LayoutKind.Explicit, Size = 0x3A90)]
public struct AddonGearSetList {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x3A8D)] public bool ResetPosition;
}
