namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::TitleList
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct TitleList {
    [FieldOffset(0x8), FixedSizeArray] internal FixedSizeArray92<byte> _titlesUnlockBitmask; // ref: "41 B8 ?? ?? ?? ?? 4C 8D 4A F8"
    [FieldOffset(0x64)] public bool DataPending;
    [FieldOffset(0x65)] public bool DataReceived;
    [FieldOffset(0x66)] public bool DataRequested;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 1A 8B CB")]
    public partial bool IsTitleUnlocked(ushort titleId);
}
