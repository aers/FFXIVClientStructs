// ReSharper disable once CheckNamespace
namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::OutdoorTerritory
//   Client::Game::HousingTerritory
[GenerateInterop]
[Inherits<HousingTerritory>]
[StructLayout(LayoutKind.Explicit, Size = 0xAE80)]
public unsafe partial struct OutdoorTerritory {
    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray732<HousingFurniture> _furniture;
    [FieldOffset(0x8968)] public HousingObjectManager HousingObjectManager;
    [FieldOffset(0x96A0)] public HouseId HouseId;
    [FieldOffset(0x96A8)] public sbyte StandingInPlot;
    [FieldOffset(0x96AA)] public sbyte EditingFixturesOfPlot;
    [FieldOffset(0x96B0)] public sbyte EditingFurnishingsOfPlot;

    [FieldOffset(0x96B8), FixedSizeArray] internal FixedSizeArray60<PlotDetail> _plots;

    [FieldOffset(0x9A78), FixedSizeArray] internal FixedSizeArray2<ApartmentBuildingState> _apartmentBuildings;

    /// <summary>
    /// Get the Icon ID used for map icons in housing areas.
    /// </summary>
    /// <param name="plot">Plot number, zero indexed. <value>127</value> for Apartment in main division, <value>128</value> for apartment in subdivision.</param>
    /// <returns>IconId, or 0 if something went wrong</returns>
    [MemberFunction("48 89 6C 24 ?? 48 89 74 24 ?? 57 41 56 41 57 48 83 EC 30 0F B6 FA")]
    public partial int GetPlotIcon(byte plot);
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct PlotDetail {
    [FieldOffset(0x00)] public PlotState State;
    [FieldOffset(0x01)] public PlotSize Size;
    [FieldOffset(0X02)] public bool IsOpen;
    [FieldOffset(0x03)] public bool Unk03;
    [FieldOffset(0x04)] public PlotOwnerType OwnerType;
}

[Flags]
public enum ApartmentBuildingState : byte {
    None = 0,
    IsFull = 1,
    IsOwn = 2,
}

public enum PlotSize : byte {
    Small = 0,
    Medium = 1,
    Large = 2,
}

public enum PlotState : byte {
    None = 0,
    UnownedLand = 1,
    OwnedLand = 2,
    OwnedEstate = 3,
}

public enum PlotOwnerType : uint {
    FreeCompany = 0,
    Individual = 2,
}
