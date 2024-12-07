namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::SatisfactionSupplyManager
// Custom Deliveries
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x323)]
public unsafe partial struct SatisfactionSupplyManager {
    [StaticAddress("8B D0 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 74 1E", 5)]
    public static partial SatisfactionSupplyManager* Instance();

    [FieldOffset(0x0)] public byte SupplySeed; // seed for pseudorandom transform that selects requested crafts for the week
    [FieldOffset(0x1)] public byte BonusGuaranteeRowId; // determines which two npcs per category will have bonus items, in addition to pseudo-random ones
    [FieldOffset(0x2), FixedSizeArray] internal FixedSizeArray11<ushort> _satisfaction; // Satisfaction of the current Rank
    [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray11<byte> _satisfactionRanks; // 1-5 indicating each NPC's "Satisfaction" value (the hearts in the UI)
    [FieldOffset(0x23), FixedSizeArray] internal FixedSizeArray11<byte> _usedAllowances;
    [FieldOffset(0x2E)] public short CurrentNpc; // current NPC being shown in AddonSatisfactionSupply
    [FieldOffset(0x30)] public short CurrentSupplyRowId;
    [FieldOffset(0x32), FixedSizeArray] internal FixedSizeArray4<short> _currentSupplySubRowIds; // unsure what the first entry is supposed to be
    [FieldOffset(0x3A), FixedSizeArray] internal FixedSizeArray4<short> _currentSupplyRewardRowIds; // unsure what the first entry is supposed to be
    [FieldOffset(0x42)] public bool CurrentNpcInitInProgress;
    [FieldOffset(0x43)] public bool CurrentNpcInitDone;
    // 0x48: ulong set together with CurrentNpc, all callers pass zero
    // 0x50: ExcelSheetWaiter* for SatisfactionSupply
    // 0x58: ExcelSheetWaiter* for SatisfactionSupplyReward
    // 0x60: ExcelSheetWaiter* for SatisfactionSupplyRewardExp
    // 0x68: ExcelSheetWaiter* for SatisfactionBonusGuarantee
    [FieldOffset(0x70)] public uint FixedRandom; // seems to be a debug thing, set by gm command, not actually used?
    [FieldOffset(0x74)] public int TimeAdjustmentForBonusGuarantee; // seems to be a debug thing, set by gm command, this is added to server time (in seconds) and used to calculate bonus guarantee row

    [StructLayout(LayoutKind.Explicit, Size = 0x1C)]
    public struct NpcInfo {
        [FieldOffset(0x00)] public uint NpcId; // ENpcResident row id
        [FieldOffset(0x04)] public uint ImageId; // npc image used for the ui; depends on rank and quest unlock
        // 0x08: int, depends on rank and quest unlock, used together with ImageId and stored in nearby column
        [FieldOffset(0x0C)] public ushort SatisfactionCur; // progress at current rank
        [FieldOffset(0x0E)] public ushort SatisfactionMax;
        [FieldOffset(0x10)] public byte RankCur;
        [FieldOffset(0x11)] public byte RankMax;
        [FieldOffset(0x12)] public byte UsedAllowances;
        [FieldOffset(0x13)] public byte MaxAllowances;
        [FieldOffset(0x14)] public ushort RemainingAllowances;
        [FieldOffset(0x16)] public short LevelUnlocked;
        [FieldOffset(0x18)] public bool CanGlamour;
        [FieldOffset(0x19)] public bool RankQuestComplete;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 2B F0 E8 ?? ?? ?? ?? 8B CB")]
    public partial int GetUsedAllowances();

    [MemberFunction("E8 ?? ?? ?? ?? 8B D0 48 8B CB E8 ?? ?? ?? ?? E8")]
    private partial int GetResetTimestamp();

    public int GetRemainingAllowances() => 12 - GetUsedAllowances();
    public DateTime GetResetDateTime() => DateTime.UnixEpoch.AddSeconds(GetResetTimestamp());
}
