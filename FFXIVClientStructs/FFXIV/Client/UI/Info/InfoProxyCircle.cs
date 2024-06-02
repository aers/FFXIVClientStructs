using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyCircle
//   Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.Circle)]
[GenerateInterop]
[Inherits<InfoProxyInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x6BB8)]
public unsafe partial struct InfoProxyCircle;
