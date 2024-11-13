using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonInventoryLarge
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("InventoryLarge")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x348)]
public partial struct AddonInventoryLarge {
    [FieldOffset(0x2A8)] public AtkAddonControl AddonControl;

    [FieldOffset(0x338)] public int TabIndex;

    [MemberFunction("E9 ?? ?? ?? ?? 41 83 FF 47")]
    public partial void SetTab(int tab);
}
