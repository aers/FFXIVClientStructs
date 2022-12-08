namespace FFXIVClientStructs.FFXIV.Client.Game.UI; 

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct ContentsFinder {
    public enum LootRule : byte {
        Normal = 0,
        GreedOnly = 1,
        Lootmaster = 2
    }

    [FieldOffset(0x00)] public void* vtbl;
    [FieldOffset(0x10)] public LootRule LootRules;
    [FieldOffset(0x11)] public byte UnrestrictedParty;
    [FieldOffset(0x12)] public byte MinimalIL;
    [FieldOffset(0x13)] public byte SilenceEcho;
    [FieldOffset(0x14)] public byte ExplorerMode;
    [FieldOffset(0x15)] public byte LevelSync;
    [FieldOffset(0x16)] public byte LimitedLevelingRoulette;
}
