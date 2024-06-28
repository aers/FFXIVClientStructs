using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonActionDoubleCrossBase
//   Client::UI::AddonActionBarBase
//     Component::GUI::AtkUnitBase
//       Component::GUI::AtkEventListener
[Addon("_ActionDoubleCrossL", "_ActionDoubleCrossR")]
[GenerateInterop]
[Inherits<AddonActionBarBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x308)]
public unsafe partial struct AddonActionDoubleCrossBase {
    [FieldOffset(0x258)] public AtkResNode* ContainerNode;
    [FieldOffset(0x260)] public AtkComponentNode* SlotContainerL;
    [FieldOffset(0x268)] public AtkComponentNode* SlotContainerR;

    [FieldOffset(0x270), FixedSizeArray] internal FixedSizeArray4<AddonActionCross.HelpMessage> _hotbarHelpL;

    [FieldOffset(0x2B0), FixedSizeArray] internal FixedSizeArray4<AddonActionCross.HelpMessage> _hotbarHelpR;

    /// <summary>
    /// Indicates whether this bar is selected.
    /// </summary>
    [FieldOffset(0x2F0)] public bool Selected;

    /// <summary>
    /// Set to 1 when the WXHB is showing the directional pad inputs as well as the action button inputs.
    /// </summary>
    [FieldOffset(0x2F1)] public byte ShowDPadSlots;

    [FieldOffset(0x2F2)] public bool AlwaysDisplay;
    [FieldOffset(0x2F3)] public bool OtherBarSelected; // true if any bar other than this one is selected
    [FieldOffset(0x2F4)] public bool DoubleTapDetected; // true if the currently-held trigger matches the previous trigger press.

    /// <summary>
    /// The ID of the hotbar in <see cref="RaptureHotbarModule"/> that this action bar is currently referencing.
    /// </summary>
    [FieldOffset(0x2F8)] public byte BarTarget;

    /// <summary>
    /// Use the left side (slots 0-7) of the hotbar specified in <see cref="BarTarget"/>.
    /// </summary>
    /// <remarks>
    /// In effect, when this is false, it means any given HotBarSlot will be at index +8 from the index in the UI.
    /// </remarks>
    [FieldOffset(0x2FC)] public byte UseLeftSide;

    /// <summary>
    /// Set to 1 when the WXHB is in "merged positioning" mode with the normal cross hotbar.
    /// </summary>
    [FieldOffset(0x2FD)] public byte MergedPositioning;
}
