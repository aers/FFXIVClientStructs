using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI; 

[StructLayout(LayoutKind.Explicit, Size = 0x248)]
public unsafe partial struct AddonActionBarBase {
    [FieldOffset(0x00)] public AtkUnitBase AtkUnitBase;

    /// <summary>
    /// Bitfield representing currently active pulses.
    /// </summary>
    [FieldOffset(0x238)] public short CurrentPulsingSlots;
    
    /// <summary>
    /// The ID of the hotbar in RaptureHotbarModule that this ActionBar is currently referencing.
    /// </summary>
    [FieldOffset(0x23C)] public byte RaptureHotbarId;
    
    /// <summary>
    /// Whether the current hotbar is considered a "shared" hotbar or not.
    /// </summary>
    [FieldOffset(0x240)] public bool IsSharedHotbar;

    /// <summary>
    /// Trigger the "pulse" effect for the specified hotbar slot, similar to what happens on hotbar slot keypress.
    ///
    /// Note that this method *CAN* trigger pulses on hotbar slots that don't have an item in them!
    /// </summary>
    /// <param name="slotIndex">A zero-indexed value of which slot to pulse.</param>
    [VirtualFunction(76)]
    public partial void PulseActionBarSlot(int slotIndex);
}