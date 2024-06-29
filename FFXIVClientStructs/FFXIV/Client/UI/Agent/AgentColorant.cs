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
        //[FieldOffset(0x2C8)] public uint Unk2C8; // a3 passed to vf13
        [FieldOffset(0x2CC)] public uint EntityId; // of local player
        [FieldOffset(0x2D0)] public bool DoUpdate;
        [FieldOffset(0x2D1)] public bool HideOtherEquipment;
        [FieldOffset(0x2D2)] public bool GearPreview;
        [FieldOffset(0x2D3)] public bool HideVisor;
        [FieldOffset(0x2D4)] public bool HideWeapon;
        [FieldOffset(0x2D5)] public bool CloseVisor;
        [FieldOffset(0x2D6)] public bool DrawWeapon;
        [FieldOffset(0x2D7)] public byte SelectedStain;
    }
}
