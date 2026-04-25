using FFXIVClientStructs.FFXIV.Client.Graphics;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10B4)]
public partial struct TofuBoardEntry {
    [FieldOffset(0x0), FixedSizeArray] internal FixedSizeArray50<TofuShortObject> _objects;
    [FieldOffset(0x1068)] public bool IsValid;
    [FieldOffset(0x1069)] public byte Index;
    [FieldOffset(0x106A)] public byte PositionInList;
    [FieldOffset(0x106B)] public byte Folder;
    [FieldOffset(0x106C), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _name;
    [FieldOffset(0x10AC)] public uint ServerTime;
    [FieldOffset(0x10B0)] public ushort Background;
    [FieldOffset(0x10B2)] public byte NumberOfObjects;
    [FieldOffset(0x10B3)] private byte Unk10B3; // Either 0xA2 or 0
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x47)]
public partial struct TofuFolderEntry {
    [FieldOffset(0x0)] public bool IsValid;
    [FieldOffset(0x1)] public byte Index;
    [FieldOffset(0x2)] public byte PositionInList;
    [FieldOffset(0x3), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _name;
    [FieldOffset(0x43)] public bool IsBoard; // boards contribute to the max folder counter and is marked as "valid", but the name is empty
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public partial struct TofuShortObject {
    [FieldOffset(0x0), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _text;
    /// <remarks> <c>A</c> is transparency, not alpha. It goes from <c>0</c> to <c>100</c> with <c>0</c> being visible. </remarks>
    [FieldOffset(0x20)] public ByteColor RGBA;
    [FieldOffset(0x24)] public ushort PosX;
    [FieldOffset(0x26)] public ushort PosY;
    [FieldOffset(0x28)] public TofuObjectType ObjectType;
    [FieldOffset(0x2A)] public TofuObjectFlags Flags;
    [FieldOffset(0x2C)] public ushort Angle;
    [FieldOffset(0x2E)] public ushort ArgsA;
    [FieldOffset(0x30)] public ushort ArgsB;
    [FieldOffset(0x32)] public ushort ArgsC;
    [FieldOffset(0x34)] public byte Scale;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x378)]
public partial struct TofuFullObject {
    // Different structure to TofuModule's TofuObject
    [FieldOffset(0x2)] public TofuObjectType ObjectType;
    [FieldOffset(0x10)] public Utf8String Name;
    [FieldOffset(0x78)] public ushort PosX;
    [FieldOffset(0x7A)] public ushort PosY;
    [FieldOffset(0x80)] public ushort Scale;
    [FieldOffset(0x82)] public ushort Angle;
    /// <remarks> <c>A</c> is transparency, not alpha. It goes from <c>0</c> to <c>100</c> with <c>0</c> being visible. </remarks>
    [FieldOffset(0x84)] public ByteColor RGBA;
    [FieldOffset(0x88)] public TofuObjectFlags Flags;
    [FieldOffset(0x8A)] public ushort ArgExtra1;
    [FieldOffset(0x8C)] public ushort ArgExtra2;
    [FieldOffset(0x8E)] public ushort ArgExtra3;
    [FieldOffset(0x90)] public Utf8String TextContent;
    [FieldOffset(0x100), FixedSizeArray] internal FixedSizeArray5<TofuObjectArgData> _argDatas;
    [FieldOffset(0x358)] public StdVector<TofuFullObject> InnerObjects;
}

[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public struct TofuObjectArgData {
    [FieldOffset(0x0)] public Utf8String Name;
}

[Flags]
public enum TofuObjectFlags : ushort {
    IsVisible = 1,
    IsLocked = 1 << 3,
}

// Taken from https://github.com/xivdev/file-formats/blob/main/imhex/stgy.hexpat
public enum TofuObjectType : ushort {
    None = 0,
    WhiteCirclePlain = 1,
    WhiteCircleTiled = 2,
    GreyCirclePlain = 3,
    CheckeredCircle = 4,
    WhiteSquarePlain = 5,
    WhiteSquareTiled = 6,
    GreySquarePlain = 7,
    CheckeredSquare = 8,
    CircleAoE = 9,
    FanAoE = 10,
    LineAoE = 11,
    Line = 12,
    Gaze = 13,
    Stack = 14,
    LineStack = 15,
    Proximity = 16,
    Donut = 17,
    Gladiator = 18,
    Pugilist = 19,
    Marauder = 20,
    Lancer = 21,
    Archer = 22,
    Conjurer = 23,
    Thaumaturge = 24,
    Arcanist = 25,
    Rogue = 26,
    Paladin = 27,
    Monk = 28,
    Warrior = 29,
    Dragoon = 30,
    Bard = 31,
    WhiteMage = 32,
    BlackMage = 33,
    Summoner = 34,
    Scholar = 35,
    Ninja = 36,
    Machinist = 37,
    DarkKnight = 38,
    Astrologian = 39,
    Samurai = 40,
    RedMage = 41,
    BlueMage = 42,
    Gunbreaker = 43,
    Dancer = 44,
    Reaper = 45,
    Sage = 46,
    Tank = 47,
    Tank1 = 48,
    Tank2 = 49,
    Healer = 50,
    Healer1 = 51,
    Healer2 = 52,
    DPS = 53,
    DPS1 = 54,
    DPS2 = 55,
    DPS3 = 56,
    DPS4 = 57,
    DPS5 = 58,
    DPS6 = 59,
    SmallEnemy = 60,
    SmallEnemy2 = 61,
    MediumEnemy = 62,
    MediumEnemy2 = 63,
    LargeEnemy = 64,
    TargetToAttack1 = 65,
    TargetToAttack2 = 66,
    TargetToAttack3 = 67,
    TargetToAttack4 = 68,
    TargetToAttack5 = 69,
    TargetToBind1 = 70,
    TargetToBind2 = 71,
    TargetToBind3 = 72,
    TargetToIgnore1 = 73,
    TargetToIgnore2 = 74,
    SquareMarker = 75,
    CircleMarker = 76,
    PlusMarker = 77,
    TriangleMarker = 78,
    WaymarkA = 79,
    WaymarkB = 80,
    WaymarkC = 81,
    WaymarkD = 82,
    Waymark1 = 83,
    Waymark2 = 84,
    Waymark3 = 85,
    Waymark4 = 86,
    CircleSymbol = 87,
    XSymbol = 88,
    TriangleSymbol = 89,
    SquareSymbol = 90,
    Unknown91 = 91, // Unused
    Unknown92 = 92, // Unused
    Unknown93 = 93, // Unused
    UpArrow = 94,
    Unknown95 = 95, // Unused
    Unknown96 = 96, // Unused
    Unknown97 = 97, // Unused
    Unknown98 = 98, // Unused
    Unknown99 = 99, // Unused
    Text = 100,
    Viper = 101,
    Pictomancer = 102,
    Rotate = 103,
    UnusedArrowClockwise = 104,
    Group = 105,
    StackMultiHit = 106,
    ProximityPlayerTargeted = 107,
    TankbusterSingleTarget = 108,
    RadialKnockback = 109,
    LinearKnockback = 110,
    Tower = 111,
    TargetingIndicator = 112,
    EnhancementEffect = 113,
    EnfeeblementEffect = 114,
    TargetToAttack6 = 115,
    TargetToAttack7 = 116,
    TargetToAttack8 = 117,
    MeleeDPS = 118,
    RangedDPS = 119,
    PhysicalRangedDPS = 120,
    MagicalRangedDPS = 121,
    PureHealer = 122,
    BarrierHealer = 123,
    GreyCircle = 124,
    GreySquare = 125,
    MovingCircleAoE = 126,
    OnePersonAoE = 127,
    TwoPersonAoE = 128,
    ThreePersonAoE = 129,
    FourPersonAoE = 130,
    RedLockOnMarker = 131,
    BlueLockOnMarker = 132,
    PurpleLockOnMarker = 133,
    GreenLockOnMarker = 134,
    HighlightedCircle = 135,
    HighlightedX = 136,
    HighlightedSquare = 137,
    HighlightedTriangle = 138,
    RotateClockwise = 139,
    RotateCounterclockwise = 140,
};
