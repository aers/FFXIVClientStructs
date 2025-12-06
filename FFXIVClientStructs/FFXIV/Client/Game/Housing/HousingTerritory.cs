// ReSharper disable once CheckNamespace
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::HousingTerritory
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct HousingTerritory { // 6 vfuncs
    [VirtualFunction(0)]
    public partial void Dtor(byte freeFlags);
    [VirtualFunction(1)]
    public partial void Update();
    [VirtualFunction(2)]
    public partial bool IsLoaded();

    // vf3 -> vf5 loads something form EXD files

    [VirtualFunction(6)]
    public partial HousingTerritoryType GetTerritoryType();

    [GenerateInterop]
    [Inherits<AtkModuleInterface.AtkEventInterface>]
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe partial struct HousingTerritoryUIEventListener {
        [FieldOffset(0x10)] public HousingTerritory* HousingTerritory;
        [FieldOffset(0x18)] public InventoryItem* InventoryItem;
        [FieldOffset(0x20)] public uint AddonId;
    }
}

public enum HousingTerritoryType {
    None,
    Outdoor,
    Indoor,
    Workshop
}
