using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonInventory
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Inventory")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x338)]
public partial struct AddonInventory {
    [FieldOffset(0x2C0)] public AtkAddonControl AddonControl;

    [FieldOffset(0x334)] public int TabIndex;

    [MemberFunction("E9 ?? ?? ?? ?? 83 FD 11")]
    public partial void SetTab(int tab);
}
