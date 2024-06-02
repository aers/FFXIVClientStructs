namespace FFXIVClientStructs.FFXIV.Client.Game.Housing;

// Client::Game::Housing::HousingTerritory
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct HousingTerritory { // 6 vfuncs
    [VirtualFunction(6)]
    public partial TerritoryType GetTerritoryType();
}

public enum TerritoryType {
    Outdoor = 1,
    Indoor,
    Workshop
}
