using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentRadioButton
//   Component::GUI::AtkComponentButton
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08"
// type 4
[GenerateInterop(isInherited: true)]
[Inherits<AtkComponentButton>]
[StructLayout(LayoutKind.Explicit, Size = 0xF8)]
public partial struct AtkComponentRadioButton : ICreatable {
    [FieldOffset(0xF0)] public ushort GroupId;
    [FieldOffset(0xF2)] public bool AlwaysFireButtonClickEvent; // otherwise it depends on AtkGroupManager

    public bool IsSelected {
        get => AtkComponentButton.IsChecked;
        set => AtkComponentButton.IsChecked = value;
    }

    [MemberFunction("40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 03 33 C0 89 83 ?? ?? ?? ?? 48 8B C3")]
    public partial void Ctor();
}
