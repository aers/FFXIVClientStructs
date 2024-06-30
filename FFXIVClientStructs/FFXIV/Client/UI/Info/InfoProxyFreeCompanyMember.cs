namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyFreeCompanyMember
//   Client::UI::Info::InfoProxyCommonList
//     Client::UI::Info::InfoProxyPageInterface
//       Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.FreeCompanyMember)]
[GenerateInterop]
[Inherits<InfoProxyCommonList>]
[StructLayout(LayoutKind.Explicit, Size = 0xE8)]
public unsafe partial struct InfoProxyFreeCompanyMember {
    [FieldOffset(0xD0)] public ulong FreeCompanyId;
}
