using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonInventoryGrid
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("InventoryGrid", "InventoryGrid0", "InventoryGrid1", "InventoryGrid0E", "InventoryGrid1E", "InventoryGrid2E", "InventoryGrid3E")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x340)]
public unsafe partial struct AddonInventoryGrid {
    [FieldOffset(0x220), FixedSizeArray] internal FixedSizeArray35<Pointer<AtkComponentDragDrop>> _slots;
}
