namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentFishGuide
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.FishGuide)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x1A8)]
public unsafe partial struct AgentFishGuide {
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 44 0F B6 83")]
    public partial void OpenForItemId(uint itemId, bool isSpearfishing);
}
