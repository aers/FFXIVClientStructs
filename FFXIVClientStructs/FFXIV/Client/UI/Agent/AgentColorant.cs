using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentColorant
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Colorant)]
[StructLayout(LayoutKind.Explicit, Size = 0x3F0)]
public partial struct AgentColorant {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [FieldOffset(0x108)] public ColorantCharaView CharaView;

    // Client::UI::Agent::AgentColorant::ColorantCharaView
    //   Client::UI::Misc::CharaView
    [StructLayout(LayoutKind.Explicit, Size = 0x2D8)]
    public unsafe struct ColorantCharaView {
        [FieldOffset(0)] public CharaView Base;
        [FieldOffset(0x2C8)] public uint Unk2C8; // a3 passed to vf13
        [FieldOffset(0x2CC)] public uint ObjectID; // of local player
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
