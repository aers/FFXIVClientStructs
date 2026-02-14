namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::RaceChocoboManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x26)]
public unsafe partial struct RaceChocoboManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 83 F8 02 75 08", 3)]
    public static partial RaceChocoboManager* Instance();

    //[FieldOffset(0x00)] private int Unknownx00;
    //[FieldOffset(0x04)] private int Unknownx04;

    // Percentage of the respective stat values.
    [FieldOffset(0x08)] public byte MaximumSpeed;
    [FieldOffset(0x09)] public byte Acceleration;
    [FieldOffset(0x0A)] public byte Endurance;
    [FieldOffset(0x0B)] public byte Stamina;
    [FieldOffset(0x0C)] public byte Cunning;

    // 1 bit: unused
    // 1 bit: Sex: 0:M, 1:F
    // 1 bit: Weather: 0:Fair, 1: Foul
    // 5 bits: Stat inheritance: 0:from father, 1:from mother:
    //         Cunning, Stamina, Endurance, Acceleration, Speed
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

    //[FieldOffset(0x14)] private byte Unknownx14;
    //[FieldOffset(0x15)] private byte Unknownx15;

    // ExcelSheet<RacingChocoboName>
    [FieldOffset(0x16)] public short NameFirst;
    [FieldOffset(0x18)] public short NameLast;

    [FieldOffset(0x1A)] public byte Rank;

    //[FieldOffset(0x1B)] private byte Unknownx1B;

    [FieldOffset(0x1C)] public short ExperienceCurrent;
    [FieldOffset(0x1E)] public short ExperienceMax;

    // ExcelSheet<Stain>
    [FieldOffset(0x20)] public byte Color;

    // ExcelSheet<BuddyEquip>
    [FieldOffset(0x21)] public byte GearHead;
    [FieldOffset(0x22)] public byte GearBody;
    [FieldOffset(0x23)] public byte GearLegs;

    [FieldOffset(0x24)] public byte SessionsAvailable;

    //[FieldOffset(0x25)] private byte Unknownx25;

    public byte GetPedigreeLevel() => (byte)(Math.Min(Father >> 12, Mother >> 12) + 1);
    public bool IsAttributeInheritedFromFather(ChocoboAttribute attribute) => (Parameters & (1 << (4 - (int)attribute))) == 0;

    public byte GetAttributeStars(ChocoboAttribute attribute)
    {
        short inheritedStats = IsAttributeInheritedFromFather(attribute) ? Father : Mother;
        return (byte)(((inheritedStats >> (2 * (int)attribute)) & 0x3) + 1);
    }

    public byte GetCurrentAttributePercentage(ChocoboAttribute attribute)
    {
        return attribute switch
        {
            ChocoboAttribute.MaximumSpeed => RaceChocoboManager.Instance()->MaximumSpeed,
            ChocoboAttribute.Acceleration => RaceChocoboManager.Instance()->Acceleration,
            ChocoboAttribute.Endurance => RaceChocoboManager.Instance()->Endurance,
            ChocoboAttribute.Stamina => RaceChocoboManager.Instance()->Stamina,
            ChocoboAttribute.Cunning => RaceChocoboManager.Instance()->Cunning,
            _ => throw new ArgumentOutOfRangeException(nameof(attribute), attribute, null)
        };
    }

    public short GetMaximumAttributeValue(ChocoboAttribute attribute) => (short)(40 * (GetAttributeStars(attribute) + GetPedigreeLevel()) - 20);
    public short GetCurrentAttributeValue(ChocoboAttribute attribute) => (short)(GetCurrentAttributePercentage(attribute) * GetMaximumAttributeValue(attribute) / 100f);

    public byte GetRating()
    {
        int sumOfAttributeMaximums = GetMaximumAttributeValue(ChocoboAttribute.MaximumSpeed) +
                              GetMaximumAttributeValue(ChocoboAttribute.Acceleration) +
                              GetMaximumAttributeValue(ChocoboAttribute.Endurance) +
                              GetMaximumAttributeValue(ChocoboAttribute.Stamina) +
                              GetMaximumAttributeValue(ChocoboAttribute.Cunning);
        return (byte)(sumOfAttributeMaximums / 500f * (10 + Rank));
    }

    public enum ChocoboAttribute
    {
        MaximumSpeed = 4,
        Acceleration = 3,
        Endurance = 2,
        Stamina = 1,
        Cunning = 0,
    }
}
