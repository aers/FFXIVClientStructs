using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyDetail
//   Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.Detail)]
[GenerateInterop]
[Inherits<InfoProxyInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x240)]
public unsafe partial struct InfoProxyDetail {
    [FieldOffset(0x28)] public UpdateDataPacket UpdateData;

    [FieldOffset(0x100)] public Utf8String SearchComment;

    [FieldOffset(0x238)] public bool HasUpdateData;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xD8)]
    public partial struct UpdateDataPacket {
        [FieldOffset(0x00)] public InfoProxyCommonList.CharacterData.OnlineStatus OnlineStatusMask;
        [FieldOffset(0x08)] public ulong LookingForPartyClassJobIdMask;
        [FieldOffset(0x10)] public byte ClassJobId;
        [FieldOffset(0x11)] public InfoProxyCommonList.CharacterData.LanguageMask LanguageMask;
        [FieldOffset(0x12), FixedSizeArray(isString: true)] internal FixedSizeArray193<byte> _searchComment;
    }

    [MemberFunction("38 51 38 74 0A")]
    public partial void SetUpdateClassJobId(byte classJobId);

    [MemberFunction("48 39 51 30 74 0B")]
    public partial void SetUpdateLookingForPartyClassJobIdMask(ulong classJobIdMask);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 53 15")]
    public partial void SetUpdateOnlineStatus(InfoProxyCommonList.CharacterData.OnlineStatus onlineStatus, bool skipAwayCheck = false);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 53 16")]
    public partial void SetUpdateLanguageMask(InfoProxyCommonList.CharacterData.LanguageMask languageMask);

    [MemberFunction("E8 ?? ?? ?? ?? 33 D2 48 8B CF E8 ?? ?? ?? ?? 33 C0"), GenerateStringOverloads]
    public partial void SetUpdateSearchComment(byte* searchComment);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B D9 BF ?? ?? ?? ?? 8B C7")]
    public partial void SendOnlineStatusUpdate(uint onlineStatusId);

    /// <param name="updateData">The packet to send. If <c>null</c>, it will use <see cref="UpdateData"/>.</param>
    [MemberFunction("E8 ?? ?? ?? ?? C6 83 ?? ?? ?? ?? ?? 40 84 FF")]
    public partial void SendUpdateData(UpdateDataPacket* updateData = null);
}
