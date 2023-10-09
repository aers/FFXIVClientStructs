
namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("_ActionCross")]
[StructLayout(LayoutKind.Explicit, Size = 0x710)]
public struct AddonActionCross {
    [FieldOffset(0x000)] public AddonActionBarBase ActionBarBase;

    /// <summary>
    /// The selection state and/or the mapped hotbar set of the Left->Right Expanded Hold Bar.<br/>
    /// </summary>
    /// <returns>Returns 0 if the Left->Right bar is not currently selected.<br/>
    /// If the bar is selected, returns a value representing the hotbar set currently mapped to the Left->Right input.
    /// </returns>
    /// <remarks>This value is related to the config options "HotbarCrossAdvancedSettingRight" and "HotbarCrossAdvancedSettingRightPvp", but is off-by-one because it uses 0 as the non-selected state.</remarks>
    [FieldOffset(0x6E8)] public int ExpandedHoldControlsLTRT;

    /// <summary>
    /// Indicates the selection state and/or the mapped hotbar set of the Right->Left Expanded Hold Bar.<br/>
    /// </summary>
    /// <returns>Returns 0 if the Right->Left bar is not currently selected.<br/>
    /// If the bar is selected, returns a value representing the hotbar set currently mapped to the Right->Left input.
    /// </returns>
    /// <remarks>This value is related to the config options "HotbarCrossAdvancedSettingLeft" and "HotbarCrossAdvancedSettingLeftPvp", but is off-by-one because it uses 0 as the non-selected state.</remarks>
    [FieldOffset(0x6EC)] public int ExpandedHoldControlsRTLT;

    /// <summary>
    /// Indicates whether the left-trigger bar is currently selected.
    /// </summary>
    [FieldOffset(0x701)] public bool LeftBar;

    /// <summary>
    /// Indicates whether the right-trigger bar is currently selected.
    /// </summary>
    [FieldOffset(0x702)] public bool RightBar;

    /// <summary>
    /// Indicates whether the Pet Cross hotbar (represented by a "+" icon) is active and overriding the selected Cross Hotbar set.
    /// </summary>
    [FieldOffset(0x704)] public bool PetBar;

    /// <summary>
    /// The combined selection state and/or bar target of the Expanded Hold controls.
    /// </summary>
    public int ExpandedHoldControls => ExpandedHoldControlsLTRT > 0 ? ExpandedHoldControlsLTRT : ExpandedHoldControlsRTLT;

    /// <summary>
    /// The current selection state of the Cross hotbar.
    /// </summary>
    /// <remarks>Will return None if one of the Double Cross Hotbars is selected (Those bars will indicate their selection state in <see cref="AddonActionDoubleCrossBase"/>)</remarks>
    public ActionCrossSelect Selected =>
        LeftBar ? ActionCrossSelect.Left :
        RightBar ? ActionCrossSelect.Right :
        ExpandedHoldControlsLTRT > 0 ? ActionCrossSelect.LR :
        ExpandedHoldControlsRTLT > 0 ? ActionCrossSelect.RL :
        ActionCrossSelect.None;
}

/// <summary>
/// Possible selection states for the Cross Hotbar.
/// </summary>
public enum ActionCrossSelect { None, Left, Right, LR, RL }
