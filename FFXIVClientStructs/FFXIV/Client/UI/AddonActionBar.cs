using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("_ActionBar")]
[StructLayout(LayoutKind.Explicit, Size = 0x2B8)]
public unsafe partial struct AddonActionBar {
    [FieldOffset(0x00)] public AddonActionBarX AddonActionBarX;

    [FieldOffset(0x2A0)] public AtkComponentBase* CycleUpArrow;
    [FieldOffset(0x2A8)] public AtkComponentBase* CycleDownArrow;
    [FieldOffset(0x2A8)] public AtkComponentCheckBox* PadlockCheckbox;

    [FieldOffset(0x2B1)] public bool HotbarIdPet; // usually both the same value, only difference is that this one changes to 18 when cycled to the pet bar
    [FieldOffset(0x2B3)] public bool HotbarId;
    [FieldOffset(0x2B5)] public bool IncludePetBarWhenCycling;
}
