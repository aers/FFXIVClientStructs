using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonInventoryRetainer
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("InventoryRetainer")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x308)]
public partial struct AddonInventoryRetainer {
    [FieldOffset(0x288)] public AtkAddonControl AddonControl;

    [FieldOffset(0x300)] public int TabIndex;

    [MemberFunction("E9 ?? ?? ?? ?? 83 FD 0A 75 D4")]
    public partial void SetTab(int tab);
}
