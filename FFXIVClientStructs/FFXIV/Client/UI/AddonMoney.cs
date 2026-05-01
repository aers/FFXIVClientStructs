using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMoney
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_Money")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x260)]
public unsafe partial struct AddonMoney {
    [FieldOffset(0x238)] public AtkCounterNode* CounterNode;
    [FieldOffset(0x240)] public AtkComponentButton* CurrencyButtonComponent;
    [FieldOffset(0x248)] public AtkImageNode* CurrencyImageNode;
    [FieldOffset(0x250)] public CStringPointer TooltipText;
    [FieldOffset(0x258)] public uint IconId; // Currently Displayed Currency IconId
}
