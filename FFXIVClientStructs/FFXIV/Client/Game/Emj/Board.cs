namespace FFXIVClientStructs.FFXIV.Client.Game.Emj;

// Client::Game::Emj::Board
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xCF8)]
public unsafe partial struct Board {
    [FieldOffset(0x000), FixedSizeArray] internal FixedSizeArray4<MeldList> _meldLists;
    [FieldOffset(0x560), FixedSizeArray] internal FixedSizeArray4<DiscardPile> _discardPiles;
    [FieldOffset(0x990)] public RoundState RoundState;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xFC)]
    public partial struct DiscardPile {
        [FieldOffset(0x00)] public int Count;
        [FieldOffset(0x04), FixedSizeArray] internal FixedSizeArray31<uint> _tiles;
        [FieldOffset(0x80), FixedSizeArray] internal FixedSizeArray31<uint> _flags;
    }
}
