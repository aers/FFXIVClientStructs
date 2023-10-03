namespace FFXIVClientStructs.FFXIV.Client.Game.Group;

[StructLayout(LayoutKind.Explicit, Size = 0x390)]
public unsafe struct PartyMember {
    [FieldOffset(0x0)] public StatusManager StatusManager;
    [FieldOffset(0x2F0)] public float X;
    [FieldOffset(0x2F4)] public float Y;
    [FieldOffset(0x2F8)] public float Z;
    [FieldOffset(0x300)] public long ContentID;
    [FieldOffset(0x308)] public uint ObjectID;
    [FieldOffset(0x30C)] public uint Unk_ObjectID_1;
    [FieldOffset(0x310)] public uint Unk_ObjectID_2;
    [FieldOffset(0x314)] public uint CurrentHP;
    [FieldOffset(0x318)] public uint MaxHP;
    [FieldOffset(0x31C)] public ushort CurrentMP;
    [FieldOffset(0x31E)] public ushort MaxMP;
    [FieldOffset(0x320)] public ushort TerritoryType;
    [FieldOffset(0x322)] public ushort HomeWorld;
    [FieldOffset(0x324)] public fixed byte Name[0x40];
    [FieldOffset(0x364)] public byte Sex;
    [FieldOffset(0x365)] public byte ClassJob;
    [FieldOffset(0x366)] public byte Level;
    [FieldOffset(0x367)] public byte DamageShield;

    // 0x18 byte struct at 0x208
    [FieldOffset(0x368)] public byte Unk_Struct_208__0;
    [FieldOffset(0x36C)] public uint Unk_Struct_208__4;
    [FieldOffset(0x370)] public ushort Unk_Struct_208__8;
    [FieldOffset(0x374)] public uint Unk_Struct_208__C;
    [FieldOffset(0x378)] public ushort Unk_Struct_208__10;
    [FieldOffset(0x37A)] public ushort Unk_Struct_208__14;

    [FieldOffset(0x380)] public byte Flags; // 0x01 == set for valid alliance members
}
