using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.FriendList)]
[StructLayout(LayoutKind.Explicit, Size = 0x3AD0)]
public unsafe partial struct InfoProxyFriendList {
    [FieldOffset(0x00)] public InfoProxyCommonList InfoProxyCommonList;
    [FieldOffset(0x0D8)] public Utf8String Str2;
    [FieldOffset(0x140)] public Utf8String Str3;
    //NExt 2: Set when seleccting a player (Name + 02 12 02 59 03 + WorldName)
    [FieldOffset(0x1A8)] public Utf8String Str4;
    [FieldOffset(0x210)] public Utf8String Str5;
    [FixedSizeArray<StrBuf>(200)]
    [FieldOffset(0x278)] public fixed byte Names[200 * 0x40];
    //3478
    [FieldOffset(0x3798)] public fixed byte Unk3798[800];


    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public unsafe partial struct StrBuf {
        [FieldOffset(0x00)] public fixed byte Data[64];
    }
}
