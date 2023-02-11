namespace FFXIVClientStructs.FFXIV.Client.UI;

// This struct is annoying to work out in realtime,
// You need another player in the instance,
// and have limited time fore the items are auto-rolled
[StructLayout(LayoutKind.Explicit, Size = 0x2B8)]
public unsafe partial struct AddonNeedGreed
{
    // Limit is assumed to be 32, due to the addon having 32 pre-allocated list item renderers
    [FixedSizeArray<LootItemInfo>(32)] 
    [FieldOffset(0x228)] public fixed byte Items[0x28 * 32];
    
    // Contains other information for each loot item,
    // Such as time remaining, and a pointer to what is probably the tooltip string
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct LootItemInfo
    {
        [FieldOffset(0x00)] public uint ItemId;
    }
}