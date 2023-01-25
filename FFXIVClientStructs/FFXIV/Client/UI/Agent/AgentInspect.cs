using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.Inspect)]
[StructLayout(LayoutKind.Explicit, Size = 0x554)]
public unsafe partial struct AgentInspect
{
    //Notes to INfoProxies:
    //0xa used for DeepDungeon
    //0xd
    public static AgentInspect* Instance() =>
        (AgentInspect*)Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(AgentId.Inspect);

    [FieldOffset(0x000)] public AgentInterface AgentInterface;
    //First byte seems to be a bit field
    // [7 | 6 | 5 | 4 | 3 | 2 | 1 | 0 ]
    // None: 7,6,5 set
    // REatiner/Chocobo: 6 is set
    // Player: 4 is set
    [FieldOffset(0x028)] public uint RequestObjectID;
    [FieldOffset(0x02C)] public uint RequestSearchCommentOID; //40007F3D for chocobo
    [FieldOffset(0x030)] public uint RequestFreeCompanyOID;   //40007F3D for chocobo
    [FieldOffset(0x034)] public uint CurrentObjectID;
    [FieldOffset(0x038)] public Utf8String SearchComment;
    [FieldOffset(0x0a0)] public Utf8String UnkString1;
    [FieldOffset(0x108)] public Utf8String PsnName; //OnlineID: XXXXXXXXX
    [FieldOffset(0x170)] public Utf8String ChocoboBarding1;
    [FieldOffset(0x1D8)] public Utf8String ChocoboBarding2;
    [FieldOffset(0x240)] public Utf8String ChocoboBarding3;
    [FixedSizeArray<ItemData>(0xd)]
    [FieldOffset(0x2A8)] public fixed byte Items[0xd * 0x28]; //Size: 0x208
    [FieldOffset(0x4B0)] public byte Unknown4b0; //Status or bool
    [FieldOffset(0x4B0)] public FreeCompanyData FreeCompany;
    [FieldOffset(0x536)] public short UnkObj536; //Maybe part of FC
    //Status fields
    //0: Nothing to do 1: Fetching Data; 2: Data ready (Fills window) 3: Probably failure
    [FieldOffset(0x538)] public uint FetchCharacterDataStatus;
    [FieldOffset(0x53c)] public uint FetchSearchCommentStatus;
    [FieldOffset(0x540)] public uint FetchFreeCompanyStatus;
    [FieldOffset(0x544)] public uint UnkObj544; //Probably some status/type seen: 0,1 Set in Show : 0
    [FieldOffset(0x548)] public void* UnkObj548; //InfoProxy 0xa Gets SerachComment
    [FieldOffset(0x550)] public void* UnkObj550; //INfoPRox 0xd Gets FreeCompanyData

    [StructLayout(LayoutKind.Explicit, Size = 0x86)]
    public struct FreeCompanyData
    {
        [FieldOffset(0x00)] public byte Unkown4b0; //Maybe FreeCompany get status 1=Finished
        [FieldOffset(0x01)] public bool IsPArtOfFreeCOmpany; //HasGuild???????? if 0 Client::UI::RaptureAtkModule.OpenAddon can be called without getting additional infos
        [FieldOffset(0x08)] public long ID;
        [FieldOffset(0x10)] public CrestData Crest;
        [FieldOffset(0x18)] public ushort MemberCount;
        [FieldOffset(0x1A)] public ushort GrandCompany;// 1=Maelstorm 2=TwinAdder 3=ImmortalFlames
        [FieldOffset(0x1c)] public ushort Unk1C;
        [FieldOffset(0x1E)] public Utf8String GuildName;
    }
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct ItemData
    {
        [FieldOffset(0x00)] public uint IconID;
        [FieldOffset(0x04)] public IconFlagsTopRight IconFlags1;
        [FieldOffset(0x05)] public ColorRGB Color;
        [FieldOffset(0x08)] public bool Filled;
        [FieldOffset(0x09)] public bool IsILevelSynced; //1 if Level < Level{Equip} So probably ILVSynced
        [FieldOffset(0x10)] public fixed short ModelMain[4];
        [FieldOffset(0x18)] public fixed short ModelSub[4];
        [FieldOffset(0x20)] public InventoryItem* Item; //Init 0 unsure
        [StructLayout(LayoutKind.Explicit)]
        public struct ColorRGB
        {
            [FieldOffset(0x0)] public byte B;
            [FieldOffset(0x1)] public byte G;
            [FieldOffset(0x2)] public byte R;
        }
        public enum IconFlagsTopRight
        {
            None = 0,
            Dyeable = 1,
            Glamoured = 4,
        }
    }
    public enum ItemDataFlags
    {
        None = 0,
        Filled = 8,
    }

    public void ExamineCharacter(uint objectID)
    {
        RequestObjectID = objectID;
        RequestSearchCommentOID = objectID;
        RequestFreeCompanyOID = objectID;
        CurrentObjectID = 0xE0000000;
        AgentInterface.Show();
    }
}
