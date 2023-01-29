using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct InfoProxyParty
{
    [FieldOffset(0x00)] public InfoProxyInterface InfoProxyInterface;
    [FieldOffset(0x20)] public Utf8String Unk20;
    [FieldOffset(0x98)] public PartyData* MemberData;
    //[FieldOffset(0xA0)] public PartyData* MemberData2;
    [FieldOffset(0xE8)] public void* UnkE8;
    [FieldOffset(0x100)] public void* Unk100;

    [StructLayout(LayoutKind.Explicit, Size = 0x318)]
    public unsafe partial struct PartyData
    {
        [FixedSizeArray<PartyMember>(8)]
        [FieldOffset(0x18)] public fixed byte Members[8 * 0x60];

        [StructLayout(LayoutKind.Explicit, Size = 0x60)]
        public unsafe partial struct PartyMember
        {
            [FieldOffset(0x0)] public ushort HomeWorld;
            [FieldOffset(0xA)] public fixed byte Name[32];
            [FieldOffset(0x2A)] public fixed byte FCTag[6];
        }
    }
}
