using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonShopExchangeItemDialog
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("ShopExchangeItemDialog")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2A8)]
public unsafe partial struct AddonShopExchangeItemDialog {
    [FieldOffset(0x278)] public AtkComponentButton* ExchangeButton;
    [FieldOffset(0x280)] public AtkComponentButton* CancelButton;
}
