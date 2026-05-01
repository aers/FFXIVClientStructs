namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct InventoryItemRef {
    [FieldOffset(0x00)] public InventoryType Container;
    [FieldOffset(0x04)] public short Slot;
    [FieldOffset(0x08)] public uint ItemId;
    [FieldOffset(0x0C)] private int UnkC; // used by AgentFreeCompanyChest, AgentTradeMultiple
}
