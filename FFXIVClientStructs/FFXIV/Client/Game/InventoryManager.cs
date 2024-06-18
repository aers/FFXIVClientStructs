using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::InventoryManager
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B F9 33 ED B9 ?? ?? ?? ??"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3620)]
public unsafe partial struct InventoryManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 81 C2", 3)]
    public static partial InventoryManager* Instance();

    [FieldOffset(0x1E08)] public InventoryContainer* Inventories;

    [MemberFunction("E8 ?? ?? ?? ?? 40 38 78 10")]
    public partial InventoryContainer* GetInventoryContainer(InventoryType inventoryType);

    [MemberFunction("E9 ?? ?? ?? ?? 33 C0 C3 0F B6 51 51")]
    public partial InventoryItem* GetInventorySlot(InventoryType inventoryType, int index);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 53 F1")]
    public partial int GetInventoryItemCount(uint itemId, bool isHq = false, bool checkEquipped = true, bool checkArmory = true, short minCollectability = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 03 F8 BB")]
    public partial int GetItemCountInContainer(uint itemId, InventoryType inventoryType, bool isHq = false, short minCollectability = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 4B 0C 66 FF C7")]
    public partial int MoveItemSlot(InventoryType srcContainer, ushort srcSlot, InventoryType dstContainer, ushort dstSlot, byte unk = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 7F 66")]
    private partial uint GetEquippedItemIdForSlot(int slotId);

    /// <summary>
    /// Get the number of gearsets the player is permitted to have/use.
    /// </summary>
    /// <returns>Returns the number of gearsets the player can use.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 C0 84 C0 74 23")]
    public partial byte GetPermittedGearsetCount();

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B E8 44 3B F8")]
    public partial uint GetEmptySlotsInBag();

    [MemberFunction("E8 ?? ?? ?? ?? 3B 44 24 58")]
    public partial uint GetGil();

    [MemberFunction("E8 ?? ?? ?? ?? 8B F0 39 43 78")]
    public partial uint GetRetainerGil();

    [MemberFunction("E8 ?? ?? ?? ?? 8B F8 39 BB ?? ?? ?? ?? 74 58 44 8B C7 BA ?? ?? ?? ?? 49 8B CF")]
    public partial uint GetFreeCompanyGil();

    [MemberFunction("E8 ?? ?? ?? ?? 3B C3 73 25")]
    public partial uint GetGoldSaucerCoin();

    [MemberFunction("E9 ?? ?? ?? ?? 8B CB E8 ?? ?? ?? ?? 84 C0 74 16")]
    public partial uint GetWolfMarks();

    [MemberFunction("E9 ?? ?? ?? ?? 83 FB 1D 75 16")]
    public partial uint GetAlliedSeals();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 4E 6C")]
    public partial uint GetCompanySeals(byte grandcompanyId);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 4C 24 48 03 CF")]
    public partial uint GetMaxCompanySeals(byte grandcompanyId);

    [MemberFunction("E8 ?? ?? ?? ?? 03 C7 EB 19")]
    public partial uint GetTomestoneCount(uint tomestoneItemId);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? 8B D8 E8 ?? ?? ?? ?? 42 8D 0C 3B")]
    private partial int GetLimitedTomestoneCount(int a1);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 4F DD")]
    private static partial int GetSpecialItemId(byte switchCase);

    /// <summary>  Gets the current maximum weekly number of limited tomestones tha player can earn. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? 8B D8 E8 ?? ?? ?? ?? 42 8D 0C 3B")]
    public static partial int GetLimitedTomestoneWeeklyLimit();

    /// <summary> Gets the number of (limited) tomestones the user has acquired during the current reset cycle. </summary>
    public int GetWeeklyAcquiredTomestoneCount() => GetLimitedTomestoneCount(GetSpecialItemId(9));
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct InventoryContainer {
    [FieldOffset(0x00)] public InventoryItem* Items;
    [FieldOffset(0x08)] public InventoryType Type;
    [FieldOffset(0x0C)] public uint Size;
    [FieldOffset(0x10)] public byte Loaded;

    [MemberFunction("E8 ?? ?? ?? ?? 8B 7B 06")]
    public partial InventoryItem* GetInventorySlot(int index);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct InventoryItem : ICreatable {
    [FieldOffset(0x00)] public InventoryType Container;
    [FieldOffset(0x04)] public short Slot;
    /// <summary>
    /// Indicates whether this InventoryItem is symbolic, serving as a link to another InventoryItem<br/>
    /// identified by <see cref="LinkedItemSlot"/> and <see cref="LinkedInventoryType"/>.
    /// </summary>
    [FieldOffset(0x06)] public bool IsSymbolic;
    /// <remarks> Only used if <see cref="IsSymbolic"/> is <c>false</c>. </remarks>
    [FieldOffset(0x08), CExporterUnion("Id")] public uint ItemId;
    /// <remarks> Only used if <see cref="IsSymbolic"/> is <c>true</c>. </remarks>
    [FieldOffset(0x08), CExporterUnion("Id", "Linked", true)] public ushort LinkedItemSlot;
    /// <remarks> Only used if <see cref="IsSymbolic"/> is <c>true</c>. </remarks>
    [FieldOffset(0x0A), CExporterUnion("Id", "Linked", true)] public ushort LinkedInventoryType;
    [FieldOffset(0x0C)] public uint Quantity;
    [FieldOffset(0x10)] public ushort Spiritbond; // TODO: This field is also used for the collectability value. Not sure if it's the same data type. See also: GetSpiritbond()
    [FieldOffset(0x12)] public ushort Condition;
    [FieldOffset(0x14)] public ItemFlags Flags;
    [FieldOffset(0x18)] public ulong CrafterContentId;
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray5<ushort> _materia;
    [FieldOffset(0x2A), FixedSizeArray] internal FixedSizeArray5<byte> _materiaGrades;
    [FieldOffset(0x2F)] public byte Stain;
    [FieldOffset(0x30)] public uint GlamourId;

    [Flags]
    public enum ItemFlags : byte {
        None = 0,
        HighQuality = 1,
        CompanyCrestApplied = 2,
        Relic = 4,
        Collectable = 8
    }

    [MemberFunction("33 D2 C7 01 ?? ?? ?? ?? 33 C0")]
    public partial void Ctor();

    [MemberFunction("8B 42 08 4C 8B C9 39 41 08")]
    public partial bool EqualTo(InventoryItem* other);

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
    [MemberFunction("E8 ?? ?? ?? ?? 80 78 06 00 75 F2")]
    public partial InventoryItem* GetLinkedItem();

    /// <summary>Gets the item id from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 89 45 8B")]
    public partial uint GetItemId();

    /// <summary>Gets the quantity from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 2B C6 89 43 0C")]
    public partial uint GetQuantity();

    /// <summary>Gets the spiritbond value from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 66 89 47 0C")]
    public partial ushort GetSpiritbond();

    /// <summary>Gets the condition from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 66 89 47 0C")]
    public partial ushort GetCondition();

    /// <summary>Gets the crafter's content id from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D8 EB 04")]
    public partial ulong GetCrafterContentId();

    /// <summary>Gets the stain from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("0F B6 41 7D 4C 8B CA")]
    public partial byte GetStain();

    /// <summary>Gets the glamour id from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 80 78 06 00 75 F2")]
    public partial uint GetGlamourId();

    /// <summary>Gets the materia id from the specified slot of the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? EB 10 32 C0")]
    public partial ushort GetMateriaId(byte materiaSlot);

    /// <summary>Gets the materia grade from the specified slot of the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E9 ?? ?? ?? ?? 0F B6 44 1F ??")]
    public partial byte GetMateriaGrade(byte materiaSlot);

    /// <summary>Gets the materia count from the original InventoryItem or itself if not symbolic.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? F6 47 14 01")]
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
