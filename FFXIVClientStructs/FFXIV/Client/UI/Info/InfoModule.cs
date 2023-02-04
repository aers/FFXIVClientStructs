using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[StructLayout(LayoutKind.Explicit, Size = 0x1C70)]
public unsafe partial struct InfoModule
{
    [FieldOffset(0x1978)] public fixed long InfoProxyArray[34];
    [FieldOffset(0x1A88)] public ulong LocalContentId;
    [FieldOffset(0x1A90)] public Utf8String UnkString0;
    [FieldOffset(0x1AF8)] public Utf8String UnkString1;
    [FieldOffset(0x1B60)] public Utf8String UnkString2;
    [FieldOffset(0x1BC8)] public Utf8String UnkString3;

    public InfoProxyInterface* GetInfoProxyById(InfoProxyId id)
        => GetInfoProxyById((uint)id);

    [MemberFunction("e8 7e 7c e8 ff")]
    public partial InfoProxyInterface* GetInfoProxyById(uint ID);
}
public enum InfoProxyId : uint
{
    Party = 0,
    Blacklsit = 5,
    FriendList = 6,
    Mail = 8,
    SearchComment = 10, //0xa
    FreeCompany = 13, //0xd
    CrossRealmParty = 19, //0x13
    CrossWorldLinkShell = 29, //0x1D
}