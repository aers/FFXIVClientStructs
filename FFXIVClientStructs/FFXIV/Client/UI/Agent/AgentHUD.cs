using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;
// Client::UI::Agent::AgentHUD
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface

// size = 0x4600
// ctor E8 ?? ?? ?? ?? EB 03 49 8B C4 45 33 C9 48 89 46 40
[Agent(AgentId.Hud)]
[StructLayout(LayoutKind.Explicit, Size = 0x4BA0)]
public unsafe partial struct AgentHUD
{
    [FieldOffset(0x0)] public AgentInterface AgentInterface;

    //[FieldOffset(0x9C0)] public uint CurrentTargetId;
    //[FieldOffset(0x9C8)] public int TargetCounter;
    //[FieldOffset(0x9D0)] public uint TargetPartyMemberId;
    //[FieldOffset(0x9D8)] public int TargetSwitchToSelfCounter;
    //[FieldOffset(0x9DC)] public uint CurrentBattleCharaTargetLevel;

    [FieldOffset(0xCB8)] public int CompanionSummonTimer;
    [FieldOffset(0xCC8)] public fixed byte PartyMemberList[0x20 * 10];
    [FieldOffset(0x12B8)] public short PartyMemberCount;
    [FieldOffset(0x12C0)] public uint PartyTitleAddonId;
    [FieldOffset(0x12C4)] public fixed uint RaidMemberIds[40];
    [FieldOffset(0x1364)] public int RaidGroupSize;

    [FieldOffset(0x13F0)] public HudPartyMemberEnmity* PartyEnmityList;

    [MemberFunction("48 85 D2 74 7F 48 89 5C 24")]
    public partial void OpenContextMenuFromTarget(GameObject* gameObject);
}

[StructLayout(LayoutKind.Explicit, Size = 0x0C)]
public struct HudPartyMemberEnmity
{
    [FieldOffset(0x00)] public uint ObjectId;
    [FieldOffset(0x04)] public int Enmity;
    [FieldOffset(0x08)] public int Index;
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct HudPartyMember
{
    [FieldOffset(0x0)] public BattleChara* Object;
    [FieldOffset(0x8)] public byte* Name;
    [FieldOffset(0x10)] public ulong ContentId;
    [FieldOffset(0x18)] public uint ObjectId;
}
