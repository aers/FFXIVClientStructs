using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("CharacterRepute")]
[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
public struct AddonCharacterRepute {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x294)] public int SelectedExpansion;
    [FieldOffset(0x298)] public int ExpansionsCount;
}
