using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;
[InfoProxy(InfoProxyId.Party)]
[StructLayout(LayoutKind.Explicit, Size = 0x348)]
public unsafe partial struct InfoProxyParty
{
    [FieldOffset(0x00)] public InfoProxyUnkInterface InfoProxyInterface;
    [FieldOffset(0x98)] public MemberData* Members;
    [FieldOffset(0xE8)] public void* UnkE8;
    [FieldOffset(0x100)] public void* Unk100;
    //Classes/Structs seen in Ghidra at:
    //+118, 100, B8/C8 + D0/E0 mabybe some start/end pointers of Arrays with entry size 0x18

    [StructLayout(LayoutKind.Explicit, Size = 0x318)]
    public unsafe partial struct MemberData
    {
        [FixedSizeArray<PartyMember>(8)]
        [FieldOffset(0x0)] public fixed byte Members[8 * 0x60];

        [StructLayout(LayoutKind.Explicit, Size = 0x60)]
        public unsafe partial struct PartyMember
        {
            [FieldOffset(0x00)] public ulong ContentId;
            //1 byte
            /// <summary>
            /// 0000 = Online
            /// 0010 = Busy
            /// 2000 = AFK
            /// 4000 = RP
            /// 8000 = LFP
            /// </summary>
            [FieldOffset(0x09)] public ushort OnlineStatus;
            //5 bytes
            [FieldOffset(0x10)] public byte IsLeader;
            //3 bytes
            [FieldOffset(0x14)] public byte MemberIndex;
            [FieldOffset(0x16)] public ushort CurrentWorld;
            [FieldOffset(0x18)] public ushort HomeWorld;
            [FieldOffset(0x1A)] public ushort Location; //ZoneID
            [FieldOffset(0x1C)] public GrandCompany GrandCompany;
            /// <summary>
            /// 0 = JP
            /// 1 = EN
            /// 2 = DE
            /// 3 = FR
            /// </summary>
            [FieldOffset(0x1D)] public byte MainLanguage;
            /// <summary>
            /// Bitmask
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
