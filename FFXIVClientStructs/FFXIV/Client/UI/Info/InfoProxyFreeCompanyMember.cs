namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.FreeCompanyMember)]
[GenerateInterop]
[Inherits<InfoProxyCommonList>]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe partial struct InfoProxyFreeCompanyMember {
    [FieldOffset(0xB8)] public ulong FreeCompanyId;
}
