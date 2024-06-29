using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerSell
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RetainerSell")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x288)]
public unsafe partial struct AddonRetainerSell {
    [FieldOffset(0x230)] public AtkComponentButton* Confirm;
    [FieldOffset(0x238)] public AtkComponentButton* Cancel;
    [FieldOffset(0x240)] public AtkComponentButton* ComparePrices;
    [FieldOffset(0x248)] public AtkComponentIcon* ItemIcon;
    [FieldOffset(0x258)] public AtkComponentNumericInput* Quantity;
    [FieldOffset(0x260)] public AtkComponentNumericInput* AskingPrice;
    [FieldOffset(0x268)] public AtkTextNode* ItemName;
    [FieldOffset(0x270)] public AtkTextNode* Total;
    [FieldOffset(0x278)] public AtkTextNode* Tax;
}
