using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("_ActionCross")]
[StructLayout(LayoutKind.Explicit, Size = 0x710)]
public unsafe partial struct AddonActionCross {
    [FieldOffset(0x000)] public AddonActionBarBase ActionBarBase;

    [FieldOffset(0x248)] public ChangeSetUI ChangeSet;
    [FieldOffset(0x3A0)] public AtkComponentNode* PadlockNode;
    [FieldOffset(0x3A8)] public AtkComponentCheckBox* PadlockCheckbox;

    [FixedSizeArray<SlotGroup>(4)]
    [FieldOffset(0x3B0)] public fixed byte SlotGroups[4 * SlotGroup.Size];

    [FieldOffset(0x530)] public ControlGuide ControlGuideDpad;
    [FieldOffset(0x578)] public ControlGuide ControlGuideActionButtons;
    [FieldOffset(0x5C0)] public AtkTextNode* SetNumIconNode;
    [FieldOffset(0x5C8)] public AtkComponentBase* ControlGuideEditComponent;
    [FieldOffset(0x6C8)] public AtkResNode* RootNode;
    [FieldOffset(0x6D0)] public AtkResNode* ContainerNode;
    [FieldOffset(0x6E0)] public byte ButtonMask; // not raw input data; represents input state after keybinds/mappings

    // values from 1-20 can be converted to a hotbar ID and left/right bool using GetMappedHotbar()
    [FieldOffset(0x6E8)] public uint ExpandedHoldMapValueLR;
    [FieldOffset(0x6EC)] public uint ExpandedHoldMapValueRL;

    [FieldOffset(0x6F0)] public bool SelectedDoubleCrossLeft;
    [FieldOffset(0x6F4)] public bool SelectedDoubleCrossRight;
    [FieldOffset(0x700)] public bool InEditMode;
    [FieldOffset(0x701)] public bool SelectedLeft;
    [FieldOffset(0x702)] public bool SelectedRight;
    [FieldOffset(0x703)] public bool DisplayChangeSet;
    [FieldOffset(0x704)] public bool DisplayPetBar;
    [FieldOffset(0x706)] public bool AlternateDisplayType;
    [FieldOffset(0x707)] public bool OverrideHidden; // if the XHB is hidden via HUD options, this field indicates whether it should be temporarily revealed

    [FieldOffset(0x708)] public byte AlphaStandard;
    [FieldOffset(0x709)] public byte AlphaActive;
    [FieldOffset(0x70A)] public byte AlphaInactive;

    [StructLayout(LayoutKind.Explicit, Size = 0x158)]
    public partial struct ChangeSetUI { // in control guide arrays: 0=top, 1=right, 2=bottom, 3=left

        [FixedSizeArray<HelpMessage>(8)]
        [FieldOffset(0x000)] public fixed byte HelpMessages[8 * HelpMessage.Size]; // hidden "hotbar help" style nodes attached to the Change Set display for some reason

        [FixedSizeArray<Pointer<AtkComponentNode>>(8)]
        [FieldOffset(0x080)] public fixed byte NumIcons[8 * 8];

        [FieldOffset(0x0C0)] public AtkResNode* ContainerNode;

        [FixedSizeArray<Pointer<AtkComponentBase>>(4)]
        [FieldOffset(0x0D0)] public fixed byte DpadComponents[4 * 8];

        [FixedSizeArray<Pointer<AtkResNode>>(4)]
        [FieldOffset(0x0F0)] public fixed byte DpadNodes[4 * 8];

        [FixedSizeArray<Pointer<AtkComponentBase>>(4)]
        [FieldOffset(0x118)] public fixed byte ActionButtonComponents[4 * 8];

        [FixedSizeArray<Pointer<AtkResNode>>(4)]
        [FieldOffset(0x138)] public fixed byte ActionButtonNodes[4 * 8];
    }

    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public partial struct SlotGroup {
        public const int Size = 0x60;

        [FixedSizeArray<HelpMessage>(4)]
        [FieldOffset(0x00)] public fixed byte HotbarHelp[4 * HelpMessage.Size];

        [FieldOffset(0x40)] public AtkComponentNode* SlotContainer;
        [FieldOffset(0x48)] public AtkComponentNode* HotbarHelpContainer;
    }

    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public partial struct HelpMessage {
        public const int Size = 0x10;

        [FieldOffset(0x00)] public AtkComponentBase* HelpComponent;
        [FieldOffset(0x08)] public AtkTextNode* HelpText;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x48)] // in control guide arrays: 0=top, 1=right, 2=bottom, 3=left
    public partial struct ControlGuide {
        [FieldOffset(0x00)] public AtkComponentBase* ComponentBase;

        [FixedSizeArray<Pointer<AtkComponentBase>>(4)]
        [FieldOffset(0x08)] public fixed byte Components[4 * 8];

        [FixedSizeArray<Pointer<AtkResNode>>(4)]
        [FieldOffset(0x28)] public fixed byte Nodes[4 * 8];
    }

    /// <summary>The current selection state of the Cross hotbar.</summary>
    public ActionCrossSelect Selected =>
        SelectedLeft ? ActionCrossSelect.Left :
        SelectedRight ? ActionCrossSelect.Right :
        ExpandedHoldMapValueLR > 0 ? ActionCrossSelect.LR :
        ExpandedHoldMapValueRL > 0 ? ActionCrossSelect.RL :
        SelectedDoubleCrossLeft ? ActionCrossSelect.DoubleCrossLeft :
        SelectedDoubleCrossRight ? ActionCrossSelect.DoubleCrossRight :
        ActionCrossSelect.None;

    public uint ExpandedHoldMapValue => ExpandedHoldMapValueLR > 0 ? ExpandedHoldMapValueLR : ExpandedHoldMapValueRL;

    public uint GetExpandedHoldBarTarget(bool* useLeftSide) => GetAdjustedBarTarget(ExpandedHoldMapValue, useLeftSide);

    /// <summary>Calls <see cref="GetBarTarget"/> but adjusts for the "cycle" options.</summary>
    /// <remarks>Anytime the client calls GetBarTarget(), it always adjusts the result in this way before actually using it.</remarks>
    public uint GetAdjustedBarTarget(uint mapValue, bool* useLeftSide) {
        var target = GetBarTarget(mapValue, useLeftSide);
        if (target == 19) target = (uint)(ActionBarBase.RaptureHotbarId - 1);
        if (target == 18) target = (uint)(ActionBarBase.RaptureHotbarId + 1);
        return target >= 18 ? 10 :
               target < 10 ? 17 :
               target;
    }

    /// <summary>
    /// Accepts a value representing the Expanded Hold Controls or WXHB configuration, and converts that value into the corresponding hotbar ID and a bool indicating which half of the bar to reference.
    /// </summary>
    /// <param name="mapValue">A value from 1-20.<br/>1-16 represent each half of the eight Cross Hotbar sets.<br/>17-20 represent the Cycle Up/Down options.</param>
    /// <param name="useLeftSide">True = left side of target bar, False = right side of target bar</param>
    /// <returns>The hotbar ID (<see cref="AddonActionBarBase.RaptureHotbarId"/>) of the set of actions assigned to this input.<br/>
    /// The Cycle Up/Down options will return the values 18 or 19, which are not actual bar IDs. You can use <see cref="GetAdjustedBarTarget"/> instead to account for this.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 8B D0 83 F8 12 74 38")]
    public static partial uint GetBarTarget(uint mapValue, bool* useLeftSide);

    // renamed fields for clarity
    [Obsolete("use ExpandedHoldMapValueLR")]
    [FieldOffset(0x6E8)] public int ExpandedHoldControlsLTRT;
    [Obsolete("use ExpandedHoldMapValueRL")]
    [FieldOffset(0x6EC)] public int ExpandedHoldControlsRTLT;
    [Obsolete("use SelectedDoubleCrossLeft")]
    [FieldOffset(0x6F0)] public bool DoubleCrossLeft;
    [Obsolete("use SelectedDoubleCrossRight")]
    [FieldOffset(0x6F4)] public bool DoubleCrossRight;
    [Obsolete("use SelectedLeftBar")]
    [FieldOffset(0x701)] public bool LeftBar;
    [Obsolete("use SelectedRightBar")]
    [FieldOffset(0x702)] public bool RightBar;
    [Obsolete("use DisplayPetBar")]
    [FieldOffset(0x704)] public bool PetBar;
    [Obsolete("use ExpandedHoldMapValue")]
    public int ExpandedHoldControls => (int)ExpandedHoldMapValue;
}

/// <summary>Possible selection states for the Cross Hotbar.</summary>
public enum ActionCrossSelect { None, Left, Right, LR, RL, DoubleCrossLeft, DoubleCrossRight }
