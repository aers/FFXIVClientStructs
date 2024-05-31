namespace FFXIVClientStructs.FFXIV.Client.Game.Group;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x390)]
public unsafe partial struct PartyMember {
    [FieldOffset(0x0)] public StatusManager StatusManager;
    [FieldOffset(0x2F0)] public float X;
    [FieldOffset(0x2F4)] public float Y;
    [FieldOffset(0x2F8)] public float Z;
    [FieldOffset(0x300)] public long ContentId;
    [FieldOffset(0x308)] public uint ObjectId;
    //[FieldOffset(0x30C)] public uint Unk_ObjectId_1;
    //[FieldOffset(0x310)] public uint Unk_ObjectId_2;
    [FieldOffset(0x314)] public uint CurrentHP;
    [FieldOffset(0x318)] public uint MaxHP;
    [FieldOffset(0x31C)] public ushort CurrentMP;
    [FieldOffset(0x31E)] public ushort MaxMP;
    [FieldOffset(0x320)] public ushort TerritoryType;
    [FieldOffset(0x322)] public ushort HomeWorld;
    [FieldOffset(0x324), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _name;
    [FieldOffset(0x364)] public byte Sex;
    [FieldOffset(0x365)] public byte ClassJob;
    [FieldOffset(0x366)] public byte Level;
    [FieldOffset(0x367)] public byte DamageShield;

    [FieldOffset(0x380)] public byte Flags; // 0x01 == set for valid alliance members
}
