using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[StructLayout(LayoutKind.Explicit, Size = 0x110)]
[GenerateInterop]
[Inherits<InfoProxyInterface>]
public unsafe partial struct InfoProxy28 {

    [FieldOffset(0x038)] public Utf8String UnkString0;
    [FieldOffset(0x0A0)] public Utf8String UnkString1;
}
