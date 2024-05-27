namespace FFXIVClientStructs.FFXIV.Client.Game.Housing;

[StructLayout(LayoutKind.Explicit, Size = 0xAE30)]
public unsafe partial struct HousingOutdoorTerritory {
    [FieldOffset(0x00), CExportIgnore] public HousingTerritory HousingTerritory;

    /// <summary>
    /// Get the Icon ID used for map icons in housing areas.
    /// </summary>
    /// <param name="plot">Plot number, zero indexed. <value>127</value> for Apartment in main division, <value>128</value> for apartment in subdivision.</param>
    /// <returns>IconID, or 0 if something went wrong</returns>
    [MemberFunction("40 56 57 48 83 EC 38 0F B6 FA")]
    public partial int GetPlotIcon(byte plot);

    [FieldOffset(0x96A8)] public sbyte StandingInPlot;
    [FieldOffset(0x96AA)] public sbyte EditingFixturesOfPlot;
    [FieldOffset(0x96B0)] public sbyte EditingFurnishingsOfPlot;

    [FixedSizeArray<PlotDetail>(60)]
    [FieldOffset(0x96B8)] public fixed byte Plot[0x10 * 60];

    [FixedSizeArray<ApartmentBuildingState>(2)]
    [FieldOffset(0x9A78)] public fixed byte ApartmentBuilding[2];

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
