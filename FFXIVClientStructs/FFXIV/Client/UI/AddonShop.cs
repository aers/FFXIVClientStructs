using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonShop
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Shop")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1208)]
public unsafe partial struct AddonShop {
    [FieldOffset(0x238)] public AtkComponentList* BuyList;
    [FieldOffset(0x240)] public AtkComponentList* BuybackList;
}
