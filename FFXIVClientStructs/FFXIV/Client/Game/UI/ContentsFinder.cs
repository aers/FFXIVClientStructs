namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe partial struct ContentsFinder {
    [StaticAddress("0F B6 FA 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 80 78 59 02", 6)]
    public static partial ContentsFinder* Instance();

    [FieldOffset(0x00)] public void* vtbl;
    [FieldOffset(0x18)] public LootRule LootRules;

    [FieldOffset(0x19)] public bool IsUnrestrictedParty;
    [FieldOffset(0x1A)] public bool IsMinimalIL;
    [FieldOffset(0x1B)] public bool IsSilenceEcho;
    [FieldOffset(0x1C)] public bool IsExplorerMode;
    [FieldOffset(0x1D)] public bool IsLevelSync;
    [FieldOffset(0x1E)] public bool IsLimitedLevelingRoulette;

    [FieldOffset(0x60)] public int EnteredQueueTimestamp;
    [FieldOffset(0x7C)] public byte PositionInQueue;
    [FieldOffset(0x87)] public byte AverageWaitTime; // In minutes

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 53 06 49 8B CE")]
    public partial uint SetJoinInProgress(bool isUnrestrictedParty);

    public DateTime GetEnteredQueueDateTime() => DateTime.UnixEpoch.AddSeconds(EnteredQueueTimestamp);

    public enum LootRule : byte {
        Normal = 0,
        GreedOnly = 1,
        Lootmaster = 2
    }
}
