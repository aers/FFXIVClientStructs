namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::BattleChara
//   Client::Game::Character::Character
//     Client::Game::Object::GameObject
//     Client::Graphics::Vfx::VfxDataListenner
//     Client::Game::Character::CharacterData
// ctor "E8 ?? ?? ?? ?? 48 8B F0 8B 87"
// characters that fight (players, monsters, etc)
[StructLayout(LayoutKind.Explicit, Size = 0x2F80)]
[GenerateInterop]
[Inherits<Character>]
public unsafe partial struct BattleChara {
    //[FieldOffset(0x1E60)] public fixed byte UnkBattleCharaStruct[0xF00];
}
