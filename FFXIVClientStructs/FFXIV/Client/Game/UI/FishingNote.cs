using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::FishingNote
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public unsafe partial struct FishingNote {
    [FieldOffset(0x00)] public GameEventCallback* GameEventCallback;
    // array of 2 (for each mode) containing 2x StdSets(?)
    [FieldOffset(0x50)] public ulong Mode; // 0 = Fishing, 1 = Spearfishing

    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray2<FishingNoteLoadState> _loadStates;

    [FieldOffset(0x70)] public ExcelSheetWaiter* FishingSpotSheetWaiter;
    [FieldOffset(0x78)] public ExcelSheetWaiter* FishParameterSheetWaiter;
    [FieldOffset(0x80)] public ExcelSheetWaiter* SpearfishingNotebookSheetWaiter;
    [FieldOffset(0x88)] public ExcelSheetWaiter* SpearfishingItemSheetWaiter;
    [FieldOffset(0x90)] public ExcelSheetWaiter* FishingNoteSheetWaiter;
}

public enum FishingNoteLoadState {
    None = 0,
    Loading = 1, // waiters are loading
    Ready = 2,
}
