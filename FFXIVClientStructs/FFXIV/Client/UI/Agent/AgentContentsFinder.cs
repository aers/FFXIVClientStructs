using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentContentsFinder
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ContentsFinder)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x2228)]
public unsafe partial struct AgentContentsFinder {

    [FieldOffset(0x38)] public Utf8String Description;

    [FieldOffset(0x264), FixedSizeArray] internal FixedSizeArray8<int> _rewardsQuantity;
    [FieldOffset(0x99C), FixedSizeArray] internal FixedSizeArray8<int> _rewardsQuantityDup;

    [FieldOffset(0xF38), FixedSizeArray] internal FixedSizeArray5<ItemReward> _upperRewards;
    [FieldOffset(0x1800)] public byte HasInNeedGilReward;
    [FieldOffset(0x1804)] public uint InNeedGilQuantity;
    [FieldOffset(0x1838), FixedSizeArray] internal FixedSizeArray5<ItemReward> _lowerRewards;

    [FieldOffset(0x1CA4)] public int SelectedDutyId; // ContentFinderCondition rowId for duties, ContentRoulette rowId for roulette
    [FieldOffset(0x1CB0)] public byte NumCollectedRewards; // Value used for "Reward already received"
    [FieldOffset(0x1CB1)] public byte HasRouletteSelected; // Prevents more roulettes from being selected


    [FieldOffset(0x1CF0)] public UIModule* UIModule;

    [FieldOffset(0x1D00), FixedSizeArray] internal FixedSizeArray10<Utf8String> _strings; // Tooltips and Category headers, ie "Gil", "Trials (Endwalker)"

    [FieldOffset(0x2169), FixedSizeArray] internal FixedSizeArray11<ContentsRouletteRole> _contentRouletteRoleBonuses;

    [FieldOffset(0x2174)] public uint DutyPenaltyMinutes;
    [FieldOffset(0x2178)] public uint UnkPenaltyMinutes;

    [FieldOffset(0x21AC)] public int CurrentTimestamp;
    [FieldOffset(0x21B8)] public byte SelectedTab;


    [MemberFunction("48 89 6C 24 ?? 48 89 74 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 8B F9 41 0F B6 E8")]
    public partial void OpenRegularDuty(uint contentsFinderCondition, bool hideIfShown = false);

    [MemberFunction("E9 ?? ?? ?? ?? 8B 93 ?? ?? ?? ?? 48 83 C4 20")]
    public partial void OpenRouletteDuty(byte roulette, bool hideIfShown = false);
}

// TODO: remove unused struct?
[StructLayout(LayoutKind.Explicit, Size = 0x20), CExporterStructUnion]
public struct ContentsFinderRewards {
    [FieldOffset(0x00)] public int ExpReward;
    [FieldOffset(0x00)] public int GilReward;
    [FieldOffset(0x00)] public int SealReward;
    [FieldOffset(0x00)] public int PoeticReward;
    [FieldOffset(0x00)] public int NonLimitedTomestoneReward;
    [FieldOffset(0x00)] public int LimitedTomestoneRward;
    [FieldOffset(0x00)] public int PvPExpReward;
    [FieldOffset(0x00)] public int WolfMarkReward;
}

[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public struct ItemReward {
    [FieldOffset(0x00)] public uint IsValid; // 0x0 not valid, 0x2 valid
    [FieldOffset(0x04)] public uint ItemId;
    [FieldOffset(0x08)] public int Quantity;
    [FieldOffset(0x0C)] public uint IconId;
    [FieldOffset(0x10)] public Utf8String TooltipString;
}

public enum ContentsRouletteRole : byte {
    Tank = 0,
    Healer = 1,
    Dps = 2,
    None = 3,
}
