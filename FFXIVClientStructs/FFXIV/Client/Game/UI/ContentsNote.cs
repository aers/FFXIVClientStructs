namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::ContentsNote
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct ContentsNote {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 75 0C 0F B6 43 41", 3)]
    public static partial ContentsNote* Instance();

    [FieldOffset(0x08)] public fixed byte CompletionFlags[11];
    [FieldOffset(0x1C)] public byte SelectedTab;
    [FieldOffset(0x1D)] public byte DisplayCount;
    [FieldOffset(0x20)] public fixed int DisplayID[19];
    [FieldOffset(0x6C)] public fixed int DisplayStatus[19];

    public bool IsContentNoteComplete(int index) {
        var offsetIndex = index - 1;
        return (CompletionFlags[offsetIndex / 8] & (1 << (offsetIndex % 8))) != 0;
    }
}
