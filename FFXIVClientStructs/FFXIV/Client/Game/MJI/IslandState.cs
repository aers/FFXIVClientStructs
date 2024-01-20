namespace FFXIVClientStructs.FFXIV.Client.Game.MJI;

// Client::Game::MJI::IslandState
// ctor "48 89 7C 24 ?? 33 FF 66 C7 01"
[StructLayout(LayoutKind.Explicit, Size = 0xE8)]
public unsafe struct IslandState {
    // Unknown!! This flag *appears* to control island state for quite a few things and is read *a lot* by Lua, but I
    // haven't been able to tack this down quite yet. 
    [FieldOffset(0x00)] public bool CanEditIsland;

    /// <summary>
    /// The current Sanctuary Rank of the player's island. Controls what buildings/items/recipes are or aren't
    /// available to the player, and represented by MJIRank.
    /// </summary>
    [FieldOffset(0x01)] public byte CurrentRank;

    /// <summary>
    /// The XP earned towards the next Island Sanctuary rank. Resets to 0 upon leveling up the Sanctuary. 
    /// </summary>
    [FieldOffset(0x04)] public uint CurrentXP;

    /// <summary>
    /// The current progress of the player, as represented by MJIProgress. Appears to be bound to the island
    /// sanctuary "tutorial" more than anything.
    /// </summary>
    [FieldOffset(0x08)] public byte CurrentProgress;

    /// <summary>
    /// The current development level of the player's village on their island. Controls what building zones are
    /// available.
    /// </summary>
    /// <remarks>
    /// Allowed building locations are part of the MJIBuildingPlace (+0x10) and MJILandmarkPlace (+0x10) Lumina
    /// sheets.
    /// </remarks>
    [FieldOffset(0x09)] public byte VillageDevelopmentLevel;

    /// <summary>
    /// The glamour ID applied to paths around the Island Sanctuary.
    /// Correlates to a subrow in MJIVillageAppearanceUI, row 0.
    /// </summary>
    [FieldOffset(0x0A)] public byte PathsGlamourId;

    /// <summary>
    /// The glamour ID applied to grounds around the Island Sanctuary.
    /// Correlates to a subrow in MJIVillageAppearanceUI, row 2.
    /// </summary>
    [FieldOffset(0x0B)] public byte GroundsGlamourId;

    /// <summary>
    /// The glamour ID applied to slopes around the Island Sanctuary.
    /// Correlates to a subrow in MJIVillageAppeareanceUI, row 1.
    /// </summary>
    [FieldOffset(0x0C)] public byte SlopesGlamourId;

    /// <summary>
    /// A bitfield representing all unlocked key items (MJIKeyItem) for the player. Backing field for
    /// <see cref="MJIManager.IsKeyItemUnlocked"/>, which should be used where possible.
    /// </summary>
    /// <remarks>
    /// The index of this field will be (RowID - 1), so "Islekeep's Stone Hatchet" appears at position 0.
    /// </remarks>
    [FieldOffset(0x0D)] public fixed byte UnlockedKeyItems[3]; // bitfield

    /// <summary>
    /// A bitfield representing if a specific recipe (MJIRecipe) is unlocked. Backing field for
    /// <see cref="MJIManager.IsRecipeUnlocked"/>, which should be used where possible.
    /// </summary>
    [FieldOffset(0x10)] public fixed byte UnlockedRecipes[3]; // bitfield

    /// <summary>
    /// An array of booleans representing if a specific item is (un)locked. Locked/unavailable items are set to true,
    /// while those that are unlocked are false. This array is indexed by RowID from the MJIItemPouch table.
    /// An item appears to be unlocked upon being gathered or crafted for the first time.
    /// <seealso cref="MJIManager.IsPouchItemLocked" />
    /// </summary>
    [FieldOffset(0x14)] public fixed byte LockedPouchItems[109];

    /// <summary>
    /// A sub-struct representing the Farm's (Cropland's) current state
    /// </summary>
    [FieldOffset(0x81)] public MJIFarmPasture Farm;

    /// <summary>
    /// A sub-struct representing the Pasture's current state.
    /// </summary>
    [FieldOffset(0x85)] public MJIFarmPasture Pasture;

    /// <summary>
    /// Appears to be set if the pasture in it has any animal currently under care.
    /// </summary>
    [FieldOffset(0x89)] public bool PastureUnderCare; // ??

    // Note: 0x78 to the game is treated as a single DWORD, but the actual values are only used in the context of
    // LOWORD or HIWORD, so we'll split these fields.

    /// <summary>
    /// The current daily care fee paid to the Creature Comforter for the pasture.
    /// </summary>
    [FieldOffset(0x8A)] public ushort PastureDailyCareFee;

    /// <summary>
    /// The current daily care fee paid to the Produce Producer for the farm.
    /// </summary>
    [FieldOffset(0x8C)] public ushort FarmDailyCareFee;

    /// <summary>
    /// The current number of hours remaining until a specific Landmark has finished construction.
    /// 
    /// This value may be zero when there is either no construction or if construction is finished and the landmark
    /// needs to be "finalized" by the player.
    /// 
    /// This array is indexed by the RowID of an MJILandmarkPlace.
    /// </summary>
    [FieldOffset(0x8E)] public fixed byte LandmarkHoursToCompletion[5];

    /// <summary>
    /// The RowID of the MJILandmark present at a specific MJILandmarkPlace.
    /// 
    /// This array is indexed by the RowID of an MJILandmarkPlace.
    /// </summary>
    [FieldOffset(0x93)] public fixed byte LandmarkIds[5];

    /// <summary>
    /// The current construction status of a landmark at a specific MJILandmarkPlace.
    /// 
    /// This array is indexed by the RowID of an MJILandmarkPlace.
    /// </summary>
    [FieldOffset(0x98)] public fixed byte LandmarkUnderConstruction[5];

    /// <summary>
    /// The current rotation of a landmark at a specific MJILandmarkPlace.
    ///
    /// This array is indexed by the RTowId of an MJILandmarkPlace.
    /// </summary>
    /// <remarks>
    /// Known values:
    /// 0 - Default
    /// 1 - 90 Degrees Clockwise
    /// 2 - 180 Degrees
    /// 3 - 90 Degrees Counterclockwise
    /// </remarks>
    [FieldOffset(0x9D)] public fixed byte LandmarkRotation[5];

    /// <summary>
    /// A struct representing the current state of workshops present on the island. See the struct documentation
    /// for more information on how to access this data.
    ///
    /// Note that this struct only provides mapping from a workshop ID to other data.
    /// </summary>
    [FieldOffset(0xA8)] public MJIWorkshops Workshops;

    /// <summary>
    /// A struct representing the current state of granaries present on the island. See the struct documentation
    /// for more information on how to access this data.
    /// </summary>
    [FieldOffset(0xC8)] public MJIGranaries Granaries;

    /// <summary>
    /// The current level of the Cozy Cabin for the Island Sanctuary.
    /// </summary>
    /// <remarks>
    /// This field is offset by 1 compared to the level present in MJIBuildings. Cabin Level 3 will actually have
    /// a value of 3 in this field. This is *probably* because Cabin Level 0 is "nonexistent"..?
    /// </remarks>
    [FieldOffset(0xE0)] public byte CabinLevel;

    /// <summary>
    /// The current glamour cast on the Cozy Cabin (if any). Relates to the appropriate sub-row in MJIBuilding.
    /// </summary>
    /// <remarks>
    /// This field is *not* offset by one like CabinLevel; Cabin Level 3 will report here as 2.
    /// </remarks>
    [FieldOffset(0xE1)] public byte CabinGlamour;
}

/// <summary>
/// A struct representing a list of workshops present in the Island Sanctuary.
/// 
/// The struct provides a helper method to retrieve information about a single workshop (referenced by ID), but will
/// otherwise allow querying a specific field by ID directly.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x08 + 5 * MaxWorkshops)]
public unsafe struct MJIWorkshops {
    private const int MaxWorkshops = 4;

    public void* vtbl;

    /// <summary>
    /// The MJIBuildingPlace in which this particular building resides.
    /// 
    /// If this building is not built, this value will be zero.
    /// </summary>
    public fixed byte PlaceId[MaxWorkshops];

    /// <summary>
    /// The glamour level of a particular building. This value refers to a specific sub-row of MJIBuilding.
    /// </summary>
    /// <remarks>
    /// This level is one less than the building's level; Workshop III will report as 2.
    /// </remarks>
    public fixed byte GlamourLevel[MaxWorkshops];

    /// <summary>
    /// Hours remaining in the construction/upgrade of a building.
    /// 
    /// If the building is done or is not under construction, this value will be zero.
    /// </summary>
    public fixed byte HoursToCompletion[MaxWorkshops];

    /// <summary>
    /// The true level of a particular building. Like GlamourLevel, also refers to a specific sub-row of MJIBuilding.
    /// </summary>
    /// <remarks>
    /// This level is one less than the building's level; Workshop III will report as 2.
    /// </remarks>
    public fixed byte BuildingLevel[MaxWorkshops];

    /// <summary>
    /// Report if a specific building is currently under construction.
    /// 
    /// May report 1 while HoursToCompletion is 0 if the building needs to be "finalized" through user interaction.
    /// </summary>
    /// <remarks>
    /// So far the only observed value for this field is 0 or 1, but more values may exist (?).
    /// </remarks>
    public fixed byte UnderConstruction[MaxWorkshops];

    /// <summary>
    /// Helper method to return all known information about a specific building at once.
    /// </summary>
    /// <param name="idx">The index of the building to retrieve</param>
    public (byte PlaceId, byte GlamourLevel, byte HoursToCompletion, byte BuildingLevel, bool UnderConstruction)
        this[int idx] => (
        this.PlaceId[idx],
        this.GlamourLevel[idx],
        this.HoursToCompletion[idx],
        this.BuildingLevel[idx],
        this.UnderConstruction[idx] > 0
    );
}

/// <summary>
/// A struct representing a list of granaries present in the Island Sanctuary.
/// 
/// The struct provides a helper method to retrieve information about a single granary (referenced by ID), but will
/// otherwise allow querying a specific field by ID directly.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x08 + 5 * MaxGranaries)]
public unsafe struct MJIGranaries {
    private const int MaxGranaries = 2;

    public void* vtbl;

    /// <inheritdoc cref="MJIWorkshops.PlaceId"/>
    public fixed byte PlaceId[MaxGranaries];

    /// <inheritdoc cref="MJIWorkshops.GlamourLevel"/>
    public fixed byte GlamourLevel[MaxGranaries];

    /// <inheritdoc cref="MJIWorkshops.HoursToCompletion"/>
    public fixed byte HoursToCompletion[MaxGranaries];

    /// <inheritdoc cref="MJIWorkshops.BuildingLevel"/>
    public fixed byte BuildingLevel[MaxGranaries];

    /// <inheritdoc cref="MJIWorkshops.UnderConstruction"/>
    public fixed byte UnderConstruction[MaxGranaries];

    public (byte PlaceId, byte GlamourLevel, byte HoursToCompletion, byte BuildingLevel, bool UnderConstruction)
        this[int idx] => (
        this.PlaceId[idx],
        this.GlamourLevel[idx],
        this.HoursToCompletion[idx],
        this.BuildingLevel[idx],
        this.UnderConstruction[idx] > 0
    );
}

[StructLayout(LayoutKind.Explicit, Size = 0x04)]
public struct MJIFarmPasture {
    [FieldOffset(0x00)] public byte Level;
    [FieldOffset(0x01)] public byte HoursToCompletion;
    [FieldOffset(0x02)] public bool UnderConstruction;
    [FieldOffset(0x03)] public byte EligibleForCare;
}
