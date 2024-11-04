using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.Attributes;

[AttributeUsage(AttributeTargets.Struct)]
public class AgentAttribute(AgentId agentId) : Attribute {

    public AgentId Id { get; } = agentId;
}
