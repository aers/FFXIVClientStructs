namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.FreeCompanyMember)]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
[GenerateInterop]
[Inherits<InfoProxyCommonList>]
public unsafe partial struct InfoProxyFreeCompanyMember {
    [FieldOffset(0xB8)] public ulong FreeCompanyId;
}
