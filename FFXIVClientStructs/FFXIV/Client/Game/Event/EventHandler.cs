using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Arrays;
using FFXIVClientStructs.FFXIV.Common.Lua;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::EventHandler
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x218)]
public unsafe partial struct EventHandler {
    [FieldOffset(0x08)] public StdSet<Pointer<GameObject>> EventObjects;
    [FieldOffset(0x18)] public EventSceneModuleUsualImpl* EventSceneModule;
    [FieldOffset(0x20)] public EventHandlerInfo Info;
    [FieldOffset(0x5C)] public uint IconId;

    [FieldOffset(0x78)] public short Scene;

    [FieldOffset(0x94)] public LuaStatus LuaStatus;

    [FieldOffset(0xC8)] public Utf8String UnkString0;
    [FieldOffset(0x168)] public Utf8String UnkString1;

    [VirtualFunction(154)]
    public partial void CancelInteraction();

    [VirtualFunction(200)]
    public partial void GetTitle(Utf8String* outTitle);

    [VirtualFunction(202)]
    public partial EventId GetEventId();

    [VirtualFunction(204)]
    public partial uint GetNameplateIconForObject(GameObject* gameObject);

    [VirtualFunction(253)]
    public partial void GetDescription(Utf8String* outDescription);

    [VirtualFunction(254)]
    public partial void GetReliefText(Utf8String* outReliefText);

    [VirtualFunction(255)]
    public partial int GetTimeRemaining(int currentTimestamp);

    [VirtualFunction(256)]
    public partial bool HasTimer();

    [VirtualFunction(258)]
    public partial uint GetEventItemId();

    [VirtualFunction(261), Obsolete($"Renamed to {nameof(GetDirectorTodos)}")]
    public partial StdVector<EventHandlerObjective>* GetObjectives();

    [VirtualFunction(261)]
    public partial StdVector<DirectorTodo>* GetDirectorTodos();

    [VirtualFunction(262)]
    public partial StdVector<MassivePcContentTodo>* GetMassivePcContentTodos(int setIndex);

    [VirtualFunction(265)]
    public partial int GetRecommendedLevel();
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public struct EventHandlerInfo {
    [FieldOffset(0x00)] public EventId EventId;
    [FieldOffset(0x04)] public byte Flags;
}

// TODO: remove (was renamed/replaced with DirectorTodo)
[StructLayout(LayoutKind.Explicit, Size = 0x160)]
public struct EventHandlerObjective {
    [FieldOffset(0x00)] public bool Enabled;

    [FieldOffset(0x04)] public int DisplayType;
    [FieldOffset(0x08)] public Utf8String Label;

    [FieldOffset(0x78)] public int CountCurrent;
    [FieldOffset(0x7C)] public int CountNeeded;
    [FieldOffset(0x80)] public ulong TimeLeft;
    [FieldOffset(0x88)] public uint MapRowId;
}

[StructLayout(LayoutKind.Explicit, Size = 0x160)]
public struct DirectorTodo {
    [FieldOffset(0x00)] public bool Enabled;

    [FieldOffset(0x04)] public TodoType Type;
    [FieldOffset(0x08)] public Utf8String Text;
    [FieldOffset(0x70)] public bool Complete;
    [FieldOffset(0x71)] public bool CheckOnCompletion; // also grays out the line

    /// <remarks> Unix timestamp. </remarks>
    [FieldOffset(0x78), CExporterIgnore] public long StartTimestamp;
    [FieldOffset(0x78), CExporterIgnore] public TodoJoinButtonType JoinButtonType;
    [FieldOffset(0x78)] public int CurrentCount;
    [FieldOffset(0x78), CExporterIgnore] public int CurrentPercentage;
    [FieldOffset(0x78), CExporterIgnore] public int IconId;
    [FieldOffset(0x7C), CExporterIgnore] public TodoBarColor BarColor;
    [FieldOffset(0x7C)] public int NeededCount;
    [FieldOffset(0x7C), CExporterIgnore] public int NeededPercentage;
    /// <remarks> Unix timestamp. </remarks>
    [FieldOffset(0x80)] public long EndTimestamp;
    /// <remarks> In seconds. </remarks>
    [FieldOffset(0x88)] public long Duration;
    [FieldOffset(0x88), CExporterIgnore] public uint MapRowId; // unsure where this is used that way. copied from old EventHandlerObjective struct
}

[StructLayout(LayoutKind.Explicit, Size = 0x168)]
public struct MassivePcContentTodo {
    [FieldOffset(0x00)] public bool Enabled;

    [FieldOffset(0x04)] public TodoType Type;
    [FieldOffset(0x08)] public Utf8String Text;
    [FieldOffset(0x70)] public bool Complete;
    [FieldOffset(0x71)] public bool CheckOnCompletion; // also grays out the line

    /// <remarks> Unix timestamp. </remarks>
    [FieldOffset(0x78), CExporterIgnore] public long StartTimestamp;
    [FieldOffset(0x78), CExporterIgnore] public TodoJoinButtonType JoinButtonType;
    [FieldOffset(0x78)] public int CurrentCount;
    [FieldOffset(0x78), CExporterIgnore] public int CurrentPercentage;
    [FieldOffset(0x78), CExporterIgnore] public int IconId;
    [FieldOffset(0x7C), CExporterIgnore] public TodoBarColor BarColor;
    [FieldOffset(0x7C)] public int NeededCount;
    [FieldOffset(0x7C), CExporterIgnore] public int NeededPercentage;
    /// <remarks> Unix timestamp. </remarks>
    [FieldOffset(0x80)] public long EndTimestamp;
    /// <remarks> In seconds. </remarks>
    [FieldOffset(0x88)] public long Duration;

    [FieldOffset(0x160)] public ulong Unk160;
}

/// <remarks>
/// Director only supports types up to 11.<br/>
/// FateDirector only supports types 0-6 and 11.<br/>
/// MassivePcContentDirector supports all 16 types.<br/>
/// DynamicEvent supports types 1, 5, 6, 8.<br/>
/// QuestTodoList supports ??.<br/>
/// <br/>
/// See also <see cref="ToDoListNumberArray.ObjectiveType"/> (same thing, different values).
/// </remarks>
public enum TodoType {
    /// <summary>
    /// Text.<br/>
    /// <br/>
    /// Available settings:<br/>
    /// - Text<br/>
    /// - Complete
    /// </summary>
    Text = 0, // ObjectiveType 0

    /// <summary>
    /// Text with current/needed count and a progress bar.<br/>
    /// <br/>
    /// Available settings:<br/>
    /// - Text<br/>
    /// - Complete<br/>
    /// - CheckOnCompletion<br/>
    /// - CurrentCount<br/>
    /// - NeededCount<br/>
    /// <br/>
    /// Formatted with Addon#1146 (lnum1 = CurrentCount, lnum2 = NeededCount, lstr3 = Text).<br/>
    /// </summary>
    FractionBar = 1, // ObjectiveType 4, in Lua "TODO_TYPE_FRACTION_BAR"

    /// <summary>
    /// Text with count.<br/>
    /// <br/>
    /// Available settings:<br/>
    /// - Text<br/>
    /// - Complete<br/>
    /// - CurrentCount<br/>
    /// <br/>
    /// Formatted with Addon#1147 (lnum1 = CurrentCount, lnum2 = 0, lstr3 = Text).
    /// </summary>
    Number = 2, // ObjectiveType 1, in Lua "TODO_TYPE_NUMBER"

    /// <summary>
    /// Text and a progress bar.<br/>
    /// <br/>
    /// Available settings:<br/>
    /// - Text<br/>
    /// - Complete<br/>
    /// - CurrentPercentage
    /// </summary>
    Bar = 3, // ObjectiveType 3, in Lua "TODO_TYPE_BAR"

    /// <summary>
    /// Text and timer.<br/>
    /// <br/>
    /// Available settings:<br/>
    /// - Text<br/>
    /// - Complete<br/>
    /// - EndTimestamp<br/>
    /// <br/>
    /// Formatted with Addon#33 (via RaptureTextModule.FormatSecondsRemaining).
    /// </summary>
    TimeRemaining = 4, // ObjectiveType 5, in Lua "TODO_TYPE_TIME_REMAINING"

    /// <summary>
    /// Progress Bar.<br/>
    /// <br/>
    /// Available settings:<br/>
    /// - CurrentPercentage<br/>
    /// - NeededPercentage<br/>
    /// <br/>
    /// When current value &lt;= minimum value, then the progress bar is red, otherwise yellow.
    /// </summary>
    LargeBar = 5, // ObjectiveType 9, in Lua "TODO_TYPE_LARGE_BAR"

    /// <summary>
    /// Text with current/needed count.<br/>
    /// <br/>
    /// Available settings:<br/>
    /// - Text<br/>
    /// - Complete<br/>
    /// - CheckOnCompletion<br/>
    /// - CurrentCount<br/>
    /// - NeededCount<br/>
    /// <br/>
    /// Formatted with Addon#1146 (lnum1 = CurrentCount, lnum2 = NeededCount, lstr3 = Text).
    /// </summary>
    Fraction = 6, // ObjectiveType 2, in Lua "TODO_TYPE_FRACTION"

    /// <summary>
    /// Colorable Progress Bar.<br/>
    /// <br/>
    /// Available settings:<br/>
    /// - CurrentPercentage<br/>
    /// - BarColor<br/>
    /// </summary>
    ColorableBar = 7, // ObjectiveType 10

    /// <summary>
    /// Large gray text.<br/>
    /// <br/>
    /// Available settings:<br/>
    /// - Text
    /// </summary>
    LargeGrayText = 8, // ObjectiveType 6

    /// <summary>
    /// Large gray text with count.<br/>
    /// <br/>
    /// Available settings:<br/>
    /// - Text<br/>
    /// - CurrentCount<br/>
    /// <br/>
    /// Formatted with Addon#1147 (lnum1 = CurrentCount, lnum2 = 0, lstr3 = Text).
    /// </summary>
    LargeGrayNumber = 9, // ObjectiveType 7

    /// <summary>
    /// Large gray text with current/needed count.<br/>
    /// <br/>
    /// Available settings:<br/>
    /// - Text<br/>
    /// - CurrentCount<br/>
    /// - NeededCount<br/>
    /// <br/>
    /// Formatted with Addon#1146 (lnum1 = CurrentCount, lnum2 = NeededCount, lstr3 = Text).
    /// </summary>
    LargeGrayFraction = 10, // ObjectiveType 8

    /// <summary>
    /// Text with long progress bar.<br/>
    /// <br/>
    /// Available settings:<br/>
    /// - Text<br/>
    /// - Complete<br/>
    /// - CurrentPercentage
    /// </summary>
    LongBar = 11, // ObjectiveType 15

    /// <summary>
    /// Quest title.<br/>
    /// <br/>
    /// Available settings:<br/>
    /// - Text<br/>
    /// - IconId
    /// </summary>
    QuestTitle = 12, // ObjectiveType 11

    /// <summary>
    /// Large timer.<br/>
    /// <br/>
    /// Available settings:<br/>
    /// - Text (not really. needs lots of spaces after if used)<br/>
    /// - EndTimestamp<br/>
    /// - Duration
    /// </summary>
    LargeTimeRemaining = 13, // ObjectiveType 13

    /// <summary>
    /// Large blue text.<br/>
    /// <br/>
    /// Available settings:<br/>
    /// - Text
    /// </summary>
    LargeBlueText = 14, // ObjectiveType 12

    /// <summary>
    /// Join button.<br/>
    /// <br/>
    /// Available settings:<br/>
    /// - JoinButtonType
    /// </summary>
    JoinButton = 15, // ObjectiveType 14
}

public enum TodoBarColor {
    Blue = 0,
    Red = 1,
    Yellow = 2,
    White = 3,
    Green = 4
}

public enum TodoJoinButtonType : byte {
    Joinable = 0,
    Joined = 1,
}

[StructLayout(LayoutKind.Explicit, Size = 0x04)]
public struct EventId : IEquatable<EventId>, IComparable<EventId> {
    [FieldOffset(0x00), CExporterIgnore] public uint Id;
    [FieldOffset(0x00)] public ushort EntryId;
    [FieldOffset(0x02)] public EventHandlerContent ContentId;
    public static implicit operator uint(EventId id) => id.Id;
    public static implicit operator EventId(uint id) => new() { Id = id };

    public bool Equals(EventId other) => Id == other.Id;
    public override bool Equals(object? obj) => obj is EventId other && Equals(other);
    public override int GetHashCode() => Id.GetHashCode();
    public static bool operator ==(EventId left, EventId right) => left.Id == right.Id;
    public static bool operator !=(EventId left, EventId right) => left.Id != right.Id;
    public int CompareTo(EventId other) => Id.CompareTo(other);
}

public enum EventHandlerContent : ushort {
    Quest = 0x0001,
    Warp = 0x0002,
    GatheringPoint = 0x0003,
    Shop = 0x0004,
    Aetheryte = 0x0005,
    GuildLeveAssignment = 0x0006,
    DefaultTalk = 0x0009,
    Craft = 0x000A,
    CustomTalk = 0x000B,
    CompanyLeveOfficer = 0x000C,
    Array = 0x000D,
    CraftLeveClient = 0x000E,
    GimmickAccessor = 0x000F,
    GimmickBill = 0x0010,
    GimmickRect = 0x0011,
    ChocoboTaxiStand = 0x0012,
    Opening = 0x0013,
    ExitRange = 0x0014,
    Fishing = 0x0015,
    GrandCompanyShop = 0x0016,
    GuildOrderGuide = 0x0017,
    GuildOrderOfficer = 0x0018,
    ContentNpc = 0x0019,
    Story = 0x001A,
    SpecialShop = 0x001B,
    DeepDungeon = 0x001C,
    InstanceContentGuide = 0x001D,
    HousingAethernet = 0x001E,
    FcTalk = 0x001F,
    MobHunt = 0x0020,
    Adventure = 0x0021,
    DailyQuestSupply = 0x0022,
    TripleTriad = 0x0023,
    GoldSaucerArcadeMachine = 0x0024,
    LotteryDaily = 0x0025, // Mini Cactpot
    LotteryWeekly = 0x0026, // Jumbo Cactpot
    RaceChocoboRegistrar = 0x0027,

    GoldSaucerTalk = 0x0029, // Q'nabyano (responding with GoldSaucerTalk#162) and Reymanaud (responding with GoldSaucerTalk#161) use this
    FreeCompanyCreditShop = 0x002A,
    AetherCurrent = 0x002B,
    ContentEntry = 0x002C,
    Verminion = 0x002D, // Verminion Tables and Tournament Recordkeeper
    SkyIslandEntrance = 0x002E,
    DpsChallengeOfficer = 0x002F, // Stone, Sky, Sea
    BeginnerTrainingOfficer = 0x0030,
    RetainerBuyback = 0x0031,
    TopicSelect = 0x0032,
    LotteryExchangeShop = 0x0034,
    DisposalShop = 0x0035,
    PreHandler = 0x0036, // checks quest completion before handling something, for example opening the Scrip Exchange
    TripleTriadCompetition = 0x0037,
    HwdDev = 0x0038, // Ishgardian Restoration (Firmament / Heavensward Development?!)
    Materialize = 0x0039, // Desynthesis (0x390000), Materia Extraction (0x390001), Aetherial Reduction (0x390002)
    InclusionShop = 0x003A,
    CollectablesShop = 0x003B,
    MJIPasture = 0x003C, // Island Sanctuary Pasture
    EventPathMove = 0x003D, // Argos in Mare Lamentorum uses this
    ReactionEvent = 0x003E, // Island Sanctuary Cropland, see ReactionEventObject

    BattleLeveDirector = 0x8001,
    GatheringLeveDirector = 0x8002,
    InstanceContentDirector = 0x8003,
    PublicContentDirector = 0x8004,
    QuestBattleDirector = 0x8006,
    CompanyLeveDirector = 0x8007,
    TreasureHuntDirector = 0x8009,
    GoldSaucerDirector = 0x800A,
    CompanyCraftDirector = 0x800B,
    SkyIslandDirector = 0x800C, // used in early phases of the Diadem
    DpsChallengeDirector = 0x800D,
    MassivePcContentDirector = 0x800E,
    FateDirector = 0x801A
}

public enum MaterializeEntryId : ushort {
    Desynth = 0x0000,
    Retrieve = 0x0001, // Materia Retrieval
    Purify = 0x0002, // Aetherial Reduction
}
