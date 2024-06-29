using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentColorant
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Colorant)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x488)]
public partial struct AgentColorant {

    [FieldOffset(0x108)] public ColorantCharaView CharaView;

    // Client::UI::Agent::AgentColorant::ColorantCharaView
    //   Client::UI::Misc::CharaView
    [GenerateInterop]
    [Inherits<CharaView>]
    [StructLayout(LayoutKind.Explicit, Size = 0x330)]
    public unsafe partial struct ColorantCharaView {
        //[FieldOffset(0x318)] public uint Unk2C8; // a3 passed to vf13
        [FieldOffset(0x31C)] public uint EntityId; // of local player
        [FieldOffset(0x320)] public bool DoUpdate;
        [FieldOffset(0x321)] public bool HideOtherEquipment;
        [FieldOffset(0x322)] public bool GearPreview;
        [FieldOffset(0x323)] public bool HideVisor;
        [FieldOffset(0x324)] public bool HideWeapon;
        [FieldOffset(0x325)] public bool CloseVisor;
        [FieldOffset(0x326)] public bool DrawWeapon;
        [FieldOffset(0x327)] public byte SelectedStain;
    }
}
