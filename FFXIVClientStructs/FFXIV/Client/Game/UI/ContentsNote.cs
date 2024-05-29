namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::ContentsNote
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
[GenerateInterop]
public unsafe partial struct ContentsNote {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 75 0C 0F B6 43 41", 3)]
    public static partial ContentsNote* Instance();

    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray11<byte> _completionFlags;
    [FieldOffset(0x1C)] public byte SelectedTab;
    [FieldOffset(0x1D)] public byte DisplayCount;
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray19<int> _displayIds;
    [FieldOffset(0x6C), FixedSizeArray] internal FixedSizeArray19<int> _displayStatuses;

    public bool IsContentNoteComplete(int index) {
        var offsetIndex = index - 1;
        return (CompletionFlags[offsetIndex / 8] & (1 << (offsetIndex % 8))) != 0;
    }
}
