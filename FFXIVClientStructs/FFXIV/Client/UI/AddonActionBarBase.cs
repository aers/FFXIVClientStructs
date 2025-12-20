using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonActionBarBase
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[GenerateInterop(isInherited: true)]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x260)]
public unsafe partial struct AddonActionBarBase {
    [FieldOffset(0x238)] public StdVector<ActionBarSlot> ActionBarSlotVector;

    /// <summary>
    /// Bitfield representing currently active pulses.
    /// </summary>
    [FieldOffset(0x250)] public short CurrentPulsingSlots;

    /// <summary>
    /// The ID of the hotbar in RaptureHotbarModule that this ActionBar is currently referencing. Changes when cycling to other bars.
    /// </summary>
    /// <remarks>
    /// This field is ignored for WHXBs.
    /// </remarks>
    [FieldOffset(0x254)] public byte RaptureHotbarId;

    [FieldOffset(0x256)] public byte SlotCount;
    [FieldOffset(0x257)] public bool IsLocked;
    /// <summary>
    /// Whether the current hotbar is considered a "shared" hotbar or not.
    /// </summary>
    [FieldOffset(0x258)] public bool IsSharedHotbar;
    [FieldOffset(0x25A)] public bool IsCrossHotbar;   // always true on XHB and WXHBs, false elsewhere
    [FieldOffset(0x25B)] public bool DragDropInProgress; // ignored by XHB and WXHBs
    [FieldOffset(0x25D)] public bool DisplayPetBar;

    /// <summary>
    /// Trigger the "pulse" effect for the specified hotbar slot, similar to what happens on hotbar slot keypress.
    ///
    /// This method *CAN* trigger pulses on hotbar slots that don't have an item in them!
    /// </summary>
    /// <param name="slotIndex">A zero-indexed value of which slot to pulse.</param>
    [VirtualFunction(81)]
    public partial void PulseActionBarSlot(int slotIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 48 81 C6 ?? ?? ?? ?? 83 C7 11")]
    public partial void UpdateHotbarSlot(ActionBarSlot* slot, NumberArrayData* numberArray, StringArrayData* stringArrayData, int numberArrayIndex, int stringArrayIndex);

    [MemberFunction("E8 ?? ?? ?? ?? EB 4B 48 8B CB")]
    public partial void ShowTooltip(AtkResNode* node, NumberArrayData* numberArray, StringArrayData* stringArrayData, int numberArrayIndex, int stringArrayIndex);
}

[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe struct ActionBarSlot {
    [FieldOffset(0x00)] public AtkComponentDragDrop* ComponentDragDrop;
    [FieldOffset(0x08)] public AtkImageNode* ChargeIcon;
    [FieldOffset(0x10)] public AtkResNode* RecastOverlayContainer;
    [FieldOffset(0x18)] public AtkResNode* IconFrame;
    [FieldOffset(0x20)] public CStringPointer PopUpHelpTextPtr; // Null when slot is empty
    [FieldOffset(0x30)] public int HotbarId; // Not persistent, only updated if slot is visible
    [FieldOffset(0x34)] public int ActionId;       // Not cleared when slot is emptied
    [FieldOffset(0xB8)] public AtkComponentNode* Icon;
    [FieldOffset(0xC0)] public AtkTextNode* ControlHintTextNode;
}
