namespace FFXIVClientStructs.FFXIV.Client.Game.UI; 

[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe struct ContentsFinder
{
    public static ContentsFinder* Instance() => &UIState.Instance()->ContentsFinder;
    
    [FieldOffset(0x00)] public void* vtbl;
    [FieldOffset(0x10)] public LootRule LootRules;
    [FieldOffset(0x11)] public byte UnrestrictedParty;
    [FieldOffset(0x12)] public byte MinimalIL;
    [FieldOffset(0x13)] public byte SilenceEcho;
    [FieldOffset(0x14)] public byte ExplorerMode;
    [FieldOffset(0x15)] public byte LevelSync;
    [FieldOffset(0x16)] public byte LimitedLevelingRoulette;

    [FieldOffset(0x60)] public int EnteredQueueTimestamp;
    [FieldOffset(0x7C)] public byte PositionInQueue;
    [FieldOffset(0x87)] public byte AverageWaitTime; // In minutes
    
    public DateTime GetEnteredQueueDateTime() => DateTime.UnixEpoch.AddSeconds(EnteredQueueTimestamp);
    
    public enum LootRule : byte 
    {
        Normal = 0,
        GreedOnly = 1,
        Lootmaster = 2
    }
}
