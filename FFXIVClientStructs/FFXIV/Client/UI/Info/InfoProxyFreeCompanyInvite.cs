using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyFreeCompanyInvite
//   Client::UI::Info::InfoProxyInvitedList
//     Client::UI::Info::InfoProxyInterface
//   Client::UI::Info::InfoProxyInvitedInterface
[InfoProxy(InfoProxyId.FreeCompanyInvite)]
[GenerateInterop]
[Inherits<InfoProxyInvitedList>, Inherits<InfoProxyInvitedInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x118)]
public unsafe partial struct InfoProxyFreeCompanyInvite {
    [FieldOffset(0x048)][Experimental("UnknownField")] public Utf8String UnkString0;
    [FieldOffset(0x0B0)][Experimental("UnknownField")] public Utf8String UnkString1;
}
