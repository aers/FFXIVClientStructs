using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;
[StructLayout(LayoutKind.Explicit, Size = 0x3C8)]
public unsafe partial struct InfoProxy12
{
    [FieldOffset(0x000)] public InfoProxyInterface InfoProxyInterface;

    [FieldOffset(0x028)] public Utf8String UnkString;
}
