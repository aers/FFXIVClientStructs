namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::CharacterManagerInterface
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
[GenerateInterop(isInherited: true)]
public unsafe partial struct CharacterManagerInterface {
    // [FieldOffset(0x8)] public ??? SomeBlacklistManagerSecondInheritance; 
    // [FieldOffset(0x10)] public void* CriticalSection; // seems to be needed for some std::vector handling related to BlackListManager

    [VirtualFunction(5)]
    public partial void Dtor(byte freeFlags);
}
