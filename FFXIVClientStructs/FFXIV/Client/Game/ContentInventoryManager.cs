using FFXIVClientStructs.FFXIV.Client.Game.WKS;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::ContentInventoryManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct ContentInventoryManager {
    [StaticAddress("48 89 1D ?? ?? ?? ?? ?? ?? ?? 48 8B 5C 24", 3, isPointer: true)]
    public static partial ContentInventoryManager* Instance();

    [FieldOffset(0x08)] public StdMap<uint, Pointer<ContentInventoryProvider>> InventoryProviders;
    [FieldOffset(0x18)] public WKSContentInventoryProvider WKSInventoryProvider;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? E8 ?? ?? ?? ?? 44 0F B7 C6")]
    public partial bool HasInventoryContainer(InventoryType inventoryType);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 48 89 5C 24 ?? 48 89 6C 24")]
    public partial bool HasItemId(uint itemId);

    [MemberFunction("E9 ?? ?? ?? ?? 8B D3 48 8B CE E8 ?? ?? ?? ?? 48 8B C8")]
    public partial ContentInventoryItem* GetInventorySlot(InventoryType inventoryType, short slotIndex);

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 49 8B 97")]
    public partial ContentInventoryContainer* GetInventoryContainer(InventoryType inventoryType);

    /// <summary>
    /// Returns the <see cref="InventoryType"/> associated with the specified <paramref name="itemId"/>.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 89 44 24 ?? E8 ?? ?? ?? ?? 48 8D 54 24 ?? ?? ?? ?? 4C 8B 41 ?? 48 8B C8 41 FF D0 48 83 C4")]
    public partial InventoryType GetInventoryTypeByItemId(uint itemId);
}
