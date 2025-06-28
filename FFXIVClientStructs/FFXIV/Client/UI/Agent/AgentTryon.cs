using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentTryon
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
// ctor "48 89 5C 24 ?? 57 48 83 EC 20 48 8B F9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 8D 4F 28 48 89 07 E8 ?? ?? ?? ?? 48 C7 87"
[Agent(AgentId.Tryon)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x6D8)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 8D 4F 28 48 89 07 E8 ?? ?? ?? ?? 48 C7 87", 3, 16)]
public unsafe partial struct AgentTryon {
    [FieldOffset(0x28)] public TryonCharaView CharaView;

    /// <remarks> Opener AddonId can be left as 0. </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? EB 5B 48 8B 49 10")]
    public static partial bool TryOn(uint openerAddonId, uint itemId, byte stain0Id = 0, byte stain1Id = 0, uint glamourItemId = 0, bool applyCompanyCrest = false);

    // Client::UI::Agent::AgentTryon::TryonCharaView
    //   Client::UI::Misc::CharaView
    [GenerateInterop]
    [Inherits<CharaView>]
    [StructLayout(LayoutKind.Explicit, Size = 0x320)]
    public unsafe partial struct TryonCharaView {
        [FieldOffset(0x318)] public bool DoUpdate; // beware: fetches data from agent too, happens in vf10
        [FieldOffset(0x319)] public bool HideOtherEquipment;
        [FieldOffset(0x31A)] public bool HideVisor;
        [FieldOffset(0x31B)] public bool HideWeapon;
        [FieldOffset(0x31C)] public bool CloseVisor;
        [FieldOffset(0x31D)] public bool DrawWeapon;
    }
}
