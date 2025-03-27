using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMiragePrismPrismBox
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("MiragePrismPrismBox")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1118)]
public unsafe partial struct AddonMiragePrismPrismBox {
    [FieldOffset(0xEC8)] public AtkComponentButton* PrevButton;
    [FieldOffset(0xED0)] public AtkComponentButton* NextButton;
    [FieldOffset(0xED8)] public AtkComponentButton* EditGlamourPlatesButton;

    [FieldOffset(0xF18)] public AtkComponentDropDownList* JobDropdown;

    [FieldOffset(0xF40)] public AtkComponentDropDownList* OrderDropdown;
}
