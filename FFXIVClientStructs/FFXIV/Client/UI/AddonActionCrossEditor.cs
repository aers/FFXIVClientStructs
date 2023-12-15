using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("ActionCrossEditor")]
[StructLayout(LayoutKind.Explicit, Size = 0x250)]
public unsafe partial struct AddonActionCrossEditor {
    [FieldOffset(0x000)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x220)] public AtkTextNode* HeadingText;
    [FieldOffset(0x228)] public AtkTextNode* InstructionText;
    [FieldOffset(0x230)] public AtkTextNode* SelectedActionText;
    [FieldOffset(0x238)] public AtkComponentBase* ControlGuide;
    [FieldOffset(0x240)] public AtkComponentIcon* SelectedActionIcon;
}
