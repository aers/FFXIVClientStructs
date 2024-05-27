using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("InventoryBuddy")]
[StructLayout(LayoutKind.Explicit, Size = 0x498)]
public unsafe partial struct AddonInventoryBuddy {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;
    [FixedSizeArray<Pointer<AtkComponentRadioButton>>(2)]
    [FieldOffset(0x220)] public fixed byte Tabs[0x08 * 2];
    [FixedSizeArray<Pointer<AtkComponentDragDrop>>(70)]
    [FieldOffset(0x230)] public fixed byte Slots[0x08 * 70];
    [FieldOffset(0x488)] public byte TabIndex;

    [MemberFunction("E9 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B 5C 24 ?? 48 83 C4 20")]
    public partial void SetTab(byte tab);
}
