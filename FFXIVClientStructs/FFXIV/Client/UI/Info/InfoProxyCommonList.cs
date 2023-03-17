using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct InfoProxyCommonList
{
    [FieldOffset(0x0)] public InfoProxyPageInterface InfoProxyPageInterface;
    [FieldOffset(0x20)] public Utf8String Unk20;
    [FieldOffset(0x88)] public byte Unk88; //Corresponding ATkModule NumberArrrayIndex
    [FieldOffset(0x89)] public byte Unk89; //Corresponding ATkModule StringArrrayIndex
    [FieldOffset(0x8A)] public ushort DataSize;
    [FieldOffset(0x8C)] public ushort DictSize;
    [FieldOffset(0x8E)] public ushort Unk8E; //10 * DataSize
    [FieldOffset(0x90)] public ushort Unk90; //10 * DataSize
    [Obsolete("Use DataSize or DictSize")]
    public ushort Size => DataSize;
    [Obsolete("Use GetEntry")]//2023-03-11
    [FieldOffset(0x98)] public CharacterArray* Data;
    [FieldOffset(0x98)] public CharacterData* CharData;
    [Obsolete("Use CharIndex")]//2023-03-11
    [FieldOffset(0xA0)] public CharacterDict* Dict;
    [FieldOffset(0xA0)] public CharIndexEntry* CharIndex;

    [MemberFunction("3B 51 10 ?? ?? 8B C2 48 8D 14 40 48 8B 81 98 00 00 00 48 C1 E2")]
    public partial long GetContentIDForEntry(uint idx);

    [MemberFunction("3B 51 10 ?? ?? 8B C2 48 8D 04 40 48 C1 E0 05 48 03 81 98 00 00 00")]
    public partial CharacterData* GetEntry(uint idx);

    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public struct CharacterData
    {
        [FieldOffset(0x00)] public long ContentId;
        //1 byte
        /// <summary>
        /// Values in Hex
        /// 0000 = Online
        /// 0010 = Busy
        /// 0040 = Playing Triple Triad
        /// 0080 = Viewing Cutscene
        /// 0200 = AFK
        /// 0400 = Camera Mode
        /// 4000 = RP
        /// 8000 = LFP
        /// </summary>
        [FieldOffset(0x09)] public ushort OnlineStatus;
        /// <summary>
        /// Values in Hex
        /// 02 = Waiting for DutyFinder
        /// 08 = Mentor
        /// 10 = PvE Mentor
        /// 20 = Trade Mentor
        /// 40 = PvPMentor
        /// 80 = Returner
        /// </summary>
        [FieldOffset(0x0B)] public byte MentorState;
        /// <summary>
        /// Values in Hex
        /// 01 = New Adventurer
        /// 10 = PartyLeader
        /// 20 = PartyMember
        /// 40 = Recruiting Memebers
        /// 80 = Party Member (Cross World)
        /// </summary>
        [FieldOffset(0x0C)] public byte PartyStatus;
        /// <summary>
        /// 08 = In duty
        /// </summary>
        [FieldOffset(0x0D)] public byte DutyStatus;
        //5 bytes
        [FieldOffset(0x13)] public byte Unk13; //Some sort of Status info
        [FieldOffset(0x14)] public byte DictIndex;
        [FieldOffset(0x16)] public ushort CurrentWorld;
        [FieldOffset(0x18)] public ushort HomeWorld;
        [FieldOffset(0x1A)] public ushort Location; //ZoneID
        [FieldOffset(0x1C)] public GrandCompany GrandCompany;
        /// <summary>
        /// Values in Dec
        /// 0 = JP
        /// 1 = EN
        /// 2 = DE
        /// 3 = FR
        /// </summary>
        [FieldOffset(0x1D)] public byte MainLanguage;
        /// <summary>
        /// Bitmask, Values in Dec
        /// 1 = JP
        /// 2 = EN
        /// 4 = DE
        /// 8 = FR
        /// </summary>
        [FieldOffset(0x1E)] public byte AvailableLanguages;
        [FieldOffset(0x21)] public byte Job;
        [FieldOffset(0x22)] public fixed byte Name[32];
        [FieldOffset(0x42)] public fixed byte FCTag[6];
    }
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct CharIndexEntry
    {
        [FieldOffset(0x0)] public long ContentID;

        [FieldOffset(0xA)] public ushort HomeWorld;
    }

    [Obsolete]//2023-03-11
    [StructLayout(LayoutKind.Explicit, Size = 0x318)]
    public partial struct CharacterDict
    {
        [FixedSizeArray<Entry>(512)]
        [FieldOffset(0x0)] public fixed byte Entries[512 * 0x10];
        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        public struct Entry
        {
            [FieldOffset(0x0)] public ulong ContentID;

            [FieldOffset(0xA)] public ushort HomeWorld;
        }
    }

    [Obsolete]//2023-03-11
    [StructLayout(LayoutKind.Explicit, Size = 0x4B00)]
    public partial struct CharacterArray
    {
        [FixedSizeArray<Entry>(200)]
        [FieldOffset(0x0)] public fixed byte Entries[200 * 0x60];

        [StructLayout(LayoutKind.Explicit, Size = 0x60)]
        public struct Entry
        {
            [FieldOffset(0x00)] public ulong ContentId;
            //1 byte
            /// <summary>
            /// Values in Hex
            /// 0000 = Online
            /// 0010 = Busy
            /// 0040 = Playing Triple Triad
            /// 0080 = Viewing Cutscene
            /// 0200 = AFK
            /// 0400 = Camera Mode
            /// 4000 = RP
            /// 8000 = LFP
            /// </summary>
            [FieldOffset(0x09)] public ushort OnlineStatus;
            /// <summary>
            /// Values in Hex
            /// 02 = Waiting for DutyFinder
            /// 08 = Mentor
            /// 10 = PvE Mentor
            /// 20 = Trade Mentor
            /// 40 = PvPMentor
            /// 80 = Returner
            /// </summary>
            [FieldOffset(0x0B)] public byte MentorState;
            /// <summary>
            /// Values in Hex
            /// 01 = New Adventurer
            /// 10 = PartyLeader
            /// 20 = PartyMember
            /// 40 = Recruiting Memebers
            /// 80 = Party Member (Cross World)
            /// </summary>
            [FieldOffset(0x0C)] public byte PartyStatus;
            /// <summary>
            /// 08 = In duty
            /// </summary>
            [FieldOffset(0x0D)] public byte DutyStatus;
            //6 bytes
            [FieldOffset(0x14)] public byte DictIndex;
            [FieldOffset(0x16)] public ushort CurrentWorld;
            [FieldOffset(0x18)] public ushort HomeWorld;
            [FieldOffset(0x1A)] public ushort Location; //ZoneID
            [FieldOffset(0x1C)] public GrandCompany GrandCompany;
            /// <summary>
            /// Values in Dec
            /// 0 = JP
            /// 1 = EN
            /// 2 = DE
            /// 3 = FR
            /// </summary>
            [FieldOffset(0x1D)] public byte MainLanguage;
            /// <summary>
            /// Bitmask, Values in Dec
            /// 1 = JP
            /// 2 = EN
            /// 4 = DE
            /// 8 = FR
            /// </summary>
            [FieldOffset(0x1E)] public byte AvailableLanguages;
            [FieldOffset(0x21)] public byte Job;
            [FieldOffset(0x22)] public fixed byte Name[32];
            [FieldOffset(0x42)] public fixed byte FCTag[6];
        }
    }
}
