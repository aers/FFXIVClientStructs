using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.Blacklsit)]
[StructLayout(LayoutKind.Explicit, Size = 0x1a00)]
public unsafe partial struct InfoProxyBlacklsit
{
    [FieldOffset(0x00)] public InfoProxyInterface InfoProxyInterface;
    [FieldOffset(0x20)] public fixed long ContentIdArray[200];
    [FieldOffset(0x660)] public Utf8String Unk660;
    [FieldOffset(0x6C8)] public Utf8String Unk6C8;

}
