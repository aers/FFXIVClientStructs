using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.WeeklyBingo)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x218)]
public unsafe partial struct AgentWeeklyBingo {
    [FieldOffset(0x28)] public void* WeeklyBingoOrderDataSheet;
    [FieldOffset(0x30)] public ExcelSheetWaiter* WeeklyBingoOrderDataSheetWaiter;
    [FieldOffset(0x38)] public void* WeeklyBingoRewardDataSheet;
    [FieldOffset(0x40)] public ExcelSheetWaiter* WeeklyBingoRewardDataSheetWaiter;
    [FieldOffset(0x48)] public void* WeeklyBingoTextSheet;
    [FieldOffset(0x50)] public ExcelSheetWaiter* WeeklyBingoTextSheetWaiter;

    [FieldOffset(0x58)] public bool IsOrderDataSheetReady;
    [FieldOffset(0x59)] public bool IsRewardDataSheetReady;
    [FieldOffset(0x5A)] public bool IsTextSheetReady;

    [FieldOffset(0x74)] public uint ContextMenuSelectedItemId;

    [FieldOffset(0x7C)] internal FixedSizeArray16<ushort> _orderDataRowIds;
    [FieldOffset(0xA0)] internal FixedSizeArray16<bool> _stickerAppliedSlots;

    [FieldOffset(0xD8)] internal FixedSizeArray13<CStringPointer> _addonStrings;
}

