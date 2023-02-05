using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[StructLayout(LayoutKind.Explicit, Size = 0x1E8)]
public unsafe partial struct InfoProxy03
{
    [FieldOffset(0x000)] public InfoProxyInterface InfoProxyInterface;
    [FieldOffset(0x038)] public Utf8String UnkString0;
    [FieldOffset(0x0A0)] public Utf8String UnkString1;
}
