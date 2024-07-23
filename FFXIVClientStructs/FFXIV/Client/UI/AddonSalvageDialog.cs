using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSalvageDialog
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("SalvageDialog")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x268)]
public unsafe partial struct AddonSalvageDialog {
    [FieldOffset(0x238)] public AtkComponentIcon* ItemIconNode;

    [Obsolete("Use BulkDesynthCheckboxNode", false)]
    [FieldOffset(0x240)] public AtkComponentCheckBox* CheckBox;
    [FieldOffset(0x240)] public AtkComponentCheckBox* BulkDesynthCheckboxNode;
    [FieldOffset(0x248)] public AtkComponentCheckBox* UnkCheckboxNode; // Unused

    [FieldOffset(0x250)] public bool BulkDesynthEnabled; // Only changes state on first opening of the addon

    [FieldOffset(0x258)] public AtkComponentButton* DesynthesizeButton;
    [FieldOffset(0x260)] public AtkComponentButton* CancelButtonNode;
}
