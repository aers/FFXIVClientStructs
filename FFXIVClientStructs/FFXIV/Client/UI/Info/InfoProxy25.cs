using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[GenerateInterop]
[Inherits<InfoProxyInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x188)]
public unsafe partial struct InfoProxy25 {
    [FieldOffset(0x038)] private Utf8String UnkString0;
    [FieldOffset(0x0A0)] private Utf8String UnkString1;
    [FieldOffset(0x108)] private Utf8String UnkString2;

}
