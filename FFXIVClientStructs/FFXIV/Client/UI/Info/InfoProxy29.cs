using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[GenerateInterop]
[Inherits<InfoProxyInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public unsafe partial struct InfoProxy29 {

    [FieldOffset(0x038)] private Utf8String UnkString0;
    [FieldOffset(0x0A0)] private Utf8String UnkString1;
}
