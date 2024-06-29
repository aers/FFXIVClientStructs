using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonInventory
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Inventory")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x330)]
public partial struct AddonInventory {
    [FieldOffset(0x2B8)] public AtkAddonControl AddonControl;

    [FieldOffset(0x32C)] public int TabIndex;

    [MemberFunction("E9 ?? ?? ?? ?? 83 FD 11")]
    public partial void SetTab(int tab);
}
