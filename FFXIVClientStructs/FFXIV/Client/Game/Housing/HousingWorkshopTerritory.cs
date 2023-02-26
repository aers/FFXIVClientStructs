using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Housing;

[StructLayout(LayoutKind.Explicit, Size = 0xB8C0)]
public unsafe partial struct HousingWorkshopTerritory
{
    [FieldOffset(0x68)] public HousingWorkshopAirshipData Airship;

    [FixedSizeArray<HousingWorkshopSubmersibleData>(4)]
    [FieldOffset(0x2960)] public fixed byte SubmersibleDataList[0x2320 * 4];

    [FixedSizeArray<Pointer<HousingWorkshopSubmersibleData>>(5)]
    [FieldOffset(0xB5E0)] public fixed byte SubmersibleDataPointerList[0x8 * 5]; // 0-3 is the same as SubmersibleDataList, 4 is the one you are currently using
}

[StructLayout(LayoutKind.Explicit, Size = 0x28F8)]
public unsafe partial struct HousingWorkshopAirshipData
{
    [FixedSizeArray<HousingWorkshopAirshipSubData>(4)]
    [FieldOffset(0x0)] public fixed byte AirshipDataList[0x1C0 * 4];
    
    [FieldOffset(0x770)] public byte ActiveAirshipId; // 0-3, 255 if none
    [FieldOffset(0x771)] public byte AirshipCount;

    [FixedSizeArray<Utf8String>(82)]
    [FieldOffset(0x778)] public fixed byte AirshipLogList[0x68 * 82];
}

[StructLayout(LayoutKind.Explicit, Size = 0x1C0)]
public unsafe partial struct HousingWorkshopAirshipSubData
{
    [FieldOffset(0x0)] public fixed byte Data[0x1C0];
    [FieldOffset(0x4)] public uint RegisterTime;
    [FieldOffset(0xC)] public byte RankId;
    [FieldOffset(0x10)] public uint ReturnTime;
    [FieldOffset(0x14)] public uint CurrentExp;
    [FieldOffset(0x18)] public uint NextLevelExp;

    [FieldOffset(0x20)] public ushort HullId; // AirshipExplorationPart Key
    [FieldOffset(0x22)] public ushort SternId; // AirshipExplorationPart Key
    [FieldOffset(0x24)] public ushort BowId; // AirshipExplorationPart Key
    [FieldOffset(0x26)] public ushort BridgeId; // AirshipExplorationPart Key

    [FieldOffset(0x28)] public ushort Surveillance;
    [FieldOffset(0x30)] public ushort Retrieval;
    [FieldOffset(0x32)] public ushort Speed;
    [FieldOffset(0x34)] public ushort Range;
    [FieldOffset(0x36)] public ushort Favor;

    [FieldOffset(0x37)] public fixed byte Name[20];

    [FixedSizeArray<HousingWorkshopGatheredData>(5)]
    [FieldOffset(0x54)] public fixed byte GatheredData[0x38 * 5];

    /// <summary>
    /// Points to <see cref="HousingWorkshopAirshipData.AirshipLogList"/>
    /// Max 82 in the array
    /// </summary>
    [FieldOffset(0x1A0)] public Utf8String* Log;

    /// <summary>Gets the registered time as a <see cref="DateTime"/> object</summary>
    public DateTime GetRegisterTime() => DateTime.UnixEpoch.AddSeconds(RegisterTime);

    /// <summary>Gets the return time as a <see cref="DateTime"/> object</summary>
    public DateTime GetReturnTime() => DateTime.UnixEpoch.AddSeconds(ReturnTime);
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct HousingWorkshopGatheredData
{
    [FieldOffset(0x0)] public uint ExpGained;

    [FieldOffset(0xC)] public uint ItemIdPrimary;
    [FieldOffset(0x10)] public uint ItemIdAdditional;
    [FieldOffset(0x14)] public ushort ItemCountPrimary;
    [FieldOffset(0x16)] public ushort ItemCountAdditional;

    [FieldOffset(0x32)] public bool AirshipItemValidPrimary;
    [FieldOffset(0x33)] public bool AirshipItemValidAdditional;
    public bool SubmarineItemValidPrimary => !AirshipItemValidPrimary;
    public bool SubmarineItemValidAdditional => !AirshipItemValidAdditional;
}

[StructLayout(LayoutKind.Explicit, Size = 0x2320)]
public unsafe partial struct HousingWorkshopSubmersibleData // possibly a substructure as well need to figure out
{
    [FieldOffset(0x0)] public HousingWorkshopSubmersibleData* Self;
    [FieldOffset(0xE)] public byte RankId;
    [FieldOffset(0x10)] public uint RegisterTime;
    [FieldOffset(0x14)] public uint ReturnTime;
    [FieldOffset(0x18)] public uint CurrentExp;
    [FieldOffset(0x1C)] public uint NextLevelExp;

    [FieldOffset(0x22)] public fixed byte Name[20];

    [FieldOffset(0x3A)] public ushort HullId; // SubmarinePart Key
    [FieldOffset(0x3C)] public ushort SternId; // SubmarinePart Key
    [FieldOffset(0x3E)] public ushort BowId; // SubmarinePart Key
    [FieldOffset(0x40)] public ushort BridgeId; // SubmarinePart Key

    [FieldOffset(0x42)] public fixed byte CurrentExplorationPoints[5];

    [FieldOffset(0x4A)] public ushort SurveillanceBase;
    [FieldOffset(0x4C)] public ushort RetrievalBase;
    [FieldOffset(0x4E)] public ushort SpeedBase;
    [FieldOffset(0x50)] public ushort RangeBase;
    [FieldOffset(0x52)] public ushort FavorBase;

    [FieldOffset(0x54)] public ushort SurveillanceBonus;
    [FieldOffset(0x56)] public ushort RetrievalBonus;
    [FieldOffset(0x58)] public ushort SpeedBonus;
    [FieldOffset(0x5A)] public ushort RangeBonus;
    [FieldOffset(0x5C)] public ushort FavorBonus;

    [FixedSizeArray<HousingWorkshopGatheredData>(5)]
    [FieldOffset(0x70)] public fixed byte GatheredData[0x38 * 5];

    [FixedSizeArray<Utf8String>(82)]
    [FieldOffset(0x1B0)] public fixed byte LogList[0x68 * 82];

    /// <summary>Gets the registered time as a <see cref="DateTime"/> object</summary>
    public DateTime GetRegisterTime() => DateTime.UnixEpoch.AddSeconds(RegisterTime);

    /// <summary>Gets the return time as a <see cref="DateTime"/> object</summary>
    public DateTime GetReturnTime() => DateTime.UnixEpoch.AddSeconds(ReturnTime);
}