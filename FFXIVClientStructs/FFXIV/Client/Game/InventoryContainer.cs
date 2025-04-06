namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::InventoryContainer
[GenerateInterop]
[VirtualTable("48 8D 0D ?? ?? ?? ?? 48 89 6C 24 ?? BD ?? ?? ?? ?? 48 89 28", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct InventoryContainer {
    [FieldOffset(0x08)] public InventoryItem* Items;
    [FieldOffset(0x10)] public InventoryType Type;
    [FieldOffset(0x14)] public uint Size;
    [FieldOffset(0x18)] public bool IsLoaded;

    [VirtualFunction(0)]
    public partial InventoryContainer* Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial void SetInventoryType(InventoryType inventoryType);

    [VirtualFunction(2)]
    public partial void Clear();

    // [VirtualFunction(3)]
    // public partial void Noop();

    [VirtualFunction(4)]
    public partial uint GetSize();

    [VirtualFunction(5)]
    public partial InventoryItem* GetInventorySlot(int index);
}
