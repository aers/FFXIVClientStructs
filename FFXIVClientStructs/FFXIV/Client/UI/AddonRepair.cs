using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRepair
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0xF7A0)]
public unsafe struct AddonRepair
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x228)] public AtkTextNode* UnusedText1; // Top right corner
    [FieldOffset(0x230)] public AtkTextNode* JobLevel;
    [FieldOffset(0x238)] public AtkImageNode* JobIcon;
    [FieldOffset(0x240)] public AtkTextNode* JobName;
    [FieldOffset(0x248)] public AtkTextNode* UnusedText2; // Top right corner
    [FieldOffset(0x250)] public AtkComponentDropDownList* Dropdown;
    [FieldOffset(0x258)] public AtkComponentButton* RepairAllButton;
    [FieldOffset(0x260)] public AtkResNode* HeaderContainer;
    [FieldOffset(0x268)] public AtkTextNode* UnusedText3; // Bottom right corner
    [FieldOffset(0x270)] public AtkTextNode* NothingToRepairText; // Middle of screen;
    [FieldOffset(0x278)] public AtkComponentList* ItemList;
}