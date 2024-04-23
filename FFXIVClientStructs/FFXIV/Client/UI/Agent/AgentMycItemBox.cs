using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MycItemBox)]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct AgentMycItemBox {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    /// <remarks>
    /// Contains how many of each item the player has in both the cache and the holster
    /// </remarks>
    [FieldOffset(0x40)] public MycItemBoxData* ItemBoxData;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1580)]
public unsafe partial struct MycItemBoxData {
    [FixedSizeArray<MycItemCategory>(7)]
    [FieldOffset(0x08)] public fixed byte ItemCacheArray[7 * 0x184];

    [FieldOffset(0x08), Obsolete("Use ItemCacheArraySpan[0]")] public MycItemCategory OffensiveCache;
    [FieldOffset(0x18C), Obsolete("Use ItemCacheArraySpan[1]")] public MycItemCategory DefensiveCache;
    [FieldOffset(0x310), Obsolete("Use ItemCacheArraySpan[2]")] public MycItemCategory RestorativeCache;
    [FieldOffset(0x494), Obsolete("Use ItemCacheArraySpan[3]")] public MycItemCategory BeneficialCache;
    [FieldOffset(0x618), Obsolete("Use ItemCacheArraySpan[4]")] public MycItemCategory TacticalCache;
    [FieldOffset(0x79C), Obsolete("Use ItemCacheArraySpan[5]")] public MycItemCategory DetrimentalCache;
    [FieldOffset(0x920), Obsolete("Use ItemCacheArraySpan[6]")] public MycItemCategory ItemRelatedCache;

    [FixedSizeArray<MycItemCategory>(7)]
    [FieldOffset(0xAA4)] public fixed byte ItemHolsterArray[7 * 0x184];

    [FieldOffset(0xAA4), Obsolete("Use ItemHolsterArraySpan[0]")] public MycItemCategory OffensiveHolster;
    [FieldOffset(0xC28), Obsolete("Use ItemHolsterArraySpan[1]")] public MycItemCategory DefensiveHolster;
    [FieldOffset(0xDAC), Obsolete("Use ItemHolsterArraySpan[2]")] public MycItemCategory RestorativeHolster;
    [FieldOffset(0xF30), Obsolete("Use ItemHolsterArraySpan[3]")] public MycItemCategory BeneficialHolster;
    [FieldOffset(0x10B4), Obsolete("Use ItemHolsterArraySpan[4]")] public MycItemCategory TacticalHolster;
    [FieldOffset(0x1238), Obsolete("Use ItemHolsterArraySpan[5]")] public MycItemCategory DetrimentalHolster;
    [FieldOffset(0x13BC), Obsolete("Use ItemHolsterArraySpan[6]")] public MycItemCategory ItemRelatedHolster;

    [FieldOffset(0x1550)] public int HolsterCurrentTab;
    [FieldOffset(0x1558)] public int LastSelectedActionId;
}

[StructLayout(LayoutKind.Explicit, Size = 0x184)]
public unsafe partial struct MycItemCategory {
    [FixedSizeArray<MycItem>(48)]
    [FieldOffset(0x00)] public fixed byte ItemArray[48 * 0x8];

    [FieldOffset(0x180)] public int ItemCount;
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct MycItem {
    [FieldOffset(0x00)] public int ActionId;
    [FieldOffset(0x04)] public int Count;
}
