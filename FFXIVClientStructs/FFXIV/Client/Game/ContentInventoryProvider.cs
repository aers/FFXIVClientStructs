namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::ContentInventoryProvider
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct ContentInventoryProvider {
    [FieldOffset(0x10)] public StdMap<uint, InventoryType> ItemIdInventoryItemMapping;
    [FieldOffset(0x20)] public short SlotCount;

    [VirtualFunction(0)]
    public partial void Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial bool HasInventoryContainer(InventoryType inventoryType);

    [VirtualFunction(2)]
    public partial bool IsValidTerritoryType(ushort territoryTypeId);

    [VirtualFunction(3)]
    public partial void Setup();

    [VirtualFunction(5)]
    public partial void Update();

    [VirtualFunction(9)]
    public partial ContentInventoryItem* GetInventorySlot(InventoryType inventoryType, short slotIndex);

    [VirtualFunction(10)]
    public partial ContentInventoryContainer* GetInventoryContainer(InventoryType inventoryType);

    // not sure
    // [VirtualFunction(16)]
    // public partial int GetQuantityWithInventoryItemFallbac(InventoryType inventoryType, InventoryItem* fallback);

    /// <summary>
    /// Returns whether the specified <paramref name="itemId"/> is a valid item that can be saved in containers provided by this <see cref="ContentInventoryProvider"/>.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 ?? 48 8B 43 ?? 80 78 ?? ?? 74 ?? 48 8B 43 ?? 80 78 ?? ?? 75 ?? 0F 1F 40")]
    public partial bool HasItemId(uint itemId);

    /// <summary>
    /// Returns the <see cref="InventoryType"/> associated with the specified <paramref name="itemId"/>.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 2D ?? ?? ?? ?? 74 ?? 83 F8 ?? 75")]
    public partial InventoryType GetInventoryTypeByItemId(uint itemId);
}
