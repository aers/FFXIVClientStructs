namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x178)]
public unsafe partial struct CSBonusManager {
    [StaticAddress("48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 63 D0", 3, true)]
    public static partial CSBonusManager* Instance();

    [FieldOffset(0x08)] public ushort State; // 1 = Pending, 2 = Underway, 3 = Finished

    [FieldOffset(0x0C)] public uint BaseTime;
    [FieldOffset(0x10)] public uint SeasonTarget;
    [FieldOffset(0x14)] public byte IsOpenShop;
    [FieldOffset(0x15)] public byte IsOpenMission;

    [FieldOffset(0x18)] public uint SeedBase;

    [FieldOffset(0x2C)] public fixed byte WBAchieveFlag[20];
    [FieldOffset(0x40)] public fixed byte PMAchieveFlag[20];
    [FieldOffset(0x54)] public fixed byte MMAchieveFlag[4];

    [FieldOffset(0x7C)] public fixed byte WBReceiveFlag[20];
    [FieldOffset(0x90)] public fixed byte PMReceiveFlag[20];
    [FieldOffset(0xA4)] public fixed byte MMReceiveFlag[4];

    [FieldOffset(0xBA)] public byte WBCount;

    [FieldOffset(0xBC)] public byte PMCount;

    [FieldOffset(0xBE)] public byte MMCount;
}
