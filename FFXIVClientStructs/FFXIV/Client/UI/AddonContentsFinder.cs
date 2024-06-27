using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonContentsFinder
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("ContentsFinder")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x16C8)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 03 48 8D BB ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 AB ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 8D 75 02 48 89 AB ?? ?? ?? ?? 66 90 48 8B CF E8 ?? ?? ?? ?? 48 83 C7 09 48 83 EE 01 75 EE 48 8D 8B", 3)]
public unsafe partial struct AddonContentsFinder {
    [FieldOffset(0x250)] public AtkAddonControl AddonControl;

    [FieldOffset(0x2B8)] public AtkComponentButton* JoinButton; // Both Join and Withdraw
    [FieldOffset(0x2C0)] public AtkComponentButton* ClearSelectionButton; // Both ClearSelection and DutyStatus

    [FieldOffset(0x2C8)] public AtkComponentRadioButton* DutyRouletteRadioButton;
    [FieldOffset(0x2D0)] public AtkComponentRadioButton* Dungeons1RadioButton;
    [FieldOffset(0x2D8)] public AtkComponentRadioButton* Dungeons2RadioButton;
    [FieldOffset(0x2E0)] public AtkComponentRadioButton* GuildHeistsRadioButton;
    [FieldOffset(0x2E8)] public AtkComponentRadioButton* Trials1RadioButton;
    [FieldOffset(0x2F0)] public AtkComponentRadioButton* Trials2RadioButton;
    [FieldOffset(0x2F8)] public AtkComponentRadioButton* Raids1RadioButton;
    [FieldOffset(0x300)] public AtkComponentRadioButton* Raids2RadioButton;
    [FieldOffset(0x308)] public AtkComponentRadioButton* PvpRadioButton;
    [FieldOffset(0x310)] public AtkComponentRadioButton* GoldSaucerRadioButton;

    [FieldOffset(0x318), FixedSizeArray] internal FixedSizeArray5<Pointer<AtkTextNode>> _selectedDutyTextNode;

    // Top bar buttons/icons indicating what duty finder settings are active, ie Unsync, LootMaster
    [FieldOffset(0x3C8), FixedSizeArray] internal FixedSizeArray8<Pointer<AtkComponentButton>> _settingsButton;

    [FieldOffset(0x340)] public AtkComponentTreeList* DutyList; // Does not contain a pointer to the rendered list =(
    [FieldOffset(0x348)] public AtkComponentDropDownList* OrderByButton;
    [FieldOffset(0x350)] public AtkComponentButton* RefreshButton;
    [FieldOffset(0x358)] public AtkComponentButton* DutyTypeButton; // "Regular Duty" / "High End duty" toggle button

    [FieldOffset(0x360)] public AtkTextNode* JobNameTextNode;
    [FieldOffset(0x368)] public AtkTextNode* UnkTextNode;
    [FieldOffset(0x370)] public AtkTextNode* LevelTextNode;
    [FieldOffset(0x378)] public AtkTextNode* ItemLevelTextNode;
    [FieldOffset(0x380)] public AtkTextNode* RoleTextNode;
    [FieldOffset(0x388)] public AtkTextNode* NumberSelectedTextNode;
    [FieldOffset(0x390)] public AtkTextNode* ObtainingDataTextNode;
    [FieldOffset(0x398)] public AtkTextNode* NumOtherPartiesRecruitingTextNode;

    [FieldOffset(0x3A8)] public AtkImageNode* StarImageNode; // Image node next to ItemLevelTextNode
    [FieldOffset(0x3B0)] public AtkResNode* RoleIconResNode;
    [FieldOffset(0x3B8)] public AtkImageNode* RoleIconImageNode;
    [FieldOffset(0x3C0)] public AtkResNode* NumOtherPartiesRecruitingResNode;

    [FieldOffset(0x16A8)] public uint SelectedRadioButton; // Index of the selected radio button
    [FieldOffset(0x16B4)] public uint SelectedRow; // Index of the currently highlighted row, index does include headers that can't be clicked on, and collapsible headers
    [FieldOffset(0x16B8)] public uint NumEntries; // Number of entries the selected tab has, includes headers such as "High-end Trials (Endwalker)"
}
