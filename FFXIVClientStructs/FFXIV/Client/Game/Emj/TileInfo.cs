namespace FFXIVClientStructs.FFXIV.Client.Game.Emj;

// Client::Game::Emj::TileInfo
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1C)]
public unsafe partial struct TileInfo {
    [FieldOffset(0x00)] public uint Seat;
    [FieldOffset(0x08)] public uint Tile;
    [FieldOffset(0x0C)] public uint Flags;
}
