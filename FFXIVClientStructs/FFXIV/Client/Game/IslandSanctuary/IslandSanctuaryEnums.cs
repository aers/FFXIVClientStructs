namespace FFXIVClientStructs.FFXIV.Client.Game.IslandSanctuary; 

public enum CraftworkSupply {
    Nonexistent = 0,
    Insufficient = 1,
    Sufficient = 2,
    Surplus = 3,
    Overflowing = 4
}

public enum CraftworkDemandShift {
    Skyrocketing = 0,
    Increasing = 1,
    NoChange = 2,  // called None in game, but that's confusing IMO.
    Decreasing = 3,
    Plummeting = 4
}