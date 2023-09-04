namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.PlayerSearch)]
[StructLayout(LayoutKind.Explicit, Size = 0x178)]
public unsafe partial struct InfoProxySearch {
    [FieldOffset(0x00)] public InfoProxyCommonList InfoProxyCommonList;
}
