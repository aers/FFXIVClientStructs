using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.CatalogSearch)]
[StructLayout(LayoutKind.Explicit, Size = 0x3C8)]
[GenerateInterop]
[Inherits<InfoProxyPageInterface>]
public unsafe partial struct InfoProxyCatalogSearch {

    [FieldOffset(0x028)] public Utf8String Query;
    //These seem to be only used when non partial matching
    [FieldOffset(0x90), FixedSizeArray] internal FixedSizeArray20<Entry> _entries;

    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct Entry {
        [FieldOffset(0x0)] public uint ItemId;
        [FieldOffset(0x4)] public uint Count;
    }
}
