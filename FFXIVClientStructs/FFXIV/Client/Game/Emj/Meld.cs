namespace FFXIVClientStructs.FFXIV.Client.Game.Emj;

// Client::Game::Emj::Meld
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x54)]
public unsafe partial struct Meld {
    [FieldOffset(0x04)] public MeldType Type;
    [FieldOffset(0x14), FixedSizeArray] internal FixedSizeArray4<uint> _tiles;
}

[Flags]
public enum MeldType : uint {
    None = 0,
    Claimed = 1 << 8,
    WaitKanchan = 1 << 16,
    WaitPenchan = 1 << 17,
    WaitRyanmen = 1 << 18,
    Open = 1 << 22,
    Unknown = 1 << 24,
    Sequence = 1 << 25,
    Pair = 1 << 26,
    Triplet = 1 << 27,
    Quad = 1 << 28,
    AddedQuad = 1 << 29,
    ConcealedQuad = 1 << 30,
}
