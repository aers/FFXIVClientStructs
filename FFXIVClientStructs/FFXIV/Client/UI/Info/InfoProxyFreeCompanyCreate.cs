using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyFreeCompanyCreate
//   Client::UI::Info::InfoProxyInterface
//   Client::UI::Info::InfoProxyInvitedInterface
[InfoProxy(InfoProxyId.FreeCompanyCreate)]
[GenerateInterop]
[Inherits<InfoProxyInterface>, Inherits<InfoProxyInvitedInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x1F8)]
public unsafe partial struct InfoProxyFreeCompanyCreate {
    //0x20 bytes
    [FieldOffset(0x38)] public Utf8String UnkString0;
    [FieldOffset(0xA0)] public Utf8String UnkString1;
}
