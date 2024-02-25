using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.LinkShell)]
[StructLayout(LayoutKind.Explicit, Size = 0x1E8)]
public unsafe partial struct InfoProxyLinkShell {
    [FieldOffset(0x000)] public InfoProxyInterface InfoProxyInterface;
    [FieldOffset(0x038)] public Utf8String UnkString0;
    [FieldOffset(0x0A0)] public Utf8String UnkString1;

    [FixedSizeArray<Entry>(8)]
    [FieldOffset(0x108)] public fixed byte LinkShells[8 * 0x18];
    //0x20 bytes
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct Entry {

    }
}
