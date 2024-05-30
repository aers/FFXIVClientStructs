using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.FriendList)]
[GenerateInterop]
[Inherits<InfoProxyCommonList>]
[StructLayout(LayoutKind.Explicit, Size = 0x3AD0)]
public unsafe partial struct InfoProxyFriendList {
    [FieldOffset(0x0D8)] public Utf8String Str2;
    [FieldOffset(0x140)] public Utf8String Str3;
    //NExt 2: Set when seleccting a player (Name + 02 12 02 59 03 + WorldName)
    [FieldOffset(0x1A8)] public Utf8String Str4;
    [FieldOffset(0x210)] public Utf8String Str5;
    [FieldOffset(0x278), FixedSizeArray] internal FixedSizeArray200<NameBuffer> _names;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct NameBuffer {
        [FieldOffset(0x00), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _value;
    }
}
