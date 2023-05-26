﻿using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentContentsFinder
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ContentsFinder)]
[StructLayout(LayoutKind.Explicit, Size = 0x2088)]
public unsafe partial struct AgentContentsFinder
{
    public static AgentContentsFinder* Instance() => (AgentContentsFinder*)AgentModule.Instance()->GetAgentByInternalId(AgentId.ContentsFinder);

    [FieldOffset(0x0)] public AgentInterface AgentInterface;

    [FieldOffset(0x86)] public byte* DescriptionString; // null-terminated cstring representing the currently displayed duty description
    
    [FieldOffset(0x1B8)] public ContentsFinderRewards Reward;
    [FieldOffset(0x408)] public ContentsFinderRewards BonusReward;
    
    // These seem to be duplicates of the above reward structs
    [FieldOffset(0x5C8)] public ContentsFinderRewards Reward2;
    [FieldOffset(0x810)] public ContentsFinderRewards BonusReward2;

    [FixedSizeArray<ItemReward>(35)] 
    [FieldOffset(0x890)] public fixed byte ItemRewardArray[0x130 * 35];
    
    [FieldOffset(0x1B6C)] public int SelectedDutyId; // ContentFinderCondition rowId for duties, ContentRoulette rowId for roulette
    [FieldOffset(0x1B78)] public byte NumCollectedRewards; // Value used for "Reward already received"

    [FixedSizeArray<Utf8String>(10)] 
    [FieldOffset(0x1BC8)] public fixed byte Strings[0x68 * 10]; // Tooltips and Category headers, ie "Gil", "Trials (Endwalker)"

    [FixedSizeArray<ContentsRouletteRole>(11)]
    [FieldOffset(0x2007)] public fixed byte ContentRouletteRoleBonus[11];
    
    [FieldOffset(0x2014)] public uint DutyPenaltyMinutes;
    [FieldOffset(0x2018)] public uint UnkPenaltyMinutes;

    [FieldOffset(0x204C)] public int CurrentTimestamp;
    [FieldOffset(0x2058)] public byte SelectedTab;

    [MemberFunction("48 89 6C 24 ?? 48 89 74 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 8B F9 41 0F B6 E8")]
    public partial void* OpenRegularDuty(uint contentsFinderCondition, byte a2 = 0);

    [MemberFunction("E9 ?? ?? ?? ?? 8B 93 ?? ?? ?? ?? 48 83 C4 20")]
    public partial void* OpenRouletteDuty(byte roulette, byte a2 = 0);
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct ContentsFinderRewards
{
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
public struct ItemReward
{
    [FieldOffset(0x44)] public int ItemId;
    [FieldOffset(0x48)] public int Quantity;
    [FieldOffset(0x58)] public Utf8String TooltipString;
    [FieldOffset(0x78)] public Utf8String UnkString; // This string seems to be unused?
}

public enum ContentsRouletteRole : byte {
    Tank = 0,
    Healer = 1,
    DPS = 2,
    None = 3,
}
