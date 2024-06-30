using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyFriendList
//   Client::UI::Info::InfoProxyCommonList
//     Client::UI::Info::InfoProxyPageInterface
//       Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.FriendList)]
[GenerateInterop]
[Inherits<InfoProxyCommonList>]
[StructLayout(LayoutKind.Explicit, Size = 0x3AE8)]
public unsafe partial struct InfoProxyFriendList {
    [FieldOffset(0xF0)] public Utf8String Str2;
    [FieldOffset(0x158)] public Utf8String Str3;
    //NExt 2: Set when seleccting a player (Name + 02 12 02 59 03 + WorldName)
    [FieldOffset(0x1C0)] public Utf8String Str4;
    [FieldOffset(0x228)] public Utf8String Str5;
    [FieldOffset(0x290), FixedSizeArray] internal FixedSizeArray200<NameBuffer> _names;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct NameBuffer {
        [FieldOffset(0x00), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _value;
    }
}
