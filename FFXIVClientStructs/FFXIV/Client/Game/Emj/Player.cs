namespace FFXIVClientStructs.FFXIV.Client.Game.Emj;

// Client::Game::Emj::Player
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x388)]
public unsafe partial struct Player {
    [FieldOffset(0x004)] public uint Seat;
    [FieldOffset(0x008)] public int HandTileCount;
    [FieldOffset(0x11C), FixedSizeArray] internal FixedSizeArray14<uint> _handTiles;
    [FieldOffset(0x190)] public bool CanRiichi;
}
