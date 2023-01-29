using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;
[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct InfoProxy01
{
    [FieldOffset(0x00)] public InfoProxyInterface InfoProxyInterface;
    [FieldOffset(0x20)] public Utf8String Unk20;

}
