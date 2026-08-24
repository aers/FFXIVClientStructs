using AtkEventInterface = FFXIVClientStructs.FFXIV.Component.GUI.AtkModuleInterface.AtkEventInterface;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::MateriaTrade
//   Component::GUI::AtkModuleInterface::AtkEventInterface
// Materia Transmutation
[GenerateInterop]
[Inherits<AtkEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct MateriaTrade {
    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray5<InventoryType> _containers;
    [FieldOffset(0x24), FixedSizeArray] internal FixedSizeArray5<ushort> _slots;
    [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray5<uint> _quantities;

    [Obsolete("Use Containers[0]"), FieldOffset(0x10)] public InventoryType Container1;
    [Obsolete("Use Containers[1]"), FieldOffset(0x14)] public InventoryType Container2;
    [Obsolete("Use Containers[2]"), FieldOffset(0x18)] public InventoryType Container3;
    [Obsolete("Use Containers[3]"), FieldOffset(0x1C)] public InventoryType Container4;
    [Obsolete("Use Containers[4]"), FieldOffset(0x20)] public InventoryType Container5;

    [Obsolete("Use Slots[0]"), FieldOffset(0x24)] public ushort MateriaId1;
    [Obsolete("Use Slots[1]"), FieldOffset(0x26)] public ushort MateriaId2;
    [Obsolete("Use Slots[2]"), FieldOffset(0x28)] public ushort MateriaId3;
    [Obsolete("Use Slots[3]"), FieldOffset(0x2A)] public ushort MateriaId4;
    [Obsolete("Use Slots[4]"), FieldOffset(0x2C)] public ushort MateriaId5;

    [Obsolete("Use Quantities[0]"), FieldOffset(0x30)] public ushort Quantity1;
    [Obsolete("Use Quantities[1]"), FieldOffset(0x34)] public ushort Quantity2;
    [Obsolete("Use Quantities[2]"), FieldOffset(0x38)] public ushort Quantity3;
    [Obsolete("Use Quantities[3]"), FieldOffset(0x3C)] public ushort Quantity4;
    [Obsolete("Use Quantities[4]"), FieldOffset(0x40)] public ushort Quantity5;
}
