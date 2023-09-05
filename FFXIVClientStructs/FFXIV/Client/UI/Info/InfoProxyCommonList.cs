using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct InfoProxyCommonList {
    [FieldOffset(0x0)] public InfoProxyPageInterface InfoProxyPageInterface;
    [FieldOffset(0x20)] public Utf8String Unk20;
    [FieldOffset(0x88)] public byte Unk88; //Corresponding ATkModule NumberArrrayIndex
    [FieldOffset(0x89)] public byte Unk89; //Corresponding ATkModule StringArrrayIndex
    [FieldOffset(0x8A)] public ushort DataSize;
    [FieldOffset(0x8C)] public ushort DictSize;
    [FieldOffset(0x8E)] public ushort Unk8E; //10 * DataSize
    [FieldOffset(0x90)] public ushort Unk90; //10 * DataSize
    [FieldOffset(0x98)] public CharacterData* CharData;

    public readonly ReadOnlySpan<CharacterData> CharDataSpan => new(CharData, (int)InfoProxyPageInterface.InfoProxyInterface.EntryCount); // It cant be higher than 200 at this time anyways so this is fine

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D0 48 8B CB E8 ?? ?? ?? ?? 41 C6 46")]
    public partial ulong GetContentIDForEntry(uint idx);

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 FF 74 55")]
    public partial CharacterData* GetEntry(uint idx);

    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public struct CharacterData {
        [FieldOffset(0x00)] public ulong ContentId;
        [FieldOffset(0x08)] public ClientState State; // bunch of stuff mashed together from online status, mentor status, duty status
        //12 bytes
        [FieldOffset(0x1C)] public byte SortId;
        // 1 byte
        [FieldOffset(0x1E)] public ushort CurrentWorld;
        [FieldOffset(0x20)] public ushort HomeWorld;
        [FieldOffset(0x22)] public ushort Location; //ZoneID
        [FieldOffset(0x24)] public GrandCompany GrandCompany;
        [FieldOffset(0x25)] public Language ClientLanguage;
        [FieldOffset(0x26)] public LanguageMask Languages;
        // 2 bytes
        [FieldOffset(0x29)] public byte Job;
        [FieldOffset(0x2A)] public fixed byte Name[32];
        [FieldOffset(0x4A)] public fixed byte FCTag[6];
        // 8 bytes
        [FieldOffset(0x58)] public CharIndexEntry* Index;

        [Flags]
        public enum ClientState : ulong {
            Offline = 0x0000000000000000,
            Busy = 0x0000000000001000,
            PlayingTripleTriad = 0x0000000000004000,
            ViewingCutscene = 0x0000000000008000,
            AFK = 0x0000000000020000,
            CameraMode = 0x0000000000040000,
            RP = 0x0000000000400000,
            LFP = 0x0000000000800000,
            WaitingForDutyFinder = 0x0000000002000000,
            Mentor = 0x0000000008000000,
            PvEMentor = 0x0000000010000000,
            TradeMentor = 0x0000000020000000,
            PvPMentor = 0x0000000040000000,
            Returner = 0x0000000080000000,
            NewAdventurer = 0x0000000100000000,
            PartyLeader = 0x0000001000000000,
            PartyMember = 0x0000002000000000,
            RecruitingMembers = 0x0000004000000000,
            PartyMemberCrossWorld = 0x0000008000000000,
            AnotherWorld = 0x0000010000000000,
            Online = 0x0000800000000000,

            // Unknowns included to improve readability of ToString, not to be used.
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk1 = 0x0000000000000001,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk2 = 0x0000000000000002,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk4 = 0x0000000000000004,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk8 = 0x0000000000000008,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk10 = 0x0000000000000010,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk20 = 0x0000000000000020,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk40 = 0x0000000000000040,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk80 = 0x0000000000000080,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk100 = 0x0000000000000100,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk200 = 0x0000000000000200,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk400 = 0x0000000000000400,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk800 = 0x0000000000000800,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk2000 = 0x0000000000002000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk10000 = 0x0000000000010000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk80000 = 0x0000000000080000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk100000 = 0x0000000000100000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk200000 = 0x0000000000200000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk1000000 = 0x0000000001000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk4000000 = 0x0000000004000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk20000000 = 0x0000000200000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk40000000 = 0x0000000400000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk80000000 = 0x0000000800000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk200000000 = 0x0000020000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk400000000 = 0x0000040000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk800000000 = 0x0000080000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk1000000000 = 0x0000100000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk2000000000 = 0x0000200000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk4000000000 = 0x0000400000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk10000000000 = 0x0001000000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk20000000000 = 0x0002000000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk40000000000 = 0x0004000000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk80000000000 = 0x0008000000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk100000000000 = 0x0010000000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk200000000000 = 0x0020000000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk400000000000 = 0x0040000000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk800000000000 = 0x0080000000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk1000000000000 = 0x0100000000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk2000000000000 = 0x0200000000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk4000000000000 = 0x0400000000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk8000000000000 = 0x0800000000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk10000000000000 = 0x1000000000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk20000000000000 = 0x2000000000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk40000000000000 = 0x4000000000000000,
            [Obsolete("Included to improve readability of ToString, not to be used.", true)] Unk80000000000000 = 0x8000000000000000
        }

        public enum Language : byte {
            JP = 0,
            EN = 1,
            DE = 2,
            FR = 3,
            None = 0xFF
        }

        [Flags]
        public enum LanguageMask : byte {
            None = 0,
            JP = 1,
            EN = 2,
            DE = 4,
            FR = 8,
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct CharIndexEntry {
        [FieldOffset(0x0)] public ulong ContentID;

        [FieldOffset(0xA)] public ushort HomeWorld;
    }
}
