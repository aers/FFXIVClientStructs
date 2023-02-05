namespace FFXIVClientStructs.FFXIV.Client.Game.Housing; 

[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public unsafe partial struct HousingManager {
    [MemberFunction("E8 ?? ?? ?? ?? 8B 56 7C")]
    public static partial HousingManager* Instance();
    
    [FieldOffset(0x00)] public HousingTerritory* CurrentTerritory;
    [FieldOffset(0x08)] public HousingTerritory* OutdoorTerritory;
    [FieldOffset(0x10)] public HousingTerritory* IndoorTerritory;
    [FieldOffset(0x18)] public HousingTerritory* WorkshopTerritory;
    
    [MemberFunction("E8 ?? ?? ?? ?? 41 BD ?? ?? ?? ?? 48 8D 4D A0")]
    private partial byte GetInvertedBrightness();
    public byte GetBrightness() => (byte)(5 - GetInvertedBrightness());

    [MemberFunction("48 8B 49 10 48 85 C9 74 53")]
    public partial bool HasHousePermissions();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4B D0 33 D2")]
    public partial bool IsInside();
    
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 C0 3B 46 3C")]
    public partial sbyte GetCurrentWard();

    // 1 for Main Division, 2 for Subdivision
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 0F 0F B6 C8")]
    public partial byte GetCurrentDivision();

    // Apartment / FC Room number
    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 D8 E8 ?? ?? ?? ?? 48 8B C8")]
    public partial short GetCurrentRoom();

    // -128 for Apartments in Main Division, -127 for Apartments in Subdivision
    [MemberFunction("E8 ?? ?? ?? ?? 88 44 24 78")]
    public partial sbyte GetCurrentPlot();
    
    // Unique Identifier
    [MemberFunction("E8 ?? ?? ?? ?? 83 CA FF 48 8B D8 8D 4A 02")]
    public partial long GetCurrentHouseId();
}