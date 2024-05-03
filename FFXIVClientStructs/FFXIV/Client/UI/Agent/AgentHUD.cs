using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentHUD
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
// ctor "E8 ?? ?? ?? ?? EB 03 48 8B C5 45 33 C9 48 89 47 40"
[Agent(AgentId.Hud)]
[StructLayout(LayoutKind.Explicit, Size = 0x4BA0)]
public unsafe partial struct AgentHUD {
    [FieldOffset(0x0)] public AgentInterface AgentInterface;

    [FieldOffset(0xAA8)] public uint CastBarAddonId;

    [FieldOffset(0xAB0)] public uint CurrentTargetId;
    [FieldOffset(0xAB8)] public int TargetCounter;
    [FieldOffset(0xAC0)] public uint TargetPartyMemberId;
    [FieldOffset(0xAC8)] public int TargetSwitchToSelfCounter;
    [FieldOffset(0x9DC)] public uint CurrentBattleCharaTargetLevel;

    [FieldOffset(0xCB8)] public int CompanionSummonTimer;

    [FixedSizeArray<HudPartyMember>(10)]
    [FieldOffset(0xCC8)] public fixed byte PartyMemberList[0x20 * 10];

    [FieldOffset(0x12B8)] public short PartyMemberCount;
    [FieldOffset(0x12C0)] public uint PartyTitleAddonId;
    [FieldOffset(0x12C4)] public fixed uint RaidMemberIds[40];
    [FieldOffset(0x1364)] public int RaidGroupSize;

    [FixedSizeArray<HudPartyMemberEnmity>(10)]
    [FieldOffset(0x1378)] public fixed byte HudPartyMemberEnmityEntries[0x0C * 10];
    [FixedSizeArray<Pointer<HudPartyMemberEnmity>>(10)]
    [FieldOffset(0x13F0)] public fixed byte HudPartyMemberEnmityPtrs[0x8 * 10];
    [Obsolete("Use HudPartyMemberEnmityEntriesSpan or HudPartyMemberEnmityPtrsSpan")]
    [FieldOffset(0x13F0)] public HudPartyMemberEnmity* PartyEnmityList;

    [FieldOffset(0x4808)] public StdVector<MapMarkerData> MapMarkers;
    [FieldOffset(0x4820)] public StdVector<Pointer<MapMarkerData>> MapMarkerPtrs;

    [MemberFunction("48 8B 81 ?? ?? ?? ?? 44 8B C2 83 E2 1F")]
    public partial bool IsMainCommandEnabled(uint mainCommandId);

    [MemberFunction("E8 ?? ?? ?? ?? 41 B0 01 EB 27")]
    public partial bool SetMainCommandEnabledState(uint mainCommandId, bool enabled);

    [MemberFunction("48 85 D2 74 7F 48 89 5C 24")]
    public partial void OpenContextMenuFromTarget(GameObject* gameObject);

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 48 8B CB E8 ?? ?? ?? ?? 48 8B D8")]
    public partial byte* GetMainCommandString(uint commandId, bool includeKeybind = true, bool includeNewIndicator = false);
}

[StructLayout(LayoutKind.Explicit, Size = 0x0C)]
public struct HudPartyMemberEnmity {
    [FieldOffset(0x00)] public uint ObjectId;
    [FieldOffset(0x04)] public int Enmity;
    [FieldOffset(0x08)] public int Index; // TODO: change to short
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct HudPartyMember {
    [FieldOffset(0x0)] public BattleChara* Object;
    [FieldOffset(0x8)] public byte* Name;
    [FieldOffset(0x10)] public ulong ContentId;
    [FieldOffset(0x18)] public uint ObjectId;
}
