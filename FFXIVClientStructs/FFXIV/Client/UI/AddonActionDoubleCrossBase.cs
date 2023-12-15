using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("_ActionDoubleCrossL", "_ActionDoubleCrossR")]
[StructLayout(LayoutKind.Explicit, Size = 0x2F8)]
public unsafe partial struct AddonActionDoubleCrossBase {
    [FieldOffset(0x000)] public AddonActionBarBase ActionBarBase;

    [FieldOffset(0x248)] public AtkResNode* ContainerNode;
    [FieldOffset(0x250)] public AtkComponentNode* SlotContainerL;
    [FieldOffset(0x258)] public AtkComponentNode* SlotContainerR;

    [FixedSizeArray<AddonActionCross.HelpMessage>(4)]
    [FieldOffset(0x260)] public fixed byte HotbarHelpL[4 * AddonActionCross.HelpMessage.Size];

    [FixedSizeArray<AddonActionCross.HelpMessage>(4)]
    [FieldOffset(0x2A0)] public fixed byte HotbarHelpR[4 * AddonActionCross.HelpMessage.Size];

    /// <summary>
    /// Indicates whether this bar is selected.
    /// </summary>
    [FieldOffset(0x2E0)] public bool Selected;

    /// <summary>
    /// Set to 1 when the WXHB is showing the directional pad inputs as well as the action button inputs.
    /// </summary>
    [FieldOffset(0x2E1)] public byte ShowDPadSlots;

    [FieldOffset(0x2E2)] public bool AlwaysDisplay;
    [FieldOffset(0x2E3)] public bool OtherBarSelected; // true if any bar other than this one is selected
    [FieldOffset(0x2E4)] public bool DoubleTapDetected; // true if the currently-held trigger matches the previous trigger press.

    /// <summary>
    /// The ID of the hotbar in <see cref="RaptureHotbarModule"/> that this action bar is currently referencing.
    /// </summary>
    [FieldOffset(0x2E8)] public byte BarTarget;

    /// <summary>
    /// Use the left side (slots 0-7) of the hotbar specified in <see cref="BarTarget"/>.
    /// </summary>
    /// <remarks>
    /// In effect, when this is false, it means any given HotBarSlot will be at index +8 from the index in the UI.
    /// </remarks>
    [FieldOffset(0x2EC)] public byte UseLeftSide;

    /// <summary>
    /// Set to 1 when the WXHB is in "merged positioning" mode with the normal cross hotbar.
    /// </summary>
    [FieldOffset(0x2ED)] public byte MergedPositioning;
}
