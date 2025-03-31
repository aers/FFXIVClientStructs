namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::CSBonusManager
// Manager for Moogle Tresure Trove / MogMog Collection / Mogpendium
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x178)]
public unsafe partial struct CSBonusManager {
    [StaticAddress("48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 63 D0", 3, isPointer: true)]
    public static partial CSBonusManager* Instance();

    [FieldOffset(0x08)] public CSBonusEventInfo EventInfo;
    [FieldOffset(0x18)] public CSBonusMissionInfo MissionInfo;

    [FieldOffset(0x08 + 0x00), Obsolete("Use EventInfo.Season", true)] public ushort State;
    [FieldOffset(0x08 + 0x04), Obsolete("Use EventInfo.BaseTime", true)] public uint BaseTime;
    [FieldOffset(0x08 + 0x08), Obsolete("Use EventInfo.SeasonTarget", true)] public uint SeasonTarget;
    [FieldOffset(0x08 + 0x0C), Obsolete("Use EventInfo.IsOpenShop", true)] public byte IsOpenShop;
    [FieldOffset(0x08 + 0x0D), Obsolete("Use EventInfo.IsOpenMission", true)] public byte IsOpenMission;

    [FieldOffset(0x18 + 0x00), Obsolete("Use MissionInfo.SeedBase", true)] public uint SeedBase;

    [FieldOffset(0x18 + 0x18), FixedSizeArray, Obsolete("Use MissionInfo.WBAchieveFlag", true)] internal FixedSizeArray20<byte> _WBAchieveFlag;
    [FieldOffset(0x18 + 0x2C), FixedSizeArray, Obsolete("Use MissionInfo.PMAchieveFlag", true)] internal FixedSizeArray20<byte> _PMAchieveFlag;
    [FieldOffset(0x18 + 0x40), FixedSizeArray, Obsolete("Use MissionInfo.MMAchieveFlag", true)] internal FixedSizeArray20<byte> _MMAchieveFlag;

    [FieldOffset(0x18 + 0x68), FixedSizeArray, Obsolete("Use MissionInfo.WBReceiveFlag", true)] internal FixedSizeArray20<byte> _WBReceiveFlag;
    [FieldOffset(0x18 + 0x7C), FixedSizeArray, Obsolete("Use MissionInfo.PMReceiveFlag", true)] internal FixedSizeArray20<byte> _PMReceiveFlag;
    [FieldOffset(0x18 + 0x90), FixedSizeArray, Obsolete("Use MissionInfo.MMReceiveFlag", true)] internal FixedSizeArray20<byte> _MMReceiveFlag;

    [FieldOffset(0x18 + 0xA6), Obsolete("Use MissionInfo.WBCount", true)] public byte WBCount;
    [FieldOffset(0x18 + 0xA8), Obsolete("Use MissionInfo.PMCount", true)] public byte PMCount;
    [FieldOffset(0x18 + 0xAA), Obsolete("Use MissionInfo.MMCount", true)] public byte MMCount;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct CSBonusEventInfo {
    [FieldOffset(0x00)] public ushort Season; // CSBonusSeason RowId
    [FieldOffset(0x04)] public uint BaseTime;
    [FieldOffset(0x08)] public uint SeasonTarget;
    [FieldOffset(0x0C)] public bool IsOpenShop;
    [FieldOffset(0x0D)] public bool IsOpenMission;
}

[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public struct CSBonusMissionInfo {
    [FieldOffset(0x00)] public uint SeedBase;
    // Unk = Standard Objectives?? Probably unused because automatically redeemed? Not even displayed in PrintDebugInfo.
    // WB = Weekly Objectives
    // PM = Minimog Challenges
    // MM = Ultimog Challenge
    [FieldOffset(0x04), FixedSizeArray] internal FixedSizeArray20<byte> _UnkAchieveFlag;
    [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray20<byte> _WBAchieveFlag;
    [FieldOffset(0x2C), FixedSizeArray] internal FixedSizeArray20<byte> _PMAchieveFlag;
    [FieldOffset(0x40), FixedSizeArray] internal FixedSizeArray20<byte> _MMAchieveFlag;
    [FieldOffset(0x54), FixedSizeArray] internal FixedSizeArray20<byte> _UnkReceiveFlag;
    [FieldOffset(0x68), FixedSizeArray] internal FixedSizeArray20<byte> _WBReceiveFlag;
    [FieldOffset(0x7C), FixedSizeArray] internal FixedSizeArray20<byte> _PMReceiveFlag;
    [FieldOffset(0x90), FixedSizeArray] internal FixedSizeArray20<byte> _MMReceiveFlag;
    [FieldOffset(0xA4), FixedSizeArray] internal FixedSizeArray2<byte> _UnkCount;
    [FieldOffset(0xA6), FixedSizeArray] internal FixedSizeArray2<byte> _WBCount;
    [FieldOffset(0xA8), FixedSizeArray] internal FixedSizeArray2<byte> _PMCount;
    [FieldOffset(0xAA), FixedSizeArray] internal FixedSizeArray2<byte> _MMCount;
}
