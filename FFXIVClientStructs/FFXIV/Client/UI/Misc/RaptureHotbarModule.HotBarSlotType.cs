namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

public enum HotbarSlotType : byte {
    Empty = 0x00,
    Action = 0x01,
    Item = 0x02,

    EventItem = 0x04,

    Emote = 0x06,
    Macro = 0x07,
    Marker = 0x08,
    CraftAction = 0x09,
    GeneralAction = 0x0A,
    BuddyAction = 0x0B,
    MainCommand = 0x0C,
    Companion = 0x0D,

    GearSet = 0x0F,
    PetAction = 0x10,
    Mount = 0x11,
    FieldMarker = 0x12,

    Recipe = 0x14,
    ChocoboRaceAbility = 0x15,
    ChocoboRaceItem = 0x16,
    Unk_0x17 = 0x17, // seems to be a legacy type, possibly PvP related based on associated icon 000785
    ExtraCommand = 0x18,
    PvPQuickChat = 0x19,
    PvPCombo = 0x1A,
    BgcArmyAction = 0x1B,
    Unk_0x1C = 0x1C, // seems to be a legacy type, possibly performance instrument related based on associated icon 000782
    PerformanceInstrument = 0x1D,
    [Obsolete("Use McGuffin instead")] Collection = 0x1E,
    McGuffin = 0x1E,
    Ornament = 0x1F,
    LostFindsItem = 0x20
}
