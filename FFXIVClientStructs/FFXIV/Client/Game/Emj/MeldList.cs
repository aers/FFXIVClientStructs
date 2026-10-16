namespace FFXIVClientStructs.FFXIV.Client.Game.Emj;

// Client::Game::Emj::MeldList
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x158)]
public unsafe partial struct MeldList {
    [FieldOffset(0x04)] public int Count;
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray4<Meld> _melds;
}
