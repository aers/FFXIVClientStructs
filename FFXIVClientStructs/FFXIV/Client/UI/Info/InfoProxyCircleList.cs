using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.CircleList)]
[StructLayout(LayoutKind.Explicit, Size = 0x1E0)]
public unsafe partial struct InfoProxyCircleList {
    [FieldOffset(0x000)] public InfoProxyInterface InfoProxyInterface;
    //0x20 bytes
    [FieldOffset(0x038)] public Utf8String UnkString0;
    [FieldOffset(0x0A0)] public Utf8String UnkString1;
    [FieldOffset(0x108)] public void* UnkObj108;
    //0x18 bytes
    [FieldOffset(0x128)] public Utf8String UnkString2;
    // 8 bytes
    [FieldOffset(0x198)] public void* UnkObj198;
    //8 bytes
    [FieldOffset(0x1A8)] public void* UnkObj1A8;
    //0x30 bytes
}
