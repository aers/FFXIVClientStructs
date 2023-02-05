using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[StructLayout(LayoutKind.Explicit, Size = 0x148)]
public unsafe partial struct InfoProxy02
{
    [FieldOffset(0x000)] public InfoProxyUnk3Interface InfoProxyUnk3Interface;

    [FieldOffset(0x048)] public Utf8String UnkString0;
    [FieldOffset(0x0B0)] public Utf8String UnkString1;
}
