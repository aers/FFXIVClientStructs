using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Housing;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::HousingGuestBookData
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x7B0)]
public unsafe partial struct HousingGuestBookData {
    [FieldOffset(0x00)] private nint UnkCallbackPtr;
    [FieldOffset(0x08)] public HouseId HouseId;
    [FieldOffset(0x10), FixedSizeArray(isString: true)] internal FixedSizeArray192<byte> _greeting;
    [FieldOffset(0xD0)] private byte UnkD0;
    [FieldOffset(0xD4)] private uint UnkD4;
    [FieldOffset(0xD8)] public int Likes;
    [FieldOffset(0xDC)] private byte UnkDC;
    [FieldOffset(0xDD)] public byte NumEntries;

    [FieldOffset(0xE0)] public byte CurrentPage;
    [FieldOffset(0xE1)] public byte NumEntriesOnPage;

    [FieldOffset(0xE8), FixedSizeArray] internal FixedSizeArray6<HousingGuestBookEntry> _entries;

    [FieldOffset(0x6E8)] private byte Unk6E8;
    [FieldOffset(0x6E9)] private bool Unk6E9;
    [FieldOffset(0x6EA)] private byte Unk6EA;

    [FieldOffset(0x7AC)] private uint Unk7AC;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x100)]
    public unsafe partial struct HousingGuestBookEntry {
        [FieldOffset(0x00)] public int Index;
        [FieldOffset(0x04)] public bool HasData;
        [FieldOffset(0x05)] public bool WasDelete;
        [FieldOffset(0x06)] public bool IsInSameFreeCompanyAsOwner;

        [FieldOffset(0x08)] public ulong ContentId;
        [FieldOffset(0x10)] public ushort HomeWorld;

        [FieldOffset(0x14)] public int Timestamp;
        [FieldOffset(0x18), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _characterName;
        [FieldOffset(0x38), FixedSizeArray(isString: true)] internal FixedSizeArray192<byte> _message;
        [FieldOffset(0xF8)] private byte UnkF8;
    }
}
