namespace FFXIVClientStructs.FFXIV.Client.Game.MJI;

// Client::Game::MJI::MJIFavorState
// ctor "48 89 5C 24 ?? 57 48 83 EC ?? 48 8B D9 48 8D 05 ?? ?? ?? ?? 33 C9"
// indices: 0-2 are 'prev', 3-5 are 'curr', 6-8 are 'next', order is 4/6/8h
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct MJIFavorState {
    [FieldOffset(0x00)] public MJIManager* Manager;
    // 0x08: some message listener class, size 0x10, contains vtbl and pointer to this
    [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray9<byte> _craftObjectIds; // MJICraftworksObject sheet row
    [FieldOffset(0x21), FixedSizeArray] internal FixedSizeArray9<byte> _numDelivered;
    [FieldOffset(0x2A), FixedSizeArray] internal FixedSizeArray9<byte> _flags1; // 0x1 = shipped
    [FieldOffset(0x33), FixedSizeArray] internal FixedSizeArray9<byte> _flags2; // 0x1 = bonus
    [FieldOffset(0x3C), FixedSizeArray] internal FixedSizeArray9<byte> _numScheduled;
    [FieldOffset(0x48)] public int UpdateState; // 0 = initial, 1 = requested, 2 = received

    public bool Shipped(int index) => (Flags1[index] & 1) != 0;
    public bool Bonus(int index) => (Flags2[index] & 1) != 0;
}
