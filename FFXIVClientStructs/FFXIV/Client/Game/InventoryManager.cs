using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Client.Game;

//ctor i guess 40 53 48 83 EC 20 48 8B D9 45 33 C9 B9
[StructLayout(LayoutKind.Explicit, Size = 0x3620)]
public unsafe partial struct InventoryManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 81 C2", 3)]
    public static partial InventoryManager* Instance();

    [FieldOffset(0x1E08)] public InventoryContainer* Inventories;

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F BE C7")]
    public partial InventoryContainer* GetInventoryContainer(InventoryType inventoryType);

    [MemberFunction("E8 ?? ?? ?? ?? 33 C9 38 48 06")]
    public partial InventoryItem* GetInventorySlot(InventoryType inventoryType, int index);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 53 F1")]
    public partial int GetInventoryItemCount(uint itemId, bool isHq = false, bool checkEquipped = true, bool checkArmory = true, short minCollectability = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 03 F8 BB")]
    public partial int GetItemCountInContainer(uint itemId, InventoryType inventoryType, bool isHq = false, short minCollectability = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 33 DB 89 5E 08")]
    public partial int MoveItemSlot(InventoryType srcContainer, ushort srcSlot, InventoryType dstContainer, ushort dstSlot, byte unk = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 7F 6D")]
    private partial uint GetEquippedItemIdForSlot(int slotId);

    /// <summary>
    /// Get the number of gearsets the player is permitted to have/use.
    /// </summary>
    /// <returns>Returns the number of gearsets the player can use.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 42 8B 74 A5")]
    public partial byte GetPermittedGearsetCount();

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B E8 44 3B E0")]
    public partial uint GetEmptySlotsInBag();

    [MemberFunction("E8 ?? ?? ?? ?? 3B 44 24 58")]
    public partial uint GetGil();

    [MemberFunction("E8 ?? ?? ?? ?? 03 D8 3B F3")]
    public partial uint GetRetainerGil();

    [MemberFunction("E8 ?? ?? ?? ?? 8B F8 39 BB")]
    public partial uint GetFreeCompanyGil();

    [MemberFunction("E8 ?? ?? ?? ?? 3B C3 73 25")]
    public partial uint GetGoldSaucerCoin();

    [MemberFunction("E8 ?? ?? ?? ?? 2B E8 8B C5 EB 61")]
    public partial uint GetWolfMarks();

    [MemberFunction("E9 ?? ?? ?? ?? 83 FB 1D")]
    public partial uint GetAlliedSeals();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 4D 6C")]
    public partial uint GetCompanySeals(byte grandcompanyId);

    [MemberFunction("E8 ?? ?? ?? ?? 2B C3 EB 11")]
    public partial uint GetMaxCompanySeals(byte grandcompanyId);

    [MemberFunction("E8 ?? ?? ?? ?? 8B CE 2B E8")]
    public partial uint GetTomestoneCount(uint tomestoneItemId);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? 8B D8 E8 ?? ?? ?? ?? 8B 55 F7")]
    private partial int GetLimitedTomestoneCount(int a1);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 4F DD")]
    private static partial int GetSpecialItemId(byte switchCase);

    // Gets the current maximum weekly number of limited tomestones tha player can earn
    [MemberFunction("E8 ?? ?? ?? ?? 42 8D 0C 23")]
    public static partial int GetLimitedTomestoneWeeklyLimit();

    // Gets the number of (limited) tomestones the user has acquired during the current reset cycle.
    public int GetWeeklyAcquiredTomestoneCount() => GetLimitedTomestoneCount(GetSpecialItemId(9));
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct InventoryContainer {
    [FieldOffset(0x00)] public InventoryItem* Items;
    [FieldOffset(0x08)] public InventoryType Type;
    [FieldOffset(0x0C)] public uint Size;
    [FieldOffset(0x10)] public byte Loaded;

    [MemberFunction("E8 ?? ?? ?? ?? 8B 57 F0")]
    public partial InventoryItem* GetInventorySlot(int index);
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct InventoryItem : ICreatable {
    [FieldOffset(0x00)] public InventoryType Container;
    [FieldOffset(0x04)] public short Slot;
    /// <summary>
    /// Indicates whether this InventoryItem is symbolic, serving as a link to another InventoryItem<br/>
    /// identified by the <see cref="LinkedItemSlot"/> and <see cref="LinkedInventoryType"/>.
    /// </summary>
    [FieldOffset(0x06)] public bool IsSymbolic;
    /// <remarks> Only used if <see cref="IsSymbolic"/> is <c>false</c>. </remarks>
    [FieldOffset(0x08)] public uint ItemID;
    /// <remarks> Only used if <see cref="IsSymbolic"/> is <c>true</c>. </remarks>
    [FieldOffset(0x08), CExportIgnore] public ushort LinkedItemSlot;
    /// <remarks> Only used if <see cref="IsSymbolic"/> is <c>true</c>. </remarks>
    [FieldOffset(0x0A), CExportIgnore] public ushort LinkedInventoryType;
    [FieldOffset(0x0C)] public uint Quantity;
    [FieldOffset(0x10)] public ushort Spiritbond; // TODO: This field is also used for the collectability value. Not sure if it's the same data type. See also: GetSpiritbond()
    [FieldOffset(0x12)] public ushort Condition;
    [FieldOffset(0x14)] public ItemFlags Flags;
    [FieldOffset(0x18)] public ulong CrafterContentID;
    [FieldOffset(0x20)] public fixed ushort Materia[5];
    [FieldOffset(0x2A)] public fixed byte MateriaGrade[5];
    [FieldOffset(0x2F)] public byte Stain;
    [FieldOffset(0x30)] public uint GlamourID;

    [Flags]
    public enum ItemFlags : byte {
        None = 0,
        HQ = 1,
        CompanyCrestApplied = 2,
        Relic = 4,
        Collectable = 8
    }

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 45 A8")]
    public partial void Ctor();

    [MemberFunction("8B 42 08 4C 8B C1")]
    public partial bool Equals(InventoryItem* other);

    /// <summary>Copies the values from the other InventoryItem and, if it's symbolic, resolves its linked item.</summary>
    [MemberFunction("E9 ?? ?? ?? ?? 48 8D 4B 48")]
    public partial bool Copy(InventoryItem* other);

    /// <summary>
    /// Resolves a symbolic InventoryItem, returning a pointer to the linked InventoryItem or to itself if not symbolic.
    /// </summary>
    /// <remarks>
    /// If the resolved InventoryItem is also symbolic, it will NOT resolve this one too.<br/>
    /// Instead, this function must be called in a loop until the original InventoryItem is found (<see cref="IsSymbolic"/> == <c>false</c>).
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 38 58 06")]
    public partial InventoryItem* GetLinkedItem();

    /// <summary>Gets the item id from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 41 3B 06")]
    public partial uint GetItemId();

    /// <summary>Gets the quantity from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 2B C6")]
    public partial uint GetQuantity();

    /// <summary>Gets the spiritbond value from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 66 41 3B 85")]
    public partial ushort GetSpiritbond();

    /// <summary>Gets the condition from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 F0 EB 04")]
    public partial ushort GetCondition();

    /// <summary>Gets the crafter's content id from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D8 EB 04")]
    public partial ulong GetCrafterContentId();

    /// <summary>Gets the stain from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 3A 43 08")]
    public partial byte GetStain();

    /// <summary>Gets the glamour id from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 39 33 75")]
    public partial uint GetGlamourId();

    /// <summary>Gets the materia id from the specified slot of the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? EB 10 32 C0")]
    public partial ushort GetMateriaId(byte materiaSlot);

    /// <summary>Gets the materia grade from the specified slot of the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 42 3A 04 33")]
    public partial byte GetMateriaGrade(byte materiaSlot);

    /// <summary>Gets the materia count from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 3A 47 67")]
    public partial byte GetMateriaCount();
}

public enum InventoryType : uint {
    Inventory1 = 0,
    Inventory2 = 1,
    Inventory3 = 2,
    Inventory4 = 3,

    EquippedItems = 1000,

    Currency = 2000,
    Crystals = 2001,
    MailEdit = 2002, // used by LetterEditor
    Mail = 2003,
    KeyItems = 2004,
    HandIn = 2005,
    Unknown2006 = 2006,
    DamagedGear = 2007,
    Unknown2008 = 2008,
    Examine = 2009,
    Reclaim = 2010, // LegacyItemStorage, HousingWithdrawStorage
    HousingExteriorAppearanceEdit = 2011,
    HousingInteriorAppearanceEdit = 2012,
    ReconstructionBuyback = 2013, // Doman Enclave Reconstruction Reclamation Box

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
