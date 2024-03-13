namespace FFXIVClientStructs.FFXIV.Client.Game.Group;

// Client::Game::Group::GroupManager
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 20 33 ED C7 81"
// there are actually two copies of this back to back in the exe
// maybe for 48 man raid support since the group manager can only hold 1 alliance worth of party members
[StructLayout(LayoutKind.Explicit, Size = 0x63F0)]
public unsafe partial struct GroupManager {
    [FixedSizeArray<PartyMember>(8)]
    [FieldOffset(0x0)] public fixed byte PartyMembers[0x390 * 8]; // PartyMember type
    [FixedSizeArray<PartyMember>(20)]
    [FieldOffset(0x1C80)] public fixed byte AllianceMembers[0x390 * 20]; // PartyMember type
    [FieldOffset(0x63C0)] public uint Unk_3D40;
    [FieldOffset(0x63C4)] public ushort Unk_3D44;
    [FieldOffset(0x63C8)] public long PartyId; // both seem to be unique per party and replicated to every member
    [FieldOffset(0x63D0)] public long PartyId_2;
    [FieldOffset(0x63D8)] public uint PartyLeaderIndex; // index of party leader in array
    [FieldOffset(0x63DC)] public byte MemberCount;
    [FieldOffset(0x63DD)] public byte Unk_3D5D;
    //[FieldOffset(0x3D5E)] public bool IsAlliance;
    [FieldOffset(0x63DF)] public byte Unk_3D5F; // some sort of count
    [FieldOffset(0x63E0)] public byte Unk_3D60;
    [FieldOffset(0x63E1)] public byte AllianceFlags; // 0x01 == is alliance; 0x02 == alliance with 5 4-man groups rather than 2 8-man

    [StaticAddress("33 D2 48 8D 0D ?? ?? ?? ?? 33 DB", 5)]
    public static partial GroupManager* Instance();

    [MemberFunction("48 8D 81 ?? ?? ?? ?? 84 D2")]
    public partial GroupManager* GetNextInstance(bool getNextInstance = true); // if true, simply adds sizeof(GroupManager) to the `this` pointer

    [MemberFunction("E8 ?? ?? ?? ?? EB B8 E8")]
    public partial bool IsObjectIDInParty(uint objectID);

    [MemberFunction("33 C0 44 8B CA F6 81")]
    public partial bool IsObjectIDInAlliance(uint objectID);

    [MemberFunction("48 63 81 ?? ?? ?? ?? 85 C0 78 14")]
    public partial bool IsObjectIDPartyLeader(uint objectID);

    [MemberFunction("48 89 5C 24 ?? 48 89 7C 24 ?? 44 0F B6 99")]
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
    public partial PartyMember* GetPartyMemberByObjectId(uint objectId);
}
