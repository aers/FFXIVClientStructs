namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::ContentsNote
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct ContentsNote {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 83 F8 02 75 16", 3)]
    public static partial ContentsNote* Instance();

    // BitCount: ContentsNoteSheet.RowCount
    [FieldOffset(0x08), FixedSizeArray(isBitArray: true, bitCount: 104)] internal FixedSizeArray13<byte> _completionFlags;
    [FieldOffset(0x18)] public ContentsNoteState State;
    [FieldOffset(0x1C)] public byte SelectedTab;
    [FieldOffset(0x1D)] public byte DisplayCount;
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray19<int> _displayIds;
    [FieldOffset(0x6C), FixedSizeArray] internal FixedSizeArray19<int> _displayStatuses;

    public bool IsContentNoteComplete(int rowId)
        => CompletionFlagsBitArray.Get(rowId - 1);

    public enum ContentsNoteState {
        Invalid = 0,
        Requested = 1,
        Loaded = 2,
    }
}
