using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMiragePrismPrismBox
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("MiragePrismPrismBox")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xF80)]
public unsafe partial struct AddonMiragePrismPrismBox {
    [FieldOffset(0xD38)] public AtkComponentButton* PrevButton;
    [FieldOffset(0xD40)] public AtkComponentButton* NextButton;

    [FieldOffset(0xD88)] public AtkComponentDropDownList* JobDropdown;

    [FieldOffset(0xDB0)] public AtkComponentDropDownList* OrderDropdown;
}
