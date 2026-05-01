namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public partial struct ZoneInitPacket {
    [FieldOffset(0x00)] public ushort ServerId;
    [FieldOffset(0x02)] public ushort TerritoryTypeId;
    [FieldOffset(0x04)] public ushort Instance; // only when IsInstancedArea is true
    [FieldOffset(0x06)] public ushort ContentFinderConditionId;
    [FieldOffset(0x08)] public uint TransitionTerritoryFilterKey;
    [FieldOffset(0x0C)] public uint PopRangeId; // InstanceId in the PlanMap lgb
    [FieldOffset(0x10)] public byte WeatherId;

    [FieldOffset(0x12)] public ZoneInitFlags Flags;

    [FieldOffset(0x15)] private byte UnkInputTimerFlags; // flags set to InputTimerModule+0x4F4

    [FieldOffset(0x20)] public uint RankedCrystallineConflictHostingDataCenterId; // WorldDCGroupType RowId
    [FieldOffset(0x24)] public bool IsLimitedTimeBonusActive;

    // Saved to GameMain, used by various systems like LayoutManager, WeatherManager, EventHandlers etc. for how things should look
    [FieldOffset(0x26), FixedSizeArray] internal FixedSizeArray8<ushort> _gameFestivalIds;
    [FieldOffset(0x36), FixedSizeArray] internal FixedSizeArray8<ushort> _gameFestivalPhases;
    // Saved to PlayerState, used by UI systems like ContentsFinder, AgentHalloweenNpcSelect, AgentFriendlist (for "Invite Friend to Return") and lua scripts for what options should be displayed
    [FieldOffset(0x46), FixedSizeArray] internal FixedSizeArray8<ushort> _uiFestivalIds;
    [FieldOffset(0x56), FixedSizeArray] internal FixedSizeArray8<ushort> _uiFestivalPhases;

    // Used for camera and streaming layout
    [FieldOffset(0x68)] public float PositionX;
    [FieldOffset(0x6C)] public float PositionY;
    [FieldOffset(0x70)] public float PositionZ;
    [FieldOffset(0x74), FixedSizeArray] internal FixedSizeArray11<byte> _contentRouletteRoleBonuses; // ContentsRouletteRole[11]
    [FieldOffset(0x80), FixedSizeArray] internal FixedSizeArray2<int> _penaltyTimestamps;
}

[Flags]
public enum ZoneInitFlags : ushort {
    None = 0,
    IsInitialLogin = 1 << 0,
    Unknown1 = 1 << 1,
    Unknown2 = 1 << 2,
    IsCrossWorld = 1 << 3,
    IsFlyingEnabled = 1 << 4,
    Unknown5 = 1 << 5,
    Unknown6 = 1 << 6,
    IsInstancedArea = 1 << 7,
    Unknown8 = 1 << 8,
    Unknown9 = 1 << 9,
}
