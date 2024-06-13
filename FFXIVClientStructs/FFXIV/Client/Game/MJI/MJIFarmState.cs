namespace FFXIVClientStructs.FFXIV.Client.Game.MJI;

// Client::Game::MJI::MJIFarmState
// ctor "48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8D 05 ?? ?? ?? ?? 48 89 49 10"
// vast majority of struct info from "E8 ?? ?? ?? ?? 8B 4C 24 24 E8"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x148)]
public unsafe partial struct MJIFarmState {
    [FieldOffset(0x18)] public bool LayoutInitialized; // if false, PlotObjectIndex / LayoutId arrays are unset
    [FieldOffset(0x1A)] public ushort ReactionEventObjectRowId; // primary row index in ReactionEventObject sheet, equal to 5

    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray20<byte> _seedType;
    [FieldOffset(0x34), FixedSizeArray] internal FixedSizeArray20<byte> _growthLevel;
    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray20<byte> _waterLevel;
    [FieldOffset(0x5C), FixedSizeArray] internal FixedSizeArray20<byte> _gardenerYield;

    [FieldOffset(0x70), FixedSizeArray] internal FixedSizeArray20<FarmSlotFlags> _farmSlotFlags;

    [FieldOffset(0x88), FixedSizeArray] internal FixedSizeArray20<uint> _plotObjectIndex; // ??
    [FieldOffset(0xD8), FixedSizeArray] internal FixedSizeArray20<uint> _layoutId;

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
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8D 4F 10 E8 ?? ?? ?? ?? 48 8D 4F 20 8B F0 E8 ?? ?? ?? ?? 84 C0")]
    public partial void Dismiss(uint slot);

    /// <summary>
    /// Collect yield from a single slot.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 0F 84 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 88 ?? ?? ?? ??")]
    public partial void CollectSingle(uint slot);

    /// <summary>
    /// Collect yield from a single slot and stop care.
    /// </summary>
    [MemberFunction("40 53 48 83 EC 30 8B DA E8 ?? ?? ?? ?? 48 85 C0 74 26")]
    public partial void CollectSingleAndDismiss(uint slot);

    /// <summary>
    /// Update expected total yield field - this is checked by the CollectAll function, which errors out if new items were gathered since last update.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8D 4F 20 E8 ?? ?? ?? ?? 0F B6 F8")]
    public partial void UpdateExpectedTotalYield();

    /// <summary>
    /// Try to collect yields from all slots.
    /// </summary>
    /// <param name="allowOvercap">If this is false, does not perform the collection if any materials would overcap.</param>
    /// <returns>False if allowOvercap is false and overcap would happen, true otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? C7 03 ?? ?? ?? ?? 84 C0")]
    public partial bool CollectAll(bool allowOvercap);
}

[Flags]
public enum FarmSlotFlags : byte {
    UnderCare = 1,
    WasUnderCare = 2, // true if mammet was dismissed after already being paid - re-entrusting won't cost anything
    CareHalted = 4,
    Flag8 = 8
}
