using System;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.Attributes {
    public class AgentAttribute : Attribute {
        public AgentId ID { get; }
        
        public AgentAttribute(AgentId agentId) {
            this.ID = agentId;
        }
    }
}
