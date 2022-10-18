using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.UI; 

[StructLayout(LayoutKind.Explicit, Size = 0x2F8)]
[Addon("_ActionDoubleCrossL", "_ActionDoubleCrossR")]
public struct AddonActionDoubleCrossBase {
    [FieldOffset(0x000)] public AddonActionBarBase ActionBarBase;

    /// <summary>
    /// Set to 1 when the WXHB is showing the directional pad inputs as well as the action button inputs.
    /// </summary>
    [FieldOffset(0x2E1)] public byte ShowDPadSlots;
    
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