using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Game.UI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentHUD
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
// ctor "E8 ?? ?? ?? ?? EB 03 48 8B C5 45 33 C9 48 89 47 40"
[Agent(AgentId.Hud)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x4DA8)]
public unsafe partial struct AgentHUD {
    [FieldOffset(0xB18)] public uint CastBarAddonId;

    [FieldOffset(0xB38)] public uint CurrentTargetId;
    [FieldOffset(0xB40)] public int TargetCounter;
    [FieldOffset(0xB48)] public uint TargetPartyMemberId;
    [FieldOffset(0xB50)] public int TargetSwitchToSelfCounter;
    [FieldOffset(0xB54)] public uint CurrentBattleCharaTargetLevel;

    [FieldOffset(0xD40)] public int CompanionSummonTimer;

    [FieldOffset(0xD50), FixedSizeArray] internal FixedSizeArray10<HudPartyMember> _partyMembers;

    [FieldOffset(0x1340)] public short PartyMemberCount;
    [FieldOffset(0x1348)] public uint PartyTitleAddonId;
    [FieldOffset(0x134C), FixedSizeArray] internal FixedSizeArray40<uint> _raidMemberIds;
    [FieldOffset(0x13EC)] public int RaidGroupSize;

    [FieldOffset(0x1400), FixedSizeArray] internal FixedSizeArray10<HudPartyMemberEnmity> _hudPartyMemberEnmity;
    [FieldOffset(0x1478), FixedSizeArray] internal FixedSizeArray10<Pointer<HudPartyMemberEnmity>> _hudPartyMemberEnmityPtrs;

    [FieldOffset(0x3530), FixedSizeArray] internal FixedSizeArray16<HudQueuedBattleTalk> _queuedBattleTalks;

    [FieldOffset(0x4A10)] public StdVector<MapMarkerData> MapMarkers;
    [FieldOffset(0x4A28)] public StdVector<Pointer<MapMarkerData>> MapMarkerPtrs;

    [MemberFunction("48 8B 81 ?? ?? ?? ?? 44 8B C2 83 E2 1F")]
    public partial bool IsMainCommandEnabled(uint mainCommandId);

    [MemberFunction("E8 ?? ?? ?? ?? 40 32 FF 45 32 C0")]
    public partial bool SetMainCommandEnabledState(uint mainCommandId, bool enabled);

    [MemberFunction("48 85 D2 74 7F 48 89 5C 24")]
    public partial void OpenContextMenuFromTarget(GameObject* gameObject);

    [MemberFunction("E8 ?? ?? ?? ?? EB 08 48 8B CB E8 ?? ?? ?? ?? 48 8B 4C 24 ?? 45 85 F6")]
    public partial byte* GetMainCommandString(uint commandId, bool includeKeybind = true, bool includeNewIndicator = false);
}

[StructLayout(LayoutKind.Explicit, Size = 0x0C)]
public struct HudPartyMemberEnmity {
    [FieldOffset(0x00)] public uint EntityId;
    [FieldOffset(0x04)] public int Enmity;
    [FieldOffset(0x08)] public short Index;
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct HudPartyMember {
    [FieldOffset(0x0)] public BattleChara* Object;
    [FieldOffset(0x8)] public byte* Name;
    [FieldOffset(0x10)] public ulong ContentId;
    [FieldOffset(0x18)] public uint EntityId;
}

[StructLayout(LayoutKind.Explicit, Size = 0xE8)]
public unsafe struct HudQueuedBattleTalk {
    [FieldOffset(0x0)] public bool IsPending;
    //[FieldOffset(0x1)] public byte Unk1;
    [FieldOffset(0x2)] public byte Style;

    [FieldOffset(0x8)] public Utf8String Name;
    [FieldOffset(0x70)] public Utf8String Text;
    [FieldOffset(0xDC)] public uint Image;
    [FieldOffset(0xE0)] public int Sound;
    [FieldOffset(0xE4)] public uint EntityId;
}
