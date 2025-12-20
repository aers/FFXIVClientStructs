using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[GenerateInterop]
[Inherits<InfoProxyInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x448)]
public unsafe partial struct InfoProxy26 {
    [FieldOffset(0x038)] private Utf8String UnkString0;
    [FieldOffset(0x0A0)] private Utf8String UnkString1;
    [FieldOffset(0x108)] private AtkEventListener Unk108;

    [FieldOffset(0x3B0)] private AtkEventTarget Unk3B0;
}
