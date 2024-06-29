using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRepair
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Repair")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xF7F8)]
public unsafe partial struct AddonRepair {
    [FieldOffset(0x238)] public AtkTextNode* UnusedText1; // Top right corner
    [FieldOffset(0x240)] public AtkTextNode* JobLevel;
    [FieldOffset(0x248)] public AtkImageNode* JobIcon;
    [FieldOffset(0x250)] public AtkTextNode* JobName;
    [FieldOffset(0x258)] public AtkTextNode* UnusedText2; // Top right corner
    [FieldOffset(0x260)] public AtkComponentDropDownList* Dropdown;

    [FieldOffset(0x278)] public AtkComponentButton* RepairAllButton;
    [FieldOffset(0x280)] public AtkResNode* HeaderContainer;
    [FieldOffset(0x288)] public AtkTextNode* UnusedText3; // Bottom right corner
    [FieldOffset(0x290)] public AtkTextNode* NothingToRepairText; // Middle of screen;
    [FieldOffset(0x298)] public AtkComponentList* ItemList;
}
