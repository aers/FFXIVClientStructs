namespace FFXIVClientStructs.FFXIV.Client.Game.Group;

// Client::Game::Group::GroupManager
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 20 33 ED C7 81"
// there are actually two copies of this back to back in the exe
// maybe for 48 man raid support since the group manager can only hold 1 alliance worth of party members
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x65D0)]
public unsafe partial struct GroupManager {
    [FieldOffset(0x0), FixedSizeArray] internal FixedSizeArray8<PartyMember> _partyMembers;
    [FieldOffset(0x1D10), FixedSizeArray] internal FixedSizeArray20<PartyMember> _allianceMembers;

    [FieldOffset(0x6588)] public long PartyId; // both seem to be unique per party and replicated to every member
    [FieldOffset(0x6590)] public long PartyId_2;
    [FieldOffset(0x6598)] public uint PartyLeaderIndex; // index of party leader in array
    [FieldOffset(0x659C)] public byte MemberCount;

    //[FieldOffset(0x3D5E)] public bool IsAlliance;

    [FieldOffset(0x65A1)] public byte AllianceFlags; // 0x01 == is alliance; 0x02 == alliance with 5 4-man groups rather than 2 8-man

    public unsafe bool IsAlliance => (AllianceFlags & 1) != 0;
    public unsafe bool IsSmallGroupAlliance => (AllianceFlags & 2) != 0; // alliance containing 6 groups of 4 members rather than 3x8

    [StaticAddress("33 D2 48 8D 0D ?? ?? ?? ?? 33 DB", 5)]
    public static partial GroupManager* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 55 80")]
    public partial GroupManager* GetNextInstance(bool getNextInstance = true); // if true, simply adds sizeof(GroupManager) to the `this` pointer

    [MemberFunction("E8 ?? ?? ?? ?? EB B8 E8")]
    public partial bool IsEntityIdInParty(uint entityId);

    [MemberFunction("33 C0 44 8B CA F6 81")]
    public partial bool IsEntityIdInAlliance(uint entityId);

    [MemberFunction("48 63 81 ?? ?? ?? ?? 85 C0 78 14")]
    public partial bool IsEntityIdPartyLeader(uint entityId);

    [MemberFunction("E9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 74 19")]
    public partial bool IsCharacterInPartyByName(byte* name);

    [MemberFunction("83 FA 14 72 03")]
    public partial PartyMember* GetAllianceMemberByIndex(int index);

    [MemberFunction("F6 81 ?? ?? ?? ?? ?? 4C 8B C9 74 1E")]
    public partial PartyMember* GetAllianceMemberByGroupAndIndex(int group, int index);

    [MemberFunction("85 D2 78 19 0F B6 81")]
    public partial PartyMember* GetPartyMemberByIndex(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D8 4C 8B 07")]
    public partial PartyMember* GetPartyMemberByContentId(ulong contentId);

    [MemberFunction("E8 ?? ?? ?? ?? 83 FF 32")]
    public partial PartyMember* GetPartyMemberByEntityId(uint entityId);
}
