using FFXIVClientStructs.FFXIV.Client.Game.GoldSaucer;

namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct GoldSaucerManager {
    [StaticAddress("89 43 64 48 89 1D", 6, isPointer: true)]
    public static partial GoldSaucerManager* Instance();

    [FieldOffset(0x28)] public GFateDirector* CurrentGFateDirector;

    // Unknown TripleTriadTournament data here
    [FieldOffset(0x50)] internal uint UnkTripleTriadTournamentTimestamp;

    [FieldOffset(0x58)] internal byte UnkTripleTriadTournamentFlags;

    [FieldOffset(0x5C)] internal uint UnkTripleTriadTournamentTimeBase;
}
