using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonShopCardDialog
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[GenerateInterop, Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x230)]
public unsafe partial struct AddonShopCardDialog {
    [FieldOffset(0x220)] public AtkComponentNumericInput* CardQuantityInput;
}
