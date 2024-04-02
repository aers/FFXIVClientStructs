using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.CatalogSearch)]
[StructLayout(LayoutKind.Explicit, Size = 0x3C8)]
public unsafe partial struct InfoProxyCatalogSearch {
    [FieldOffset(0x000)] public InfoProxyPageInterface InfoProxyPageInterface;

    [FieldOffset(0x028)] public Utf8String Query;
    //These seem to be only used when non partial matching
    [FixedSizeArray<Entry>(20)]
    [FieldOffset(0x90)] public fixed byte Entries[20 * 0x8];

    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct Entry {
        [FieldOffset(0x0)] public uint ItemID;
        [FieldOffset(0x4)] public uint Count;
    }
}
