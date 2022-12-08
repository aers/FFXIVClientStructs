using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.Attributes;

public class AgentAttribute : Attribute
{
    public AgentAttribute(AgentId agentId)
    {
        ID = agentId;
    }

    public AgentId ID { get; }
}