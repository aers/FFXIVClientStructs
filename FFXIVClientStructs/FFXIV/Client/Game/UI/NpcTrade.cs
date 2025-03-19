using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::NpcTrade
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x328)]
public unsafe partial struct NpcTrade {
    [FieldOffset(0x008)] public ItemRequests Requests;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public partial struct Item {
        [FieldOffset(0x00)] public uint ItemId;
        [FieldOffset(0x04)] public int RequiredQuantity;
        [FieldOffset(0x08)] public uint IconId;
        [FieldOffset(0x10)] public Utf8String ItemName;
        [FieldOffset(0x78)] public bool WantHQ;
        [FieldOffset(0x7A), FixedSizeArray] internal FixedSizeArray5<ushort> _wantMateriaIds;
        [FieldOffset(0x84), FixedSizeArray] internal FixedSizeArray5<byte> _wantMateriaGrades;
        [FieldOffset(0x89)] public byte WantMateriaFilledSlots;
        [FieldOffset(0x8A)] public ushort MinCollectibility;
        [FieldOffset(0x8C)] public bool WantCollectible;
        [FieldOffset(0x8D)] public bool Stackable;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x2D8)]
    public partial struct ItemRequests {
        [FieldOffset(0)] public byte Count;
        [FieldOffset(8), FixedSizeArray] internal FixedSizeArray5<Item> _items;
    }

    [VirtualFunction(0)]
    public partial NpcTrade* Dtor(byte freeFlags);
}
