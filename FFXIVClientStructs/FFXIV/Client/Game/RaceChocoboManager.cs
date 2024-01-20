namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x26)]
public unsafe partial struct RaceChocoboManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 0F B7 D8 E8 ?? ?? ?? ?? 0F B7", 3)]
    public static partial RaceChocoboManager* Instance();

    //[FieldOffset(0x00)] public int Unknownx00;
    //[FieldOffset(0x04)] public int Unknownx04;

    // These aren't direct stats but represent then number
    // of points in an attribute.  To get the stat value,
    // there's a formula that takes Pedigree & Stars.
    // I've not fully nailed it down, but it's something like:
    // ((Pedigree + Stars) * 0.38) * Value = Stat
    //
    // But where are Stars and Pedigree stored?
    [FieldOffset(0x08)] public byte MaximumSpeed;
    [FieldOffset(0x09)] public byte Acceleration;
    [FieldOffset(0x0A)] public byte Endurance;
    [FieldOffset(0x0B)] public byte Stamina;
    [FieldOffset(0x0C)] public byte Cunning;

    // On investigation this looks like:
    // 2 bits: Sex: 00:M, 01:F
    // 2 bits: Weather: 01:Fair, 10: Foul, ?? Neutral
    // 4 bits: Pedigree
    // So a value of 102/0x66/01 10 0110
    //   Would be:            M Foul  6
    // But it doesn't seem to be super stable.
    // Maybe it suffers a bit like RetainerManager.
    [FieldOffset(0x0D)] public byte Parameters;

    // 4 bits: Pedigree
    // 2 bits: Unused?
    // 5x2 bits: Cunning, Stamina, Endurance, Acceleration, Speed
    //           I think this looks reversed because of Little Endian
    // The attributes are represented as Stars-1, so 3 stars would be 0b10
    [FieldOffset(0x0E)] public short Father;
    [FieldOffset(0x10)] public short Mother;

    // ExcelSheet<ChocoboRaceAbility>
    [FieldOffset(0x12)] public byte AbilityHereditary;
    [FieldOffset(0x13)] public byte AbilityLearned;

    //[FieldOffset(0x14)] public byte Unknownx14;
    //[FieldOffset(0x15)] public byte Unknownx15;

    // ExcelSheet<RacingChocoboName>
    [FieldOffset(0x16)] public short NameFirst;
    [FieldOffset(0x18)] public short NameLast;

    [FieldOffset(0x1A)] public byte Rank;

    //[FieldOffset(0x1B)] public byte Unknownx1B;

    [FieldOffset(0x1C)] public short ExperienceCurrent;
    [FieldOffset(0x1E)] public short ExperienceMax;

    // ExcelSheet<Stain>
    [FieldOffset(0x20)] public byte Color;

    // ExcelSheet<BuddyEquip>
    [FieldOffset(0x21)] public byte GearHead;
    [FieldOffset(0x22)] public byte GearBody;
    [FieldOffset(0x23)] public byte GearLegs;

    [FieldOffset(0x24)] public byte SessionsAvailable;

    //[FieldOffset(0x25)] public byte Unknownx25;
}
