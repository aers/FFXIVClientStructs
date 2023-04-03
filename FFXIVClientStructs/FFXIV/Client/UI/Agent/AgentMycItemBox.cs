using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MycItemBox)]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe struct AgentMycItemBox
{
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [FieldOffset(0x40)] public MycLostFindsCache* LostFindsCache;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1580)]
public unsafe partial struct MycLostFindsCache
{
    [FixedSizeArray<MycItemCategory>(7)] 
    [FieldOffset(0x08)] public fixed byte ItemCacheArray[7 * 0x184];

    [FieldOffset(0x08)] public MycItemCategory OffensiveCache;
    [FieldOffset(0x18C)] public MycItemCategory DefensiveCache;
    [FieldOffset(0x310)] public MycItemCategory RestorativeCache;
    [FieldOffset(0x494)] public MycItemCategory BeneficialCache;
    [FieldOffset(0x618)] public MycItemCategory TacticalCache;
    [FieldOffset(0x79C)] public MycItemCategory DetrimentalCache;
    [FieldOffset(0x920)] public MycItemCategory ItemRelatedCache;
    
    [FixedSizeArray<MycItemCategory>(7)] 
    [FieldOffset(0xAA4)] public fixed byte ItemHolsterArray[7 * 0x184];
    
    [FieldOffset(0xAA4)] public MycItemCategory OffensiveHolster;
    [FieldOffset(0xC28)] public MycItemCategory DefensiveHolster;
    [FieldOffset(0xDAC)] public MycItemCategory RestorativeHolster;
    [FieldOffset(0xF30)] public MycItemCategory BeneficialHolster;
    [FieldOffset(0x10B4)] public MycItemCategory TacticalHolster;
    [FieldOffset(0x1238)] public MycItemCategory DetrimentalHolster;
    [FieldOffset(0x13BC)] public MycItemCategory ItemRelatedHolster;

    [FieldOffset(0x1550)] public int HolsterCurrentTab;
    [FieldOffset(0x1558)] public int LastSelectedActionId;
}

[StructLayout(LayoutKind.Explicit, Size = 0x184)]
public unsafe partial struct MycItemCategory
{
    [FixedSizeArray<MycItem>(48)]
    [FieldOffset(0x00)] public fixed byte ItemArray[48 * 0x8];

    [FieldOffset(0x180)] public int ItemCount;
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct MycItem
{
    [FieldOffset(0x00)] public int ActionId;
    [FieldOffset(0x04)] public int Count;
}