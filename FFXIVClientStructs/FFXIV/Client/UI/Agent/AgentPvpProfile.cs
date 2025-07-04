using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentPvpProfile
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.PvpProfile)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x428)]
public unsafe partial struct AgentPvpProfile {
    [FieldOffset(0x02C), FixedSizeArray] internal FixedSizeArray32<uint> _jobActionIds;
    [FieldOffset(0x0AC)] public uint ActionComboRouteId;
    [FieldOffset(0x12C)] public byte JobActionIdCount;
    [FieldOffset(0x12D)] public bool HasActionCombo;
    [FieldOffset(0x158)] public byte SelectedRoleActionIndex;
    [FieldOffset(0x200)] public Utf8String JobName;
    [FieldOffset(0x2D0)] public int SelectedTab;
    [FieldOffset(0x2E8)] public int PvpRewardAddonId;
}
