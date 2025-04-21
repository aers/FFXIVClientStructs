using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMcGuffin
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.McGuffin)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x4C0)]
public unsafe partial struct AgentMcGuffin {
    [MemberFunction("48 83 EC 28 80 3D ?? ?? ?? ?? ?? 74 20")]
    public partial bool CanOpenMcGuffin(uint mcGuffinId);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 40 80 3D")]
    public partial bool OpenMcGuffin(uint mcGuffinId);
}
