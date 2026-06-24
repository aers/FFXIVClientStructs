namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxySearch
//   Client::UI::Info::InfoProxyCommonList
//     Client::UI::Info::InfoProxyPageInterface
//       Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.PlayerSearch)]
[GenerateInterop]
[Inherits<InfoProxyCommonList>]
[StructLayout(LayoutKind.Explicit, Size = 0x190)]
public unsafe partial struct InfoProxySearch {
    [FieldOffset(0xD0)] public byte SearchType;
    [FieldOffset(0xD8)] public ulong ContentId; // set to ulong.MaxValue to disable
    [FieldOffset(0xE0)] public ushort SearchArea; // TerritoryTypeId, 0 = all areas
    [FieldOffset(0xE2)] public ushort SearchSubArea;
    [FieldOffset(0xE8)] public ulong ClassFilter; // set to ulong.MaxValue to disable
    [FieldOffset(0xF0)] public ulong ClassFilterHigh; // set to ulong.MaxValue to disable
    [FieldOffset(0x100), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _searchName;
    [FieldOffset(0x128)] public ushort SearchWorld; // 0 = current world
    [FieldOffset(0x160)] public uint LevelMin;
    [FieldOffset(0x164)] public uint LevelMax;
    [FieldOffset(0x180)] public byte LanguageMask; // bit0=JP, bit1=EN, bit2=DE, bit3=FR
    [FieldOffset(0x184)] public byte OnlineStatusMask; // bit0=Online, bit1=Busy, bit2=LookingForParty
}
