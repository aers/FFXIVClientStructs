namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::InstanceContent
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe partial struct InstanceContent {
    [StaticAddress("45 32 FF 48 8D 0D ?? ?? ?? ?? F3 0F 7F 44 24 ??", 6)]
    public static partial InstanceContent* Instance();

    /// <summary>
    /// Provides the number of minutes remaining on the penalty.
    /// </summary>
    /// <param name="index">0 = Duty penalty<br/>1 = Unknown</param>
    /// <returns>Number of minutes left</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 8B 0E 3B C8")]
    public partial uint GetPenaltyRemainingInMinutes(byte index);

    [MemberFunction("48 83 EC 28 84 D2 74 33")]
    public partial bool IsRouletteIncomplete(byte roulette);

    public bool IsRouletteComplete(byte roulette) => !IsRouletteIncomplete(roulette);
}
