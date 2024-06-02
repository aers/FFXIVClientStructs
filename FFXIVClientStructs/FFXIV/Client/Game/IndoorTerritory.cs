namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::IndoorTerritory
//   Client::Game::HousingTerritory
[GenerateInterop]
[Inherits<HousingTerritory>]
[StructLayout(LayoutKind.Explicit, Size = 0xA1A0)]
public unsafe partial struct IndoorTerritory {
    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray732<HousingFurniture> _furniture;
    [FieldOffset(0x8968)] public HousingObjectManager HousingObjectManager;
    [FieldOffset(0x96A0)] public uint HouseId; // Combines Ward, Plot, and Room
}
