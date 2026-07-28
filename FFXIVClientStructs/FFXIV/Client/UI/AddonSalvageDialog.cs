using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSalvageDialog
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("SalvageDialog")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
public unsafe partial struct AddonSalvageDialog {
    [FieldOffset(0x240)] public AtkComponentIcon* ItemIconNode;

    [FieldOffset(0x248)] private byte Unk248;
    [FieldOffset(0x250)] public AtkComponentCheckBox* GuaranteeNQResultsCheckboxNode;
    [FieldOffset(0x258)] public bool GuaranteeNQResultsEnabled; // this is cached and has no bearing on the checkbox itself

    [FieldOffset(0x260)] private byte Unk260;
    [FieldOffset(0x268)] public AtkComponentCheckBox* BulkDesynthCheckboxNode;
    [FieldOffset(0x270)] public bool BulkDesynthEnabled;

    [FieldOffset(0x278)] private byte Unk278;
    [FieldOffset(0x280)] private AtkComponentCheckBox* Unk280; // Unused
    [FieldOffset(0x288)] private bool Unk288Checked;

    [FieldOffset(0x290)] public AtkComponentButton* DesynthesizeButton;
    [FieldOffset(0x298)] public AtkComponentButton* CancelButtonNode;
}
