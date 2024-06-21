namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::HousingTerritory
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct HousingTerritory { // 6 vfuncs
    [VirtualFunction(6)]
    public partial HousingTerritoryType GetTerritoryType();
}

public enum HousingTerritoryType {
    Outdoor = 1,
    Indoor,
    Workshop
}
