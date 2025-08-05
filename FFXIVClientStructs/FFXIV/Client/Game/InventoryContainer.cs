namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::InventoryContainer
[GenerateInterop(isInherited: true)]
[VirtualTable("4C 8D 05 ?? ?? ?? ?? ?? ?? ?? 8B CD 48 8B C2", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct InventoryContainer {
    [FieldOffset(0x08)] public InventoryItem* Items;
    [FieldOffset(0x10)] public InventoryType Type;
    [FieldOffset(0x14)] public int Size;
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
    public partial int GetSize();

    [VirtualFunction(5)]
    public partial InventoryItem* GetInventorySlot(int index);
}
