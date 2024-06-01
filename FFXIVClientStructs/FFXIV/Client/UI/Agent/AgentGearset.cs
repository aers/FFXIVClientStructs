using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using static FFXIVClientStructs.FFXIV.Client.UI.Misc.RaptureGearsetModule;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentGearSet
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.GearSet)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xB00)]
public partial struct AgentGearSet {
    [FieldOffset(0x808)] public GearsetCharaView CharaView;

    // Client::UI::Agent::AgentGearSet::GearsetCharaView
    //   Client::UI::Misc::CharaView
    [GenerateInterop]
[Inherits<CharaView>]
    [StructLayout(LayoutKind.Explicit, Size = 0x2D8)]
    public unsafe partial struct GearsetCharaView {
        [FieldOffset(0x2C8)] public bool UpdateVisibility;
        [FieldOffset(0x2C9)] public bool UpdateItems;
        [FieldOffset(0x2CA)] public bool HideVisor;
        [FieldOffset(0x2CB)] public bool HideWeapon;
        [FieldOffset(0x2CC)] public bool CloseVisor;
        [FieldOffset(0x2CD)] public bool DrawWeapon;
        [FieldOffset(0x2CE)] public bool CharacterDisplayMode;

        [FieldOffset(0x2D0)] public GearsetEntry* Gearset;
    }
}
