namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::TitleList
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct TitleList {
    [FieldOffset(0x8)] public fixed byte TitlesUnlockBitmask[92]; // ref: "41 B8 ?? ?? ?? ?? 4C 8D 4A F8"
    [FieldOffset(0x64)] public bool DataPending;
    [FieldOffset(0x65)] public bool DataReceived;
    [FieldOffset(0x66)] public bool DataRequested;

    [MemberFunction("B8 ?? ?? ?? ?? 44 0F B7 C2 4C 8B C9")]
    public partial bool IsTitleUnlocked(ushort titleId);
}
