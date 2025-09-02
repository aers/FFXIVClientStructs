namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::ContentFinderConditionInterface
//   Client::Game::UI::ContentInterface
[GenerateInterop(isInherited: true)]
[Inherits<ContentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct ContentFinderConditionInterface {
    [FieldOffset(0x08)] public ushort ContentFinderConditionRowId;
}
