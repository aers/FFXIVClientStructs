namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3D)]
public partial struct UpdateInventorySlotPacket {
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
