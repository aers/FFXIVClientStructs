using FFXIVClientStructs.FFXIV.Client.Network;

namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

// TODO: remove with HandleUpdateInventorySlotPacket (replaced by InventoryItemPacket)
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3D)]
public partial struct UpdateInventorySlotPacket {
    [FieldOffset(0x00)] public uint ContextId;
    [FieldOffset(0x08)] public ushort InventoryType;
    [FieldOffset(0x0A)] public short InventorySlot;
    [FieldOffset(0x0C)] public int Quantity;
    [FieldOffset(0x10)] public uint ItemId;
    [FieldOffset(0x18)] public ulong CrafterContentId;
    [FieldOffset(0x20)] public byte ItemFlags;
    [FieldOffset(0x22)] public ushort Condition;
    [FieldOffset(0x24)] public ushort SpiritbondOrCollectability;
    [FieldOffset(0x28)] public uint GlamourId;
    [FieldOffset(0x2C), FixedSizeArray] internal FixedSizeArray5<short> _materia;
    [FieldOffset(0x36), FixedSizeArray] internal FixedSizeArray5<byte> _materiaGrades;
    [FieldOffset(0x3B), FixedSizeArray] internal FixedSizeArray2<byte> _stains;
}

/// <remarks> Packet for <see cref="PacketDispatcher.HandleInventoryItemPacket"/> and <see cref="PacketDispatcher.HandleInventoryItemUpdatePacket"/> </remarks>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3D)]
public partial struct InventoryItemPacket {
    [FieldOffset(0x00)] public uint ContextId;
    [FieldOffset(0x08)] public ushort InventoryType;
    [FieldOffset(0x0A)] public ushort Slot;
    [FieldOffset(0x0C)] public uint Quantity;
    [FieldOffset(0x10)] public uint ItemId;

    [FieldOffset(0x18)] public ulong CrafterContentId;
    [FieldOffset(0x20)] public byte ItemFlags;

    [FieldOffset(0x22)] public ushort Condition;
    [FieldOffset(0x24)] public ushort SpiritbondOrCollectability;

    [FieldOffset(0x28)] public uint GlamourId;
    [FieldOffset(0x2C), FixedSizeArray] internal FixedSizeArray5<ushort> _materia;
    [FieldOffset(0x36), FixedSizeArray] internal FixedSizeArray5<byte> _materiaGrades;
    [FieldOffset(0x3B), FixedSizeArray] internal FixedSizeArray2<byte> _stains;
}

/// <remarks> Packet for <see cref="PacketDispatcher.HandleInventoryItemCurrencyPacket"/> </remarks>
[StructLayout(LayoutKind.Explicit, Size = 0x14)]
public struct InventoryItemCurrencyPacket {
    [FieldOffset(0x00)] public uint ContextId;
    [FieldOffset(0x04)] public ushort InventoryType;
    [FieldOffset(0x06)] public ushort Slot;
    [FieldOffset(0x08)] public uint Quantity;

    [FieldOffset(0x10)] public uint ItemId;
}

/// <remarks> Packet for <see cref="PacketDispatcher.HandleInventoryItemSymbolicPacket"/> </remarks>
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct InventoryItemSymbolicPacket {
    [FieldOffset(0x00)] public uint ContextId;
    [FieldOffset(0x04)] public ushort InventoryType;
    [FieldOffset(0x06)] public ushort Slot;
    [FieldOffset(0x08)] public uint Quantity;
    [FieldOffset(0x0C)] public ushort TargetInventoryType;
    [FieldOffset(0x0E)] public ushort TargetSlot;
}
