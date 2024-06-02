using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyFreeCompanyCreate
//   Client::UI::Info::InfoProxyInvitedInterface
//     Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.FreeCompanyCreate)]
[GenerateInterop]
[Inherits<InfoProxyInvitedInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x118)]
public unsafe partial struct InfoProxyFreeCompanyCreate {
    [FieldOffset(0x048)] public Utf8String UnkString0;
    [FieldOffset(0x0B0)] public Utf8String UnkString1;
}
