using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonActionBarBase
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[GenerateInterop(isInherited: true)]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x258)]
public unsafe partial struct AddonActionBarBase {
    [FieldOffset(0x230)] public StdVector<ActionBarSlot> ActionBarSlotVector;

    /// <summary>
    /// Bitfield representing currently active pulses.
    /// </summary>
    [FieldOffset(0x248)] public short CurrentPulsingSlots;

    /// <summary>
    /// The ID of the hotbar in RaptureHotbarModule that this ActionBar is currently referencing. Changes when cycling to other bars.
    /// </summary>
    /// <remarks>
    /// This field is ignored for WHXBs.
    /// </remarks>
    [FieldOffset(0x24C)] public byte RaptureHotbarId;

    [FieldOffset(0x24E)] public byte SlotCount;
    [FieldOffset(0x24F)] public bool IsLocked;
    /// <summary>
    /// Whether the current hotbar is considered a "shared" hotbar or not.
    /// </summary>
    [FieldOffset(0x250)] public bool IsSharedHotbar;
    [FieldOffset(0x252)] public bool IsCrossHotbar;   // always true on XHB and WXHBs, false elsewhere
    [FieldOffset(0x253)] public bool DragDropInProgress; // ignored by XHB and WXHBs
    [FieldOffset(0x255)] public bool DisplayPetBar;

    /// <summary>
    /// Trigger the "pulse" effect for the specified hotbar slot, similar to what happens on hotbar slot keypress.
    ///
    /// Note that this method *CAN* trigger pulses on hotbar slots that don't have an item in them!
    /// </summary>
    /// <param name="slotIndex">A zero-indexed value of which slot to pulse.</param>
    [VirtualFunction(79)]
    public partial void PulseActionBarSlot(int slotIndex);
}

[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe struct ActionBarSlot {
    [FieldOffset(0x00)] public int HotbarId; // Not persistent, only updated if slot is visible
    [FieldOffset(0x04)] public int ActionId;       // Not cleared when slot is emptied
    [FieldOffset(0x88)] public AtkComponentDragDrop* ComponentDragDrop;
    [FieldOffset(0x90)] public AtkComponentNode* Icon;
    [FieldOffset(0x98)] public AtkTextNode* ControlHintTextNode;
    [FieldOffset(0xA0)] public AtkResNode* IconFrame;
    [FieldOffset(0xA8)] public AtkImageNode* ChargeIcon;
    [FieldOffset(0xB0)] public AtkResNode* RecastOverlayContainer;
    [FieldOffset(0xB8)] public byte* PopUpHelpTextPtr; // Null when slot is empty
}
