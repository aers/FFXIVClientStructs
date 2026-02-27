using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::RaceChocoboManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x26)]
public unsafe partial struct RaceChocoboManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 83 F8 02 75 08", 3)]
    public static partial RaceChocoboManager* Instance();

    [FieldOffset(0x00)] public EventId EventId;
    [FieldOffset(0x04)] public RaceChocoboState State;

    // Percentage of the respective stat values
    [FieldOffset(0x08)] public byte MaximumSpeed;
    [FieldOffset(0x09)] public byte Acceleration;
    [FieldOffset(0x0A)] public byte Endurance;
    [FieldOffset(0x0B)] public byte Stamina;
    [FieldOffset(0x0C)] public byte Cunning;

    [BitField<bool>(nameof(IsMaximumSpeedFromMother), 0)]
    [BitField<bool>(nameof(IsAccelerationFromMother), 1)]
    [BitField<bool>(nameof(IsEnduranceFromMother), 2)]
    [BitField<bool>(nameof(IsStaminaFromMother), 3)]
    [BitField<bool>(nameof(IsCunningFromMother), 4)]
    [BitField<bool>(nameof(IsWeatherFoul), 5)]
    [BitField<bool>(nameof(IsFemale), 6)]
    [FieldOffset(0x0D)] public byte Parameters;

    // The attributes are represented as Stars-1
    [BitField<byte>(nameof(FatherCunning), 0, 2)]
    [BitField<byte>(nameof(FatherStamina), 2, 2)]
    [BitField<byte>(nameof(FatherEndurance), 4, 2)]
    [BitField<byte>(nameof(FatherAcceleration), 6, 2)]
    [BitField<byte>(nameof(FatherMaximumSpeed), 8, 2)]
    [BitField<byte>(nameof(FatherPedigree), 12, 4)]
    [FieldOffset(0x0E)] public ushort FatherParameters;

    [BitField<byte>(nameof(MotherCunning), 0, 2)]
    [BitField<byte>(nameof(MotherStamina), 2, 2)]
    [BitField<byte>(nameof(MotherEndurance), 4, 2)]
    [BitField<byte>(nameof(MotherAcceleration), 6, 2)]
    [BitField<byte>(nameof(MotherMaximumSpeed), 8, 2)]
    [BitField<byte>(nameof(MotherPedigree), 12, 4)]
    [FieldOffset(0x10)] public ushort MotherParameters;

    // ExcelSheet<ChocoboRaceAbility>
    [FieldOffset(0x12)] public byte AbilityHereditary;
    [FieldOffset(0x13)] public byte AbilityLearned;

    [FieldOffset(0x14)] private byte Unk14;

    // ExcelSheet<RacingChocoboName>
    [FieldOffset(0x16)] public short NameFirst;
    [FieldOffset(0x18)] public short NameLast;

    [FieldOffset(0x1A)] public byte Rank;

    [FieldOffset(0x1C)] public short ExperienceCurrent;
    [FieldOffset(0x1E)] public short ExperienceMax;

    // ExcelSheet<Stain>
    [FieldOffset(0x20)] public byte Color;

    // ExcelSheet<BuddyEquip>
    [FieldOffset(0x21)] public byte GearHead;
    [FieldOffset(0x22)] public byte GearBody;
    [FieldOffset(0x23)] public byte GearLegs;
    [FieldOffset(0x24)] public byte SessionsAvailable;
    [FieldOffset(0x25)] private byte Unk25;

    [FieldOffset(0x0E), Obsolete("Use FatherParameters or the generated bit field properties")] public short Father;
    [FieldOffset(0x10), Obsolete("Use MotherParameters or the generated bit field properties")] public short Mother;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 55 ?? 48 8B CF E8 ?? ?? ?? ?? 48 8D 77")]
    public partial void GetAttributesCurrent(RaceChocoboAttributeValues* outValues);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 77 ?? 41 BF")]
    public partial void GetAttributesMaximum(RaceChocoboAttributeValues* outValues);

    /// <remarks> The amount of stars is the respective value + 1. </remarks>
    [MemberFunction("48 83 EC ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 44 24 ?? 4C 8B D2 4C 8B C9")]
    public partial void GetAttributesStars(RaceChocoboAttributeValues* outValues);

    [MemberFunction("E8 ?? ?? ?? ?? 8B CE 48 6B D1")]
    public partial int GetRating();

    [MemberFunction("80 79 ?? 00 77 ?? 33 C0")]
    public partial int GetPedigreeLevel();

    public enum RaceChocoboState {
        Invalid = 0,
        Requested = 1,
        Loaded = 2,
    }
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 5 * 4)]
public partial struct RaceChocoboAttributeValues {
    [FieldOffset(0x00), FixedSizeArray, CExporterIgnore] internal FixedSizeArray5<uint> _values;
    [FieldOffset(0x00)] public uint MaximumSpeed;
    [FieldOffset(0x04)] public uint Acceleration;
    [FieldOffset(0x08)] public uint Endurance;
    [FieldOffset(0x0C)] public uint Stamina;
    [FieldOffset(0x10)] public uint Cunning;
}
