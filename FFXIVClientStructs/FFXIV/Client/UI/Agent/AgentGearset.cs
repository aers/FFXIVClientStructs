using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.Misc.RaptureGearsetModule;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentGearSet
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.GearSet)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xBC0)]
public unsafe partial struct AgentGearSet {
    [FieldOffset(0x808)] public GearsetCharaView CharaView;

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 8B F9 8B DA 48 8B 49 10 48 8B 01 FF 50 70 4C 8D 44 24")]
    public partial void OpenBannerEditorForGearset(int gearsetId);

    public void CreateGearset()
        => SendEvent(1);

    public void OpenDeleteDialog(int gearsetId)
        => SendEvent(2, gearsetId);

    public void EquipGearset(int gearsetId)
        => SendEvent(4, gearsetId);

    public void OpenRenameDialog(int gearsetId)
        => SendEvent(10, gearsetId);

    public void OpenGearsetItemList(int gearsetId)
        => SendEvent(11, gearsetId);

    public void OpenGearsetPreview(int gearsetId)
        => SendEvent(12, gearsetId);

    public void UpdateGearset(int gearsetId)
        => SendEvent(16, gearsetId);

    private void SendEvent(int evt, int gearsetId = 0) {
        var result = stackalloc AtkValue[1];
        var values = stackalloc AtkValue[2];
        values[0].SetInt(evt); // case
        values[1].SetInt(gearsetId); // optional gearsetId
        ReceiveEvent(result, values, 2, 0);
    }

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
