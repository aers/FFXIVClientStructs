using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonCharacterRepute
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("CharacterRepute")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
public partial struct AddonCharacterRepute {
    [FieldOffset(0x294)] public int SelectedExpansion;
    [FieldOffset(0x298)] public int ExpansionsCount;
}
