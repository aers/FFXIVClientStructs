using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[StructLayout(LayoutKind.Explicit, Size = 0x418)]
public unsafe partial struct InfoProxy25 {
    [FieldOffset(0x00)] public InfoProxyInterface InfoProxyInterface;

    [FieldOffset(0x038)] public Utf8String UnkString0;
    [FieldOffset(0x0A0)] public Utf8String UnkString1;
    [FieldOffset(0x108)] public AtkEventListener Unk108;

    [FieldOffset(0x3B0)] public AtkEventTarget Unk3B0;
}
