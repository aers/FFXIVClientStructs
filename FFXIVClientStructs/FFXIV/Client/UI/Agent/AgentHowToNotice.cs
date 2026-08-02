namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentHowToNotice
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.HowToNotice)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct AgentHowToNotice {
    /// <summary>Queued HowTo row ids waiting to be shown as the green Active Help notice.</summary>
    [FieldOffset(0x28)] public StdDeque<uint> PendingHowTos;

    /// <summary>Show the Active Help notice for a HowTo row (or adds to queue if one is already pending)</summary>
    /// <param name="howToId">HowTo row id</param>
    [MemberFunction("48 89 6C 24 ?? 41 56 48 83 EC 70 4C 8B F1")]
    public partial void ShowNotice(uint howToId);
}
