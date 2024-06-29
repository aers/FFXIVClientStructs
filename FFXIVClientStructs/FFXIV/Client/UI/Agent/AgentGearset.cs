using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using static FFXIVClientStructs.FFXIV.Client.UI.Misc.RaptureGearsetModule;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentGearSet
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.GearSet)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xBC0)]
public partial struct AgentGearSet {
    [FieldOffset(0x808)] public GearsetCharaView CharaView;

    // Client::UI::Agent::AgentGearSet::GearsetCharaView
    //   Client::UI::Misc::CharaView
    [GenerateInterop]
    [Inherits<CharaView>]
    [StructLayout(LayoutKind.Explicit, Size = 0x328)]
    public unsafe partial struct GearsetCharaView {
        [FieldOffset(0x318)] public bool UpdateVisibility;
        [FieldOffset(0x319)] public bool UpdateItems;
        [FieldOffset(0x31A)] public bool HideVisor;
        [FieldOffset(0x31B)] public bool HideWeapon;
        [FieldOffset(0x31C)] public bool CloseVisor;
        [FieldOffset(0x31D)] public bool DrawWeapon;
        [FieldOffset(0x31E)] public bool CharacterDisplayMode;

        [FieldOffset(0x320)] public GearsetEntry* Gearset;
    }
}
