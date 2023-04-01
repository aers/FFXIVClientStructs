using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MycItemBox)]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe struct AgentMycItemBox
{
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [FieldOffset(0x40)] public MycLostFindsCache* LostFindsCache;
}

[StructLayout(LayoutKind.Explicit, Size = 0xAA4)]
public unsafe partial struct MycLostFindsCache
{
    [FixedSizeArray<MycItemCategory>(7)] 
    [FieldOffset(0x08)] public fixed byte ItemCategoryArray[7 * 0x184];

    [FieldOffset(0x08)] public MycItemCategory OffensiveCategory;
    [FieldOffset(0x18C)] public MycItemCategory DefensiveCategory;
    [FieldOffset(0x310)] public MycItemCategory RestorativeCategory;
    [FieldOffset(0x494)] public MycItemCategory BeneficialCategory;
    [FieldOffset(0x618)] public MycItemCategory TacticalCategory;
    [FieldOffset(0x79C)] public MycItemCategory DetrimentalCategory;
    [FieldOffset(0x920)] public MycItemCategory ItemRelatedCategory;
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