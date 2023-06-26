namespace FFXIVClientStructs.FFXIV.Client.Game.Housing; 

[StructLayout(LayoutKind.Explicit, Size = 0xAE30)]
public unsafe partial struct HousingOutdoorTerritory {
    [FieldOffset(0x00)] public HousingTerritory HousingTerritory;
    
    /// <summary>
    /// Get the Icon ID used for map icons in housing areas.
    /// </summary>
    /// <param name="plot">Plot number, zero indexed. <value>127</value> for Apartment in main division, <value>128</value> for apartment in subdivision.</param>
    /// <returns>IconID, or 0 if something went wrong</returns>
    [MemberFunction("40 56 57 48 83 EC 38 0F B6 FA")]
    public partial int GetPlotIcon(byte plot);
}

