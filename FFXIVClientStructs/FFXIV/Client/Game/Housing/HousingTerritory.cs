// ReSharper disable once CheckNamespace
namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::HousingTerritory
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct HousingTerritory { // 6 vfuncs
    [VirtualFunction(0)]
    public partial void Dtor(bool free);
    [VirtualFunction(1)]
    public partial void Update();
    [VirtualFunction(2)]
    public partial bool IsLoaded();

    // vf3 -> vf5 loads something form EXD files

    [VirtualFunction(6)]
    public partial HousingTerritoryType GetTerritoryType();
}

public enum HousingTerritoryType {
    None,
    Outdoor,
    Indoor,
    Workshop
}
