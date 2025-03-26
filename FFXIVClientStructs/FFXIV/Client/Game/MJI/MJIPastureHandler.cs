namespace FFXIVClientStructs.FFXIV.Client.Game.MJI;

// Client::Game::MJI::MJIPastureHandler
//   Client::Game::Event::EventHandler
// ctor "48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 20 BA ?? ?? ?? ?? 48 8B F9"
[GenerateInterop]
[Inherits<Client.Game.Event.EventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0xBA8)]
public unsafe partial struct MJIPastureHandler {
    // 0x230: AtkEventInterface-derived structure of size 0x30, used by agent to execute operations

    /// <summary>
    /// Mapping from MJIAnimal row id to Item row ids for both leavings.
    /// </summary>
    [FieldOffset(0x2D0)] public StdMap<uint, StdPair<uint, uint>> AnimalToLeavingItemIds;

    /// <summary>
    /// Per-item totals of uncollected leavings.
    /// Key is Item sheet row id, value is total amount for all animals.
    /// </summary>
    [FieldOffset(0x2E0)] public StdMap<uint, int> AvailableMammetLeavings;

    /// <summary>
    /// An array representing all animals currently present in the pastures on the Island. 
    /// </summary>
    [FieldOffset(0x2F0), FixedSizeArray] internal FixedSizeArray20<MJIAnimal> _MJIAnimals;

    /// <summary>
    /// An array representing which minions are currently out roaming the Island. This array is indexed by row ID from
    /// the Companion EXD sheet. See <see cref="MinionSlots"/> if information about minion locations is required.
    /// </summary>
    // Warning: This array will change size every time new minions are added!! Should be the row count of the Companion sheet.
    [FieldOffset(0x700), FixedSizeArray] internal FixedSizeArray512<bool> _roamingMinions;

    /// <summary>
    /// An array containing information on all the minion slots present on the Island Sanctuary.
    /// This array is indexed by an internal ID and does not appear to be grouped by location or similar.
    /// </summary>
    [FieldOffset(0x900), FixedSizeArray] internal FixedSizeArray50<MJIMinionSlot> _minionSlots;

    // 0xB50: substructure describing currently captured animal, if there are no slots available; size is at least 8

    /// <summary>
    /// Collect all leavings gathered by mammets.
    /// </summary>
    [MemberFunction("48 83 EC 38 E8 ?? ?? ?? ?? 45 33 C9 C7 44 24 ?? ?? ?? ?? ?? 45 33 C0 8B D0 B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 83 C4 38 C3 CC CC CC CC CC CC CC CC 40 53")]
    public partial void CollectLeavingsAll();

    /// <summary>
    /// Gets the current number of minions roaming the Island Sanctuary.
    /// </summary>
    [MemberFunction("32 C0 4C 8D 81 ?? ?? ?? ?? 41 B9 ?? ?? ?? ?? 90 41 81 38 ?? ?? ?? ??")]
    public partial byte GetCurrentRoamingMinionCount();
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = Size)]
public unsafe partial struct MJIAnimal {
    public const int Size = 0x34;

    [FieldOffset(0x00)] public byte SlotId;
    [FieldOffset(0x01), FixedSizeArray(isString: true)] internal FixedSizeArray24<byte> _nickname;
    [FieldOffset(0x1C)] public uint BNPCNameId;
    [FieldOffset(0x20)] public uint EntityId;

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

    [FieldOffset(0x4)] public uint EntityId;
    [FieldOffset(0x8)] public ushort MinionId;

    /// <summary>
    /// The MJIMinionPopAreaId that this minion currently resides in.
    /// </summary>
    [FieldOffset(0xA)] public byte PopAreaId;

    /// <summary>
    /// Check if this specific Minion Slot contains a minion or not.
    /// </summary>
    /// <returns>Returns <c>true</c> if a minion is present, <c>false</c> otherwise.</returns>
    public bool IsSlotPopulated() => MinionId != 0;
}
