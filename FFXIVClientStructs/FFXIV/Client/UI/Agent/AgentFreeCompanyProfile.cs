using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.FreeCompanyProfile)]
[StructLayout(LayoutKind.Explicit, Size = 0x27C)]
public unsafe partial struct AgentFreeCompanyProfile {
    [FieldOffset(0x000)] public AgentInterface AgentInterface;
    //First = 0xe0 00 00 00 00 00 00 00
    //Next were the same as AgentINspect GuildStruct 0x08
    //These (in Decimal) are the same as used on the Lodestone
    [FieldOffset(0x028)] public long RequestID;
    [FieldOffset(0x030)] public long UnkID2;
    [FieldOffset(0x038)] public long UnkID3;
    [FieldOffset(0x040)] public long UnkID4;
    [FieldOffset(0x048)] public CrestData Crest;
    //Estate Data
    [FieldOffset(0x050)] public ushort PlotNumber; //Starts at 0 (+1 in UI) Only last 6 bits are valid
    [FieldOffset(0x052)] public ushort WardNumber; //Starts at 0 (+1 in UI) Only last 6 bits are valid
    [FieldOffset(0x054)] public ushort EstateZone;
    [FieldOffset(0x056)] public ushort World;
    //4 byte unknown Set to 0xe0000000 in ctor
    [FieldOffset(0x05C)] public uint FoundationDate; //UNIX Timestamp
    [FieldOffset(0x060)] public short MemberCount;
    [FieldOffset(0x062)] public short MembersOnline;
    [FieldOffset(0x064)] public FCProfile Profile;
    [FieldOffset(0x06A)] public GrandCompany GrandCompany;
    [FieldOffset(0x06C)] public byte Rank;
    [FieldOffset(0x06D)] public byte Reputation;
    //2 byte unkown
    [FieldOffset(0x070)] public Utf8String Name;
    [FieldOffset(0x0D8)] public Utf8String Tag;
    [FieldOffset(0x140)] public Utf8String Master;
    [FieldOffset(0x1A8)] public Utf8String Slogan;
    [FieldOffset(0x210)] public Utf8String EstateName;
    //4 Status bytes
    [FieldOffset(0x278)] public byte Unk278;
    [FieldOffset(0x279)] public byte Unk279;
    [FieldOffset(0x27A)] public byte Unk27A;
    [FieldOffset(0x27B)] public byte Unk27B;

    [StructLayout(LayoutKind.Explicit, Size = 0x6)]
    public struct FCProfile {
        //the bit offsets represents RowID in FCPRofile (like in 1st bit set = row 0, 2nd bit set = row 1,...)
        [FieldOffset(0x0)] public FocusType Focus;
        [FieldOffset(0x2)] public SeekingType Seeking;
        [FieldOffset(0x4)] public ActiveType Active;
        [FieldOffset(0x5)] public RecruitmentType Recruitment;

        public enum SeekingType : ushort {
            None = 0,
            Tank = 1,
            HEaler = 2,
            DPS = 4,
            Crafter = 8,
            Gatherer = 16,
        }
        public enum FocusType : ushort {
            None = 0,
            RolePlaying = 1,
            Leveling = 2,
            Casual = 4,
            Hardcore = 8,
            GuildHeist = 16,
            Trials = 32,
            Dungeons = 64,
            Raids = 128,
            PvP = 256,
        }
        public enum ActiveType : byte {
            None = 0,
            Weekdays = 1,
            Weekends = 2,
            Always = 3,
        }
        public enum RecruitmentType : byte {
            Closed = 0,
            Open = 1
        }
    }
}
public enum GrandCompany : byte {
    None = 0,
    Maelstrom = 1,
    TwinAdder = 2,
    ImmortalFlames = 3,
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public struct CrestData {
    //8 bits: Charge
    //6 bits: Ordinary
    //6 bits: Escutcheon
    //2 Bits unused
    //3 bits Charge Color
    //7 bits unused
    //4 bits OrdinaryColor1
    //4 bits OrdinaryColor2
    [FieldOffset(0x0), CExportIgnore] public ulong Data;
    [FieldOffset(0x0)] public byte Charge;
    [FieldOffset(0x4)] public byte OrdinaryTinctures;

    public byte Ordinary {
        get => (byte)((Data >> 8) & 0x3F);
        set => Data = (Data & 0xFFFFC0FF) + (ulong)((value & 0x3F) << 8);
    }
    public byte Escutcheon {
        get => (byte)((Data >> 0xE) & 0x3F);
        set => Data = (Data & 0xFFF03FFF) + (ulong)((value & 0x3F) << 0xE);
    }
    public byte ChargeColor {
        get => (byte)((Data >> 0x16) & 0x7);
        set => Data = (Data & 0xFE3FFFFF) + (ulong)((value & 0x7) << 0x16);
    }
    public byte OrdinaryTincture1 {
        get => (byte)(OrdinaryTinctures & 0xF);
        set => OrdinaryTinctures = (byte)((OrdinaryTinctures & 0xF0) + (value & 0x0F));
    }
    public byte OrdinaryTincture2 {
        get => (byte)((OrdinaryTinctures >> 4) & 0xF);
        set => OrdinaryTinctures = (byte)(((value & 0x0F) << 4) + (OrdinaryTinctures & 0x0F));
    }
}
