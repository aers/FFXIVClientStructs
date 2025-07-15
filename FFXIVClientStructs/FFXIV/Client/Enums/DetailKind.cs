namespace FFXIVClientStructs.FFXIV.Client.Enums;

public enum DetailKind : byte {
    None = 0,

    // ItemDetail
    Item = 1, // items in chat (except KeyItems), on the action bar, in some shops...
    InventoryItem = 2,
    ItemSearchResult = 3,
    Loot = 4,
    ShopBuyback = 5,
    ShopItem = 6, // most shops use this, exceptions are grand company and sundry splendors
    Reclaim = 7,
    KeyItem = 8,
    GearSet = 9,
    FreeCompanyChest = 10,
    ItemId = 11,
    InventoryContext = 12,
    ItemInspection = 13,
    TreasureHighLow = 14,
    MiragePrismItem = 15, // used by MiragePrismPrismItemDetail with item id
    MiragePrismBoxItem = 16, // used by MiragePrismPrismItemDetail with index in MirageManager.PrismBoxItemIds
    MateriaAttach = 17,
    ReconstructionBuyback = 18,
    MerchantSetting = 19,
    MJIItemPouch = 20,
    MJIKeyItem = 21,
    MJICraftworksObject = 22,
    Cabinet = 23,
    TradeRemote = 24,
    HandIn = 25,
    RepairRequest = 26,
    LetterView = 27,

    // ActionDetail
    /// Keep in sync with <see cref="UI.Agent.ActionKind"/>
    Action = 28,
    CraftingAction = 29,
    GeneralAction = 30,
    BuddyOrder = 31,
    MainCommand = 32,
    ExtraCommand = 33,
    Companion = 34,
    PetOrder = 35,
    Trait = 36,
    BuddyAction = 37,
    CompanyAction = 38,
    Mount = 39,
    ChocoboRaceAction = 40,
    ChocoboRaceItem = 41,
    DeepDungeonEquipment = 42,
    DeepDungeonEquipment2 = 43,
    DeepDungeonItem = 44,
    QuickChat = 45,
    ActionComboRoute = 46,
    PvPSelectTrait = 47,
    BgcArmyAction = 48,
    Perform = 49,
    DeepDungeonMagicStone = 50,
    DeepDungeonDemiclone = 51,
    EurekaMagiaAction = 52,
    MYCTemporaryItem = 53,
    Ornament = 54,
    Glasses = 55,
    Unk56 = 56,
    MKDTrait = 57,
    Unk58 = 58,
}
