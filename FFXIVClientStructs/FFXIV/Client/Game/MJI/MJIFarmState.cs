namespace FFXIVClientStructs.FFXIV.Client.Game.MJI;

// Client::Game::MJI::MJIFarmState
// ctor "E8 ?? ?? ?? ?? EB 03 48 8B C7 33 D2 48 89 83 ?? ?? ?? ?? 45 33 C0 8D 4A 01"
// vast majority of struct info from "E8 ?? ?? ?? ?? 8B 4C 24 24 E8"
[StructLayout(LayoutKind.Explicit, Size = 0x148)]
public unsafe partial struct MJIFarmState {
    [FieldOffset(0x00)] public void* vtbl;

    // 0x08: substructure of size 0x10, some interface with vtable and pointer back to the outer object
    [FieldOffset(0x08)] public void* vtbl2; // ??
    // 0x08+0x08: MJIFarmState* owner

    [FieldOffset(0x18)] public bool LayoutInitialized; // if false, PlotObjectIndex / LayoutId arrays are unset
    [FieldOffset(0x1A)] public ushort ReactionEventObjectRowId; // primary row index in ReactionEventObject sheet, equal to 5

    [FieldOffset(0x20)] public fixed byte SeedType[20];
    [FieldOffset(0x34)] public fixed byte GrowthLevel[20];
    [FieldOffset(0x48)] public fixed byte WaterLevel[20];
    [FieldOffset(0x5C)] public fixed byte GardenerYield[20];

    [FixedSizeArray<FarmSlotFlags>(20)]
    [FieldOffset(0x70)] public fixed byte FarmSlotFlags[20];

    [FieldOffset(0x88)] public fixed uint PlotObjectIndex[20]; // ??
    [FieldOffset(0xD8)] public fixed uint LayoutId[20];

    [FieldOffset(0x128)] public StdVector<uint> SeedItemIds; // index = MJICropSeed row id, value = corresponding seed's Item row id
    [FieldOffset(0x140)] public int ExpectedTotalYield; // checked when collect all request is executed
    [FieldOffset(0x144)] public bool SlotUpdatePending;
    [FieldOffset(0x145)] public byte SlotUpdateIndex;

    /// <summary>
    /// Start care for specified slot, planting specified seed.
    /// </summary>
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 30 41 8B D8 8B FA E8 ?? ?? ?? ?? 48 85 C0")]
    public partial void Entrust(uint slot, uint seedItemId);

    /// <summary>
    /// Stop care for specified slot.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? EB 22 48 8D 4E 10 E8 ?? ?? ?? ?? 48 8D 4E 20 8B D8")]
    public partial void Dismiss(uint slot);

    /// <summary>
    /// Collect yield from a single slot.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? EB 4C 48 8D 4E 10")]
    public partial void CollectSingle(uint slot);

    /// <summary>
    /// Collect yield from a single slot and stop care.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? EB 6B E8 ?? ?? ?? ?? 48 85 C0")]
    public partial void CollectSingleAndDismiss(uint slot);

    /// <summary>
    /// Update expected total yield field - this is checked by the CollectAll function, which errors out if new items were gathered since last update.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8D 4E 20 E8 ?? ?? ?? ?? 0F B6 D8")]
    public partial void UpdateExpectedTotalYield();

    /// <summary>
    /// Try to collect yields from all slots.
    /// </summary>
    /// <param name="allowOvercap">If this is false, does not perform the collection if any materials would overcap.</param>
    /// <returns>False if allowOvercap is false and overcap would happen, true otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 12 C7 07")]
    public partial bool CollectAll(bool allowOvercap);
}

[Flags]
public enum FarmSlotFlags : byte {
    UnderCare = 1,
    WasUnderCare = 2, // true if mammet was dismissed after already being paid - re-entrusting won't cost anything
    CareHalted = 4,
    Flag8 = 8
}
