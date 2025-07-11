using FFXIVClientStructs.FFXIV.Client.Game.UI;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::InventoryManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3730)]
public unsafe partial struct InventoryManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 81 C2", 3)]
    public static partial InventoryManager* Instance();

    [FieldOffset(0x1E08)] public InventoryContainer* Inventories;
    /// <remarks>
    /// Used to calculate the average item level of equipped items in various places,
    /// for example in the agents MiragePrismMiragePlate, Status or TryOn.<br/>
    /// Can be EquippedItems or RetainerEquippedItems.
    /// </remarks>
    [FieldOffset(0x1E10)] public InventoryType ItemLevelInventoryType;

    // Seems to be reused for FATE HandIns and Mail too??!
    [FieldOffset(0x1E18), FixedSizeArray] internal FixedSizeArray6<InventoryItem> _tradeItemsLocal; // 6th slot is Gil
    [FieldOffset(0x1FC8), FixedSizeArray] internal FixedSizeArray6<InventoryItem> _tradeItemsRemote; // 6th slot is Gil
    [FieldOffset(0x2178)] public uint TradeUnk2178;
    [FieldOffset(0x217C)] public TradeState TradeLocalState;
    [FieldOffset(0x2180)] public TradeState TradeRemoteState;
    [FieldOffset(0x2184), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _tradePartnerName;
    [FieldOffset(0x21A4)] public uint TradePartnerEntityId;
    [FieldOffset(0x21A8)] public bool TradeUnk21A8;
    [FieldOffset(0x21A9)] public bool TradeWarnIfMovedTooFar;
    [FieldOffset(0x21AB)] public bool TradeIsSyncPending;

    [FieldOffset(0x21B8), FixedSizeArray] internal FixedSizeArray20<ulong> _retainerMarketPrices;

    // Data here for Gearset Item check
    [FieldOffset(0x2400)] internal BannerData GearsetPortraitData;
    // Related to Addon#4385 "<head(<ennoun(Item,2,lnum1,1,1)>)> registered to this gear set could not be found in your Armoury Chest. Replace it with <ennoun(Item,1,lnum2,1,1)>?"
    [FieldOffset(0x2438)] internal int GearsetReplaceItemSelectYesNoAddonId;
    [FieldOffset(0x2440)] internal uint GearsetId;

    // Retainer item swap stuff?
    [FieldOffset(0x3620)] internal InventoryItem UnkInventoryItem0;
    [FieldOffset(0x3668)] internal InventoryItem UnkInventoryItem1;

    [MemberFunction("E8 ?? ?? ?? ?? 88 58 18")]
    public partial InventoryContainer* GetInventoryContainer(InventoryType inventoryType);

    [MemberFunction("E9 ?? ?? ?? ?? 33 C0 C3 0F B6 51 51")]
    public partial InventoryItem* GetInventorySlot(InventoryType inventoryType, int index);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 53 F1")]
    public partial int GetInventoryItemCount(uint itemId, bool isHq = false, bool checkEquipped = true, bool checkArmory = true, short minCollectability = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 8B F0 8D 4F FE")]
    public partial int GetItemCountInContainer(uint itemId, InventoryType inventoryType, bool isHq = false, short minCollectability = 0);

    [MemberFunction("E8 ?? ?? ?? ?? EB 7A 83 F8 04")]
    public partial int MoveItemSlot(InventoryType srcContainer, ushort srcSlot, InventoryType dstContainer, ushort dstSlot, byte unk = 0);

    [MemberFunction("40 55 53 56 57 41 55 41 57 48 8D 6C 24 ?? 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 45 ?? 8D B2")]
    public partial int SplitItem(InventoryType container, ushort slot, int quantity);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? 48 8B 11")]
    public partial int DiscardItem(InventoryType container, ushort slot);

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 7F 66")]
    private partial uint GetEquippedItemIdForSlot(int slotId);

    /// <summary>
    /// Get the number of gearsets the player is permitted to have/use.
    /// </summary>
    /// <returns>Returns the number of gearsets the player can use.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 C0 85 F6")]
    public partial byte GetPermittedGearsetCount();

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 74 39 48 8B 06")]
    public partial uint GetEmptySlotsInBag();

    [MemberFunction("E8 ?? ?? ?? ?? 3B 44 24 58")]
    public partial uint GetGil();

    [MemberFunction("E8 ?? ?? ?? ?? 8B F8 39 43 78")]
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

    [MemberFunction("E8 ?? ?? ?? ?? 8B CD 2B F0")]
    public partial uint GetTomestoneCount(uint tomestoneItemId);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? 8B D8 E8 ?? ?? ?? ?? 42 8D 0C 23")]
    private partial int GetLimitedTomestoneCount(int a1);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 4F DD")]
    private static partial int GetSpecialItemId(byte switchCase);

    /// <summary>  Gets the current maximum weekly number of limited tomestones tha player can earn. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 42 8D 0C 2B")]
    public static partial int GetLimitedTomestoneWeeklyLimit();

    [MemberFunction("E8 ?? ?? ?? ?? 48 0F AF C7 48 03 E8")]
    public partial ulong GetRetainerMarketPrice(short slot);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4B ?? 40 88 71")]
    public partial void SetRetainerMarketPrice(short slot, uint price);

    [MemberFunction("E8 ?? ?? ?? ?? 4A 8B B4 3D")]
    public partial void SetSlotBlocked(InventoryType type, short slot);

    [MemberFunction("E8 ?? ?? ?? ?? 39 6B 38")]
    public partial void SetSlotUnblocked(InventoryType type, short slot);

    /// <summary> Gets the number of (limited) tomestones the user has acquired during the current reset cycle. </summary>
    public int GetWeeklyAcquiredTomestoneCount() => GetLimitedTomestoneCount(GetSpecialItemId(9));
}

public enum TradeState {
    NotTrading = 1, // ?
    TradeRequestPending = 2,
    SelectingTradeGoods = 3,
    LockedIn = 4,
    WaitingForConfirmation = 5,
    Confirmed = 6
}
