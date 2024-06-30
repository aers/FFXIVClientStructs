using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoModule
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1C78)]
public unsafe partial struct InfoModule {
    public static InfoModule* Instance() => UIModule.Instance()->GetInfoModule();

    [FieldOffset(0x1978), FixedSizeArray] internal FixedSizeArray35<Pointer<InfoProxyInterface>> _infoProxies;
    [FieldOffset(0x1A90)] public ulong LocalContentId;
    [FieldOffset(0x1A98)] public Utf8String LocalCharName;
    [FieldOffset(0x1B00)] public Utf8String UnkString1;
    [FieldOffset(0x1B68)] public Utf8String UnkString2;
    [FieldOffset(0x1BD0)] public Utf8String UnkString3;
    [FieldOffset(0x1C40)] public ulong OnlineStatusFlags;

    [MemberFunction("E8 ?? ?? ?? ?? 45 85 E4 7E 5C")]
    public partial InfoProxyInterface* GetInfoProxyById(InfoProxyId id);

    [MemberFunction("E8 ?? ?? ?? ?? 49 C7 C1 ?? ?? ?? ?? 48 8D 8C 24 ?? ?? ?? ??")]
    public partial byte* GetLocalCharacterName();

    [MemberFunction("E8 ?? ?? ?? ?? 49 39 07")]
    public partial ulong GetLocalContentId();

    /// <summary>
    /// Checks if the local player has a specific online status set.
    /// </summary>
    /// <param name="id">The RowId in the OnlineStatus sheet.</param>
    [MemberFunction("48 8B 81 ?? ?? ?? ?? 0F B6 CA 48 D3 E8")]
    public partial bool IsOnlineStatusSet(uint id);

    /// <summary>
    /// Sets the local player's online status to the specified flag bitmask.
    /// Sent by the server; devs should not call this manually. May be called multiple times.
    /// </summary>
    /// <param name="flags">A bitfield representing set flags.</param>
    [MemberFunction("48 89 91 ?? ?? ?? ?? 48 8B 89 ?? ?? ?? ?? 48 85 C9 0F 85")]
    public partial void SetOnlineStatusFlags(ulong flags);

    /// <summary>
    /// Checks if the local player is in a cross world duty.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 44 8B 8C 24 ?? ?? ?? ?? 84 C0")]
    public partial bool IsInCrossWorldDuty();
}

public enum InfoProxyId : uint {
    //ShellCommandDice refers to  3, 13(Fc), 18 ,24
    PartyMember = 0,
    PartyMemberMji = 1,
    PartyInvite = 2,
    Linkshell = 3,
    LinkshellMember = 4,
    Blacklist = 5,
    FriendList = 6,
    FriendListMji = 7,
    Letter = 8,
    PlayerSearch = 9,
    Detail = 10,
    ItemSearch = 11,
    CatalogSearch = 12,
    FreeCompany = 13,
    FreeCompanyInvite = 14,
    FreeCompanyMember = 15,
    FreeCompanyMemberMji = 16,
    // FreeCompanyMemberUnkown = 17,
    FreeCompanyCreate = 18,
    Chat = 19,
    CrossRealmParty = 20,
    NoviceNetwork = 21,
    NoviceNetworkMember = 22,
    NoviceNetworkMentor = 23,
    CrossWorldLinkshell = 30,
    CrossWorldLinkshellMember = 31,
    CircleList = 32,
    Circle = 33,
    CircleFinder = 34
}
