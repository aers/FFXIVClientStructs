using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[StructLayout(LayoutKind.Explicit, Size = 0x1C70)]
public unsafe partial struct InfoModule
{
    [FieldOffset(0x1978)] public fixed long InfoProxyArray[34];
    [FieldOffset(0x1A88)] public ulong LocalContentId;
    [FieldOffset(0x1A90)] public Utf8String LocalCharName;
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
    //3 refers to AgentChatLog
    //ShellCommandChatLinkShell refers to 3,18
    //Party Decline, PartyInv,PartyJoin  refer to 2
    //ShellCommandDice refers to  3, 13(Fc), 18 ,24
    //AgentChatLogvf9 refers to 18
    //15 and 16 are the same class
    Party = 0,
    Party2 = 1,
    Blacklist = 5,
    FriendList = 6,
    FriendList2 = 7,
    Mail = 8,
    SearchComment = 10, //0xa
    //Maybe Retainer(List) = 11, or gets something needed there
    FreeCompany = 13,
    OTherFCStuff = 17,
    CrossRealmParty = 19,
    CrossWorldLinkShellList = 29,
    CrossWorldLinkShell = 30,
    CircleList = 31,
    Circle = 32,
    CircleFinder = 33,

}