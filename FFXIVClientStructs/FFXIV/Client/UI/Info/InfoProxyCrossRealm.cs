namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.CrossRealmParty)]
[StructLayout(LayoutKind.Explicit, Size = 0x1620)]
public unsafe partial struct InfoProxyCrossRealm {
    [FieldOffset(0x00)] public InfoProxyInterface InfoProxyInterface;

    // memset((void *)(a1 + 0x30),  0, 0x358ui64);
    // memset((void *)(a1 + 0x3A0), 0, 0xF30ui64);

    [FieldOffset(0x38D)] public byte LocalPlayerGroupIndex;
    [FieldOffset(0x38E)] public byte GroupCount;

    [FieldOffset(0x390)] public byte IsCrossRealm; //i guess?
    [FieldOffset(0x391)] public byte IsInAllianceRaid;
    [FieldOffset(0x392)] public byte IsPartyLeader;
    [FieldOffset(0x393)] public byte IsInCrossRealmParty;

    [FixedSizeArray<CrossRealmGroup>(6)]
    [FieldOffset(0x3A0)] public fixed byte CrossRealmGroupArray[6 * 0x2C8];

    [MemberFunction("E8 ?? ?? ?? ?? F6 D8 1A C0")]
    public static partial bool IsCrossRealmParty();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 ?? 8B AF")]
    public static partial bool IsAllianceRaid();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 D8 8B CB")]
    public static partial byte GetGroupIndex(byte group);

    [MemberFunction("E8 ?? ?? ?? ?? 3C ?? 77 ?? C7 43")]
    public static partial byte GetPartyMemberCount();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 C0 EB 0C")]
    public static partial byte GetGroupMemberCount(int groupIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 44 38 60 53")]
    public static partial CrossRealmMember* GetGroupMember(uint memberIndex, int groupIndex = -1);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D0 48 8B 05")]
    public static partial CrossRealmMember* GetMemberByContentId(ulong contentId);

    [MemberFunction("48 89 5C 24 ?? 48 89 7C 24 ?? 4C 8B 1D")]
    public static partial CrossRealmMember* GetMemberByObjectId(uint objectId);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 ?? 0F B6 5E")]
    public static partial bool IsContentIdInParty(ulong contentId);
}

[StructLayout(LayoutKind.Explicit, Size = 0x2C8)]
public unsafe partial struct CrossRealmGroup {
    [FieldOffset(0x00)] public byte GroupMemberCount;
    [FixedSizeArray<CrossRealmMember>(8)]
    [FieldOffset(0x08)] public fixed byte GroupMembers[8 * 0x58];
}

[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe struct CrossRealmMember {
    [FieldOffset(0x08)] public ulong ContentId;
    [FieldOffset(0x18)] public uint ObjectId;
    [FieldOffset(0x20)] public byte Level;
    [FieldOffset(0x22)] public short HomeWorld;
    [FieldOffset(0x24)] public short CurrentWorld;
    [FieldOffset(0x26)] public byte ClassJobId;
    [FieldOffset(0x2B)] public fixed byte Name[32];
    [FieldOffset(0x50)] public byte MemberIndex;
    [FieldOffset(0x51)] public byte GroupIndex;
    [FieldOffset(0x53)] public byte IsPartyLeader;
}
