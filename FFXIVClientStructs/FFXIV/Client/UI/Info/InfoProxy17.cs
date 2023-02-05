using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;
[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct InfoProxy17
{
    [FieldOffset(0x00)] public InfoProxyUnkInterface InfoProxyInterface;
    [FieldOffset(0x38)] public Utf8String Unk38;
    [FieldOffset(0xA0)] public Utf8String UnkA0;

}
