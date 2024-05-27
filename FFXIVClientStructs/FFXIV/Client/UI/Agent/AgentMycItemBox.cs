namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MycItemBox)]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
[GenerateInterop]
[Inherits<AgentInterface>]
public unsafe partial struct AgentMycItemBox {

    /// <remarks>
    /// Contains how many of each item the player has in both the cache and the holster
    /// </remarks>
    [FieldOffset(0x40)] public MycItemBoxData* ItemBoxData;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1580)]
[GenerateInterop]
public unsafe partial struct MycItemBoxData {
    [FieldOffset(0x08)] [FixedSizeArray] internal FixedSizeArray7<MycItemCategory> _itemCacheArray;

    [FieldOffset(0x08), Obsolete("Use ItemCacheArray[0]")] public MycItemCategory OffensiveCache;
    [FieldOffset(0x18C), Obsolete("Use ItemCacheArray[1]")] public MycItemCategory DefensiveCache;
    [FieldOffset(0x310), Obsolete("Use ItemCacheArray[2]")] public MycItemCategory RestorativeCache;
    [FieldOffset(0x494), Obsolete("Use ItemCacheArray[3]")] public MycItemCategory BeneficialCache;
    [FieldOffset(0x618), Obsolete("Use ItemCacheArray[4]")] public MycItemCategory TacticalCache;
    [FieldOffset(0x79C), Obsolete("Use ItemCacheArray[5]")] public MycItemCategory DetrimentalCache;
    [FieldOffset(0x920), Obsolete("Use ItemCacheArray[6]")] public MycItemCategory ItemRelatedCache;

    [FieldOffset(0xAA4)] [FixedSizeArray] internal FixedSizeArray7<MycItemCategory> _itemHolsterArray;

    [FieldOffset(0xAA4), Obsolete("Use ItemHolsterArray[0]")] public MycItemCategory OffensiveHolster;
    [FieldOffset(0xC28), Obsolete("Use ItemHolsterArray[1]")] public MycItemCategory DefensiveHolster;
    [FieldOffset(0xDAC), Obsolete("Use ItemHolsterArray[2]")] public MycItemCategory RestorativeHolster;
    [FieldOffset(0xF30), Obsolete("Use ItemHolsterArray[3]")] public MycItemCategory BeneficialHolster;
    [FieldOffset(0x10B4), Obsolete("Use ItemHolsterArray[4]")] public MycItemCategory TacticalHolster;
    [FieldOffset(0x1238), Obsolete("Use ItemHolsterArray[5]")] public MycItemCategory DetrimentalHolster;
    [FieldOffset(0x13BC), Obsolete("Use ItemHolsterArray[6]")] public MycItemCategory ItemRelatedHolster;

    [FieldOffset(0x1550)] public int HolsterCurrentTab;
    [FieldOffset(0x1558)] public int LastSelectedActionId;
}

[StructLayout(LayoutKind.Explicit, Size = 0x184)]
[GenerateInterop]
public unsafe partial struct MycItemCategory {
    [FieldOffset(0x00)] [FixedSizeArray] internal FixedSizeArray48<MycItem> _itemArray;

    [FieldOffset(0x180)] public int ItemCount;
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct MycItem {
    [FieldOffset(0x00)] public int ActionId;
    [FieldOffset(0x04)] public int Count;
}
