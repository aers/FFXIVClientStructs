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
public enum AetherFlags : ushort {
    None = 0,
    IfritAttuned = 1 << 0,
    TitanAttuned = 1 << 1,
    GarudaAttuned = TitanAttuned | IfritAttuned,
    Attunement1 = 1 << 2,
    Attunement2 = 1 << 3,
    Attunement4 = 1 << 4,
    Attunement = Attunement1 | Attunement2 | Attunement4,
    Aetherflow1 = 1 << 8,
    Aetherflow2 = 1 << 9,
    Aetherflow = Aetherflow1 | Aetherflow2,
    PhoenixReady = 1 << 10,
    SolarBahamutReady = 1 << 11,
    IfritReady = 1 << 13,
    TitanReady = 1 << 14,
    GarudaReady = 1 << 15
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
