namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x3BC)]
public unsafe partial struct MonsterNoteManager
{
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 E9", 3)]
    public static partial MonsterNoteManager* Instance();
    
    [FixedSizeArray<MonsterNoteRankInfo>(12)]
    [FieldOffset(0x00)] public fixed byte RankDataArray[0x38 * 12];
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct MonsterNoteRankInfo
{
    [FixedSizeArray<RankData>(10)]
    [FieldOffset(0x00)] public fixed byte RankDataArray[0x08 * 10];

    [FieldOffset(0x28)] public long Flags;
    [FieldOffset(0x30)] public int Unknown1;
    [FieldOffset(0x34)] public int Unknown2; // Suspected to be some kind of flags?
}

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe struct RankData
{
    [FieldOffset(0x00)] public fixed byte Counts[4];

    public int this[int index] => Counts[index];
}