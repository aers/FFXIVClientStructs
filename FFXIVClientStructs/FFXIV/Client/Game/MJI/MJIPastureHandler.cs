namespace FFXIVClientStructs.FFXIV.Client.Game.MJI; 


// ctor 1413EA840 ? - extends EventHandler
[StructLayout(LayoutKind.Explicit, Size = 0xAE0)]
public unsafe partial struct MJIPastureHandler {
    [FieldOffset(0x0)] public void* vtbl;
    
    /// <summary>
    /// An array representing all animals currently present in the pastures on the Island. 
    /// </summary>
    [FixedSizeArray<MJIAnimal>(20)]
    [FieldOffset(0x2E8)] public fixed byte MJIAnimals[MJIAnimal.Size * 20];

    /// <summary>
    /// An array representing which minions are currently out roaming the Island. This array is indexed by row ID from
    /// the Companion EXD sheet. See <see cref="MinionSlots"/> if information about minion locations is required.
    /// </summary>
    // Warning: This array will change size every time new minions are added!!
    [FixedSizeArray<bool>(480)]
    [FieldOffset(0x6F8)] public fixed byte RoamingMinions[480];

    /// <summary>
    /// An array containing information on all the minion slots present on the Island Sanctuary.
    /// This array is indexed by an internal ID and does not appear to be grouped by location or similar.
    /// </summary>
    [FixedSizeArray<MJIMinionSlot>(40)] 
    [FieldOffset(0x8B8)] public fixed byte MinionSlots[40 * MJIMinionSlot.Size];

    /// <summary>
    /// Gets the current number of minions roaming the Island Sanctuary.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 3A C3 72 1E")]
    public partial byte GetCurrentRoamingMinionCount();
}

[StructLayout(LayoutKind.Explicit, Size = Size)]
public struct MJIAnimal {
    public const int Size = 0x34;

    [FieldOffset(0x0)] public byte SlotId;
    [FieldOffset(0x1C)] public uint BNPCNameId;
    [FieldOffset(0x20)] public uint ObjectId;
    [FieldOffset(0x24)] public byte AnimalType;
    [FieldOffset(0x25)] public byte FoodLevel;
    [FieldOffset(0x26)] public byte Mood;
    [FieldOffset(0x27)] public ushort Leavings; // ??
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