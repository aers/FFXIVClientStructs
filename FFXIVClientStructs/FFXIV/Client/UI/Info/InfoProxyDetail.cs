namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyDetail
//   Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.Detail)]
[GenerateInterop]
[Inherits<InfoProxyInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x240)]
public unsafe partial struct InfoProxyDetail {
    [FieldOffset(0x28)] public DetailUpdateData UpdateData;

    [FieldOffset(0x100)] public Utf8String SearchComment;

    [FieldOffset(0x238)] public bool HasUpdateData;

    [MemberFunction("38 51 38 74 0A")]
    public partial void SetUpdateClassJobId(byte classJobId);

    [MemberFunction("48 39 51 30 74 0B")]
    public partial void SetUpdateLookingForPartyClassJobIdMask(ulong classJobIdMask);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 6C 24 ?? ?? ?? ?? 41 B1")]
    public partial void SetUpdateOnlineStatus(InfoProxyCommonList.CharacterData.OnlineStatus onlineStatus, bool skipAwayCheck = false);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5C 24 ?? 41 83 FE")]
    public partial void SetUpdateLanguageMask(InfoProxyCommonList.CharacterData.LanguageMask languageMask);

    [MemberFunction("E8 ?? ?? ?? ?? 33 D2 48 8B CF E8 ?? ?? ?? ?? C6 46 08 01"), GenerateStringOverloads]
    public partial void SetUpdateSearchComment(CStringPointer searchComment);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B D9 BF ?? ?? ?? ?? 8B C7")]
    public partial void SendOnlineStatusUpdate(uint onlineStatusId);

    /// <param name="updateData">The packet to send. If <c>null</c>, it will use <see cref="UpdateData"/>.</param>
    [MemberFunction("E8 ?? ?? ?? ?? C6 83 ?? ?? ?? ?? ?? 40 84 FF")]
    public partial void SendUpdateData(DetailUpdateData* updateData = null);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 4C 8B 49 28 48 8B D9")]
    public partial void RefreshOnlineStatus();

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xD8)]
    public partial struct DetailUpdateData {
        [FieldOffset(0x00)] public InfoProxyCommonList.CharacterData.OnlineStatus OnlineStatusMask;
        [FieldOffset(0x08)] public ulong LookingForPartyClassJobIdMask;
        [FieldOffset(0x10)] public byte ClassJobId;
        [FieldOffset(0x11)] public InfoProxyCommonList.CharacterData.LanguageMask LanguageMask;
        [FieldOffset(0x12), FixedSizeArray(isString: true)] internal FixedSizeArray193<byte> _searchComment;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x1AC)]
    /// <remarks> Packet for <see cref="InfoProxyDetail.AddData"/> </remarks>
    public partial struct AddDataPacket {
        [FieldOffset(0x000)] public ulong ContentId;
        [FieldOffset(0x010)] public ulong LookingForPartyClassJobIdMask;
        [FieldOffset(0x018)] public CrestData FCCrest;
        [FieldOffset(0x020)] private ushort Unk020;
        [FieldOffset(0x022)] public ushort WorldId;
        [FieldOffset(0x024), FixedSizeArray(isString: true)] internal FixedSizeArray193<byte> _searchComment;
        [FieldOffset(0x0E5), FixedSizeArray(isString: true)] internal FixedSizeArray22<byte> _fcName;
        /// <remarks> [0] Unused, [1] Maelstrom, [2] Order of the Twin Adder, [3] Immortal Flames </remarks>
        [FieldOffset(0x0FB), FixedSizeArray] internal FixedSizeArray4<byte> _grandCompanyRanks;
        [FieldOffset(0x100), FixedSizeArray] internal FixedSizeArray43<ClassJobEntry> _classJobEntries;

        [StructLayout(LayoutKind.Explicit, Size = 4)]
        public struct ClassJobEntry
        {
            [FieldOffset(0)] public byte ClassJobId;
            [FieldOffset(1)] private byte Unk1;
            [FieldOffset(2)] public ushort Level;
        }
    }
}
