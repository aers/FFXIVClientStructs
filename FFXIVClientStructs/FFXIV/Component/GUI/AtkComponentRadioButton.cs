namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentRadioButton
//   Component::GUI::AtkComponentButton
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 4
[StructLayout(LayoutKind.Explicit, Size = 0xF8)]
public struct AtkComponentRadioButton {
    [FieldOffset(0x0)] public AtkComponentButton AtkComponentButton;
    [Obsolete("Use AtkComponentButton.AtkComponentBase")]
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;

    public bool IsSelected {
        get => AtkComponentButton.IsChecked;
        set => AtkComponentButton.IsChecked = value;
    }
}
