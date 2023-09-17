namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x31F)]
public unsafe partial struct SatisfactionSupplyManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 45 33 C0 66 89 43 60", 3)]
    public static partial SatisfactionSupplyManager* Instance();

    [FieldOffset(0x14)] public fixed byte SatisfactionRankArray[9]; // 1-5 indicating each NPC's "Satisfaction" value (the hearts in the UI)
    [FieldOffset(0x1D)] public fixed byte UsedAllowanceArray[9];

    [MemberFunction("0F B6 41 24 4C 8B C1")]
    public partial int GetUsedAllowances();

    [MemberFunction("E8 ?? ?? ?? ?? 8B D0 48 8B CB E8 ?? ?? ?? ?? E8")]
    private partial int GetResetTimestamp();

    public int GetRemainingAllowances() => 12 - GetUsedAllowances();
    public DateTime GetResetDateTime() => DateTime.UnixEpoch.AddSeconds(GetResetTimestamp());

    public byte GetRankByName(SatisfactionSupplyNpc npc) => SatisfactionRankArray[(int)npc - 1];
    public byte GetUsedAllowancesByName(SatisfactionSupplyNpc npc) => UsedAllowanceArray[(int)npc - 1];
}

// Based on SatisfactionNpc lumina sheet
public enum SatisfactionSupplyNpc {
    ZholeAliapoh = 1,
    Mnaago,
    Kurenai,
    Adkiragh,
    KaiShirr,
    EhllTou,
    Charlemend,
    Ameliance,
    Anden
}
