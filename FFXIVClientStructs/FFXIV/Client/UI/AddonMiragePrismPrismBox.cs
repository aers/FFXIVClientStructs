using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMiragePrismPrismBox
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("MiragePrismPrismBox")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xC28)]
public unsafe partial struct AddonMiragePrismPrismBox {
    [FieldOffset(0xA00)] public AtkComponentButton* PrevButton;
    [FieldOffset(0xA08)] public AtkComponentButton* NextButton;

    [FieldOffset(0xA50)] public AtkComponentDropDownList* JobDropdown;

    [FieldOffset(0xA78)] public AtkComponentDropDownList* OrderDropdown;
}
