namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::ContentRoulette
//   Client::Game::UI::ContentInterface
[GenerateInterop]
[Inherits<ContentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct ContentRoulette {
    [FieldOffset(0x08)] public byte ContentRouletteRowId;
    [FieldOffset(0x09)] public byte ContentRouletteOpenRuleType;
    [FieldOffset(0x0A)] private byte UnkA;
}
