namespace FFXIVClientStructs.FFXIV.Client.UI.NumberArray;

[NumberArray(4)]
[StructLayout(LayoutKind.Explicit, Size = 0x04 * 727)]
public unsafe partial struct PartyListNumberArray {
    public const int PartyMemberNumberCount = 42;

    [FieldOffset(0x04 * 002)] public int PartyLeaderIndex;
    [FieldOffset(0x04 * 005)] public int PartyMemberCount;
    
    [FixedSizeArray<PartyMemberNumberArray>(8)]
    [FieldOffset(0x04 * 009)] public fixed byte PartyMember[0x04 * PartyMemberNumberCount * 8];

    [FieldOffset(0x04 * (009 + PartyMemberNumberCount * 0))] public PartyMemberNumberArray PartyMember0;
    [FieldOffset(0x04 * (009 + PartyMemberNumberCount * 1))] public PartyMemberNumberArray PartyMember1;
    [FieldOffset(0x04 * (009 + PartyMemberNumberCount * 2))] public PartyMemberNumberArray PartyMember2;
    [FieldOffset(0x04 * (009 + PartyMemberNumberCount * 3))] public PartyMemberNumberArray PartyMember3;
    [FieldOffset(0x04 * (009 + PartyMemberNumberCount * 4))] public PartyMemberNumberArray PartyMember4;
    [FieldOffset(0x04 * (009 + PartyMemberNumberCount * 5))] public PartyMemberNumberArray PartyMember5;
    [FieldOffset(0x04 * (009 + PartyMemberNumberCount * 6))] public PartyMemberNumberArray PartyMember6;
    [FieldOffset(0x04 * (009 + PartyMemberNumberCount * 7))] public PartyMemberNumberArray PartyMember7;
    
    [StructLayout(LayoutKind.Explicit, Size = 0x04 * PartyMemberNumberCount)]
    public partial struct PartyMemberNumberArray {
        [FieldOffset(0x04 * 00)] public int Level;
        [FieldOffset(0x04 * 01)] public int ClassJobIcon;
        [FieldOffset(0x04 * 02)] public int Unk02;
        [FieldOffset(0x04 * 03)] public int Unk03;
        [FieldOffset(0x04 * 04)] public int HP;
        [FieldOffset(0x04 * 05)] public int HPMax;
        [FieldOffset(0x04 * 06)] public int ShieldPercentage;
        [FieldOffset(0x04 * 07)] public int MP;
        [FieldOffset(0x04 * 08)] public int MPMax;
        [FieldOffset(0x04 * 09)] public int Unk09;
        [FieldOffset(0x04 * 10)] public int PartySlot;
        [FieldOffset(0x04 * 11)] public int Unk11;
        [FieldOffset(0x04 * 12)] public void* Unk12_ULong;
        [FieldOffset(0x04 * 12)] public int Unk12;
        [FieldOffset(0x04 * 13)] public int Unk13;
        [FieldOffset(0x04 * 14)] public int StatusEffectCount;
        [FixedSizeArray<StatusEffect>(10), FieldOffset(0x04 * 15)]
        public fixed byte StatusEffects[0x04 * 10];
        [FieldOffset(0x04 * 25)] public int Unk25;
        [FieldOffset(0x04 * 26)] public int Unk26;
        [FieldOffset(0x04 * 27)] public int Unk27;
        [FieldOffset(0x04 * 28)] public int Unk28;
        [FieldOffset(0x04 * 29)] public int Unk29;
        [FieldOffset(0x04 * 30)] public int Unk30;
        [FieldOffset(0x04 * 31)] public int Unk31;
        [FieldOffset(0x04 * 32)] public int Unk32;
        [FieldOffset(0x04 * 33)] public int Unk33;
        [FieldOffset(0x04 * 34)] public int Unk34;
        [FieldOffset(0x04 * 35)] public int CastingPercent;
        [FieldOffset(0x04 * 36)] public uint CastingActionId;
        [FieldOffset(0x04 * 37)] public int CastingTargetIndex;
        [FieldOffset(0x04 * 38)] public uint ObjectId;
        [FieldOffset(0x04 * 39)] public uint Unk39;
        [FieldOffset(0x04 * 40)] public uint Unk40;
        [FieldOffset(0x04 * 41)] public uint Unk41;
    }
    
    [StructLayout(LayoutKind.Explicit, Size = 0x4)]
    public struct StatusEffect {
        [FieldOffset(0x00)] public ushort IconId;
        [FieldOffset(0x03)] public StatusFlags Flags;

        public enum StatusFlags : byte {
            None = 0,
            IsOwn = 64
        }
    }
}
