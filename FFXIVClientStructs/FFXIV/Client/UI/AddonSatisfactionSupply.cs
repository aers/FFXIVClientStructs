using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("SatisfactionSupply")]
[StructLayout(LayoutKind.Explicit, Size = 0x670)]
public unsafe partial struct AddonSatisfactionSupply {
    [FieldOffset(0x00)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x224)] public int HoveredElementIndex; // Index 0-2 of the last hovered turn in element

    [FixedSizeArray<AddonDeliveryItemInfo>(3)]
    [FieldOffset(0x308)] public fixed byte DeliveryInfo[0x68 * 3];
}

[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct AddonDeliveryItemInfo {
    [FieldOffset(0x00)] public uint ItemId;

    // The rest of this array are pointers to various other blocks of memory it seems.
    // These pointers don't seem to be vfuncs
}
