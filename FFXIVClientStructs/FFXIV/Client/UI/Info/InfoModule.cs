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
    public partial InfoProxyInterface* GetInfoProxyById(uint id);
}
public enum InfoProxyId : uint
{
    //ShellCommandChatLinkShell = 3,18
    //Party Decline, PartyInv,PArtyJoin,  = 2
    //ShellCommandDice = FC, 0x18, 3, 0x12
    //AgentChatLogvf9 = 0x12
    //15 and 16 are the same class
    Party = 0,
    Party2 = 1,
    Blacklist = 5,
    FriendList = 6,
    FriendList2 = 6,
    Mail = 8,
    SearchComment = 10, //0xa
    Retainer = 11, //0xb or List
    FreeCompany = 13, //0xd
    OTherFCStuff = 17, //0x11
    CrossRealmParty = 19, //0x13
    CrossWorldLinkShellList = 29, //0x1D
    CrossWorldLinkShell = 30, //0x1E
    CircleList = 31,
    Circle = 32,
    CircleFinder = 33,

}