using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentContentsFinder
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ContentsFinder)]
[StructLayout(LayoutKind.Explicit, Size = 0x20E8)]
[GenerateInterop]
[Inherits<AgentInterface>]
public unsafe partial struct AgentContentsFinder {

    [FieldOffset(0x38)] public Utf8String Description;

    // TODO split into 3 separate arrays, (8F0, EE0, 14D0), each with 5 entries, 8F0 seems to be the top row of rewards while 14D0 is the bottom row, EE0 is unknown
    [FieldOffset(0x8F0)][FixedSizeArray] internal FixedSizeArray15<ItemReward> _itemRewardArray;

    [FieldOffset(0x1B6C)] public int SelectedDutyId; // ContentFinderCondition rowId for duties, ContentRoulette rowId for roulette
    [FieldOffset(0x1B78)] public byte NumCollectedRewards; // Value used for "Reward already received"

    [FieldOffset(0x1BC8)][FixedSizeArray] internal FixedSizeArray10<Utf8String> _strings; // Tooltips and Category headers, ie "Gil", "Trials (Endwalker)"

    [FieldOffset(0x2007)][FixedSizeArray] internal FixedSizeArray11<ContentsRouletteRole> _contentRouletteRoleBonus;

    [FieldOffset(0x2034)] public uint DutyPenaltyMinutes;
    [FieldOffset(0x2038)] public uint UnkPenaltyMinutes;

    [FieldOffset(0x206C)] public int CurrentTimestamp;
    [FieldOffset(0x2078)] public byte SelectedTab;

    [MemberFunction("48 89 6C 24 ?? 48 89 74 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 8B F9 41 0F B6 E8")]
    public partial void* OpenRegularDuty(uint contentsFinderCondition, byte a2 = 0);

    [MemberFunction("E9 ?? ?? ?? ?? 8B 93 ?? ?? ?? ?? 48 83 C4 20")]
    public partial void* OpenRouletteDuty(byte roulette, byte a2 = 0);
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

[StructLayout(LayoutKind.Explicit, Size = 0x130)]
public struct ItemReward {
    [FieldOffset(0x04)] public uint ItemId;
    [FieldOffset(0x08)] public int Quantity; // -1 seems to be arrow up
    [FieldOffset(0x10)] public uint IconId;
    [FieldOffset(0x18)] public Utf8String TooltipString;
    [FieldOffset(0x88)] public Utf8String UnkString; // This string seems to be unused?
}

public enum ContentsRouletteRole : byte {
    Tank = 0,
    Healer = 1,
    Dps = 2,
    None = 3,
}
