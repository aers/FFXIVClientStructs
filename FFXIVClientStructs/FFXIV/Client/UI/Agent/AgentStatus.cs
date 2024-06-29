using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentStatus
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Status)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x3B0)]
public partial struct AgentStatus {

    [FieldOffset(0x3C)] public byte TabIndex;

    [FieldOffset(0x80)] public StatusCharaView CharaView;

    // Client::UI::Agent::AgentStatus::StatusCharaView
    //   Client::UI::Misc::CharaView
    [GenerateInterop]
    [Inherits<CharaView>]
    [StructLayout(LayoutKind.Explicit, Size = 0x320)]
    public partial struct StatusCharaView {
        [FieldOffset(0x318)] public uint MainhandItemId;
        [FieldOffset(0x31C)] public bool DrawWeapon;
    }
}
