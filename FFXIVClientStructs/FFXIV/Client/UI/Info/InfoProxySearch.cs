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
    [FieldOffset(0xD0)] public byte LocationCount;
    [FieldOffset(0xD8)] public ulong JobMask; // 0xFFFFFFFFFFFFFFFF = all
    [FieldOffset(0xE0)] public ushort LevelMin;
    [FieldOffset(0xE2)] public ushort LevelMax;
    [FieldOffset(0xE8)] public byte LanguageMask; // bit1=JP, bit2=EN, bit3=DE, bit4=FR, 0xFF = all
    [FieldOffset(0xF0)] public byte GrandCompanyMask; // bit0=Maelstrom, bit1=TwinAdder, bit2=ImmortalFlames, 0xFF = all
    [FieldOffset(0xF8)] public ulong OnlineStatusMask; // 0 = unset (defaults to 1ul << 47 = Online only)
    [FieldOffset(0x100), FixedSizeArray] internal FixedSizeArray50<ushort> _locationIDs;
    [FieldOffset(0x164), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;
    [FieldOffset(0x184)] private uint Unk184;
    [FieldOffset(0x188)] private uint Unk188;
}
