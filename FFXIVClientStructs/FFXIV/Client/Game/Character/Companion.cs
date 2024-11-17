namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::Companion
//   Client::Game::Character::Character
//     Client::Game::Object::GameObject
//     Client::Graphics::Vfx::VfxDataListenner
//     Client::Game::Character::CharacterData
// ctor "E8 ?? ?? ?? ?? 48 8B C8 EB 03 48 8B CD 48 8B 43 08"
// companion = minion
[GenerateInterop]
[Inherits<Character>]
[StructLayout(LayoutKind.Explicit, Size = 0x23B0)]
public unsafe partial struct Companion {
    [FieldOffset(0x2350)] public BattleChara* Owner;

    /// <summary> Used when the companion places itself on its owner's shoulder or head. </summary>
    [MemberFunction("48 89 5C 24 ?? 55 57 41 57 48 8D 6C 24 ?? 48 81 EC ?? ?? ?? ?? 48 8B F9")]
    public partial void PlaceCompanion();
}
