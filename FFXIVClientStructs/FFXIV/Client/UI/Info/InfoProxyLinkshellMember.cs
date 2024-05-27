namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.LinkShellMember)]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe partial struct InfoProxyLinkshellMember {
    [FieldOffset(0x00)] public InfoProxyCommonList InfoProxyCommonList;
}
