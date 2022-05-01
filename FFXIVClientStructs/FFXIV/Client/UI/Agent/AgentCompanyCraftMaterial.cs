using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

//Client::UI::Agent::AgentCompanyCraftMaterial
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.CompanyCraftMaterial)]
[StructLayout(LayoutKind.Explicit, Size = 0xE8)]
public unsafe struct AgentCompanyCraftMaterial
{
    [FieldOffset(0x0)] public AgentInterface AgentInterface;

    [FieldOffset(0x94)] public uint ResultItem;
    [FieldOffset(0x99)] public byte SelectedSupplyItemIndex;
    [FieldOffset(0x9C)] public fixed uint SupplyItem[12];
}
