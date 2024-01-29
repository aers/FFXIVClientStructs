namespace FFXIVClientStructs.FFXIV.Client.Game.MJI;

// Client::Game::MJI::MJIFavorState
// ctor "E8 ?? ?? ?? ?? 48 8B F8 66 89 B3"
// indices: 0-2 are 'prev', 3-5 are 'curr', 6-8 are 'next', order is 4/6/8h
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct MJIFavorState {
    [FieldOffset(0x00)] public MJIManager* Manager;
    // 0x08: some message listener class, size 0x10, contains vtbl and pointer to this
    [FieldOffset(0x18)] public fixed byte CraftObjectIds[9]; // MJICraftworksObject sheet row
    [FieldOffset(0x21)] public fixed byte NumDelivered[9];
    [FieldOffset(0x2A)] public fixed byte Flags1[9]; // 0x1 = shipped
    [FieldOffset(0x33)] public fixed byte Flags2[9]; // 0x1 = bonus
    [FieldOffset(0x3C)] public fixed byte NumScheduled[9];
    [FieldOffset(0x48)] public int UpdateState; // 0 = initial, 1 = requested, 2 = received

    public bool Shipped(int index) => (Flags1[index] & 1) != 0;
    public bool Bonus(int index) => (Flags2[index] & 1) != 0;
}
