namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::Companion
//   Client::Game::Character::Character
//     Client::Game::Object::GameObject
//     Client::Graphics::Vfx::VfxDataListenner
//     Client::Game::Character::CharacterData
// companion = minion
[GenerateInterop]
[Inherits<Character>]
[VirtualTable("E8 ?? ?? ?? ?? 0F B7 56 68", [1, 0xDE])]
[StructLayout(LayoutKind.Explicit, Size = 0x23B0)]
public unsafe partial struct Companion {
    [FieldOffset(0x2350)] public BattleChara* Owner;

    /// <summary> Used when the companion places itself on its owner's shoulder or head. </summary>
    [MemberFunction("48 89 5C 24 ?? 55 57 41 57 48 8D 6C 24 ?? 48 81 EC ?? ?? ?? ?? 48 8B F9")]
    public partial void PlaceCompanion();
}
