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

    [FieldOffset(0xAA4), FixedSizeArray] internal FixedSizeArray7<MycItemCategory> _itemHolsters;

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
