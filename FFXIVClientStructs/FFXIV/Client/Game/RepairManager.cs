namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::RepairManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct RepairManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? BA ?? ?? ?? ?? 41 0F 94 C0 45 33 C9", 3)]
    public static partial RepairManager* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 83 F8 03 75 46")]
    public partial bool RepairItem(InventoryType itemToRepairInventory, ushort itemToRepairSlot, bool isNpc);

    /// <summary>Repairs all items of the selected mixed InventoryType. </summary>
    /// <param name="isNpc">Set if it's using a mender or self-repair</param>
    /// <param name="inventoryIndex">Mapped index ids of repair gear dropdown. (7 = Equipped, 0 = Main/Off Hand, 1 =     Head/Body/Hands, ...) </param>
    /// <param name="arg0"></param>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 92")]
    public partial bool RepairAllItems(bool isNpc, int inventoryIndex, byte arg0);

    [MemberFunction("E8 ?? ?? ?? ?? EB 2F 83 F8 07")]
    public partial bool RepairEquipped(int inventoryTypeEquipped, bool isNpc, byte arg0);
    public bool RepairEquipped(bool isNpc) => RepairEquipped(1000, isNpc, 0);
}
