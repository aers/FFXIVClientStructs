namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::HousingManager
// ctor inlined at "48 83 EC ?? 48 83 3D ?? ?? ?? ?? ?? 0F 85 ?? ?? ?? ?? 48 89 5C 24 ?? 45 33 C0 33 D2 48 89 7C 24 ?? B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 33 FF 48 8B D8 48 85 C0 0F 84 ?? ?? ?? ?? 48 89 38 48 8D 88 ?? ?? ?? ?? 48 89 78 ?? 48 89 78"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xE8)]
public unsafe partial struct HousingManager {
    [StaticAddress("48 89 1D ?? ?? ?? ?? EB 07", 3, isPointer: true)]
    public static partial HousingManager* Instance();

    [FieldOffset(0x00)] public HousingTerritory* CurrentTerritory;
    [FieldOffset(0x08)] public OutdoorTerritory* OutdoorTerritory;
    [FieldOffset(0x10)] public IndoorTerritory* IndoorTerritory;
    [FieldOffset(0x18)] public WorkshopTerritory* WorkshopTerritory;

    [MemberFunction("E8 ?? ?? ?? ?? 41 BE 05 00 00 00 8D 53")]
    private partial byte GetInvertedBrightness();
    public byte GetBrightness() => (byte)(5 - GetInvertedBrightness());

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 41 8B F5")]
    public partial bool HasHousePermissions();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 10 40 0F B6 D7")]
    public partial bool IsOutside();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 41 8B D6")]
    public partial bool IsInside();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 0E 48 8B CB")]
    public partial bool IsInWorkshop();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 C0 3B 46 3C")]
    public partial sbyte GetCurrentWard();

    // 1 for Main Division, 2 for Subdivision
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 0B 0F B6 C8 E8 ?? ?? ?? ?? 0F B6 D8")]
    public partial byte GetCurrentDivision();

    // Apartment / FC Room number
    [MemberFunction("40 53 48 83 EC 20 48 8B 59 10 48 85 DB 74 24")]
    public partial short GetCurrentRoom();

    // -128 for Apartments in Main Division, -127 for Apartments in Subdivision
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 D8 3C FF")]
    public partial sbyte GetCurrentPlot();

    [MemberFunction("E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B F8 8D 4A 02")]
    public partial HouseId GetCurrentIndoorHouseId();

    /// <summary>
    /// Gets the TerritoryTypeId of the house the player is currently standing at.<br/>
    /// For indoor territories that were renovated, this returns the original location.
    /// </summary>
    /// <returns></returns>
    [MemberFunction("48 8B 05 ?? ?? ?? ?? 48 8B 50 08 48 85 D2 74 10")]
    public static partial uint GetOriginalHouseTerritoryTypeId();

    /// <summary>
    /// Gets the player owned house ids.
    /// </summary>
    /// <param name="type">The type of the estate.</param>
    /// <param name="sharedEstateIndex">For type <see cref="EstateType.SharedEstate"/> an index must be specified (currently either 0 or 1).</param>
    [MemberFunction("83 F9 06 77 64")]
    public static partial HouseId GetOwnedHouseId(EstateType type, int sharedEstateIndex = -1);

    /// <summary>
    /// Gets the airship voyage distance and time in pointers
    /// <br/>
    /// Starting point is at 127 and then goes from 0-24
    /// <br/>
    /// 22 is not used as its the old Diadem
    /// </summary>
    /// <param name="pointA">The point to calculate from</param>
    /// <param name="pointB">The point to calculate to</param>
    /// <param name="speed">Speed of the airship to use</param>
    /// <param name="time">The voyage time returned</param>
    /// <param name="distance">The voyage distance returned</param>
    /// <returns>Does not return anything use full at times</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 8B 44 24 50 0F B7 D5")]
    public static partial int GetAirshipVoyageTimeAndDistance(byte pointA, byte pointB, short speed, uint* time, uint* distance);

    /// <summary>
    /// Gets the airship survey duration
    /// </summary>
    /// <param name="point">The point to calculate 0-24. 22 is not used</param>
    /// <param name="speed">Speed of the airship to use</param>
    /// <returns>Survey duration</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 01 43 10 8B CE")]
    public static partial uint GetAirshipSurveyDuration(byte point, short speed);

    /// <summary>
    /// Gets the submarine voyage time
    /// <br/>
    /// Each map uses 0 index as their starting point respectably.
    /// <br/>
    /// Example: Deep-sea Site starts at 0 where Sea of Ash starts at 31 and so on.
    /// <br/>
    /// This is related to that Deep-sea Site has 30 points and 1 starting location.
    /// </summary>
    /// <param name="pointA">The point to calculate from</param>
    /// <param name="pointB">The point to calculate to</param>
    /// <param name="speed">Speed of the submarine to use</param>
    /// <returns>Voyage time</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 8C 24 ?? ?? ?? ?? 03 F8")]
    public static partial uint GetSubmarineVoyageTime(byte pointA, byte pointB, short speed);

    /// <summary>
    /// Gets the submarine voyage distance
    /// </summary>
    /// <param name="pointA">The point to calculate from</param>
    /// <param name="pointB">The point to calculate to</param>
    /// <returns>Voyage distance</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 01 7B 10")]
    public static partial uint GetSubmarineVoyageDistance(byte pointA, byte pointB);

    /// <summary>
    /// Gets the submarine survey duration
    /// </summary>
    /// <param name="point">The point to calculate</param>
    /// <param name="speed">Speed of the submarine to use</param>
    /// <returns>Survey Duration</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 8B 7D 0F")]
    public static partial uint GetSubmarineSurveyDuration(byte point, short speed);

    /// <summary>
    /// Gets if the point is unlocked
    /// </summary>
    /// <param name="point">The point to check is unlocked or not</param>
    /// <returns>True or False</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 4F 49 8B 57 38")]
    public static partial bool IsSubmarineExplorationUnlocked(byte point);

    /// <summary>
    /// Gets if the point is unlocked
    /// </summary>
    /// <param name="point">The point to check is explored or not</param>
    /// <returns>True or False</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 88 45 38")]
    public static partial bool IsSubmarineExplorationExplored(byte point);

    public HousingTerritoryType GetCurrentHousingTerritoryType()
        => CurrentTerritory != null ? CurrentTerritory->GetTerritoryType() : HousingTerritoryType.None;
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public struct HouseId : IEquatable<HouseId>, IComparable<HouseId> {
    [FieldOffset(0x0), CExportIgnore] public long Id;
    /// <remarks>
    /// Masked data:<br/>
    /// - <c>0b1000_0000</c> (<c>0x80</c>) = Apartment Flag<br/>
    /// - <c>0b0111_1111</c> (<c>0x7F</c>) = Apartment Division (only if Apartment Flag is <c>true</c>)<br/>
    /// - <c>0b0111_1111</c> (<c>0x7F</c>) = PlotIndex (only if Apartment Flag is <c>false</c>)
    /// </remarks>
    [FieldOffset(0x0)] public byte Data0;
    [FieldOffset(0x1)] public byte Unk1;
    /// <remarks>
    /// Masked data:<br/>
    /// - <c>0b0000_0000_0011_1111</c> (<c>0x0003F</c>) = WardIndex<br/>
    /// - <c>0b1111_1111_1100_0000</c> (<c>0xFFC06</c>) = Room
    /// </remarks>
    [FieldOffset(0x2)] public ushort Data2;
    [FieldOffset(0x4)] public ushort TerritoryTypeId;
    [FieldOffset(0x6)] public ushort WorldId;

    public bool IsApartment => (Data0 & 0x80) != 0 && (byte)(Data0 & 0x7F) < 2;
    public byte ApartmentDivision => (byte)(Data0 & 0x7F);

    public byte PlotIndex => (byte)(Data0 & 0x7F);
    public byte WardIndex => (byte)(Data2 & 0x3F);
    public short RoomNumber => (short)(Data2 >> 6);
    public bool IsWorkshop => RoomNumber == 0x3FF;

    public static implicit operator long(HouseId id) => id.Id;
    public static unsafe implicit operator HouseId(long id) => *(HouseId*)&id;

    public bool Equals(HouseId other) => Id == other.Id;
    public override bool Equals(object? obj) => obj is HouseId other && Equals(other);
    public override int GetHashCode() => Id.GetHashCode();
    public static bool operator ==(HouseId left, HouseId right) => left.Id == right.Id;
    public static bool operator !=(HouseId left, HouseId right) => left.Id != right.Id;
    public int CompareTo(HouseId other) => Id.CompareTo(other);
}

public enum EstateType {
    FreeCompanyEstate = 0,
    PersonalChambers = 1,
    PersonalEstate = 2,
    Unknown3 = 3,
    SharedEstate = 4,
    ApartmentBuilding = 5,
    ApartmentRoom = 6
}
