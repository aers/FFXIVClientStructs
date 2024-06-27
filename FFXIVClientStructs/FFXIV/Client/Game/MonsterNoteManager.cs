namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::MonsterNoteManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x460)]
public unsafe partial struct MonsterNoteManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 0F B6 4B 22", 3)]
    public static partial MonsterNoteManager* Instance();

    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray12<MonsterNoteRankInfo> _rankData;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct MonsterNoteRankInfo {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray10<RankData> _rankData;

    [FieldOffset(0x28)] public long Flags;
    [FieldOffset(0x30)] public int Rank;
    [FieldOffset(0x34)] public int Unknown2; // Suspected to be some kind of flags?
    [FieldOffset(0x38)] public int Index;
    [FieldOffset(0x3C)] public int Unknown3; // Seems to be zero padding
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x04)]
public unsafe partial struct RankData {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray4<byte> _counts;

    public int this[int index] => Counts[index];
}
