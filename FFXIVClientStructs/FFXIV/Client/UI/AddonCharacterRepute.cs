using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonCharacterRepute
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("CharacterRepute")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2C0)]
public unsafe partial struct AddonCharacterRepute {
    [FieldOffset(0x250)] public AtkComponentDropDownList* ExpansionsDropDownList;
    [FieldOffset(0x2A0), FixedSizeArray] internal FixedSizeArray6<int> _expansionMapping;
    [FieldOffset(0x2B8)] public int SelectedExpansion;
    [FieldOffset(0x2BC)] public int ExpansionsCount;
}
