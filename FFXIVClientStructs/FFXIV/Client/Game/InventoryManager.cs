namespace FFXIVClientStructs.FFXIV.Client.Game;

//ctor i guess 40 53 48 83 EC 20 48 8B D9 45 33 C9 B9
[StructLayout(LayoutKind.Explicit, Size = 0x3620)]
public unsafe partial struct InventoryManager
{
    [FieldOffset(0x1E08)] public InventoryContainer* Inventories;

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F BE C7")]
    public partial InventoryContainer* GetInventoryContainer(InventoryType inventoryType);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 53 F1")]
    public partial int GetInventoryItemCount(uint itemId, bool isHq = false, bool checkEquipped = true, bool checkArmory = true, short minCollectability = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 03 F8 BB")]
    public partial int GetItemCountInContainer(uint itemId, InventoryType inventoryType, bool isHq = false, short minCollectability = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 33 DB 89 1E")]
    public partial int MoveItemSlot(InventoryType srcContainer, uint srcSlot, InventoryType dstContainer, uint dstSlot, byte unk = 0);

    /// <summary>
    /// Get the number of gearsets the player is permitted to have/use.
    /// </summary>
    /// <returns>Returns the number of gearsets the player can use.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 42 8B 74 A5")]
    public partial byte GetPermittedGearsetCount();

    [StaticAddress("48 8D 0D ?? ?? ?? ?? 81 C2", 3)]
    public static partial InventoryManager* Instance();
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct InventoryContainer
{
    [FieldOffset(0x00)] public InventoryItem* Items;
    [FieldOffset(0x08)] public InventoryType Type;
    [FieldOffset(0x0C)] public uint Size;
    [FieldOffset(0x10)] public byte Loaded;

    [MemberFunction("E8 ?? ?? ?? ?? 8B 5B 0C")]
    public partial InventoryItem* GetInventorySlot(int index);
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct InventoryItem
{
    [FieldOffset(0x00)] public InventoryType Container;
    [FieldOffset(0x04)] public short Slot;
    [FieldOffset(0x08)] public uint ItemID;
    [FieldOffset(0x0C)] public uint Quantity;
    [FieldOffset(0x10)] public ushort Spiritbond;
    [FieldOffset(0x12)] public ushort Condition;
    [FieldOffset(0x14)] public ItemFlags Flags;
    [FieldOffset(0x18)] public ulong CrafterContentID;
    [FieldOffset(0x20)] public fixed ushort Materia[5];
    [FieldOffset(0x2A)] public fixed byte MateriaGrade[5];
    [FieldOffset(0x2F)] public byte Stain;
    [FieldOffset(0x30)] public uint GlamourID;

    [Flags]
    public enum ItemFlags : byte
    {
        None = 0,
        HQ = 1,
        CompanyCrestApplied = 2,
        Relic = 4,
        Collectable = 8
    }
}

public enum InventoryType : uint
{
    Inventory1 = 0,
    Inventory2 = 1,
    Inventory3 = 2,
    Inventory4 = 3,

    EquippedItems = 1000,

    Currency = 2000,
    Crystals = 2001,
    Mail = 2003,
    KeyItems = 2004,
    HandIn = 2005,
    DamagedGear = 2007,
    Examine = 2009,

    ArmoryOffHand = 3200,
    ArmoryHead = 3201,
    ArmoryBody = 3202,
    ArmoryHands = 3203,
    ArmoryWaist = 3204,
    ArmoryLegs = 3205,
    ArmoryFeets = 3206,
    ArmoryEar = 3207,
    ArmoryNeck = 3208,
    ArmoryWrist = 3209,
    ArmoryRings = 3300,
    ArmorySoulCrystal = 3400,
    ArmoryMainHand = 3500,

    SaddleBag1 = 4000,
    SaddleBag2 = 4001,
    PremiumSaddleBag1 = 4100,
    PremiumSaddleBag2 = 4101,

    RetainerPage1 = 10000,
    RetainerPage2 = 10001,
    RetainerPage3 = 10002,
    RetainerPage4 = 10003,
    RetainerPage5 = 10004,
    RetainerPage6 = 10005,
    RetainerPage7 = 10006,
    RetainerEquippedItems = 11000,
    RetainerGil = 12000,
    RetainerCrystals = 12001,
    RetainerMarket = 12002,

    FreeCompanyPage1 = 20000,
    FreeCompanyPage2 = 20001,
    FreeCompanyPage3 = 20002,
    FreeCompanyPage4 = 20003,
    FreeCompanyPage5 = 20004,
    FreeCompanyGil = 22000,
    FreeCompanyCrystals = 22001,

    HousingExteriorAppearance = 25000,
    HousingExteriorPlacedItems = 25001,
    HousingInteriorAppearance = 25002,
    HousingInteriorPlacedItems1 = 25003,
    HousingInteriorPlacedItems2 = 25004,
    HousingInteriorPlacedItems3 = 25005,
    HousingInteriorPlacedItems4 = 25006,
    HousingInteriorPlacedItems5 = 25007,
    HousingInteriorPlacedItems6 = 25008,
    HousingInteriorPlacedItems7 = 25009,
    HousingInteriorPlacedItems8 = 25010,

    HousingExteriorStoreroom = 27000,
    HousingInteriorStoreroom1 = 27001,
    HousingInteriorStoreroom2 = 27002,
    HousingInteriorStoreroom3 = 27003,
    HousingInteriorStoreroom4 = 27004,
    HousingInteriorStoreroom5 = 27005,
    HousingInteriorStoreroom6 = 27006,
    HousingInteriorStoreroom7 = 27007,
    HousingInteriorStoreroom8 = 27008
}