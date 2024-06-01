using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("CutSceneSelectString")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x248)]
public unsafe partial struct AddonCutSceneSelectString {
    [FieldOffset(0x230)] public AtkComponentList* OptionList;
    [FieldOffset(0x238)] public AtkComponentTextNineGrid* TextLabel;
}
