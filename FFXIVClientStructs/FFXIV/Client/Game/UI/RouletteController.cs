namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::RouletteController
// ctor inlined in UIState_ctor
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe partial struct RouletteController
{
    public static RouletteController* Instance() => &UIState.Instance()->RouletteController;

    /// <summary>
    /// Provides the number of minutes remaining on the penalty.
    /// </summary>
    /// <param name="index">0 = Duty penalty<br/>1 = Unknown</param>
    /// <returns>Number of minutes left</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 8B 0E 3B C8")]
    public partial uint GetPenaltyRemainingInMinutes(byte index);
    
    [MemberFunction("48 83 EC 28 84 D2 75 07 32 C0")]
    public partial bool IsRouletteIncomplete(byte roulette);

    public bool IsRouletteComplete(byte roulette) => !IsRouletteIncomplete(roulette);
}
