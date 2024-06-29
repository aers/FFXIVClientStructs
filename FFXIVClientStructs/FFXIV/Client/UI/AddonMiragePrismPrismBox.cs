using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMiragePrismPrismBox
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("MiragePrismPrismBox")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xF78)]
public unsafe partial struct AddonMiragePrismPrismBox {
    [FieldOffset(0xA10)] public AtkComponentButton* PrevButton;
    [FieldOffset(0xA18)] public AtkComponentButton* NextButton;

    [FieldOffset(0xA60)] public AtkComponentDropDownList* JobDropdown;

    [FieldOffset(0xA88)] public AtkComponentDropDownList* OrderDropdown;
}
