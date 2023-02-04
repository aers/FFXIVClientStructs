using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.FreeCompany)]
[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct InfoProxyFreeCompany
{
    [FieldOffset(0x00)] public InfoProxyInterface InfoProxyInterface;
    [FieldOffset(0x20)] public void* Unk20; //Low adress probably high in hierarchy
    [FieldOffset(0x30)] public ulong ID;
    [FieldOffset(0x44)] public GrandCompany GrandCompany;
    [FieldOffset(0x46)] public uint HomeWorldID;
    [FieldOffset(0x59)] public byte Rank;
    [FieldOffset(0x70)] public CrestData Crest;
    [FieldOffset(0x78)] public ushort OnlineMembers;
    [FieldOffset(0x7A)] public ushort TotalMembers;
    [FieldOffset(0x7C)] public fixed byte Name[22];
    [FieldOffset(0x93)] public fixed byte Master[60];
    [FieldOffset(0xD0)] public Utf8String UnkD0;
    [FieldOffset(0x138)] public byte ActiveListItemNum; //0=Topics, 1 = Members, ....
    [FieldOffset(0x139)] public byte MemberTabIndex;
    [FieldOffset(0x13E)] public byte InfoTabIndex;
    [FixedSizeArray<RankData>(14)]
    [FieldOffset(0x198)] public fixed byte RankArray[14 * 0x58];

    //0x100fc0d0
    //40 53 48 81 EC 80 0F 00 00 48 8B 05 E0 47 F9 01 48 33 C4 48 89 84 24 70 0F 00 00 48 8B 0D E6 1E FB 01 8B DA
    [MemberFunction("e8 dc 99 47 ff")]
    public partial void RequestDataForCharacter(uint objectID);

    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public partial struct RankData
    {
        [FieldOffset(0x00)] public ushort MemberCount;
        [FieldOffset(0x02)] public byte RankNumber;
        [FieldOffset(0x03)] public fixed byte Name[32];//32 is an educated guessed
    }
}
