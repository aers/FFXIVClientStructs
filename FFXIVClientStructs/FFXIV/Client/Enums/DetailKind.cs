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
    MiragePrismPlateItem = 15, // used by MiragePrismPrismPlate with item id
    MiragePrismBoxItemSetPreview = 16, // used by MiragePrismBoxItemSetConvert with item id
    MiragePrismBoxItem = 17, // used by MiragePrismPrismItemDetail with index in MirageManager.PrismBoxItemIds
    MateriaAttach = 18,
    ReconstructionBuyback = 19,
    MerchantSetting = 20,
    MJIItemPouch = 21,
    MJIKeyItem = 22,
    MJICraftworksObject = 23,
    Cabinet = 24,
    TradeRemote = 25,
    HandIn = 26,
    RepairRequest = 27,
    LetterView = 28,

    // ActionDetail
    Action = 30,
    CraftingAction = 31,
    GeneralAction = 32,
    BuddyOrder = 33,
    MainCommand = 34,
    ExtraCommand = 35,
    Companion = 36,
    PetOrder = 37,
    Trait = 38,
    BuddyAction = 39,
    CompanyAction = 40,
    Mount = 41,
    ChocoboRaceAction = 42,
    ChocoboRaceItem = 43,
    DeepDungeonEquipment = 44,
    DeepDungeonEquipment2 = 45,
    DeepDungeonItem = 46,
    QuickChat = 47,
    ActionComboRoute = 48,
    PvPSelectTrait = 49,
    BgcArmyAction = 50,
    Perform = 51,
    DeepDungeonMagicStone = 52,
    DeepDungeonDemiclone = 53,
    DeepDungeon4GimmickEffect = 54,
    EurekaMagiaAction = 55,
    MYCTemporaryItem = 56,
    Ornament = 57,
    Glasses = 58,
    PhantomAction = 59,
    MKDTrait = 60,
    Unk60 = 61,
}
