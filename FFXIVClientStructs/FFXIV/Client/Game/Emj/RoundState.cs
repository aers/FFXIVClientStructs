namespace FFXIVClientStructs.FFXIV.Client.Game.Emj;

// Client::Game::Emj::RoundState
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x368)]
public unsafe partial struct RoundState {
    [FieldOffset(0x028), FixedSizeArray] internal FixedSizeArray4<int> _points;
    [FieldOffset(0x03C)] public int RoundWind;
    [FieldOffset(0x040)] public int Dealer;
    [FieldOffset(0x044)] public int Honba;
    [FieldOffset(0x04C)] public int RiichiSticks;
    [FieldOffset(0x0B4), FixedSizeArray] internal FixedSizeArray4<int> _isRiichi;
    [FieldOffset(0x0E8)] public int WallTilesRemaining;
    [FieldOffset(0x0F0)] public int DoraIndicatorCount;
    [FieldOffset(0x0F4), FixedSizeArray] internal FixedSizeArray5<uint> _doraIndicators;
    [FieldOffset(0x314)] public int StartSeatOffset;
}
