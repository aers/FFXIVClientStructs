using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("CharacterInspect")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x500)]
public unsafe partial struct AddonCharacterInspect {
    [FieldOffset(0x430)] public AtkComponentBase* PreviewComponent;
}
