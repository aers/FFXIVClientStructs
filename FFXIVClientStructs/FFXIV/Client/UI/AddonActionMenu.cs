using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("ActionMenu")]
[StructLayout(LayoutKind.Explicit, Size = 0x1720)]
public unsafe partial struct AddonActionMenu {
    [FieldOffset(0x00)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x220)] public AtkComponentList* ActionList;
    [FieldOffset(0x228)] public AtkComponentList* TraitList;
    [FieldOffset(0x230)] public AtkComponentRadioButton* ActionsRadioButton;
    [FieldOffset(0x238)] public AtkComponentRadioButton* TraitsRadioButton;
    [FieldOffset(0x240)] public AtkComponentRadioButton* GathererRoleRadioButton; // Possibly old and unused now
    [FieldOffset(0x248)] public AtkComponentRadioButton* GeneralRadioButton;
    [FieldOffset(0x250)] public AtkComponentRadioButton* OrdersRadioButton;
    [FieldOffset(0x258)] public AtkComponentRadioButton* MainCommandsRadioButton;
    [FieldOffset(0x260)] public AtkComponentRadioButton* PerformanceRadioButton;
    [FieldOffset(0x268)] public AtkComponentRadioButton* ExtrasRadioButton;
    [FieldOffset(0x270)] public AtkComponentRadioButton* RoleRadioButton;

    [FixedSizeArray<ActionInfo>(80)]
    [FieldOffset(0x318)] public fixed byte ActionArray[0x38 * 80];

    [FieldOffset(0x14A8)] public AtkResNode* SidebarContainer; // Contains radio buttons for Actions, Role, Traits etc, including all of the icon buttons that are on the left side
    [FieldOffset(0x14B0)] public AtkResNode* ContentsContainer; // Contains all the nodes tha appear in the main area of the window
    [FieldOffset(0x14B8)] public AtkResNode* ActionsFooterContainer; // Contains the compact view toggle, some text, and a help button
    [FieldOffset(0x14C0)] public AtkComponentButton* HelpButton; // Opens Job Gauge Details window, Addon name: "Guide"
    [FieldOffset(0x14C8)] public AtkComponentButton* CompactModeToggleButton;
    [FieldOffset(0x14D0)] public AtkResNode* LevelTextContainer;
    [FieldOffset(0x14D8)] public AtkImageNode* JobIcon;
    [FieldOffset(0x14E0)] public AtkTextNode* JobText;

    // [FieldOffset(0x14E8)] public AtkTextNode* UnknownText;
    // [FieldOffset(0x14F0)] public AtkComponentNode* UnknownNode; // Appears to be the first action node in the new action view? Not sure.
    [FieldOffset(0x1510)] public AtkComponentScrollBar* Scrollbar;
    [FieldOffset(0x1518)] public AtkResNode* ActionContentsContainer; // Contains only the Actions nodes, only the new view
    [FieldOffset(0x1520)] public AtkCollisionNode* ActionCollision; // Collision node for the action contents area
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct ActionInfo {
    [FieldOffset(0x00)] public byte* ActionText; // ie "Cure\nLv. 2 MP: 400"
    [FieldOffset(0x08)] public byte* TooltipText; // ie "Displays a list of class actions." When hovering over the "Class" button in Compact View
    [FieldOffset(0x14)] public uint ActionId;
    [FieldOffset(0x18)] public uint IconId;
    [FieldOffset(0x24)] public uint ActionCategory; // ie "Ability", Seems to only be populated in the newer view for Actions

    // There appears to be some flags or individual bytes near the end of this struct
}
