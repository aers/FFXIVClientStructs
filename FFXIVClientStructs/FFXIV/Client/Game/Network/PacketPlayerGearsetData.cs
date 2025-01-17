using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x46)]
public partial struct PacketPlayerGearsetData {
    // Stores the weapon data. Includes both dyes in the data. </summary>
    [FieldOffset(0x00)] public WeaponModelId MainhandWeaponData;
    [FieldOffset(0x08)] public WeaponModelId OffhandWeaponData;
    [FieldOffset(0x10)] public byte CrestBitField; // A Bitfield:: ShieldCrest == 1, HeadCrest == 2, Chest Crest == 4
    [FieldOffset(0x11)] public byte JobId; // Job ID associated with the gearset change.
    [FieldOffset(0x12)] private byte Unk12; // Flicks from 0 to 128 (anywhere inbetween), have yet to associate what it is linked to. Remains the same when flicking between gearsets of the same job.
    [FieldOffset(0x13)] private byte Unk13; // I have never seen this be anything other than 0.
    [FieldOffset(0x14), FixedSizeArray] internal FixedSizeArray10<LegacyEquipmentModelId> _equipmentModelIds;
    [FieldOffset(0x3C), FixedSizeArray] internal FixedSizeArray10<byte> _equipmentSecondaryDyes;
}
