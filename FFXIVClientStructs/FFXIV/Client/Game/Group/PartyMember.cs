namespace FFXIVClientStructs.FFXIV.Client.Game.Group;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x390)]
public unsafe partial struct PartyMember {
    [FieldOffset(0x0)] public StatusManager StatusManager;
    [FieldOffset(0x2F0)] public float X;
    [FieldOffset(0x2F4)] public float Y;
    [FieldOffset(0x2F8)] public float Z;
    [FieldOffset(0x300)] public ulong ContentId;
    [FieldOffset(0x308)] public uint EntityId;
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
    [FieldOffset(0x368), FixedSizeArray] internal FixedSizeArray3<ExtraProperty> _extraProperties;
    [FieldOffset(0x380)] public byte Flags; // 0x01 == set for valid alliance members, 0x04 == set if XYZ is valid?

    public bool IsValidAllianceMember => (Flags & 1) != 0;

    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct ExtraProperty {
        [FieldOffset(0)] public byte Key; // 1 = ?, 2/3 = something eureka related, 5 = bozja rank
        [FieldOffset(4)] public int Value;
    }
}
