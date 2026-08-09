using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMiragePrismPrismBoxCrystallize
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("MiragePrismPrismBoxCrystallize")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2E0)]
public unsafe partial struct AddonMiragePrismPrismBoxCrystallize {
    [FieldOffset(0x238)] public AtkComponentTreeList* ItemTreeList;
    [FieldOffset(0x240)] private void* Unk240; // icon renderer?
    [FieldOffset(0x248)] private void* Unk248; // text renderer?
    [FieldOffset(0x250)] private void* Unk250; // I think it's some callback to the tree list populator
    [FieldOffset(0x268)] public AtkComponentCheckBox* GearsetFilterCheckbox;
    [FieldOffset(0x270), FixedSizeArray] internal FixedSizeArray6<CStringPointer> _categoryLabels;
    [FieldOffset(0x2A0)] private byte Unk2A0;
    [FieldOffset(0x2A8)] public AtkComponentDropDownList* CategoryDropDown;
    [FieldOffset(0x2B0)] public AtkComponentButton* CategoryPrevButton;
    [FieldOffset(0x2B8)] public AtkComponentButton* CategoryNextButton;
    [FieldOffset(0x2D8)] public bool IsTooltipVisible;
}
