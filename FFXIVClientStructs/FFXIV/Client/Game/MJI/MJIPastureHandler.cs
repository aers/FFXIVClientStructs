namespace FFXIVClientStructs.FFXIV.Client.Game.MJI;

// Client::Game::MJI::MJIPastureHandler
//   Client::Game::Event::EventHandler
// ctor "48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 20 BA ?? ?? ?? ?? 48 8B F9"
[StructLayout(LayoutKind.Explicit, Size = 0xB78)]
public unsafe partial struct MJIPastureHandler {
    [FieldOffset(0x0)] public void* vtbl;

    // 0x230: AtkEventInterface-derived structure of size 0x30, used by agent to execute operations

    /// <summary>
    /// Mapping from MJIAnimal row id to Item row ids for both leavings.
    /// </summary>
    [FieldOffset(0x2C8)] public StdMap<uint, StdPair<uint, uint>> AnimalToLeavingItemIds;

    /// <summary>
    /// Per-item totals of uncollected leavings.
    /// Key is Item sheet row id, value is total amount for all animals.
    /// </summary>
    [FieldOffset(0x2D8)] public StdMap<uint, int> AvailableMammetLeavings;

    /// <summary>
    /// An array representing all animals currently present in the pastures on the Island. 
    /// </summary>
    [FixedSizeArray<MJIAnimal>(20)]
    [FieldOffset(0x2E8)] public fixed byte MJIAnimals[MJIAnimal.Size * 20];

    /// <summary>
    /// An array representing which minions are currently out roaming the Island. This array is indexed by row ID from
    /// the Companion EXD sheet. See <see cref="MinionSlots"/> if information about minion locations is required.
    /// </summary>
    // Warning: This array will change size every time new minions are added!! Should be the row count of the Companion sheet.
    [FixedSizeArray<bool>(512)]
    [FieldOffset(0x6F8)] public fixed byte RoamingMinions[512];

    /// <summary>
    /// An array containing information on all the minion slots present on the Island Sanctuary.
    /// This array is indexed by an internal ID and does not appear to be grouped by location or similar.
    /// </summary>
    [FixedSizeArray<MJIMinionSlot>(50)]
    [FieldOffset(0x8F8)] public fixed byte MinionSlots[50 * MJIMinionSlot.Size];

    // 0xB50: substructure describing currently captured animal, if there are no slots available; size is at least 8

    /// <summary>
    /// Collect all leavings gathered by mammets.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? EB 72 48 8D 4D 10")]
    public partial void CollectLeavingsAll();

    /// <summary>
    /// Gets the current number of minions roaming the Island Sanctuary.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 3A C3 72 1E")]
    public partial byte GetCurrentRoamingMinionCount();
}

[StructLayout(LayoutKind.Explicit, Size = Size)]
public unsafe struct MJIAnimal {
    public const int Size = 0x34;

    [FieldOffset(0x00)] public byte SlotId;
    [FieldOffset(0x01)] public fixed byte Nickname[24]; // string
    [FieldOffset(0x1C)] public uint BNPCNameId;
    [FieldOffset(0x20)] public uint ObjectId;

    /// <summary>
    /// Row index in MJIAnimals sheet.
    /// </summary>
    [FieldOffset(0x24)] public byte AnimalType;

    /// <summary>
    /// Value representing the animal's current food level. Decreases once every hour.
    /// Appears to cap at 36.
    /// </summary>
    [FieldOffset(0x25)] public byte FoodLevel;

    /// <summary>
    /// The animal's current mood. Ranges from 0 for "very unhappy" (lightning icon) to 4 for "very happy" (sun icon).
    /// </summary>
    [FieldOffset(0x26)] public byte Mood;

    [FieldOffset(0x27), Obsolete("Use ManualLeavingsAvailable & UnderCare fields instead.")] public ushort Leavings; // ?? unsure why this is a ushort.

    /// <summary>
    /// True if there are some leavings that you can manually collect.
    /// </summary>
    [FieldOffset(0x27)] public bool ManualLeavingsAvailable;

    /// <summary>
    /// True if this animal is managed by a mammet.
    /// </summary>
    [FieldOffset(0x28)] public bool UnderCare;

    /// <summary>
    /// True if mammet was paid for care already - if true, dismissing and re-entrusting won't cost anything.
    /// </summary>
    [FieldOffset(0x29)] public bool WasUnderCare;

    /// <summary>
    /// True if not cared for, either because mammet was not assigned, or because it was not paid.
    /// </summary>
    [FieldOffset(0x2A)] public bool CareHalted;

    /// <summary>
    /// 0 if not under care, otherwise Item row id of used food.
    /// </summary>
    [FieldOffset(0x2C)] public uint AutoFoodItemId;

    /// <summary>
    /// Number of leavings of each type automatically gathered by a mammet that are ready for collection.
    /// </summary>
    [FieldOffset(0x30)] public byte AutoAvailableLeavings1;
    [FieldOffset(0x31)] public byte AutoAvailableLeavings2;
}

[StructLayout(LayoutKind.Explicit, Size = Size)]
public struct MJIMinionSlot {
    public const int Size = 0xC;

    /// <summary>
    /// An internal ID used to track minion slots.
    /// </summary>
    /// <remarks>
    /// May be set to 40 if the slot is currently empty or uninitialized.
    /// </remarks>
    [FieldOffset(0x0)] public byte SlotId;

    [FieldOffset(0x4)] public uint ObjectId;
    [FieldOffset(0x8)] public ushort MinionId;

    /// <summary>
    /// The MJIMinionPopAreaId that this minion currently resides in.
    /// </summary>
    [FieldOffset(0xA)] public byte PopAreaId;

    /// <summary>
    /// Check if this specific Minion Slot contains a minion or not.
    /// </summary>
    /// <returns>Returns <c>true</c> if a minion is present, <c>false</c> otherwise.</returns>
    public bool IsSlotPopulated() => this.MinionId != 0;
}
