using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Group;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3A0)]
public unsafe partial struct PartyMember {
    [FieldOffset(0x0)] public StatusManager StatusManager;
    [FieldOffset(0x2F0)] public float X;
    [FieldOffset(0x2F4)] public float Y;
    [FieldOffset(0x2F8)] public float Z;

    [Obsolete("Renamed to AccountId", true)]
    [FieldOffset(0x300)] public ulong Unk300; // content id for anonymous players?
    [FieldOffset(0x300)] public ulong AccountId;

    [FieldOffset(0x308)] public ulong ContentId;
    [FieldOffset(0x310)] public uint EntityId;
    [FieldOffset(0x314)] public uint PetEntityId; // carbuncle, etc
    [FieldOffset(0x318)] public uint CompanionEntityId; // chocobo
    [FieldOffset(0x31C)] public uint CurrentHP;
    [FieldOffset(0x320)] public uint MaxHP;
    [FieldOffset(0x324)] public ushort CurrentMP;
    [FieldOffset(0x326)] public ushort MaxMP;
    [FieldOffset(0x328)] public ushort TerritoryType;
    [FieldOffset(0x32A)] public ushort HomeWorld;
    // GroupManager::GetPartyMemberName: "E8 ? ? ? ? 4C 8B C5 4C 2B C0" or "48 8B 81 ? ? ? ? 48 85 C0 74 ? 48 8B C8 E9"
    [FieldOffset(0x32C), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _name;

    [Obsolete("Renamed to NameOverride", true)]
    [FieldOffset(0x370)] public Utf8String* UnkName;
    [FieldOffset(0x370)] public Utf8String* NameOverride; // if non-null, replaces real name in ui (eg for blacklisted players)

    [FieldOffset(0x378)] public byte Sex;
    [FieldOffset(0x379)] public byte ClassJob;
    [FieldOffset(0x37A)] public byte Level;
    [FieldOffset(0x37B)] public byte DamageShield;
    /// <remarks> For easier access, use <see cref="GetContentValue"/>. </remarks>
    [FieldOffset(0x37C), FixedSizeArray] internal FixedSizeArray3<StdPair<uint, uint>> _contentKeyValueData;
    [FieldOffset(0x394)] public byte Flags; // 0x01 == set for valid alliance members, 0x04 == set if XYZ is valid?, 0x10 == in cutscene

    /// <inheritdoc cref="PlayerState.GetContentValue"/>
    public uint GetContentValue(uint key) {
        for (var i = 0; i < 3; i++) {
            var entry = ContentKeyValueData.GetPointer(i);
            if (entry->Item1 == key) {
                return entry->Item2;
            }
        }
        return 0;
    }
}
