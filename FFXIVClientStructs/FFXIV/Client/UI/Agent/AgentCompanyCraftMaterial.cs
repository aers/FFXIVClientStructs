namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

//Client::UI::Agent::AgentCompanyCraftMaterial
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.CompanyCraftMaterial)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xE8)]
public unsafe partial struct AgentCompanyCraftMaterial {

    [FieldOffset(0x94)] public uint ResultItem;
    [FieldOffset(0x99)] public byte SelectedSupplyItemIndex;
    [FieldOffset(0x9C), FixedSizeArray] internal FixedSizeArray12<uint> _supplyItems;
}
