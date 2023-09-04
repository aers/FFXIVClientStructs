using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.CircleFinder)]
[StructLayout(LayoutKind.Explicit, Size = 0x1C8)]
public unsafe partial struct InfoProxyCircleFinder {
    [FieldOffset(0x00)] public InfoProxyInterface InfoProxyInterface;

    [FieldOffset(0x0A0)] public Utf8String UnkString0;
    //8 bytes
    [FieldOffset(0x110)] public Utf8String UnkString1;
    //8 bytes
    [FieldOffset(0x180)] public AtkEventTarget AtkEventTarget0;
    //8 bytes
    [FieldOffset(0x190)] public AtkEventTarget AtkEventTarget1;
}
