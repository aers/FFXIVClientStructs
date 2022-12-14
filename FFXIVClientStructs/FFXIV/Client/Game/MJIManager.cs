namespace FFXIVClientStructs.FFXIV.Client.Game;

/// <summary>
///     Manager struct (?) for Island Sanctuary (internally MJI).
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x328)]
public unsafe partial struct MJIManager {
    /// <summary>
    ///     Reports if the player is currently on the Island Sanctuary.
    /// </summary>
    // Not actually sure about the accuracy of this name. It's a guess based on the fact that the map system and target
    // system appear to change their behavior when this is set to 1, plus verification with how it looks in game.
    [FieldOffset(0x06)] public byte IsPlayerInSanctuary;

    /// <summary>
    ///		Represents the currently allowed visitors to the Island Sanctuary.
    /// </summary>
    [FieldOffset(0x08)] public MJIAllowedVisitors AllowedVisitors;

    /// <summary>
    ///		The current mode (as listed in MJIHudMode) that the player is in.
    /// </summary>
    [FieldOffset(0x10)] public uint CurrentMode;

    /// <summary>
    ///		The currently-selected item for the player's gathering mode. Will only have a value if the gathering mode
    ///		in question supports item usage.
    /// </summary>
    [FieldOffset(0x1C)] public uint CurrentModeItem;

    // NOTE: At +0x28, there's a sub-structure of size A8 that has a lot of interesting things in it (namely, whatever
    // happens to be below). For now, this struct is just going to be ignored, as it mostly seems to cause confusion
    // when referring to the game code. That being said, it's possible to see how the struct is made by  taking a look
    // at E8 ?? ?? ?? ?? 0F B6 8C 1C, which appears to be some kind of clone function.

    #region sub-struct at 0x28

    /// <summary>
    ///     The current Sanctuary Rank of the player's island. Controls what buildings/items/recipes are or aren't
    ///		available to the player, and represented by MJIRank.
    /// </summary>
    [FieldOffset(0x29)] public byte CurrentRank;

    /// <summary>
    ///     The XP earned towards the next Island Sanctuary rank. Resets to 0 upon leveling up the Sanctuary. 
    /// </summary>
    [FieldOffset(0x2C)] public uint CurrentXP;

    /// <summary>
    ///		The current progress of the player, as represented by MJIProgress. Appears to be bound to the island
    ///		sanctuary "tutorial" more than anything.
    /// </summary>
    [FieldOffset(0x30)] public byte CurrentProgress;

    /// <summary>
    ///     The current development level of the player's village on their island. Controls what building zones are
    ///     available.
    /// </summary>
    /// <remarks>
    ///     Allowed building locations are part of the MJIBuildingPlace (+0x10) and MJILandmarkPlace (+0x10) Lumina
    ///		sheets.
    /// </remarks>
    [FieldOffset(0x31)] public byte VillageDevelopmentLevel;

    /// <summary>
    ///		A bitfield representing all unlocked key items (MJIKeyItem) for the player. Backing field for
    ///		<see cref="IsKeyItemUnlocked"/>, which should be used where possible.
    /// </summary>
    /// <remarks>
    ///		The index of this field will be (RowID - 1), so "Islekeep's Stone Hatchet" appears at position 0.
    /// </remarks>
    [FieldOffset(0x35)] public ushort UnlockedKeyItems; // bitfield

    /// <summary>
    ///		A bitfield representing if a specific recipe (MJIRecipe) is unlocked. Backing field for
    ///		<see cref="IsRecipeUnlocked"/>, which should be used where possible.
    /// </summary>
    // This is a weird size for a bitfield, I suppose. It starts at 0x37, spans 17 elements (requiring a minimum of 3
    // bytes), and is immediately followed by 0x3A. 
    [FieldOffset(0x37)] public fixed byte UnlockedRecipes[3]; // bitfield

    /// <summary>
    ///     An array of booleans representing if a specific item is (un)locked. Locked/unavailable items are set to true,
    ///     while those that are unlocked are false. This array is indexed by RowID from the MJIItemPouch table.
    ///     An item appears to be unlocked upon being gathered or crafted for the first time.
    ///     <seealso cref="IsPouchItemLocked" />
    /// </summary>
    [FieldOffset(0x3A)] public fixed byte LockedPouchItems[67];

    /// <summary>
    ///     The current number of hours remaining until a specific Landmark has finished construction.
    /// 
    ///     This value may be zero when there is either no construction or if construction is finished and the landmark
    ///     needs to be "finalized" by the player.
    ///     
    ///     This array is indexed by the RowID of an MJILandmarkPlace.
    /// </summary>
    [FieldOffset(0x8A)] public fixed byte LandmarkHoursToCompletion[4];
    
    /// <summary>
    ///     The RowID of the MJILandmark present at a specific MJILandmarkPlace.
    ///     
    ///     This array is indexed by the RowID of an MJILandmarkPlace.
    /// </summary>
    [FieldOffset(0x8E)] public fixed byte LandmarkIds[4];
    
    /// <summary>
    ///     The current construction status of a landmark at a specific MJILandmarkPlace.
    ///     
    ///     This array is indexed by the RowID of an MJILandmarkPlace.
    /// </summary>
    [FieldOffset(0x92)] public fixed byte LandmarkUnderConstruction[4];

    /// <summary>
    ///		A struct representing the current state of workshops present on the island. See the struct documentation
    ///		for more information on how to access this data.
    ///
    ///     Note that this struct only provides mapping from a workshop ID to other data. If information about a
    ///     building at a specific location is desired, it may be better to use <see cref="Facility1"/> et al.
    /// </summary>
    [FieldOffset(0x98)] public MJIWorkshops Workshops;

    /// <summary>
    ///		A struct representing the current state of granaries present on the island. See the struct documentation
    ///		for more information on how to access this data.
    /// </summary>
    [FieldOffset(0xB0)] public MJIGranaries Granaries;

    /// <summary>
    ///		The current level of the Cozy Cabin for the Island Sanctuary.
    /// </summary>
    /// <remarks>
    ///		This field is offset by 1 compared to the level present in MJIBuildings. Cabin Level 3 will actually have
    ///		a value of 3 in this field. This is *probably* because Cabin Level 0 is "nonexistent"..?
    /// </remarks>
    [FieldOffset(0xC8)] public byte CabinLevel;

    /// <summary>
    ///		The current glamour cast on the Cozy Cabin (if any). Relates to the appropriate sub-row in MJIBuilding.
    /// </summary>
    /// <remarks>
    ///		This field is *not* offset by one like CabinLevel; Cabin Level 3 will report here as 2.
    /// </remarks>
    [FieldOffset(0xC9)] public byte CabinGlamour;

    #endregion End sub-struct (0xCF last byte)
    
    /// <summary>
    ///     A struct representing landmark placements on the Island Sanctuary. Each index represents a specific landmark
    ///     slot directly. Refer to <see cref="MJILandmarkPlacement"/> for more information.
    /// </summary>
    /// <remarks>
    ///     This field's exact purpose is currently unknown, but seems to be related to either mapping or rendering
    ///     logic. To that end, this field doesn't actually seem authoritative for determining what's going on - see
    ///     <see cref="LandmarkIds"/> et al for what seems to be used by system logic.
    /// </remarks>
    [FieldOffset(0x16C)] public MJILandmarkPlacements LandmarkPlacements;
    
    /// <summary>
    ///     A struct representing building placements on the Island Sanctuary. Each index represents a specific building
    ///     slot directly. Refer to <see cref="MJIBuildingPlacement"/> for more information.
    /// </summary>
    /// <remarks>
    ///     This field's exact purpose is currently unknown, but seems to be related to either mapping or rendering
    ///     logic. To that end, this field doesn't actually seem authoritative for determining what's going on - see
    ///     <see cref="Granaries"/> and <see cref="Workshops"/> for what seems to be used by system logic.
    /// </remarks>
    [FieldOffset(0x19C)] public MJIBuildingPlacements BuildingPlacements;
    
    /// <summary>
    ///     The current day in the Craftworks cycle, from 0 to 6.
    /// </summary>
    /// <remarks>
    ///     0 represents reset day (Tuesday).
    /// </remarks>
    [FieldOffset(0x27A)] public byte CurrentCycleDay;
    
    /// <summary>
    ///     An array containing the currently-configured rest days for the Isleworks. Contains values 0 - 13, and is
    ///     always in order.
    /// </summary>
    /// <remarks>
    ///     Like CurrentCycleDay, 0 represents Reset Day. 7, likewise, represents the next reset. This field may not be
    ///     populated until the Craftworks have been opened at least once.
    /// </remarks>
    [FieldOffset(0x27B)] public fixed byte CraftworksRestDays[4];
    
    /// <summary>
    ///     The current groove level of the Isleworks.
    /// </summary>
    /// <remarks>
    ///     May not be present until the Isleworks is loaded at least once by the player.
    /// </remarks>
    [FieldOffset(0x2C8)] public uint CurrentGroove;

    /// <summary>
    ///     A reference to the current set of popularity scores given to craftworks on the player's island. The actual
    ///     popularity scores can be pulled from the MJICraftworksPopularity sheet using this value as a Row ID.
    /// </summary>
    [FieldOffset(0x2E8)] public byte CurrentPopularity;

    /// <summary>
    ///     A reference to the next cycle's popularity scores (called "predicted demand" in-game). Follows the same rules
    ///     as <see cref="CurrentPopularity" />.
    /// </summary>
    [FieldOffset(0x2E9)] public byte NextPopularity;

    /// <summary>
    ///     An array of bytes representing the current supply and demand shift for each craftwork that the player can
    ///     create. Information for a specific item can be retrieved by querying the RowID for the item under inspection.
    ///     <br /><br />
    ///     The current supply value is stored in the upper half of each byte, while the current demand shift is stored in
    ///     the lower half.
    /// </summary>
    [FieldOffset(0x2EA)] public fixed byte SupplyAndDemandShifts[62];

    /// <summary>
    ///     Retrieve an instance of IslandSanctuaryManager for consumption.
    /// </summary>
    /// <returns>Returns a pointer to the game's IslandSanctuaryManager instance.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 8B 50 10")]
    public static partial MJIManager* Instance();

    /// <summary>
    ///     Check if a specific MJIRecipe is *unlocked*. Does not care if the item has been crafted.
    /// </summary>
    /// <param name="recipeId">The recipe ID to check for.</param>
    /// <returns>Returns true if the recipe can be crafted, false otherwise.</returns>
    [MemberFunction("0F B7 C2 80 E2 07")]
    public partial bool IsRecipeUnlocked(ushort recipeId);

    /// <summary>
    ///     Check if a specific item in the Island Pouch is (un)locked.
    ///     See <see cref="LockedPouchItems" /> for more information. This method simply looks a value up from that
    ///     array.
    /// </summary>
    /// <param name="itemId">The MJIItemPouch row ID to look up.</param>
    /// <returns>Returns true if the item is locked and/or hidden to the player.</returns>
    [MemberFunction("0F B7 C2 0F B6 44 08")]
    public partial bool IsPouchItemLocked(ushort itemId);

    /// <summary>
    ///		Check if a specific MJIKeyItem is unlocked by the player.
    /// </summary>
    /// <remarks>
    ///		This is manually implemented as the only place this key item check actually seems to exist in the code is
    ///		(frustratingly) not within MJIManager. See <code>E8 ?? ?? ?? ?? 84 C0 74 61 48 85 DB</code> for the
    ///		reference(-ish) implementation used here.
    /// </remarks>
    /// <param name="keyItemId">The RowID of the MJIKeyItem to check.</param>
    /// <returns>Returns true if the key item is unlocked.</returns>
    public bool IsKeyItemUnlocked(ushort keyItemId) {
        return (this.UnlockedKeyItems & (1 << keyItemId - 1)) > 0;
    }

    /// <summary>
    ///     Return the Supply value for a specified craftwork.
    /// </summary>
    /// <param name="itemId">The Craftwork ID to look up</param>
    /// <returns>Returns an enum value.</returns>
    public CraftworkSupply GetSupplyForCraftwork(uint itemId) {
        return (CraftworkSupply) ((SupplyAndDemandShifts[itemId] & 0xF0) >> 4);
    }

    /// <summary>
    ///     Return the Demand Shift value for a specified craftwork.
    /// </summary>
    /// <param name="itemId">The Craftwork ID to look up</param>
    /// <returns>Returns an enum value.</returns>
    public CraftworkDemandShift GetDemandShiftForCraftwork(uint itemId) {
        return (CraftworkDemandShift) (SupplyAndDemandShifts[itemId] & 0x0F);
    }
}

/// <summary>
///     A helper struct that wraps an array of structs for <see cref="MJIBuildingPlacement"/>.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = Size)]
public unsafe struct MJIBuildingPlacements {
    public const int Slots = 6;  // 5 facilities + one cabin
    public const int Size = MJIBuildingPlacement.Size * Slots;
    
    private fixed byte data[Size];

    /// <summary>
    ///     Retrieve a specific MJIBuildingPlacement by facility ID.
    /// </summary>
    /// <remarks>
    ///     The facility ID is shown in-game plus one, so Facility III is site ID 2. The Cozy Cabin is present at Site 5.
    /// </remarks>
    /// <param name="i">The Building Site ID to pull data for. Valid values are currently 0 to 5.</param>
    public MJIBuildingPlacement* this[int i] {
        get {
            if (i < 0 || i >= Slots) return null;
            fixed (byte* p = data) {
                return (MJIBuildingPlacement*) (p + sizeof(MJIBuildingPlacement) * i);
            }
        }
    }
}

/// <summary>
///     A record of building population information at a specific Site ID. 
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct MJIBuildingPlacement {
    public const int Size = 0x10;
    
    /// <summary>
    ///     At load, the location of this specific building. Will update if a building is changed, but the exact
    ///     mechanism of the update (and why it does such) is not currently known.
    /// </summary>
    [FieldOffset(0x4)] public uint PlaceId;

    /// <summary>
    ///		The current model (?) ID of the building present in this slot.
    ///
    ///		When a building is fully constructed, this will be the value present at offset +0x0C from MJIBuilding. While
    ///		a building is under construction, however, the appropriate model (as determined by progress) will be shown
    ///		from columns +0E, +10, +12, or +14.
    ///
    ///		Can also be a blank model ID, if nothing is built in that location yet.
    /// </summary>
    [FieldOffset(0x8)] public ushort BuildingTypeId;
}

/// <summary>
///     A struct representing a list of workshops present in the Island Sanctuary.
///     
///     The struct provides a helper method to retrieve information about a single workshop (referenced by ID), but will
///     otherwise allow querying a specific field by ID directly.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x08 + 5 * MaxWorkshops)]
public unsafe struct MJIWorkshops {
    private const int MaxWorkshops = 3;

    public void* vtbl;

    /// <summary>
    ///     The MJIBuildingPlace in which this particular building resides.
    ///     
    ///     If this building is not built, this value will be zero.
    /// </summary>
    public fixed byte PlaceId[MaxWorkshops];

    /// <summary>
    ///     The glamour level of a particular building. This value refers to a specific sub-row of MJIBuilding.
    /// </summary>
    /// <remarks>
    ///     This level is one less than the building's level; Workshop III will report as 2.
    /// </remarks>
    public fixed byte GlamourLevel[MaxWorkshops];

    /// <summary>
    ///     Hours remaining in the construction/upgrade of a building.
    ///     
    ///     If the building is done or is not under construction, this value will be zero.
    /// </summary>
    public fixed byte HoursToCompletion[MaxWorkshops];

    /// <summary>
    ///     The true level of a particular building. Like GlamourLevel, also refers to a specific sub-row of MJIBuilding.
    /// </summary>
    /// <remarks>
    ///     This level is one less than the building's level; Workshop III will report as 2.
    /// </remarks>
    public fixed byte BuildingLevel[MaxWorkshops];

    /// <summary>
    ///     Report if a specific building is currently under construction.
    /// 
    ///     May report 1 while HoursToCompletion is 0 if the building needs to be "finalized" through user interaction.
    /// </summary>
    /// <remarks>
    ///     So far the only observed value for this field is 0 or 1, but more values may exist (?).
    /// </remarks>
    public fixed byte UnderConstruction[MaxWorkshops];

    /// <summary>
    ///     Helper method to return all known information about a specific building at once.
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
///     A struct representing a list of granaries present in the Island Sanctuary.
///     
///     The struct provides a helper method to retrieve information about a single granary (referenced by ID), but will
///     otherwise allow querying a specific field by ID directly.
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

/// <summary>
///     A helper struct that wraps an array of structs for <see cref="MJILandmarkPlacement"/>.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = Size)]
public unsafe struct MJILandmarkPlacements {
    public const int Slots = 4;  // 4 landmarks
    public const int Size = MJILandmarkPlacement.Size * Slots;
    
    private fixed byte data[Size];

    /// <summary>
    ///     Retrieve a specific MJILandmarkPlacement by site ID.
    /// </summary>
    /// <param name="i">The Landmark Site ID to pull data for. Valid values are currently 0 to 3.</param>
    public MJILandmarkPlacement* this[int i] {
        get {
            if (i < 0 || i >= Slots) return null;
            fixed (byte* p = data) {
                return (MJILandmarkPlacement*) (p + sizeof(MJILandmarkPlacement) * i);
            }
        }
    }
}

/// <summary>
///     A record of landmark population information at a specific Site ID. 
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = Size)]
public struct MJILandmarkPlacement {
    public const int Size = 0xC;
    
    /// <summary>
    ///		The RowID of the landmark currently present at the specified location.
    /// </summary>
    [FieldOffset(0x9)] public byte LandmarkId;
}

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
    None = 2,
    Decreasing = 3,
    Plummeting = 4
}

[Flags]
public enum MJIAllowedVisitors : byte {
    Friends = 1,
    FreeCompany = 2,
    Party = 4
}