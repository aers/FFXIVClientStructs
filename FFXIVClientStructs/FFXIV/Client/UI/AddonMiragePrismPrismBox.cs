using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMiragePrismPrismBox
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("MiragePrismPrismBox")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1438)]
public unsafe partial struct AddonMiragePrismPrismBox {
    [FieldOffset(0x11E8)] public AtkComponentButton* PrevButton;
    [FieldOffset(0x11F0)] public AtkComponentButton* NextButton;
    [FieldOffset(0x11F8)] public AtkComponentButton* EditGlamourPlatesButton;

    [FieldOffset(0x1238)] public AtkComponentDropDownList* JobDropdown;

    [FieldOffset(0x1260)] public AtkComponentDropDownList* OrderDropdown;
}
