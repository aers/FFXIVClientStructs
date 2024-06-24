using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.Attributes;

public class AgentAttribute(AgentId agentId) : Attribute {

    public AgentId Id { get; } = agentId;
}
