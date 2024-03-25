namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.FreeCompanyMember)]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe partial struct InfoProxyFreeCompanyMember {
    [FieldOffset(0x00)] public InfoProxyCommonList InfoProxyCommonList;
    [FieldOffset(0xB8)] public ulong FreeCompanyID;
}
