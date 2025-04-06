using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Group;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x490)]
public unsafe partial struct PartyMember {
    [FieldOffset(0x0)] public StatusManager StatusManager;
    [FieldOffset(0x3E0)] public float X;
    [FieldOffset(0x3E4)] public float Y;
    [FieldOffset(0x3E8)] public float Z;

    [FieldOffset(0x3F0)] public ulong AccountId;

    [FieldOffset(0x3F8)] public ulong ContentId;
    [FieldOffset(0x400)] public uint EntityId;
    [FieldOffset(0x404)] public uint PetEntityId; // carbuncle, etc
    [FieldOffset(0x408)] public uint CompanionEntityId; // chocobo
    [FieldOffset(0x40C)] public uint CurrentHP;
    [FieldOffset(0x410)] public uint MaxHP;
    [FieldOffset(0x414)] public ushort CurrentMP;
    [FieldOffset(0x416)] public ushort MaxMP;
    [FieldOffset(0x418)] public ushort TerritoryType;
    [FieldOffset(0x41A)] public ushort HomeWorld;
    // GroupManager::GetPartyMemberName: "E8 ? ? ? ? 4C 8B C5 4C 2B C0" or "48 8B 81 ? ? ? ? 48 85 C0 74 ? 48 8B C8 E9"
    [FieldOffset(0x41C), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _name;

    [FieldOffset(0x460)] public Utf8String* NameOverride; // if non-null, replaces real name in ui (eg for blacklisted players)

    [FieldOffset(0x468)] public byte Sex;
    [FieldOffset(0x469)] public byte ClassJob;
    [FieldOffset(0x46A)] public byte Level;
    [FieldOffset(0x46B)] public byte DamageShield;
    /// <remarks> For easier access, use <see cref="GetContentValue"/>. </remarks>
    [FieldOffset(0x46C), FixedSizeArray] internal FixedSizeArray3<StdPair<uint, uint>> _contentKeyValueData;
    [FieldOffset(0x484)] public byte Flags; // 0x01 == set for valid alliance members, 0x04 == set if XYZ is valid?, 0x10 == in cutscene

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
