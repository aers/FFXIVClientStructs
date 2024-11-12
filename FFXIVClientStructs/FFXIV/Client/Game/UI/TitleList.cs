namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::TitleList
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe partial struct TitleList {
    [FieldOffset(0x8), FixedSizeArray] internal FixedSizeArray96<byte> _titlesUnlockBitmask;
    [FieldOffset(0x68)] public bool DataPending;
    [FieldOffset(0x69)] public bool DataReceived;
    [FieldOffset(0x6A)] public bool DataRequested;

    [MemberFunction("E8 ?? ?? ?? ?? 89 6E 58")]
    public partial void RequestTitleList();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 1A 8B CB")]
    public partial bool IsTitleUnlocked(ushort titleId);
}
