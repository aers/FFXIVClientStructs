using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonActionCrossEditor
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("ActionCrossEditor")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x268)]
public unsafe partial struct AddonActionCrossEditor {
    [FieldOffset(0x238)] public AtkTextNode* HeadingText;
    [FieldOffset(0x240)] public AtkTextNode* InstructionText;
    [FieldOffset(0x248)] public AtkTextNode* SelectedActionText;
    [FieldOffset(0x250)] public AtkComponentBase* ControlGuide;
    [FieldOffset(0x258)] public AtkComponentIcon* SelectedActionIcon;
}
