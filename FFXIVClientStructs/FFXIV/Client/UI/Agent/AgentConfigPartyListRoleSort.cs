namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentConfigPartyListRoleSort
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ConfigPartyListRoleSort)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public partial struct AgentConfigPartyListRoleSort {
    [FieldOffset(0x28)] public int SelectedRole;
    [FieldOffset(0x2C)] public int SelectedItemIndex;
    [FieldOffset(0x30)] public bool HasChanges;
    [FieldOffset(0x34)] public uint YesNoAddonId;
    [FieldOffset(0x38), FixedSizeArray] internal FixedSizeArray16<ushort> _tankOrder;
    [FieldOffset(0x58), FixedSizeArray] internal FixedSizeArray16<ushort> _healerOrder;
    [FieldOffset(0x78), FixedSizeArray] internal FixedSizeArray16<ushort> _dpsOrder;
}
