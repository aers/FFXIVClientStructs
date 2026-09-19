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

    [FieldOffset(0x248), FixedSizeArray] internal FixedSizeArray3<CheckboxSlot> _checkboxes;

    [Obsolete("Iterate Checkboxes instead.")]
    [FieldOffset(0x250)] public AtkComponentCheckBox* GuaranteeNQResultsCheckboxNode;
    [Obsolete("Use CheckboxSlot.IsCheckedCached")]
    [FieldOffset(0x258)] public bool GuaranteeNQResultsEnabled;

    [Obsolete("Iterate Checkboxes instead.")]
    [FieldOffset(0x268)] public AtkComponentCheckBox* BulkDesynthCheckboxNode;
    [Obsolete("Use CheckboxSlot.IsCheckedCached")]
    [FieldOffset(0x270)] public bool BulkDesynthEnabled;

    [FieldOffset(0x290)] public AtkComponentButton* DesynthesizeButton;
    [FieldOffset(0x298)] public AtkComponentButton* CancelButtonNode;

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public unsafe struct CheckboxSlot {
        [FieldOffset(0x00)] public SalvageDialogCheckboxType Type;
        [FieldOffset(0x08)] public AtkComponentCheckBox* Checkbox;
        [FieldOffset(0x10)] public bool IsCheckedCached; // check IsChecked on the checkbox itself if you want the live value
    }
}

public enum SalvageDialogCheckboxType : byte {
    BulkDesynth = 0,
    Warning = 1, // unique/collectable/etc
    GuaranteeNQ = 2,
}
