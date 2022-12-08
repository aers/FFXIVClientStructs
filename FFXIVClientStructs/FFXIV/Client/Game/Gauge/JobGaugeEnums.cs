namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge;

public enum AstrologianCard
{
    None = 0,
    Balance = 1,
    Bole = 2,
    Arrow = 3,
    Spear = 4,
    Ewer = 5,
    Spire = 6,
    Lord = 0x70,
    Lady = 0x80
}

public enum AstrologianSeal
{
    Solar = 1,
    Lunar = 2,
    Celestial = 3
}

public enum DanceStep : byte
{
    Finish = 0,
    Emboite = 1,
    Entrechat = 2,
    Jete = 3,
    Pirouette = 4
}

[Flags]
public enum EnochianFlags : byte
{
    None = 0,
    Enochian = 1,
    Paradox = 2
}

public enum KaeshiAction : byte
{
    Higanbana = 1,
    Goken = 2,
    Setsugekka = 3,
    Namikiri = 4
}

[Flags]
public enum SenFlags : byte
{
    None = 0,
    Setsu = 1 << 0,
    Getsu = 1 << 1,
    Ka = 1 << 2
}

[Flags]
public enum SongFlags : byte
{
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
public enum AetherFlags : byte
{
    None = 0,
    Aetherflow1 = 1 << 0,
    Aetherflow2 = 1 << 1,
    Aetherflow = Aetherflow1 | Aetherflow2,
    IfritAttuned = 1 << 2,
    TitanAttuned = 1 << 3,
    GarudaAttuned = TitanAttuned | IfritAttuned,
    PhoenixReady = 1 << 4,
    IfritReady = 1 << 5,
    TitanReady = 1 << 6,
    GarudaReady = 1 << 7
}

public enum BeastChakraType : byte
{
    None = 0,
    Coeurl = 1,
    OpoOpo = 2,
    Raptor = 3
}

[Flags]
public enum NadiFlags : byte
{
    Lunar = 2,
    Solar = 4
}