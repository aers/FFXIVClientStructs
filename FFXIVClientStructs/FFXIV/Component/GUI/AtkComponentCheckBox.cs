namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentCheckBox
//   Component::GUI::AtkComponentButton
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 3
[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public struct AtkComponentCheckBox {
    [FieldOffset(0x0)] public AtkComponentButton AtkComponentButton;

    public bool IsChecked {
        get => AtkComponentButton.IsChecked;
        set => AtkComponentButton.IsChecked = value;
    }
}
