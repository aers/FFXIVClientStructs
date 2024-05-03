using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("InventoryGrid", "InventoryGrid0", "InventoryGrid1", "InventoryGrid0E", "InventoryGrid1E", "InventoryGrid2E", "InventoryGrid3E")]
[StructLayout(LayoutKind.Explicit, Size = 0x340)]
public unsafe partial struct AddonInventoryGrid {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;
    [FixedSizeArray<Pointer<AtkComponentDragDrop>>(35)]
    [FieldOffset(0x220)] public fixed byte Slots[0x08 * 35];
}
