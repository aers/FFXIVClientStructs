using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyCircleList
//   Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.CircleList)]
[GenerateInterop]
[Inherits<InfoProxyInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x1E0)]
public unsafe partial struct InfoProxyCircleList;
