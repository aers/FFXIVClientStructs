namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// This name may be wrong,
// the only known member function that uses this struct returns the completion status of the input roulette
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct RouletteController
{
    public static RouletteController* Instance() => &UIState.Instance()->RouletteController;
    
    [MemberFunction("48 83 EC 28 84 D2 75 07 32 C0")]
    private partial bool IsRouletteIncomplete(byte roulette);

    public bool IsRouletteComplete(byte roulette) => !IsRouletteIncomplete(roulette);
}