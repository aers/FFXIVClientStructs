using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Duty action manager maintains two duty action slots
// In some contexts, game uses value of the PrimaryCostType (column in Action sheet) to identify duty actions, with 20 meaning 'slot 0' and 21 meaning 'slot 1'
// The game sets available actions either by referencing ContentExAction sheet, or by specifying details explicitly
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct DutyActionManager {
    [FieldOffset(0x00)] public byte PendingContentExActionRowId; // if not equal to current, on next tick game will start reading the sheet and will initialize set of actions when done
    [FieldOffset(0x01)] public byte CurrentContentExActionRowId;
    [FieldOffset(0x08)] public ExcelSheet* ContentExActionSheet;
    [FieldOffset(0x10)] public nint RowReader;
    [FieldOffset(0x18)] public byte NumValidSlots;
    [FieldOffset(0x19)] public bool ActionsPresent; // see RaptureHotbarModule.SetDutyActionsPresent
    [FieldOffset(0x1A), FixedSizeArray] internal FixedSizeArray5<bool> _actionActive;
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray5<uint> _actionId;
    [FieldOffset(0x34), FixedSizeArray] internal FixedSizeArray5<RecastDetail> _recast;
    [FieldOffset(0x98), FixedSizeArray] internal FixedSizeArray2<byte> _maxCharges;
    [FieldOffset(0x9A), FixedSizeArray] internal FixedSizeArray2<byte> _curCharges;

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 ?? 8B D3 48 8B C8 E8 ?? ?? ?? ?? 3C 01")]
    public static partial DutyActionManager* GetInstanceIfReady();

    /// <summary>
    /// Returns the ID of the action present at the specified Duty Action slot.
    /// </summary>
    /// <param name="dutyActionSlot">The Duty Action slot number (0 or 1) to look up.</param>
    /// <returns>Returns an Action ID.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 8B F0 EB 41")]
    public static partial uint GetDutyActionId(ushort dutyActionSlot);
}
