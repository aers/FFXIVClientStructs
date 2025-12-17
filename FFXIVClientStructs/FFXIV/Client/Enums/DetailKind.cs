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
    /// Keep in sync with <see cref="UI.Agent.ActionKind"/>
    Action = 29,
    CraftingAction = 30,
    GeneralAction = 31,
    BuddyOrder = 32,
    MainCommand = 33,
    ExtraCommand = 34,
    Companion = 35,
    PetOrder = 36,
    Trait = 37,
    BuddyAction = 38,
    CompanyAction = 39,
    Mount = 40,
    ChocoboRaceAction = 41,
    ChocoboRaceItem = 42,
    DeepDungeonEquipment = 43,
    DeepDungeonEquipment2 = 44,
    DeepDungeonItem = 45,
    QuickChat = 46,
    ActionComboRoute = 47,
    PvPSelectTrait = 48,
    BgcArmyAction = 49,
    Perform = 50,
    DeepDungeonMagicStone = 51,
    DeepDungeonDemiclone = 52,
    EurekaMagiaAction = 53,
    MYCTemporaryItem = 54,
    Ornament = 55,
    Glasses = 56,
    Unk57 = 57,
    MKDTrait = 58,
    Unk59 = 59,
}
