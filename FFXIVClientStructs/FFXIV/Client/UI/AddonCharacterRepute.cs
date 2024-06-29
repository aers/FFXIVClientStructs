using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonCharacterRepute
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("CharacterRepute")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2B0)]
public partial struct AddonCharacterRepute {
    [FieldOffset(0x2A4)] public int SelectedExpansion;
    [FieldOffset(0x2A8)] public int ExpansionsCount;
}
