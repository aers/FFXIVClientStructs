using System;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge {
    public enum AstrologianCard {
        None = 0,
        Balance = 1,
        Bole = 2,
        Arrow = 3,
        Spear = 4,
        Ewer = 5,
        Spire = 6,
        Lord = 112,
        Lady = 128
    }

    public enum AstrologianSeal {
        Solar = 1,
        Lunar = 2,
        Celestial = 3
    }

    public enum DanceStep : byte {
        Finish = 0,
        Emboite = 1,
        Entrechat = 2,
        Jete = 3,
        Pirouette = 4
    }

    public enum BardSong : byte {
        None = 0,
        MagesBallad = 5,
        ArmysPaeon = 10,
        WanderersMinuet = 15
    }

    [Flags]
    public enum AetherFlags : byte {
        None = 0,
        AetherFlow1 = 1,
        AetherFlow2 = 2,
        Dreadwyrm1 = 4,
        Dreadwyrm2 = 8,
        Firebird = 16
    }
}