using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;
[InfoProxy(InfoProxyId.Circle)]
[StructLayout(LayoutKind.Explicit, Size = 0x6BB8)]
public unsafe partial struct InfoProxyCircle
{
    [FieldOffset(0x0000)] public InfoProxyInterface InfoProxyInterface;
    [FieldOffset(0x0038)] public Utf8String Unk0038;
    [FieldOffset(0x00A0)] public Utf8String Unk00A0;
    [FieldOffset(0x0128)] public Utf8String Unk0128;

}
