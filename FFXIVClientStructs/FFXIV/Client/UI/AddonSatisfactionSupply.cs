using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("SatisfactionSupply")]
[GenerateInterop, Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x670)]
public unsafe partial struct AddonSatisfactionSupply {
    [FieldOffset(0x224)] public int HoveredElementIndex; // Index 0-2 of the last hovered turn in element

    [FieldOffset(0x308), FixedSizeArray] internal FixedSizeArray3<AddonDeliveryItemInfo> _deliveryInfo;
}

[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public struct AddonDeliveryItemInfo {
    [FieldOffset(0x00)] public uint ItemId;

    // The rest of this array are pointers to various other blocks of memory it seems.
    // These pointers don't seem to be vfuncs
}
