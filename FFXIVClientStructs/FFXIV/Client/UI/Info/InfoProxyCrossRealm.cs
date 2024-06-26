namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyCrossRealm
//   Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.CrossRealmParty)]
[GenerateInterop]
[Inherits<InfoProxyInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x1620)]
public unsafe partial struct InfoProxyCrossRealm {
    [FieldOffset(0x38D)] public byte LocalPlayerGroupIndex;
    [FieldOffset(0x38E)] public byte GroupCount;

    [FieldOffset(0x390)] public byte IsCrossRealm; //i guess?
    [FieldOffset(0x391)] public byte IsInAllianceRaid;
    [FieldOffset(0x392)] public byte IsPartyLeader;
    [FieldOffset(0x393)] public byte IsInCrossRealmParty;

    [FieldOffset(0x3A0), FixedSizeArray] internal FixedSizeArray6<CrossRealmGroup> _crossRealmGroups;

    [MemberFunction("E8 ?? ?? ?? ?? F6 D8 1A C0")]
    public static partial bool IsCrossRealmParty();

    [MemberFunction("48 83 EC 28 80 3D ?? ?? ?? ?? ?? 75 2F")]
    public static partial bool IsAllianceRaid();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 D8 8B CB")]
    public static partial byte GetGroupIndex(byte group);

    [MemberFunction("E8 ?? ?? ?? ?? 3C ?? 77 ?? C7 43")]
    public static partial byte GetPartyMemberCount();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 C0 EB 08")]
    public static partial byte GetGroupMemberCount(int groupIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 5E 10 48 8B C8")]
    public static partial CrossRealmMember* GetGroupMember(uint memberIndex, int groupIndex = -1);

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 0C 0F B6 40 2E")]
    public static partial CrossRealmMember* GetMemberByContentId(ulong contentId);

    [MemberFunction("E8 ?? ?? ?? ?? 83 FF 32")]
    public static partial CrossRealmMember* GetMemberByEntityId(uint entityId);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 ?? 0F B6 5E")]
    public static partial bool IsContentIdInParty(ulong contentId);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x2C8)]
public unsafe partial struct CrossRealmGroup {
    [FieldOffset(0x00)] public byte GroupMemberCount;
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray8<CrossRealmMember> _groupMembers;
}

[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe struct CrossRealmMember {
    [FieldOffset(0x08)] public ulong ContentId;
    [FieldOffset(0x18)] public uint EntityId;
    [FieldOffset(0x20)] public byte Level;
    [FieldOffset(0x22)] public short HomeWorld;
    [FieldOffset(0x24)] public short CurrentWorld;
    [FieldOffset(0x26)] public byte ClassJobId;
    [FieldOffset(0x2B), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;
    [FieldOffset(0x50)] public byte MemberIndex;
    [FieldOffset(0x51)] public byte GroupIndex;
    [FieldOffset(0x53)] public byte IsPartyLeader;
}
