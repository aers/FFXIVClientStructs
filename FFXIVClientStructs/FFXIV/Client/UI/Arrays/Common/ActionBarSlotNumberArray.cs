namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays.Common;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 17 * 4)]
public partial struct ActionBarSlotNumberArray {
    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray17<int> _data;

    [FieldOffset(0 * 4), Obsolete("Use ActionTypeEnum")] public int ActionType;
    [FieldOffset(0 * 4)] public ActionType ActionTypeEnum; // maybe rename to ActionType, once ActionType can be removed?

    [FieldOffset(1 * 4)] public int CostType;
    [FieldOffset(3 * 4)] public uint ActionId;
    [FieldOffset(4 * 4)] public uint IconId;
    [FieldOffset(5 * 4)] public bool Executable;
    [FieldOffset(6 * 4)] public bool Executable2;
    [FieldOffset(7 * 4)] public int MaxCharges;

    /// <summary>
    /// Range is 0 to 100
    /// </summary>
    [FieldOffset(8 * 4)] public int GlobalCoolDownPercentage;

    /// <summary>
    /// Range is 0 to 100
    /// </summary>
    [FieldOffset(9 * 4)] public int ChargesCooldownPercent;

    [FieldOffset(10 * 4)] public int RechargeTime;              // Same slot as ManaCost            (The game reuses this)
    [FieldOffset(10 * 4), CExporterIgnore] public int ManaCost; // Same slot as RechargeTime        (The game reuses this)

    [FieldOffset(12 * 4)] public bool DisplayDot;
    [FieldOffset(13 * 4)] public int CurrentCharges;
    [FieldOffset(14 * 4)] public bool Glows;
    [FieldOffset(15 * 4)] public bool Pulses;
    [FieldOffset(16 * 4)] public bool InRange;
}

// These values tend to shift up when new forays or jobs are added.
public enum ActionType {
    None = 0,

    Macro = 47,
    Action = 48,
    Emote = 49,
    Item = 50,
    InventoryItem = 51,
    EventItem = 52,
    KeyItem = 53,
    Crystal = 54,
    Marker = 55,
    CraftAction = 56,
    GeneralAction = 57,
    BuddyAction = 58,
    MainCommand = 59,
    Companion = 60,
    GearSet = 61,
    PetAction = 62,
    Mount = 63,
    FieldMarker = 64,
    Recipe = 65,
    ChocoboRaceAbility = 66,
    ChocoboRaceItem = 67,
    Unknown23 = 68,
    ExtraCommand = 69,
    PvPQuickChat = 70,
    PvPCombo = 71,
    BgcArmyAction = 72,
    Unknown28 = 73,
    PerformanceInstrument = 74,
    McGuffin = 75,
    Ornament = 76,
    LostFindsItem = 77,
    Glasses = 78,
    QuickPanel = 79,
    Unknown36 = 80, // XBM related (AgentXBMContentsMainHUD), maybe BeastMasterAction
}
