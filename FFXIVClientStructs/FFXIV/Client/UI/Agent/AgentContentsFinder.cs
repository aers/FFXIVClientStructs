using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentContentsFinder
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ContentsFinder)]
[StructLayout(LayoutKind.Explicit, Size = 0x2068)]
public unsafe partial struct AgentContentsFinder
{
    public static AgentContentsFinder* Instance() => (AgentContentsFinder*)AgentModule.Instance()->GetAgentByInternalId(AgentId.ContentsFinder);

    [FieldOffset(0x0)] public AgentInterface AgentInterface;

    [FieldOffset(0x86)] public byte* DescriptionString; // null-terminated cstring representing the currently displayed duty description

    // Reward values for the currently selected duty
    // Will be -1 or 0xFFFFFFFF if the UI displays an "up arrow" icon instead of a value
    [FieldOffset(0x1B8)] public int ExpReward;
    [FieldOffset(0x1BC)] public int GilReward;
    [FieldOffset(0x1C0)] public int SealReward;
    [FieldOffset(0x1C4)] public int PoeticReward;
    [FieldOffset(0x1C8)] public int NonLimitedTomestoneReward; // As of 6.3 this is Astronomy
    [FieldOffset(0x1CC)] public int LimitedTomestoneRward; // As of 6.3 this is Causality
    [FieldOffset(0x1D0)] public int PvPExpReward;
    [FieldOffset(0x1D4)] public int WolfMarkReward;

    [FieldOffset(0x1B4C)] public int SelectedDutyId; // ContentFinderCondition rowId for duties, ContentRoulette rowId for roulette
    [FieldOffset(0x1B58)] public byte NumCollectedRewards; // Value used for "Reward already received"

    [FixedSizeArray<Utf8String>(10)] 
    [FieldOffset(0x1BA8)] public fixed byte Strings[0x68 * 10]; // Tooltips and Category headers, ie "Gil", "Trials (Endwalker)"
    
    [FieldOffset(0x204C)] public int CurrentTimestamp;
    [FieldOffset(0x2058)] public byte SelectedTab;

    [MemberFunction("48 89 6C 24 ?? 48 89 74 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 8B F9 41 0F B6 E8")]
    public partial void* OpenRegularDuty(uint contentsFinderCondition, byte a2 = 0);

    [MemberFunction("E9 ?? ?? ?? ?? 8B 93 ?? ?? ?? ?? 48 83 C4 20")]
    public partial void* OpenRouletteDuty(byte roulette, byte a2 = 0);
}
