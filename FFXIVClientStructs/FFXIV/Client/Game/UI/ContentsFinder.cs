namespace FFXIVClientStructs.FFXIV.Client.Game.UI; 

[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe partial struct ContentsFinder
{
    public static ContentsFinder* Instance() => &UIState.Instance()->ContentsFinder;
    
    [FieldOffset(0x00)] public void* vtbl;
    [FieldOffset(0x10)] public LootRule LootRules;
    
    [Obsolete("Use IsUnrestrictedParty boolean property instead", true)] 
    [FieldOffset(0x19)] public byte UnrestrictedParty;
    
    [Obsolete("Use IsMinimalIL boolean property instead", true)]
    [FieldOffset(0x1A)] public byte MinimalIL;
    
    [Obsolete("Use IsSilenceEcho boolean property instead", true)]
    [FieldOffset(0x1B)] public byte SilenceEcho;
    
    [Obsolete("Use IsExplorerMode boolean property instead", true)]
    [FieldOffset(0x1C)] public byte ExplorerMode;
    
    [Obsolete("Use IsLevelSync boolean property instead", true)]
    [FieldOffset(0x1D)] public byte LevelSync;
    
    [Obsolete("Use IsLimitedLevelingRoulette boolean property instead", true)]
    [FieldOffset(0x1E)] public byte LimitedLevelingRoulette;
    
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
    
    public enum LootRule : byte 
    {
        Normal = 0,
        GreedOnly = 1,
        Lootmaster = 2
    }
}
