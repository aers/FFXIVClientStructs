namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentItemComp
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ItemComp)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public partial struct AgentItemComp {
    [MemberFunction("E8 ?? ?? ?? ?? EB 3F 83 F8 FE")]
    public partial void CompareItem(ushort parentAddonId, uint itemId, byte stainId);
}
