namespace FFXIVClientStructs.FFXIV.Client.Game.Group;

[StructLayout(LayoutKind.Explicit, Size = 0x230)]
public unsafe struct PartyMember
{
    [FieldOffset(0x0)] public StatusManager StatusManager;
    [FieldOffset(0x190)] public float X;
    [FieldOffset(0x194)] public float Y;
    [FieldOffset(0x198)] public float Z;
    [FieldOffset(0x1A0)] public long ContentID;
    [FieldOffset(0x1A8)] public uint ObjectID;
    [FieldOffset(0x1AC)] public uint Unk_ObjectID_1;
    [FieldOffset(0x1B0)] public uint Unk_ObjectID_2;
    [FieldOffset(0x1B4)] public uint CurrentHP;
    [FieldOffset(0x1B8)] public uint MaxHP;
    [FieldOffset(0x1BC)] public ushort CurrentMP;
    [FieldOffset(0x1BE)] public ushort MaxMP;
    [FieldOffset(0x1C0)] public ushort TerritoryType;
    [FieldOffset(0x1C2)] public ushort HomeWorld;
    [FieldOffset(0x1C4)] public fixed byte Name[0x40];
    [FieldOffset(0x204)] public byte Sex;
    [FieldOffset(0x205)] public byte ClassJob;
    [FieldOffset(0x206)] public byte Level;

    // 0x18 byte struct at 0x208
    [FieldOffset(0x208)] public byte Unk_Struct_208__0;
    [FieldOffset(0x20C)] public uint Unk_Struct_208__4;
    [FieldOffset(0x210)] public ushort Unk_Struct_208__8;
    [FieldOffset(0x214)] public uint Unk_Struct_208__C;
    [FieldOffset(0x218)] public ushort Unk_Struct_208__10;
    [FieldOffset(0x21A)] public ushort Unk_Struct_208__14;

    [FieldOffset(0x220)] public byte Flags; // 0x01 == set for valid alliance members
}