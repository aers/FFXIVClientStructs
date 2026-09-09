namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge;

public enum AstrologianCard {
    None = 0,
    Balance = 1,
    Bole = 2,
    Arrow = 3,
    Spear = 4,
    Ewer = 5,
    Spire = 6,
    Lord = 7,
    Lady = 8
}

public enum AstrologianDraw : byte {
    Astral = 0,
    Umbral = 1
}

public enum DanceStep : byte {
    Finish = 0,
    Emboite = 1,
    Entrechat = 2,
    Jete = 3,
    Pirouette = 4
}

[Flags]
public enum EnochianFlags : byte {
    None = 0,
    Enochian = 1,
    Paradox = 2
}

public enum KaeshiAction : byte {
    Higanbana = 1,
    Goken = 2,
    Setsugekka = 3,
    Namikiri = 4
}

[Flags]
public enum SenFlags : byte {
    None = 0,
    Setsu = 1 << 0,
    Getsu = 1 << 1,
    Ka = 1 << 2
}

[Flags]
public enum SongFlags : byte {
    None = 0,
    MagesBallad = 1 << 0,
    ArmysPaeon = 1 << 1,
    WanderersMinuet = MagesBallad | ArmysPaeon,
    MagesBalladLastPlayed = 1 << 2,
    ArmysPaeonLastPlayed = 1 << 3,
    WanderersMinuetLastPlayed = MagesBalladLastPlayed | ArmysPaeonLastPlayed,
    MagesBalladCoda = 1 << 4,
    ArmysPaeonCoda = 1 << 5,
    WanderersMinuetCoda = 1 << 6
}

[Flags]
public enum AetherFlags : byte {
    None = 0,
    Aetherflow1 = 1 << 0,
    Aetherflow2 = 1 << 1,
    Aetherflow = Aetherflow1 | Aetherflow2,
    PhoenixPrimed = 1 << 2,
    SolarBahamutFirstPrimed = 1 << 3,
    SolarBahamutSecondPrimed = PhoenixPrimed | SolarBahamutFirstPrimed,
    IfritReady = 1 << 5,
    TitanReady = 1 << 6,
    GarudaReady = 1 << 7
}

public enum BeastChakraType : byte {
    None = 0,
    OpoOpo = 1,
    Raptor = 2,
    Coeurl = 3
}

[Flags]
public enum NadiFlags : byte {
    Lunar = 1,
    Solar = 2
}

[Flags]
public enum CanvasFlags : byte {
    Pom = 1,
    Wing = 2,
    Claw = 4,
    Maw = 8,
    Weapon = 16,
    Landscape = 32,
}

[Flags]
public enum CreatureFlags : byte {
    Pom = 1,
    Wings = 2,
    Claw = 4,

    MooglePortait = 16,
    MadeenPortrait = 32,
}

public enum DreadCombo : byte {
    Dreadwinder = 1,
    HuntersCoil = 2,
    SwiftskinsCoil = 3,
    PitOfDread = 4,
    HuntersDen = 5,
    SwiftskinsDen = 6,
    //Reawakened = 7,
    //FirstGeneration = 8,
    //SecondGeneration = 9,
    //ThirdGeneration = 10,
}

public enum SerpentCombo : byte {
    DeathRattle = 1,
    LastLash = 2,
    FirstLegacy = 3,
    SecondLegacy = 4,
    ThirdLegacy = 5,
    FourthLegacy = 6,
}

// The Inner Compass runs clockwise Volant -> Rampant -> Durant -> Eldritch -> Volant, so an
// intentional combo is simply the next affinity in sequence, wrapping Eldritch back to Volant.
// Completing one grants a fifth or sixth affinity, which the game calls the "two additional
// instinctual affinities". Which of the two you get is the parity of the affinity the combo
// started from: odd -> Sunstrider, even -> Moonstalker. Pairing those two in turn triggers
// what the game calls an "infinitive combo".
// The upgrade only lands if the target survives the combo. Kill it with the second skill and
// you still get Wavering Heart and a ChainCount increment, but no Sunstrider or Moonstalker.
// These values match the player statuses the job applies, which are contiguous and in this
// same order: Status rows 4595 Volant Heart, 4596 Rampant Heart, 4597 Durant Heart,
// 4598 Eldritch Heart, 4599 Sunstrider, 4600 Moonstalker.
public enum BeastmasterAffinity : byte {
    None = 0,
    Volant = 1,
    Rampant = 2,
    Durant = 3,
    Eldritch = 4,
    Sunstrider = 5,
    Moonstalker = 6,
}

// A familiar's kin type, which decides which Kinship status Borrow grants and therefore which
// ability Beast Mode turns into. Matches the order of the eight contiguous Kinship statuses,
// Status rows 4602 Beast Kinship through 4609 Ash Kinship. All eight values observed directly
// in the gauge, each cross-checked against the Kinship status the familiar actually granted.
public enum BeastmasterKinType : byte {
    None = 0,
    Beastkin = 1,
    Vilekin = 2,
    Cloudkin = 3,
    Seedkin = 4,
    Wavekin = 5,
    Scalekin = 6,
    Soulkin = 7,
    Ashkin = 8,
}
