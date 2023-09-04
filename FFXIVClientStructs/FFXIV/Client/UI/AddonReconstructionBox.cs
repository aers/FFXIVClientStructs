using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("ReconstructionBox")]
[StructLayout(LayoutKind.Explicit, Size = 0x440)]
public unsafe partial struct AddonReconstructionBox {
    [FieldOffset(0x00)] public AtkUnitBase AtkUnitBase;

    [FixedSizeArray<AddonItemDonationInfo>(10)]
    [FieldOffset(0x258)] public fixed byte DonationInfoArray[0x30 * 10];

    [FieldOffset(0x438)] public int ItemHovered; // 1 if hovering an item, 0 otherwise
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct AddonItemDonationInfo {
    [FieldOffset(0x00)] public void* UnkPtr1;
    [FieldOffset(0x08)] public void* UnkPtr2;
    [FieldOffset(0x10)] public void* UnkPtr3;
    [FieldOffset(0x18)] public void* UnkPtr4;
    [FieldOffset(0x20)] public void* UnkPtr5;
    [FieldOffset(0x2C)] public int UnkValue1;
}
