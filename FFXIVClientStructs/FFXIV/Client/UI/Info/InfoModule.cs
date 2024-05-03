using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[StructLayout(LayoutKind.Explicit, Size = 0x1C70)]
public unsafe partial struct InfoModule {
    public static InfoModule* Instance() => UIModule.Instance()->GetInfoModule();

    [FieldOffset(0x1978)] public fixed long InfoProxyArray[34];
    [FieldOffset(0x1A88)] public ulong LocalContentId;
    [FieldOffset(0x1A90)] public Utf8String LocalCharName;
    [FieldOffset(0x1AF8)] public Utf8String UnkString1;
    [FieldOffset(0x1B60)] public Utf8String UnkString2;
    [FieldOffset(0x1BC8)] public Utf8String UnkString3;
    [FieldOffset(0x1C30)] public ulong OnlineStatusFlags;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 55 68")]
    public partial InfoProxyInterface* GetInfoProxyById(InfoProxyId id);

    [Obsolete("Use GetInfoProxyById(InfoProxyId)")]
    public InfoProxyInterface* GetInfoProxyById(uint id)
        => GetInfoProxyById((InfoProxyId)id);

    [MemberFunction("E8 ?? ?? ?? ?? 49 83 C9 FF 48 8D 8C 24")]
    public partial byte* GetLocalCharacterName();

    [MemberFunction("E8 ?? ?? ?? ?? 48 39 03")]
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
    Party = 0,
    Party2 = 1,
    PartyInvite = 2,
    LinkShell = 3,
    LinkShellMember = 4,
    Blacklist = 5,
    FriendList = 6,
    FriendList2 = 7,
    Letter = 8,
    PlayerSearch = 9,
    SearchComment = 10, //0xa
    ItemSearch = 11,
    CatalogSearch = 12,
    FreeCompany = 13,
    FreeCompanyCreate = 14,
    FreeCompanyMember = 15,
    FreeCompanyMember2 = 16,
    //OTherFCStuff = 17,
    LinkShellChat = 18,
    CrossRealmParty = 19,
    CrossWorldLinkShell = 29,
    CrossWorldLinkShellMember = 30,
    CircleList = 31,
    Circle = 32,
    CircleFinder = 33

}
