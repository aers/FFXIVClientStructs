namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::Treasure
//   Client::Game::Object::GameObject
[GenerateInterop]
[Inherits<GameObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x210)]
public unsafe partial struct Treasure {

    /// <remarks>
    /// Has a lot of overlap with <see cref="Flags"/>.
    /// </remarks>
    [FieldOffset(0x1A0)] public TreasureState State;

    /// <remarks>
    /// Starts counting down in seconds from <see cref="CountdownStartTime"/> once spawned.  Unsure what hitting zero actually does
    /// in the unopened state.  If the treasure contains rollable items, opening the it resets this to the claim period length
    /// and it starts counting down again (except when lootmaster is active, in which case it resets to zero).  This value is
    /// rounded to nearest whole number and shown as the loot window timer.
    /// </remarks>
    [FieldOffset(0x1A4)] public float CountdownTime;

    /// <summary>
    /// The starting value of <see cref="CountdownTime"/> (in seconds) at initial object spawn.
    /// </summary>
    [FieldOffset(0x1A8)] public float CountdownStartTime;

    /// <summary>
    /// The number of seconds available after opening the treasure to be able to roll on or assign drops before auto-disposition of loot.
    /// </summary>
    [FieldOffset(0x1AC)] public float ClaimTime;

    /// <summary>
    /// The Item sheet row IDs for the contents of this treasure that have been added to the loot window.
    /// </summary>
    [FieldOffset(0x1B0), FixedSizeArray] internal FixedSizeArray16<uint> _lootableItemIds;

    /// <summary>
    /// The number of valid item IDs in <see cref="LootableItemIds"/>.
    /// </summary>
    [FieldOffset(0x1F0)] public byte ItemCount;

    [FieldOffset(0x1F4)] private int Unk_1F4; // Probably just a bool.  Seems to be something like "has been opened for looting while object exists locally for the current player", but more testing required.

    /// <summary>
    /// How many seconds the treasure has been open.
    /// </summary>
    /// <remarks>
    /// Starts from zero when opening.  Stops when fadeout begins.
    /// </remarks>
    [FieldOffset(0x1F8)] public float TreasureOpenTime;

    /// <remarks>
    /// Has a lot of overlap with <see cref="State"/>.
    /// </remarks>
    [FieldOffset(0x1FC)] public TreasureFlags Flags;

    /// <remarks>
    /// Seems to be -1 for treasures that can spawn in non-fixed locations (i.e., enemies dropping coffers, deep dungeon).  Have only otherwise seen zero.
    /// </remarks>
    [FieldOffset(0x1FE)] private short Unk_1FE;

    [FieldOffset(0x200)] public TreasureKind CofferKind;

    /// <remarks>
    /// Non-zero when the base ID does not have an SGB entry in the Treasure sheet.  So far only seen for treasure hunt coffers.
    /// </remarks>
    [FieldOffset(0x204)] public int ExportedSGRowId;

    public enum TreasureState : byte {
        Unopened = 0,
        Opening = 1,
        Opened = 2,
        Unk_3 = 3, // Went directly to this (skipped 1 and 2) when opening personal spoils in certain instances.  Is also a transition state that lasts a few frames as fadeout beings for some coffers.
        FadingOut = 4,
        FadedOut = 5,
    }

    [Flags]
    public enum TreasureFlags : byte {
        None = 0,
        Opened = 1,
        /// <remarks>
        /// Sometimes set when fading starts, sometimes when fading is complete.  It depends upon when TreasureState 3 happens.
        /// </remarks>
        FadedOut = 2,
        Unk_4 = 4, // Probably either "contains loot rollable by player's party", or "claim timer running for player's party" / "items from this treasure are in rolling UI window".
    }

    public enum TreasureKind : byte {
        Unknown = 0,
        Levequest = 1,
        DungeonRaid = 2,
        Unk_3 = 3,
        TreasureHunt = 4,
        PersonalLoot = 5, // Variant, Occult Crescent, etc.
    }
}
