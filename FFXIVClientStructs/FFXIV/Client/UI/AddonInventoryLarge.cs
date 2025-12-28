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
    [FieldOffset(0x240)] public int OpenerAddonId;

    [FieldOffset(0x2A8)] public AtkAddonControl AddonControl;

    [FieldOffset(0x338)] public int TabIndex;

    [MemberFunction("40 56 57 41 56 48 83 EC ?? 8B B9")]
    public partial void SetTab(int tab);
}
