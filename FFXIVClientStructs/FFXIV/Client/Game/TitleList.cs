namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::TitleList
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public partial struct TitleList {
    [FieldOffset(0x8), FixedSizeArray(isBitArray: true, bitCount: 894)] internal FixedSizeArray112<byte> _unlockedTitles;
    [FieldOffset(0x7C)] public bool DataPending;
    [FieldOffset(0x7D)] public bool DataReceived;
    [FieldOffset(0x7E)] public bool DataRequested;

    [MemberFunction("E8 ?? ?? ?? ?? 89 6E 58")]
    public partial void RequestTitleList();

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 8B 44 24 ?? B9")]
    public partial void SetTitleUnlocked(ushort titleId);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 1A 8B CB")]
    public partial bool IsTitleUnlocked(ushort titleId);
}
