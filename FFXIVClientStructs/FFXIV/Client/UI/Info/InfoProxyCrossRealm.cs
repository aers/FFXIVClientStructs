namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyCrossRealm
//   Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.CrossRealmParty)]
[GenerateInterop]
[Inherits<InfoProxyInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x1620)]
public unsafe partial struct InfoProxyCrossRealm {
    [FieldOffset(0x46D)] public byte LocalPlayerGroupIndex;
    [FieldOffset(0x46E)] public byte GroupCount;

    [FieldOffset(0x470)] public byte IsCrossRealm; //i guess?
    [FieldOffset(0x471)] public byte IsInAllianceRaid;
    [FieldOffset(0x472)] public byte IsPartyLeader;
    [FieldOffset(0x473)] public byte IsInCrossRealmParty;

    [FieldOffset(0x480), FixedSizeArray] internal FixedSizeArray6<CrossRealmGroup> _crossRealmGroups;

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

    [MemberFunction("48 89 5C 24 ?? 48 89 7C 24 ?? 4C 8B 15")]
    public static partial CrossRealmMember* GetMemberByEntityId(uint entityId);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 ?? 0F B6 5E")]
    public static partial bool IsContentIdInParty(ulong contentId);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x348)]
public unsafe partial struct CrossRealmGroup {
    [FieldOffset(0x00)] public byte GroupMemberCount;
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray8<CrossRealmMember> _groupMembers;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct CrossRealmMember {
    [FieldOffset(0x10)] public ulong ContentId;

    [FieldOffset(0x20)] public uint EntityId;

    [FieldOffset(0x28)] public byte Level;

    [FieldOffset(0x2A)] public short HomeWorld;
    [FieldOffset(0x2C)] public short CurrentWorld;
    [FieldOffset(0x2E)] public byte ClassJobId;

    [FieldOffset(0x33), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;

    [FieldOffset(0x58)] public byte* NameOverride;
    [FieldOffset(0x60)] public byte MemberIndex;
    [FieldOffset(0x61)] public byte GroupIndex;

    [FieldOffset(0x63)] public byte IsPartyLeader;
}
