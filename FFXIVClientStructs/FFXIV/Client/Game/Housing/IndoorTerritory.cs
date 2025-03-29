// ReSharper disable once CheckNamespace
namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::IndoorTerritory
//   Client::Game::HousingTerritory
[GenerateInterop]
[Inherits<HousingTerritory>]
[StructLayout(LayoutKind.Explicit, Size = 0xA220)]
public unsafe partial struct IndoorTerritory {
    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray732<HousingFurniture> _furniture;
    [FieldOffset(0x8968)] public HousingObjectManager HousingObjectManager;
    [FieldOffset(0x96A0)] public HouseId HouseId; // Combines Ward, Plot, and Room
    [FieldOffset(0x970C)] public uint CurrentFloor; // Might be int but was casted to uint
    [FieldOffset(0x99B4)] public bool SSAOEnable;
}
