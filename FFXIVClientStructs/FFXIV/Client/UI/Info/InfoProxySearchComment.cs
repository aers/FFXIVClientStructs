using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.SearchComment)]
[StructLayout(LayoutKind.Explicit, Size = 0x240)]
public unsafe partial struct InfoProxySearchComment {
    [FieldOffset(0x00)] public InfoProxyInterface InfoProxyInterface;
    [FieldOffset(0x20)] public void* Unk20;
    [FieldOffset(0x3a)] public fixed byte SearchCommentAsByteArr[62]; //Length is guessed
    //136 bytes
    [FieldOffset(0x100)] public Utf8String SearchComment;
    [FieldOffset(0x168)] public Utf8String UnkString1;
    [FieldOffset(0x1D0)] public Utf8String UnkString2;
    //8 bytes
}
