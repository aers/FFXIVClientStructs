using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonCharacterInspect
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("CharacterInspect")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x510)]
public unsafe partial struct AddonCharacterInspect {
    [FieldOffset(0x440)] public AtkComponentBase* PreviewComponent;
}
