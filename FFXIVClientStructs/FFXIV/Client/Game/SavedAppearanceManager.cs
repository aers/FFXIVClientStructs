using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::SavedAppearanceManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x9EB8)]
public unsafe partial struct SavedAppearanceManager {
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray40<SavedAppearanceSlot> _slot;

    [VirtualFunction(1)] public partial bool IsSlotCreated(byte slotIndex);
    [VirtualFunction(2)] public partial SavedAppearanceSlot* GetSlot(byte slotIndex);
    [VirtualFunction(6)] public partial uint GetSlotCount();
}

[StructLayout(LayoutKind.Explicit, Size = 0x140)]
public unsafe partial struct SavedAppearanceSlot {
    [FieldOffset(0x00)] public uint Magic; // Should be 0x2013_FF14
    [FieldOffset(0x04)] public uint Version;
    [FieldOffset(0x10)] public CustomizeData CustomizeData;
    [FieldOffset(0x30), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _label;
    [FieldOffset(0x134)] public bool IsCreated;
    [FieldOffset(0x13C)] public byte SlotIndex;
}
