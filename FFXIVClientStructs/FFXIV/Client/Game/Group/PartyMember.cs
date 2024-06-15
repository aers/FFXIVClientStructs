using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Group;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3A0)]
public unsafe partial struct PartyMember {
    [FieldOffset(0x0)] public StatusManager StatusManager;
    [FieldOffset(0x2F0)] public float X;
    [FieldOffset(0x2F4)] public float Y;
    [FieldOffset(0x2F8)] public float Z;
    [FieldOffset(0x300)] public ulong Unk300; // content id for anonymous players?
    [FieldOffset(0x308)] public ulong ContentId;
    [FieldOffset(0x310)] public uint EntityId;
    // [FieldOffset(0x300)] public ulong ContentId; // content id for anonymous players?
    //[FieldOffset(0x30C)] public uint Unk_ObjectId_1;
    //[FieldOffset(0x310)] public uint Unk_ObjectId_2;
    [FieldOffset(0x31C)] public uint CurrentHP;
    [FieldOffset(0x320)] public uint MaxHP;
    [FieldOffset(0x324)] public ushort CurrentMP;
    [FieldOffset(0x326)] public ushort MaxMP;
    [FieldOffset(0x328)] public ushort TerritoryType;
    [FieldOffset(0x32A)] public ushort HomeWorld;
    // GroupManager::GetPartyMemberName: "E8 ? ? ? ? 4C 8B C5 4C 2B C0" or "48 8B 81 ? ? ? ? 48 85 C0 74 ? 48 8B C8 E9"
    [FieldOffset(0x32C), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _name;
    [FieldOffset(0x370)] public Utf8String* UnkName; // TODO: is this anonymous name?
    [FieldOffset(0x378)] public byte Sex;
    [FieldOffset(0x379)] public byte ClassJob;
    [FieldOffset(0x37A)] public byte Level;
    [FieldOffset(0x37B)] public byte DamageShield;
    [FieldOffset(0x37C), FixedSizeArray] internal FixedSizeArray3<ExtraProperty> _extraProperties;
    [FieldOffset(0x394)] public byte Flags; // 0x01 == set for valid alliance members, 0x04 == set if XYZ is valid?

    public bool IsValidAllianceMember => (Flags & 1) != 0;

    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct ExtraProperty {
        [FieldOffset(0)] public byte Key; // 1 = ?, 2/3 = something eureka related, 5 = bozja rank
        [FieldOffset(4)] public int Value;
    }
}
