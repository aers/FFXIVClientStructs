namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x31F)]
[GenerateInterop]
public unsafe partial struct SatisfactionSupplyManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 45 33 C0 66 89 43 60", 3)]
    public static partial SatisfactionSupplyManager* Instance();

    [FieldOffset(0x1)] public byte BonusGuaranteeRowId;
    [FieldOffset(0x2), FixedSizeArray] internal FixedSizeArray10<ushort> _satisfaction; // Satisfaction of the current Rank
    [FieldOffset(0x16), FixedSizeArray] internal FixedSizeArray10<byte> _satisfactionRanks; // 1-5 indicating each NPC's "Satisfaction" value (the hearts in the UI)
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray10<byte> _usedAllowances;
    [FieldOffset(0x2A)] public short CurrentNpc; // current NPC being shown in AddonSatisfactionSupply
    [FieldOffset(0x2C)] public short CurrentSupplyRowId;
    [FieldOffset(0x2E), FixedSizeArray] internal FixedSizeArray4<short> _currentSupplySubRowIds; // unsure what the first entry is supposed to be
    [FieldOffset(0x36), FixedSizeArray] internal FixedSizeArray4<short> _currentSupplyRewardRowIds; // unsure what the first entry is supposed to be

    [MemberFunction("E8 ?? ?? ?? ?? 2B F0 E8 ?? ?? ?? ?? 8B CB")]
    public partial int GetUsedAllowances();

    [MemberFunction("E8 ?? ?? ?? ?? 8B D0 48 8B CB E8 ?? ?? ?? ?? E8")]
    private partial int GetResetTimestamp();

    public int GetRemainingAllowances() => 12 - GetUsedAllowances();
    public DateTime GetResetDateTime() => DateTime.UnixEpoch.AddSeconds(GetResetTimestamp());
}
