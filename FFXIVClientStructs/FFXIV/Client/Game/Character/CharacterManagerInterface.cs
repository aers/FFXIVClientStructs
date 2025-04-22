namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::CharacterManagerInterface
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
[GenerateInterop(isInherited: true)]
public unsafe partial struct CharacterManagerInterface {
    [VirtualFunction(5)]
    public partial void Dtor(bool free);
}
