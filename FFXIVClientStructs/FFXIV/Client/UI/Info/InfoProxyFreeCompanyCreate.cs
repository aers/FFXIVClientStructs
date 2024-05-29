using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.FreeCompanyCreate)]
[StructLayout(LayoutKind.Explicit, Size = 0x118)]
[GenerateInterop]
[Inherits<InfoProxyInvitedInterface>]
public unsafe partial struct InfoProxyFreeCompanyCreate {
    [FieldOffset(0x048)] public Utf8String UnkString0;
    [FieldOffset(0x0B0)] public Utf8String UnkString1;
}
