using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI; 

[StructLayout(LayoutKind.Explicit, Size = 0x248)]
public unsafe partial struct AddonActionBarBase {
    [FieldOffset(0x00)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x220)] public ActionBarSlot* ActionBarSlots;

    /// <summary>
    /// Bitfield representing currently active pulses.
    /// </summary>
    [FieldOffset(0x238)] public short CurrentPulsingSlots;
    
    /// <summary>
    /// The ID of the hotbar in RaptureHotbarModule that this ActionBar is currently referencing.
    /// </summary>
    /// <remarks>
    /// This field is ignored for WHXBs.
    /// </remarks>
    [FieldOffset(0x23C)] public byte RaptureHotbarId;

    [FieldOffset(0x23E)] public byte SlotCount;
    
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
    [VirtualFunction(77)]
    public partial void PulseActionBarSlot(int slotIndex);


    public Span<ActionBarSlot> Slot => new(ActionBarSlots, SlotCount);

}

[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe struct ActionBarSlot {
    [FieldOffset(0x04)] public int ActionId;       // Not cleared when slot is emptied
    [FieldOffset(0x90)] public AtkComponentNode* Icon;
    [FieldOffset(0x98)] public AtkTextNode* ControlHintTextNode;
    [FieldOffset(0xA0)] public AtkResNode* IconFrame;
    [FieldOffset(0xA8)] public AtkImageNode* ChargeIcon;
    [FieldOffset(0xB0)] public AtkResNode* RecastOverlayContainer;
    [FieldOffset(0xB8)] public byte* PopUpHelpTextPtr; // Null when slot is empty
}