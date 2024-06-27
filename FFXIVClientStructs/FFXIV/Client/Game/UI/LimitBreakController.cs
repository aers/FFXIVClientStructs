namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::LimitBreakController
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct LimitBreakController {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 3B C7", 3)]
    public static partial LimitBreakController* Instance();

    [FieldOffset(0x08)] public byte BarCount;
    [FieldOffset(0x0A)] public ushort CurrentUnits;
    [FieldOffset(0x0C)] public ushort BarUnits;
    [FieldOffset(0x0F)] public bool IsPvP;
}
