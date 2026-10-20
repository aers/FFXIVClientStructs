namespace FFXIVClientStructs.FFXIV.Client.Game.Emj;

// Client::Game::Emj::Table
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x1418)]
public unsafe partial struct Table {
    [FieldOffset(0x0008), FixedSizeArray] internal FixedSizeArray4<Player> _players;

    [FieldOffset(0x12C0)] public Board* Board;
    [FieldOffset(0x1350)] public TileInfo DrawnTile;
    [FieldOffset(0x136C)] public TileInfo LastDiscard;
}
