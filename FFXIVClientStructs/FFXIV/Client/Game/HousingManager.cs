namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::HousingManager
// ctor inlined at "48 83 EC ?? 48 83 3D ?? ?? ?? ?? ?? 0F 85 ?? ?? ?? ?? 48 89 5C 24 ?? 45 33 C0 33 D2 48 89 7C 24 ?? B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 33 FF 48 8B D8 48 85 C0 0F 84 ?? ?? ?? ?? 48 89 38 48 8D 88 ?? ?? ?? ?? 48 89 78 ?? 48 89 78"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public unsafe partial struct HousingManager {
    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 7E 5A")]
    public static partial HousingManager* Instance();

    [FieldOffset(0x00)] public HousingTerritory* CurrentTerritory;
    [FieldOffset(0x08)] public OutdoorTerritory* OutdoorTerritory;
    [FieldOffset(0x10)] public IndoorTerritory* IndoorTerritory;
    [FieldOffset(0x18)] public WorkshopTerritory* WorkshopTerritory;

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 C0 48 8D 4C 24")]
    private partial byte GetInvertedBrightness();
    public byte GetBrightness() => (byte)(5 - GetInvertedBrightness());

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 41 8B F5")]
    public partial bool HasHousePermissions();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 41 8B D6")]
    public partial bool IsInside();

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

    // Unique Identifier
    [MemberFunction("E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B F8 8D 4A 02")]
    public partial long GetCurrentHouseId();

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
}
