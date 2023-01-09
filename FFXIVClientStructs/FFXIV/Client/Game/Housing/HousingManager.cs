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
}