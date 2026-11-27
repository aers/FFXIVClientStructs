using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("QTE")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2D8)]
public partial struct AddonQTE {
    [FieldOffset(0x238)] public AtkAddonControl AddonControl;
}
