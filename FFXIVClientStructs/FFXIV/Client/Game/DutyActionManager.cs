using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Duty action manager maintains two duty action slots
// In some contexts, game uses value of the PrimaryCostType (column in Action sheet) to identify duty actions, with 20 meaning 'slot 0' and 21 meaning 'slot 1'
// The game sets available actions either by referencing ContentExAction sheet, or by specifying details explicitly
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct DutyActionManager {
    [FieldOffset(0x00)] public byte PendingContentExActionRowId; // if not equat to current, on next tick game will start reading the sheet and will initialize set of actions when done
    [FieldOffset(0x01)] public byte CurrentContentExActionRowId;
    [FieldOffset(0x08)] public ExcelSheet* ContentExActionSheet;
    [FieldOffset(0x10)] public nint RowReader;
    [FieldOffset(0x18)] public byte NumValidSlots;
    [FieldOffset(0x1C), FixedSizeArray] internal FixedSizeArray2<uint> _actionId;
    [FieldOffset(0x24), FixedSizeArray] internal FixedSizeArray2<byte> _maxCharges;
    [FieldOffset(0x28)] public bool ActionsPresent; // see RaptureHotbarModule.SetDutyActionsPresent
    [FieldOffset(0x29), FixedSizeArray] internal FixedSizeArray2<bool> _actionActive;
    [FieldOffset(0x2C), FixedSizeArray] internal FixedSizeArray2<RecastDetail> _recast;
    [FieldOffset(0x54), FixedSizeArray] internal FixedSizeArray2<byte> _curCharges;
}
