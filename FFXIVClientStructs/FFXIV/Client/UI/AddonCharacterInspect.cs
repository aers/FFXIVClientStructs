using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("CharacterInspect")]
[StructLayout(LayoutKind.Explicit, Size = 0x500)]
public unsafe struct AddonCharacterInspect {
    [FieldOffset(0x000)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x430)] public AtkComponentBase* PreviewComponent;
}
