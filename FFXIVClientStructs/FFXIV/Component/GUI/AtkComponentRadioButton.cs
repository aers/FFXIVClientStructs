using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentRadioButton
//   Component::GUI::AtkComponentButton
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 4
[GenerateInterop]
[Inherits<AtkComponentButton>]
[StructLayout(LayoutKind.Explicit, Size = 0xF8)]
public partial struct AtkComponentRadioButton : ICreatable {
    public bool IsSelected {
        get => AtkComponentButton.IsChecked;
        set => AtkComponentButton.IsChecked = value;
    }

    [MemberFunction("40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 03 33 C0 89 83 ?? ?? ?? ?? 48 8B C3")]
    public partial void Ctor();
}
