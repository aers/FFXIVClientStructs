using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.Group;

// Client::Game::Group::GroupManager
//   Client::Game::Character::CharacterManagerInterface
// group manager has two copies of the state - the normal one and a separate used when viewing recordings
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10000)]
[Inherits<CharacterManagerInterface>]
public unsafe partial struct GroupManager {
    [StaticAddress("33 D2 48 8D 0D ?? ?? ?? ?? 33 DB", 5)]
    public static partial GroupManager* Instance();

    [FieldOffset(0x0020)] public Group MainGroup;
    [FieldOffset(0x8010)] public Group ReplayGroup;

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 55 80")]
    public partial Group* GetGroup(bool replayGroup = false);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 57 DD")]
    public partial Group* GetGroupWithCheck(bool replayGroup = false);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x7FF0)]
    public unsafe partial struct Group {
        [FieldOffset(0x0), FixedSizeArray] internal FixedSizeArray8<PartyMember> _partyMembers;
        [FieldOffset(0x2480), FixedSizeArray] internal FixedSizeArray20<PartyMember> _allianceMembers;

        // Maps displayed alliance group slot to group number (0 = A, 1 = B, 2 = C, etc.).
        // Normal alliances use 3 entries; small-group alliances use 6.
        [FieldOffset(0x7FC0), FixedSizeArray] internal FixedSizeArray6<byte> _allianceGroupIndices;

        [FieldOffset(0x7FC8)] public long PartyId; // both seem to be unique per party and replicated to every member
        [FieldOffset(0x7FD0)] public long PartyId_2;
        [FieldOffset(0x7FD8)] public uint PartyLeaderIndex; // index of party leader in array
        [FieldOffset(0x7FDC)] public byte MemberCount;

        [BitField<bool>(nameof(IsAlliance), 0)]
        [BitField<bool>(nameof(IsSmallGroupAlliance), 1)]
        [FieldOffset(0x7FE1)] public byte AllianceFlags; // 0x01 == is alliance; 0x02 == 6 groups of 4, rather than 3 groups of 8

        public int AllianceGroupIndexCount => !IsAlliance ? 0 : IsSmallGroupAlliance ? 6 : 3;

        /// <summary>
        /// Returns the group number (0 = A, 1 = B, 2 = C, etc.) for a displayed alliance group slot.
        /// </summary>
        public byte GetAllianceGroupIndexBySlot(int slot) {
            if ((uint)slot >= (uint)AllianceGroupIndexCount)
                return 0xFF;

            return AllianceGroupIndices[slot];
        }

        [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? B0 01 E9 ?? ?? ?? ?? E8")]
        public partial bool IsEntityIdInParty(uint entityId);

        [MemberFunction("33 C0 44 8B CA F6 81")]
        public partial bool IsEntityIdInAlliance(uint entityId);

        [MemberFunction("48 63 81 ?? ?? ?? ?? 85 C0 78 14")]
        public partial bool IsEntityIdPartyLeader(uint entityId);

        [MemberFunction("E9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 74 19 48 8B CB")]
        public partial bool IsCharacterInPartyByName(byte* name);

        [MemberFunction("83 FA 14 72 03")]
        public partial PartyMember* GetAllianceMemberByIndex(int index);

        [MemberFunction("F6 81 ?? ?? ?? ?? ?? 4C 8B C9 74 1E")]
        public partial PartyMember* GetAllianceMemberByGroupAndIndex(int group, int index);

        [MemberFunction("85 D2 78 19 0F B6 81")]
        public partial PartyMember* GetPartyMemberByIndex(int index);

        [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 ?? 41 B6")]
        public partial PartyMember* GetPartyMemberByContentId(ulong contentId);

        [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 75 ?? 0F B6 B7")]
        public partial PartyMember* GetPartyMemberByEntityId(uint entityId);
    }
}
