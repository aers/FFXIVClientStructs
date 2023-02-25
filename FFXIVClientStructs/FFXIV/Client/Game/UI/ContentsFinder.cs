namespace FFXIVClientStructs.FFXIV.Client.Game.UI; 

[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe struct ContentsFinder
{
    public static ContentsFinder* Instance() => &UIState.Instance()->ContentsFinder;
    
    [FieldOffset(0x00)] public void* vtbl;
    [FieldOffset(0x10)] public LootRule LootRules;
    
    [Obsolete("Use IsUnrestrictedParty boolean property instead", true)] 
    [FieldOffset(0x11)] public byte UnrestrictedParty;
    
    [Obsolete("Use IsMinimalIL boolean property instead", true)]
    [FieldOffset(0x12)] public byte MinimalIL;
    
    [Obsolete("Use IsSilenceEcho boolean property instead", true)]
    [FieldOffset(0x13)] public byte SilenceEcho;
    
    [Obsolete("Use IsExplorerMode boolean property instead", true)]
    [FieldOffset(0x14)] public byte ExplorerMode;
    
    [Obsolete("Use IsLevelSync boolean property instead", true)]
    [FieldOffset(0x15)] public byte LevelSync;
    
    [Obsolete("Use IsLimitedLevelingRoulette boolean property instead", true)]
    [FieldOffset(0x16)] public byte LimitedLevelingRoulette;
    
    [FieldOffset(0x11)] public bool IsUnrestrictedParty;
    [FieldOffset(0x12)] public bool IsMinimalIL;
    [FieldOffset(0x13)] public bool IsSilenceEcho;
    [FieldOffset(0x14)] public bool IsExplorerMode;
    [FieldOffset(0x15)] public bool IsLevelSync;
    [FieldOffset(0x16)] public bool IsLimitedLevelingRoulette;

    [FieldOffset(0x60)] public int EnteredQueueTimestamp;
    [FieldOffset(0x7C)] public byte PositionInQueue;
    [FieldOffset(0x87)] public byte AverageWaitTime; // In minutes
    
    public DateTime GetEnteredQueueDateTime() => DateTime.UnixEpoch.AddSeconds(EnteredQueueTimestamp);
}

public enum LootRule : byte 
{
    Normal = 0,
    GreedOnly = 1,
    Lootmaster = 2
}