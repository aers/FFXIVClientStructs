using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

//Client::UI::Agent::AgentRevive
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Revive)]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe struct AgentRevive
{
    [FieldOffset(0x0)] public AgentInterface AgentInterface;
    [FieldOffset(0x28)] public Revive* Revive; //callback for SelectYesNo
    [FieldOffset(0x38)] public byte ReviveState;
    [FieldOffset(0x40)] public int ResurrectionTimeLeft;
    [FieldOffset(0x44)] public uint ResurrectingPlayerId;
    [FieldOffset(0x48)] public Utf8String ResurrectingPlayerName;
}