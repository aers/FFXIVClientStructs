using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerSell
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x278)]
public unsafe struct AddonRetainerSell
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x220)] public AtkComponentButton* Confirm;
    [FieldOffset(0x228)] public AtkComponentButton* Cancel;
    [FieldOffset(0x230)] public AtkComponentButton* ComparePrices;
    [FieldOffset(0x238)] public AtkComponentIcon* ItemIcon;
    [FieldOffset(0x248)] public AtkComponentNumericInput* Quantity;
    [FieldOffset(0x250)] public AtkComponentNumericInput* AskingPrice;
    [FieldOffset(0x258)] public AtkTextNode* ItemName;
    [FieldOffset(0x260)] public AtkTextNode* Total;
    [FieldOffset(0x268)] public AtkTextNode* Tax;
}