
namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("_ActionCross")]
[StructLayout(LayoutKind.Explicit, Size = 0x710)]
public struct AddonActionCross {
    [FieldOffset(0x000)] public AddonActionBarBase ActionBarBase;

    /// <summary>
    /// Bitmask representing the current input state of the D-Pad and 4 face buttons.
    /// </summary>
    /// <remarks>This is not the raw controller input data; it represents the state of these input values after mappings  &amp; keybinds are applied.</remarks>
    [FieldOffset(0x6E0)] public byte ButtonMask;

    /// <summary>
    /// The selection state and/or the mapped hotbar set of the Left->Right Expanded Hold Bar.<br/>
    /// Value is 0 if the Left->Right bar is not currently selected.<br/>
    /// If the Left->Right bar is selected, the value indicates the set currently mapped to that input.
    /// </summary>
    /// <remarks>This value is related to the config options "HotbarCrossAdvancedSettingRight" and "HotbarCrossAdvancedSettingRightPvp", but is off-by-one because it uses 0 as the non-selected state.</remarks>
    [FieldOffset(0x6E8)] public int ExpandedHoldControlsLTRT;

    /// <summary>
    /// The selection state and/or the mapped hotbar set of the Right->Left Expanded Hold Bar.<br/>
    /// Value is 0 if the Right->Left bar is not currently selected.<br/>
    /// If the Right->Left bar is selected, the value indicates the set currently mapped to that input.
    /// </summary>
    /// <remarks>This value is related to the config options "HotbarCrossAdvancedSettingLeft" and "HotbarCrossAdvancedSettingLeftPvp", but is off-by-one because it uses 0 as the non-selected state.</remarks>
    [FieldOffset(0x6EC)] public int ExpandedHoldControlsRTLT;

    /// <summary>
    /// The combined selection state and/or mapped Cross Hotbar set of the Expanded Hold controls.
    /// </summary>
    public int ExpandedHoldControls => ExpandedHoldControlsLTRT > 0 ? ExpandedHoldControlsLTRT : ExpandedHoldControlsRTLT;

    /// <summary>
    /// Indicates whether the Left Double Cross Hotbar (WXHB) is currently selected.
    /// </summary>
    [FieldOffset(0x6F0)] public bool DoubleCrossLeft;

    /// <summary>
    /// Indicates whether the Right Double Cross Hotbar (WXHB) is currently selected.
    /// </summary>
    [FieldOffset(0x6F4)] public bool DoubleCrossRight;

    /// <summary>
    /// Indicates whether the Left Cross Hotbar is currently selected.
    /// </summary>
    [FieldOffset(0x701)] public bool LeftBar;

    /// <summary>
    /// Indicates whether the Right Cross Hotbar is currently selected.
    /// </summary>
    [FieldOffset(0x702)] public bool RightBar;

    /// <summary>
    /// The current selection state of the Cross hotbar.
    /// </summary>
    public ActionCrossSelect Selected =>
        LeftBar ? ActionCrossSelect.Left :
        RightBar ? ActionCrossSelect.Right :
        ExpandedHoldControlsLTRT > 0 ? ActionCrossSelect.LR :
        ExpandedHoldControlsRTLT > 0 ? ActionCrossSelect.RL :
        DoubleCrossLeft ? ActionCrossSelect.DoubleCrossLeft :
        DoubleCrossRight ? ActionCrossSelect.DoubleCrossRight :
        ActionCrossSelect.None;

    /// <summary>
    /// Indicates whether the Pet Cross hotbar (represented by a "+" icon) is active and overriding the selected Cross Hotbar set.
    /// </summary>
    [FieldOffset(0x704)] public bool PetBar;

    /// <summary>
    /// Alpha value based on the "Standard" transparency configuration slider for the Cross Hotbar.
    /// </summary>
    [FieldOffset(0x708)] public byte AlphaStandard;

    /// <summary>
    /// Alpha value based on the "Active" transparency configuration slider for the Cross Hotbar.
    /// </summary>
    [FieldOffset(0x709)] public byte AlphaActive;

    /// <summary>
    /// Alpha value based on the "Inactive" transparency configuration slider for the Cross Hotbar.
    /// </summary>
    [FieldOffset(0x70A)] public byte AlphaInactive;
}

/// <summary>
/// Possible selection states for the Cross Hotbar.
/// </summary>
public enum ActionCrossSelect { None, Left, Right, LR, RL, DoubleCrossLeft, DoubleCrossRight }
