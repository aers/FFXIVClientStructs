using FFXIVClientStructs.FFXIV.Client.Game.GoldSaucer;

namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct GoldSaucerManager {
    [StaticAddress("89 43 64 48 89 1D", 6, isPointer: true)]
    public static partial GoldSaucerManager* Instance();

    [FieldOffset(0x28)] public GFateDirector* CurrentGFateDirector;

    [FieldOffset(0x50)] public uint WeeklyLotOffsetTime;

    [FieldOffset(0x58)] public GoldSaucerFlag Flags;
}

[Flags]
public enum GoldSaucerFlag : byte {
    Unk0 = 1 << 0,
    ChocoboRaceTutorialClear = 1 << 1,
    Unk2 = 1 << 2,
    Unk3 = 1 << 3,
    Unk4 = 1 << 4,
    ChocoboRaceAllOpen = 1 << 5,
    Unk6 = 1 << 6,
    Unk7 = 1 << 7,
}
