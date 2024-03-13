using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// ToDo: Wrap in RaptureHotbarModule partial struct for namespacing (API 10)

/// <summary>
/// An intermediate struct used to translate from a <see cref="HotBarSlot"/> to the UI String/NumberArrays. 
/// </summary>
/// <remarks>
/// <b>Do not consider this struct stable (yet).</b>
/// </remarks>
[StructLayout(LayoutKind.Explicit, Size = 0x43)]
internal unsafe struct HotBarUiIntermediate {
    // Converts to array in E8 ?? ?? ?? ?? EB 34 E8

    [FieldOffset(0x00)] public Utf8String* PopUpHelpText; // to StringArray idx slotBase + 14
    [FieldOffset(0x08)] public nint CostTextPtr; // to StringArray idx slotBase + 1
    [FieldOffset(0x10)] public uint IntermediateActionType; // to NumberArray idx slotBase + 0
    [FieldOffset(0x14)] public uint ActionId; // to NumberArray idx slotBase + 3
    [FieldOffset(0x18)] public uint IconId; // to NumberArray idx slotBase + 4
    [FieldOffset(0x1C)] public uint CooldownMode; // to NumberArray idx slotBase + 7
    [FieldOffset(0x20)] public uint CooldownSeconds;
    [FieldOffset(0x24)] public uint CooldownPercent; // to NumberArray idx slotBase + 8
    [FieldOffset(0x28)] public uint LastCooldownPercent;
    [FieldOffset(0x2C)] public uint ChargePercent; // to NumberArray idx slotBase + 9
    [FieldOffset(0x30)] public uint LastChargePercent;
    [FieldOffset(0x34)] public uint CurrentCharges; // to NumberArray idx slotBase + 13
    [FieldOffset(0x38)] public uint CostValue; // to NumberArray idx slotBase + 10
    [FieldOffset(0x3C)] public byte CostType; // to NumberArray idx slotBase + 1
    [FieldOffset(0x3D)] public byte CostDisplayMode; // to NumberArray idx slotBase + 2
    [FieldOffset(0x3E)] public bool ActionAvailable1; // to NumberArray idx slotBase + 5
    [FieldOffset(0x3F)] public bool ActionAvailable2; // to NumberArray idx slotBase + 6
    [FieldOffset(0x40)] public bool ActionTargetSatisfied; // to NumberArray idx slotBase + 15
    [FieldOffset(0x41)] public bool DrawAnts; // to NumberArray idx slotBase + 14
    [FieldOffset(0x42)] public byte Unk_0x42;
}
