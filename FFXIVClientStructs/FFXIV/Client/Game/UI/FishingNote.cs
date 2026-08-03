using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::FishingNote
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public unsafe struct FishingNote {
    [FieldOffset(0x50)] public FishingNoteMode Mode;

    [FieldOffset(0x48)] public FishingNoteLoadState FishingLoadState;
    [FieldOffset(0x4C)] public FishingNoteLoadState SpearfishingLoadState;

    [FieldOffset(0x70)] public ExcelSheetWaiter* FishingSpotWaiter;
    [FieldOffset(0x78)] public ExcelSheetWaiter* FishParameterWaiter;
    [FieldOffset(0x80)] public ExcelSheetWaiter* SpearfishingNotebookWaiter;
    [FieldOffset(0x88)] public ExcelSheetWaiter* SpearfishingItemWaiter;
    [FieldOffset(0x90)] public ExcelSheetWaiter* FishingNoteInfoWaiter;
}

public enum FishingNoteMode : byte {
    Fishing = 0,
    Spearfishing = 1,
}

public enum FishingNoteLoadState {
    None = 0,
    Loading = 1, // waiters are loading
    Ready = 2,
}
