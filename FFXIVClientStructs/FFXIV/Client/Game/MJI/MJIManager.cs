namespace FFXIVClientStructs.FFXIV.Client.Game.MJI;

/// <summary>
/// Manager for Island Sanctuary (internally MJI).
/// </summary>
// Client::Game::MJI::MJIManager
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 33 F6 48 C7 01"
[StructLayout(LayoutKind.Explicit, Size = 0x440)]
public unsafe partial struct MJIManager {
    /// <summary>
    /// Reports if the player is currently on the Island Sanctuary.
    /// </summary>
    // Not actually sure about the accuracy of this name. It's a guess based on the fact that the map system and target
    // system appear to change their behavior when this is set to 1, plus verification with how it looks in game.
    [FieldOffset(0x06)] public byte IsPlayerInSanctuary;

    /// <summary>
    /// Represents the currently allowed visitors to the Island Sanctuary.
    /// </summary>
    [FieldOffset(0x08)] public MJIAllowedVisitors AllowedVisitors;

    /// <summary>
    /// The current mode (as listed in MJIHudMode) that the player is in.
    /// </summary>
    [FieldOffset(0x10)] public uint CurrentMode;

    /// <summary>
    /// The currently-selected item for the player's gathering mode. Will only have a value if the gathering mode
    /// in question supports item usage.
    /// </summary>
    [FieldOffset(0x1C)] public uint CurrentModeItem;

    [FieldOffset(0x28)] public IslandState IslandState;

    [FieldOffset(0x128)] public MJIPastureHandler* PastureHandler;
    [FieldOffset(0x130)] public MJIFarmState* FarmState;
    [FieldOffset(0x140)] public MJIGranariesState* GranariesState;

    [FieldOffset(0x168)] public MJIFavorState* FavorState;

    /// <summary>
    /// A struct representing landmark placements on the Island Sanctuary. Each index represents a specific landmark
    /// slot directly. Refer to <see cref="MJILandmarkPlacement"/> for more information.
    /// </summary>
    /// <remarks>
    /// This field's exact purpose is currently unknown, but seems to be related to either mapping or rendering
    /// logic. To that end, this field doesn't actually seem authoritative for determining what's going on - see
    /// <see cref="MJI.IslandState.LandmarkIds"/> et al for what seems to be used by system logic.
    /// </remarks>
    [FixedSizeArray<MJILandmarkPlacement>(5)]
    [FieldOffset(0x1D4)] public fixed byte LandmarkPlacements[5 * MJILandmarkPlacement.Size]; // ??

    /// <summary>
    /// A struct representing building placements on the Island Sanctuary. Each index represents a specific building
    /// slot directly. Refer to <see cref="MJIBuildingPlacement"/> for more information.
    /// </summary>
    /// <remarks>
    /// This field's exact purpose is currently unknown, but seems to be related to either mapping or rendering
    /// logic. To that end, this field doesn't actually seem authoritative for determining what's going on - see
    /// <see cref="MJI.IslandState.Granaries"/> and <see cref="MJI.IslandState.Workshops"/> for what seems to be
    /// used by system logic.
    /// </remarks>
    [FixedSizeArray<MJIBuildingPlacement>(6)]
    [FieldOffset(0x224)] public fixed byte BuildingPlacements[6 * MJIBuildingPlacement.Size];

    /// <summary>
    /// A struct representing information about the cabin.
    /// </summary>
    /// <remarks>
    /// Like <c>MJIBuildingPlacements</c>, the purpose of this field is unknown but it at least appears to behave
    /// like any other building placement.
    /// </remarks>
    [FieldOffset(0x284)] public MJIBuildingPlacement CabinPlacement;

    /// <summary>
    /// A struct representing farm (garden/cropland) placements on the current Island Sanctuary.
    /// </summary>
    [FixedSizeArray<MJIFarmPasturePlacement>(3)]
    [FieldOffset(0x294)] public fixed byte FarmPlacements[MJIFarmPasturePlacement.Size * 3];

    /// <summary>
    /// A struct representing pasture placements on the current Island Sanctuary. Identical in behavior (hopefully)
    /// to that of <see cref="FarmPlacements"/>
    /// </summary>
    [FixedSizeArray<MJIFarmPasturePlacement>(3)]
    [FieldOffset(0x2B8)] public fixed byte PasturePlacements[MJIFarmPasturePlacement.Size * 3];

    [FieldOffset(0x2E0)] public ushort RequestDemandCraftId;
    [FieldOffset(0x2E4)] public int RequestDemandType; // 0 = none, 1 = everything, 2 = specific object
    [FieldOffset(0x2E8)] public bool DemandDirty; // if true, fields below (popularity and supply/demand are unset)

    /// <summary>
    /// A reference to the current set of popularity scores given to craftworks on the player's island. The actual
    /// popularity scores can be pulled from the MJICraftworksPopularity sheet using this value as a Row ID.
    /// Valid only if DemandDirty == false.
    /// </summary>
    [FieldOffset(0x2F0)] public byte CurrentPopularity;

    /// <summary>
    /// A reference to the next cycle's popularity scores (called "predicted demand" in-game). Follows the same rules
    /// as <see cref="CurrentPopularity" />.
    /// Valid only if DemandDirty == false.
    /// </summary>
    [FieldOffset(0x2F1)] public byte NextPopularity;

    /// <summary>
    /// An array of bytes representing the current supply and demand shift for each craftwork that the player can
    /// create. Information for a specific item can be retrieved by querying the RowID for the item under inspection.
    /// Valid only if DemandDirty == false.
    /// <br /><br />
    /// The current supply value is stored in the upper half of each byte, while the current demand shift is stored in
    /// the lower half.
    /// </summary>
    // Set to the row count of the MJICraftworksObject table
    [FieldOffset(0x2F2)] public fixed byte SupplyAndDemandShifts[91];

    /// <summary>
    /// The current day in the Craftworks cycle, from 0 to 6.
    /// </summary>
    /// <remarks>
    /// 0 represents reset day (Tuesday).
    /// </remarks>
    [FieldOffset(0x3A8)] public byte CurrentCycleDay;

    /// <summary>
    /// An array containing the currently-configured rest days for the Isleworks. Contains values 0 - 13, and is
    /// always in order.
    /// </summary>
    /// <remarks>
    /// Like CurrentCycleDay, 0 represents Reset Day. 7, likewise, represents the next reset. This field may not be
    /// populated until the Craftworks have been opened at least once.
    /// </remarks>
    [FieldOffset(0x3A9)] public fixed byte CraftworksRestDays[4];

    /// <summary>
    /// The current groove level of the Isleworks.
    /// </summary>
    /// <remarks>
    /// May not be present until the Isleworks is loaded at least once by the player.
    /// </remarks>
    [FieldOffset(0x3F6)] public uint CurrentGroove; // unverified for 6.5!

    /// <summary>
    /// Retrieve an instance of IslandSanctuaryManager for consumption.
    /// </summary>
    /// <returns>Returns a pointer to the game's IslandSanctuaryManager instance.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 8B 50 10")]
    public static partial MJIManager* Instance();

    /// <summary>
    /// Check if a specific MJIRecipe is *unlocked*. Does not care if the item has been crafted.
    /// </summary>
    /// <param name="recipeId">The recipe ID to check for.</param>
    /// <returns>Returns true if the recipe can be crafted, false otherwise.</returns>
    [MemberFunction("0F B7 C2 80 E2 07")]
    public partial bool IsRecipeUnlocked(ushort recipeId);

    /// <summary>
    /// Check if a specific item in the Island Pouch is (un)locked.
    /// See <see cref="MJI.IslandState.LockedPouchItems" /> for more information. This method simply looks a value
    /// up from that array.
    /// </summary>
    /// <param name="itemId">The MJIItemPouch row ID to look up.</param>
    /// <returns>Returns true if the item is locked and/or hidden to the player.</returns>
    [MemberFunction("0F B7 C2 0F B6 44 08")]
    public partial bool IsPouchItemLocked(ushort itemId);

    /// <summary>
    /// Check if an item (by EXD item ID) is locked in Island Sanctuary. This method performs *no validation* that
    /// the Item passed to it is actually an Island Sanctuary item.
    /// </summary>
    /// <remarks>
    /// This method performs an EXD lookup. If the Item is already known, it is better to query
    /// <see cref="MJI.IslandState.LockedPouchItems" />  by the AdditionalData field of the Item to avoid the
    /// unnecessary call.
    /// </remarks>
    /// <seealso cref="IsPouchItemLocked" />
    /// <param name="itemId">The Item ID (from EXD) to look up.</param>
    /// <returns>Returns <c>true</c> if the item is locked, <c>false</c> otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 04 33 ED")]
    public partial bool IsItemLocked(uint itemId);

    /// <summary>
    /// Checks if a specific MJIFunction is unlocked and able to be used
    /// </summary>
    /// <param name="functionId">The RowID of the MJIFunction to check</param>
    /// <returns>Returns <c>true</c> if the function is unlocked, <c>false</c> otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 44 3A F0")]
    public partial bool IsFunctionUnlocked(byte functionId);

    /// <summary>
    /// Get a bitfield representing the currently-displayed minimap icons.
    /// </summary>
    /// <returns></returns>
    [MemberFunction("E8 ?? ?? ?? ?? 85 47 40")]
    public partial MJIMinimapIcons GetVisibleMinimapIcons();

    /// <summary>
    /// Gets the total number of slots available in the Island Sanctuary pasture.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 C0 48 8D 9E")]
    public partial byte GetPastureSlotCount();

    /// <summary>
    /// Gets the total number of slots available Island Sanctuary farm.
    /// </summary>
    /// <returns></returns>
    [MemberFunction("E8 ?? ?? ?? ?? 45 33 F6 0F B6 D0")]
    public partial byte GetFarmSlotCount();

    /// <summary>
    /// Request updated popularity and demand data.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CD E8 ?? ?? ?? ?? 32 C0")]
    public partial void RequestDemandFull();

    /// <summary>
    /// Schedule specified item to be crafted in a given workshop at a given time.
    /// </summary>
    /// <param name="craftObjectId">MJICraftworksObject row id for object to be crafted.</param>
    /// <param name="startingHour">(slot + 17) % 24, where slot 0 is first hour of the cycle.</param>
    /// <param name="cycle">0-13 range, this/next week in order.</param>
    /// <param name="workshop">0-3 range.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 46 28 41 8D 4E FF")]
    public partial void ScheduleCraft(ushort craftObjectId, byte startingHour, byte cycle, byte workshop);

    /// <summary>
    /// Request updated favor data.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 47 28 C7 00")]
    public partial void RequestFavorData();

    /// <summary>
    /// Check if a specific MJIKeyItem is unlocked by the player.
    /// </summary>
    /// <remarks>
    /// This is manually implemented as the only place this key item check actually seems to exist in the code is
    /// (frustratingly) not within MJIManager. See <code>E8 ?? ?? ?? ?? 84 C0 74 61 48 85 DB</code> for the
    /// reference(-ish) implementation used here.
    /// </remarks>
    /// <param name="keyItemId">The RowID of the MJIKeyItem to check.</param>
    /// <returns>Returns true if the key item is unlocked.</returns>
    public bool IsKeyItemUnlocked(ushort keyItemId) {
        return ((1 << (keyItemId & 7)) & this.IslandState.UnlockedKeyItems[keyItemId >> 3]) > 0;
    }

    /// <summary>
    /// Return the Supply value for a specified craftwork.
    /// </summary>
    /// <param name="itemId">The Craftwork ID to look up</param>
    /// <returns>Returns an enum value.</returns>
    public CraftworkSupply GetSupplyForCraftwork(uint itemId) {
        return (CraftworkSupply)((this.SupplyAndDemandShifts[itemId] & 0xF0) >> 4);
    }

    /// <summary>
    /// Return the Demand Shift value for a specified craftwork.
    /// </summary>
    /// <param name="itemId">The Craftwork ID to look up</param>
    /// <returns>Returns an enum value.</returns>
    public CraftworkDemandShift GetDemandShiftForCraftwork(uint itemId) {
        return (CraftworkDemandShift)(this.SupplyAndDemandShifts[itemId] & 0x0F);
    }
}

/// <summary>
/// A record of building population information at a specific Site ID. 
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct MJIBuildingPlacement {
    public const int Size = 0x10;

    /// <summary>
    /// At load, the location of this specific building. Will update if a building is changed, but the exact
    /// mechanism of the update (and why it does such) is not currently known.
    /// </summary>
    [FieldOffset(0x4)] public uint PlaceId;

    /// <summary>
    /// The current SGB ID of this particular building.
    ///
    /// When a building is fully constructed, this will be the value present at offset +0x0C from MJIBuilding. While
    /// a building is under construction, however, the appropriate model (as determined by progress) will be shown
    /// from columns +0E, +10, +12, or +14.
    ///
    /// Can also be zero, if nothing is built in that location yet.
    /// </summary>
    [FieldOffset(0x8)] public ushort SgbId;
}

/// <summary>
/// A record of landmark population information at a specific Site ID. 
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = Size)]
public struct MJILandmarkPlacement {
    public const int Size = 0x10;

    [FieldOffset(0x8)] public byte HoursToCompletion;

    /// <summary>
    /// The RowID of the landmark currently present at the specified location.
    /// </summary>
    [FieldOffset(0x9)] public byte LandmarkId;

    [FieldOffset(0xA)] public ushort UnderConstruction; // ?? unverified for 6.5!

    [FieldOffset(0xC)] public ushort Rotation;
}

/// <summary>
/// A record of landmark population information at a specific Site ID. 
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = Size)]
public struct MJIFarmPasturePlacement {
    public const int Size = 0xC;

    /// <summary>
    /// The SGB ID of the model to use for this location
    /// </summary>
    [FieldOffset(0x8)] public byte SgbId;
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

[Flags]
public enum MJIMinimapIcons : byte {
    Trees = 1,
    Vegetation = 2,
    Soils = 4,
    Minerals = 8,
    Aquatic = 16
}
