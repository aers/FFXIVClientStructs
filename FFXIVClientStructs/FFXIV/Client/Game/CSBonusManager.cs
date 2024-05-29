namespace FFXIVClientStructs.FFXIV.Client.Game;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x178)]
public unsafe partial struct CSBonusManager {
    [StaticAddress("48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 63 D0", 3, true)]
    public static partial CSBonusManager* Instance();

    [FieldOffset(0x08)] public ushort State; // 1 = Pending, 2 = Underway, 3 = Finished, 4 = Part 2 Underway, 5 = Part 2 Finished

    [FieldOffset(0x0C)] public uint BaseTime;
    [FieldOffset(0x10)] public uint SeasonTarget;
    [FieldOffset(0x14)] public byte IsOpenShop;
    [FieldOffset(0x15)] public byte IsOpenMission;

    [FieldOffset(0x18)] public uint SeedBase;

    [FieldOffset(0x2C), FixedSizeArray] internal FixedSizeArray20<byte> _WBAchieveFlag;
    [FieldOffset(0x40), FixedSizeArray] internal FixedSizeArray20<byte> _PMAchieveFlag;
    [FieldOffset(0x54), FixedSizeArray] internal FixedSizeArray4<byte>  _MMAchieveFlag;

    [FieldOffset(0x7C), FixedSizeArray] internal FixedSizeArray20<byte> _WBReceiveFlag;
    [FieldOffset(0x90), FixedSizeArray] internal FixedSizeArray20<byte> _PMReceiveFlag;
    [FieldOffset(0xA4), FixedSizeArray] internal FixedSizeArray4<byte>  _MMReceiveFlag;

    [FieldOffset(0xBA)] public byte WBCount;

    [FieldOffset(0xBC)] public byte PMCount;

    [FieldOffset(0xBE)] public byte MMCount;

    // 0xC0 (byte) observed to store weekly minimog fate count. probably an array for progress
}
