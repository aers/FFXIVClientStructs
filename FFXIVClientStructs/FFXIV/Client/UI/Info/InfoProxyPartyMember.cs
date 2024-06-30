namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyPartyMember
//   Client::UI::Info::InfoProxyCommonList
//     Client::UI::Info::InfoProxyPageInterface
//       Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.PartyMember)]
[GenerateInterop]
[Inherits<InfoProxyCommonList>]
[StructLayout(LayoutKind.Explicit, Size = 0x360)]
public unsafe partial struct InfoProxyPartyMember;
