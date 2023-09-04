using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("GSInfoChocoboParam")]
[StructLayout(LayoutKind.Explicit, Size = 0x248)]
public unsafe partial struct AddonGSInfoChocoboParam {
    [FieldOffset(0x00)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x238)] public AtkComponentBase* RaceAbility1;
    [FieldOffset(0x240)] public AtkComponentBase* RaceAbility2;
}
