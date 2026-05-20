using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentContentsFinderInterface
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x880)]
public unsafe partial struct AgentContentsFinderInterface {
    /// <remarks> Agent depends on where it's used, for example AgentContentsFinder or AgentRaidFinder. </remarks>
    [FieldOffset(0x00)] public AgentInterface* AgentInterface;
    [FieldOffset(0x08)] public ulong EventKind;
    [FieldOffset(0x10)] public Utf8String Description;
    [FieldOffset(0x78)] public RewardsContainer Rewards;
    [FieldOffset(0x840)] public ExcelSheet* InstanceContentSheet;
    [FieldOffset(0x848)] public ExcelSheet* ContentFinderConditionTransientSheet;
    [FieldOffset(0x850)] public ExcelSheet* InstanceContentRewardItemSheet;
    [FieldOffset(0x858)] public ExcelSheetWaiter* InstanceContentSheetWaiter;
    [FieldOffset(0x860)] public ExcelSheetWaiter* ContentFinderConditionTransientSheetWaiter;
    [FieldOffset(0x868)] public ExcelSheetWaiter* InstanceContentRewardItemSheetWaiter;
    /// <remarks> ContentFinderCondition RowId for duties, ContentRoulette RowId for roulette. </remarks>
    [FieldOffset(0x870)] public int SelectedDutyId;
    /// <remarks> Unsure what the values are, but the game counts all values that are not -1 in GetMaxReceivedRewardCount. </remarks>
    [FieldOffset(0x874), FixedSizeArray] internal FixedSizeArray4<sbyte> _unkMaxReceivedRewardValues;
    // these 3 bools handle whether the agents ReceiveEvent should be called
    [FieldOffset(0x878)] private bool Unk878;
    [FieldOffset(0x879)] private bool Unk879;
    [FieldOffset(0x87A)] private bool Unk87A;

    [FieldOffset(0x00), Obsolete("Use AgentInterface")] public AgentContentsFinder* AgentContentsFinder;
    [FieldOffset(0x858), Obsolete("Use InstanceContentSheetWaiter")] public nint ExcelSheetWaiterInstanceContent;
    [FieldOffset(0x860), Obsolete("Use ContentFinderConditionTransientSheetWaiter")] public nint ExcelSheetWaiterContentFinderConditionTransient;
    [FieldOffset(0x868), Obsolete("Use InstanceContentRewardItemSheetWaiter")] public nint ExcelSheetWaiterInstanceContentRewardItem;

    [MemberFunction("E8 ?? ?? ?? ?? 49 63 47 ?? 49 8D 4F")]
    public partial void SetAgent(AgentInterface* agent, ulong eventKind);

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 0F B6 52")]
    public partial bool LoadContentFinderCondition(byte rowId);

    [MemberFunction("E8 ?? ?? ?? ?? 49 63 47 ?? 49 8D 4F")]
    public partial bool LoadContentRoulette(byte rowId);

    [MemberFunction("E9 ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ?? 48 89 6C 24 ?? 33 ED")]
    public partial bool LoadInstanceContent(byte rowId);

    [MemberFunction("E9 ?? ?? ?? ?? 32 C0 48 81 C4")]
    public partial int GetReceivedRewardCount();

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 74 ?? 48 8D 4B ?? E8")]
    public partial int GetMaxReceivedRewardCount();

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x7C8)]
    public partial struct RewardsContainer {
        [FieldOffset(0x00)] public RewardsData ContentRewards;
        [FieldOffset(0x220), FixedSizeArray] internal FixedSizeArray5<InventoryItem> _items;
        [FieldOffset(0x388)] public RewardsData ContentRouletteRoleBonusRewards;
        [FieldOffset(0x5A8)] private RewardsData UnkItems3; // special thing for ContentRoulette#39 and item id 26535 - unreleased/cut content?!
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x220)]
    public partial struct RewardsData {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray7<InventoryItem> _items;
        /// <remarks> Formula: <c>ContentRouletteRoleBonus.BaseExperience * ParamGrow.ScaledQuestXP * ParamGrow.QuestExpModifier / 1000</c> </remarks>
        [FieldOffset(0x1F8)] public int Experience;
        /// <remarks> Formula: <c>InstanceContent.InstanceClearGil * ContentRouletteRoleBonus.GilMultiplier / 1000</c> </remarks>
        [FieldOffset(0x1FC)] public int Gil;
        /// <remarks> Formula: <c>CurrentLevel * ContentRouletteRoleBonus.GCSealsMultiplier / 1000</c> </remarks>
        [FieldOffset(0x200)] public int GrandCompanySeals;
        /// <remarks> Count for TomestonesItem where Tomestones == 1 </remarks>
        [FieldOffset(0x204)] public int CurrencyA;
        /// <remarks> Count for TomestonesItem where Tomestones == 2 </remarks>
        [FieldOffset(0x208)] public int CurrencyB;
        /// <remarks> Count for TomestonesItem where Tomestones == 3 </remarks>
        [FieldOffset(0x20C)] public int CurrencyC;
        [FieldOffset(0x210)] public int PvPExp;
        [FieldOffset(0x214)] public int SeriesExp;
        [FieldOffset(0x218)] public int WolfMarks;
        [FieldOffset(0x21C)] public bool LimitedTimeBonus;
    }
}
