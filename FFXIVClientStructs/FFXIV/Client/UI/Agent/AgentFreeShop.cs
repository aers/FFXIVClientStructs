namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentFreeShop
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.FreeShop)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x630)]
public partial struct AgentFreeShop {
    [FieldOffset(0x28), FixedSizeArray] internal FixedSizeArray61<Item> _items;
    [FieldOffset(0x5E0)] public ItemCatalogContextEvent ItemCatalogContextEvent;
    [FieldOffset(0x618)] public uint ItemCount;
    /// <summary>Bits refer to ClassJob row IDs.</summary>
    [FieldOffset(0x620)] public ulong ClassJobMask;
    [FieldOffset(0x628)] public bool IsInteractionBlocked;
    [FieldOffset(0x629)] public bool IsLoadingItems;

    /// <summary>Refreshes the addon and retries loading missing item data.</summary>
    [MemberFunction("40 53 B8 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 2B E0 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 48 8B 01 48 8B D9 66 C7 81")]
    public partial void RefreshAddon();

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct Item {
        [FieldOffset(0x00)] public uint ItemId;
        [FieldOffset(0x04)] public uint Quantity;
        [FieldOffset(0x0C)] public ushort Patch;
        [FieldOffset(0x14)] public bool IsOwned;
        [FieldOffset(0x15)] public bool IsUnavailable;
        [FieldOffset(0x16)] public bool IsCached;
    }
}
