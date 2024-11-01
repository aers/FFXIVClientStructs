namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::BattleChara
//   Client::Game::Character::Character
//     Client::Game::Object::GameObject
//     Client::Graphics::Vfx::VfxDataListenner
//     Client::Game::Character::CharacterData
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC ?? 48 8B F1 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 8D 8E"
// characters that fight (players, monsters, etc)
[GenerateInterop]
[Inherits<Character>]
[StructLayout(LayoutKind.Explicit, Size = 0x3630)]
public unsafe partial struct BattleChara {
    [FieldOffset(0x22C0)] public StatusManager StatusManager;
    [FieldOffset(0x25B0)] public CastInfo CastInfo;
    [FieldOffset(0x2720)] public ActionEffectHandler ActionEffectHandler;
    [FieldOffset(0x3620)] public ForayInfo ForayInfo;
}
