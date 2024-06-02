using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyCircleFinder
//   Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.CircleFinder)]
[GenerateInterop]
[Inherits<InfoProxyInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x1C8)]
public unsafe partial struct InfoProxyCircleFinder {
    [FieldOffset(0x180)] public AtkEventTarget AtkEventTarget0;
    //8 bytes
    [FieldOffset(0x190)] public AtkEventTarget AtkEventTarget1;
}
