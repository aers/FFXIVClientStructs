using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.Misc.RaptureGearsetModule;
using static FFXIVClientStructs.FFXIV.Client.UI.RaptureAtkModule;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentGearSet
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.GearSet)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xBC0)]
public unsafe partial struct AgentGearSet {
    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray14<ContextMenuParam> _contextMenuParams;

    [FieldOffset(0x118), FixedSizeArray] internal FixedSizeArray13<ItemCache> _itemCaches;

    [FieldOffset(0x878)] public GearsetCharaView CharaView;

    [FieldOffset(0xBA8)] public StdVector<int> GearSetIds;

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 8B F9 8B DA 48 8B 49 10 48 8B 01 FF 50 70 4C 8D 44 24")]
    public partial void OpenBannerEditorForGearset(int gearsetId);

    public void CreateGearset()
        => SendEvent(1);

    public void OpenDeleteDialog(int gearsetId)
        => SendEvent(2, gearsetId);

    public void EquipGearset(int gearsetId)
        => SendEvent(4, gearsetId);

    public void ReassignGear(int gearsetId)
        => SendEvent(6, gearsetId);

    public void ReassignSetNumber(int gearsetId)
        => SendEvent(7, gearsetId);

    public void MoveSetUp(int gearsetId)
        => SendEvent(8, gearsetId);

    public void MoveSetDown(int gearsetId)
        => SendEvent(9, gearsetId);

    public void OpenRenameDialog(int gearsetId)
        => SendEvent(10, gearsetId);

    public void OpenGearsetItemList(int gearsetId)
        => SendEvent(11, gearsetId);

    public void OpenGearsetPreview(int gearsetId)
        => SendEvent(12, gearsetId);

    /// <remarks> Only works when Cross Hotbars are enabled. </remarks>
    public void SetToHotbar(int gearsetId)
        => SendEvent(13, gearsetId);

    public void UpdateGearset(int gearsetId)
        => SendEvent(16, gearsetId);

    public void LinkToGlamourPlate(int gearsetId)
        => SendEvent(20, gearsetId);

    public void ChangeGlamourPlateLink(int gearsetId)
        => SendEvent(21, gearsetId);

    public void RemoveGlamourPlateLink(int gearsetId)
        => SendEvent(22, gearsetId);

    public void EditPortrait(int gearsetId)
        => SendEvent(23, gearsetId);

    private void SendEvent(int evt, int gearsetId = 0) {
        var result = stackalloc AtkValue[1];
        var values = stackalloc AtkValue[2];
        values[0].SetInt(evt); // case
        values[1].SetInt(gearsetId); // optional gearsetId
        ReceiveEvent(result, values, 2, 0);
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x0C)]
    public struct ContextMenuParam {
        [FieldOffset(0x00)] public int Unk0;
        [FieldOffset(0x04)] public int EventId;
        [FieldOffset(0x08)] public int GearSetId;
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
