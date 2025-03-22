namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMycItemBox
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.MycItemBox)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct AgentMycItemBox {

    /// <remarks>
    /// Contains how many of each item the player has in both the cache and the holster
    /// </remarks>
    [FieldOffset(0x40)] public MycItemBoxData* ItemBoxData;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1580)]
public unsafe partial struct MycItemBoxData {
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray7<MycItemCategory> _itemCaches;

    [FieldOffset(0x08), Obsolete("Use ItemCacheArray[0]", true)] public MycItemCategory OffensiveCache;
    [FieldOffset(0x18C), Obsolete("Use ItemCacheArray[1]", true)] public MycItemCategory DefensiveCache;
    [FieldOffset(0x310), Obsolete("Use ItemCacheArray[2]", true)] public MycItemCategory RestorativeCache;
    [FieldOffset(0x494), Obsolete("Use ItemCacheArray[3]", true)] public MycItemCategory BeneficialCache;
    [FieldOffset(0x618), Obsolete("Use ItemCacheArray[4]", true)] public MycItemCategory TacticalCache;
    [FieldOffset(0x79C), Obsolete("Use ItemCacheArray[5]", true)] public MycItemCategory DetrimentalCache;
    [FieldOffset(0x920), Obsolete("Use ItemCacheArray[6]", true)] public MycItemCategory ItemRelatedCache;

    [FieldOffset(0xAA4), FixedSizeArray] internal FixedSizeArray7<MycItemCategory> _itemHolsters;

    [FieldOffset(0xAA4), Obsolete("Use ItemHolsterArray[0]", true)] public MycItemCategory OffensiveHolster;
    [FieldOffset(0xC28), Obsolete("Use ItemHolsterArray[1]", true)] public MycItemCategory DefensiveHolster;
    [FieldOffset(0xDAC), Obsolete("Use ItemHolsterArray[2]", true)] public MycItemCategory RestorativeHolster;
    [FieldOffset(0xF30), Obsolete("Use ItemHolsterArray[3]", true)] public MycItemCategory BeneficialHolster;
    [FieldOffset(0x10B4), Obsolete("Use ItemHolsterArray[4]", true)] public MycItemCategory TacticalHolster;
    [FieldOffset(0x1238), Obsolete("Use ItemHolsterArray[5]", true)] public MycItemCategory DetrimentalHolster;
    [FieldOffset(0x13BC), Obsolete("Use ItemHolsterArray[6]", true)] public MycItemCategory ItemRelatedHolster;

    [FieldOffset(0x1550)] public int HolsterCurrentTab;
    [FieldOffset(0x1558)] public int LastSelectedActionId;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x184)]
public unsafe partial struct MycItemCategory {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray48<MycItem> _items;

    [FieldOffset(0x180)] public int ItemCount;
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct MycItem {
    [FieldOffset(0x00)] public int ActionId;
    [FieldOffset(0x04)] public int Count;
}
