using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentItemSearch
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface

// size = 0x3568
// ctor 48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 20 33 ED C6 41 08 00 48 89 69 18
[Agent(AgentId.ItemSearch)]
[StructLayout(LayoutKind.Explicit, Size = 0x37F0)]
public unsafe struct AgentItemSearch
{
    // Market Board
    public static AgentItemSearch* Instance()
    {
        return (AgentItemSearch*) Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(
            AgentId.ItemSearch);
    }

    [FieldOffset(0x0)] public AgentInterface AgentInterface;
    [FieldOffset(0x3304)] public uint ResultItemID;
    [FieldOffset(0x330C)] public uint ResultSelectedIndex;
    [FieldOffset(0x331C)] public uint ResultHoveredIndex;
    [FieldOffset(0x3324)] public uint ResultHoveredCount;
    [FieldOffset(0x332C)] public byte ResultHoveredHQ;
}