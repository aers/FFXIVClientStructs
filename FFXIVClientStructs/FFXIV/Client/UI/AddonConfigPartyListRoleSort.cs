using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonConfigPartyListRoleSort
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_ConfigPartyListRoleSort")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x290)]
public unsafe partial struct AddonConfigPartyListRoleSort {
    [FieldOffset(0x238)] public AtkComponentRadioButton* TankRadioButton;
    [FieldOffset(0x240)] public AtkComponentRadioButton* HealerRadioButton;
    [FieldOffset(0x248)] public AtkComponentRadioButton* DpsRadioButton;
    [FieldOffset(0x250)] public AtkComponentList* RoleList;
    [FieldOffset(0x258)] public AtkComponentButton* MoveUpButton;
    [FieldOffset(0x260)] public AtkComponentButton* MoveDownButton;
    [FieldOffset(0x268)] public AtkComponentButton* DefaultButton;
    [FieldOffset(0x270)] public AtkComponentButton* ApplyButton;
    [FieldOffset(0x278)] public AtkComponentButton* CloseButton;
    [FieldOffset(0x280)] public int SelectedRole;
    [FieldOffset(0x284)] public int SelectedItemIndex;
}
