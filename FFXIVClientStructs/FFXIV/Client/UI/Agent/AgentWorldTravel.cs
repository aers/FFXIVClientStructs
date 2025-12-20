using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentWorldTravel
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.WorldTravel)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x140)]
public unsafe partial struct AgentWorldTravel {
    [FieldOffset(0x30)] private uint YesNo2Id;
    [FieldOffset(0x40)] public ushort* HomeWorldId;
    [FieldOffset(0x48)] private uint QueueTimer1; // only active during waiting
    [FieldOffset(0x4C)] public ushort DestinationWorldId;
    [FieldOffset(0x50)] public Utf8String CurrentWorldName;
    [FieldOffset(0xB8)] public Utf8String DestinationWorldName;
    [FieldOffset(0x120)] private ushort TransportFlag; // InQueue vs Ready
    [FieldOffset(0x124)] private void* QueueTimer2; // only resets on each new travel, counts up in ~seconds
    [FieldOffset(0x138)] private byte BetweenAreas; // Roughly corresponds to the BetweenAreas condition

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B F9 41 0F B7 F0 48 8B 49")]
    public partial void SetupWorldTravelInfo(ushort currentWorld, ushort targetWorld);
}
