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

    /// <summary>
    /// Get the spell action id for character's current class limit break of specified level.
    /// </summary>
    /// <param name="character">Character whose class to check</param>
    /// <param name="level">LB level (0 for LB1, 1 for LB2, 2 for LB3).</param>
    [MemberFunction("E8 ?? ?? ?? ?? 33 FF 85 C0 75 48")]
    public partial uint GetActionId(Character.Character* character, byte level);
}
