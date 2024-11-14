namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::TitleList
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public unsafe partial struct TitleList {
    [FieldOffset(0x8), FixedSizeArray] internal FixedSizeArray106<byte> _titlesUnlockBitmask;
    [FieldOffset(0x72)] public bool DataPending;
    [FieldOffset(0x73)] public bool DataReceived;
    [FieldOffset(0x74)] public bool DataRequested;

    [MemberFunction("E8 ?? ?? ?? ?? 89 6E 58")]
    public partial void RequestTitleList();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 1A 8B CB")]
    public partial bool IsTitleUnlocked(ushort titleId);
}
